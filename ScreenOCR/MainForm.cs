using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ScreenOCR
{
    public partial class MainForm : Form
    {
        // Helps aligning mouse and screenshot coordinates
        [DllImport("user32.dll")]
        public static extern bool SetProcessDPIAware();

        /// <summary>
        /// Possible working states of the program
        /// </summary>
        private enum MODE {
            IDLE,
            CAPTURE,
            CROP
        }

        public Dictionary<String, String> getConfigDict()
        {
            return this.configDict;
        }

        public void fetchConfigDict()
        {
            // attempt to load configs from static file 
            configDict = Config.loadConfig();
        }

        // start in IDLE
        private MODE currentMode = MODE.IDLE;

        // points used for visual feedback
        private Point initialMouseLocation = new Point(0, 0);
        private Point finalMouseLocation = new Point(0, 0);

        // points used for image cropping
        private Point initialCursorPosition = new Point(0, 0);
        private Point finalCursorPosition = new Point(0, 0);

        private bool showHelpText = false;
        
        // focus timer used in capture & crop modes
        private readonly Timer focusTimer = new Timer() { Interval = 50 };

        // fade in/out animation timers
        private readonly Timer showTimer = new Timer() { Interval = 30 };
        private readonly Timer hideTimer = new Timer() { Interval = 30 };

        private const float FORM_MAX_OPACITY = 0.5f;

        // fade in/out velocity
        private const float OPACITY_VELOCITY = 0.05f;

        // holds the parameters for the remote service (api key and language)
        private Dictionary<String, String> configDict;

        // used to hide capture window from alt-tab menu
        private const int WS_EX_TOOLWINDOW = 0x00000080;

        // other forms 
        private ConfigForm configForm;

        // global hook for creating the shortcut to cropping mode
        private KeyboardHook hook = new KeyboardHook();

        public MainForm()
        {
            SetProcessDPIAware();
            InitializeComponent();
        }

        /// <summary>
        /// Hides the background form and disables focus gaining
        /// </summary>
        private void setIdleMode()
        {
            currentMode = MODE.IDLE;
            animateHide();
            focusTimer.Stop();
        }

        /// <summary>
        /// Displays background form & attempts to keep focus 
        /// </summary>
        /// <param name="showHelpText"></param>
        private void setCaptureMode(bool showHelpText)
        {
            currentMode = MODE.CAPTURE;
            animateShow();

            focusTimer.Start();

            if (showHelpText)
                this.showHelpText = showHelpText;

        }

        /// <summary>
        /// Switches ro crop mode and keeps focus
        /// </summary>
        private void setCropMode()
        {
            currentMode = MODE.CROP;
            showHelpText = false;

            focusTimer.Start();
        }

        /// <summary>
        /// Hides the form from alt-tab menu
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                var Params = base.CreateParams;
                Params.ExStyle |= WS_EX_TOOLWINDOW;
                return Params;
            }
        }


        private void animateShow()
        {
            hideTimer.Stop();
            showTimer.Start();
        }

        private void animateHide()
        {
            showTimer.Stop();
            hideTimer.Start();
        }

        

        private void MainForm_Load(object sender, EventArgs e)
        {
            // set main form properties
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.ShowInTaskbar = false;
            this.DoubleBuffered = true;
            this.TransparencyKey = Color.Red;
            this.BackColor = Color.Black;
            this.Opacity = 0;

            this.configForm = new ConfigForm(this);

            // set focus timer
            focusTimer.Tick += (_sender, _e) => { if (!this.Focused) this.Activate(); };

            // set opacity timers
            showTimer.Tick += (_sender, _e) => { if (this.Opacity < FORM_MAX_OPACITY) this.Opacity += OPACITY_VELOCITY; else showTimer.Stop(); };
            hideTimer.Tick += (_sender, _e) => { if (this.Opacity > 0) this.Opacity -= OPACITY_VELOCITY; else hideTimer.Stop(); };
            
            // set shortcut hook
            hook.RegisterHotKey(ModKeys.Shift | ModKeys.Win, Keys.Q);
            hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);

            // go idle and wait for the hotkeys
            this.setIdleMode();

            this.fetchConfigDict();
                
            // show the ConfigForm if there's an error; most likely fields are not filled
            if (configDict.ContainsKey("err"))
                configForm.animateShow();
        }

        /// <summary>
        /// Event handler for the main (global) hook which intercepts the shortcut keys
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            this.Activate();
            setCaptureMode(false);
        }

        private void parseResult(Object result)
        {

        }

        /// <summary>
        /// Event handler which handles local keypresses (focus needed)
        /// - [ESC] - falls back to IDLE mode (i.e., resets capturing)
        /// - [SHIFT] + [ESC] - closes the entire program
        /// - [SHIFT] + [O] - toggles the ConfigForm 
        /// - [Enter] - (only in capture mode) submits data to the OCR/HTR service
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (e.Shift)
                    this.Close();

                setIdleMode();
            }

            if (e.KeyCode == Keys.O && e.Shift)
            {
                setIdleMode();
                configForm.animateShow();
                configDict = Config.loadConfig();
                
            }

            if (currentMode == MODE.CAPTURE && e.KeyCode == Keys.Enter)
            {
                setIdleMode();

                // preserve the context in order to show the ResultForm later
                var context = TaskScheduler.FromCurrentSynchronizationContext();

                // run service querying task in background and, once finished, show the result form
                Task<OcrData> task = Task.Factory.StartNew(() => { return getRegionText(); });
                task.ContinueWith((_task) => { if (_task.Result != null) { new ResultForm(_task.Result).Show(); } return _task.Result; }, context);
                
            }
        }

        /// <summary>
        /// The core of the program; isolates the region of interest and queries the OCR/HTR engine
        /// </summary>
        /// <returns></returns>
        private OcrData getRegionText()
        { 
            int minImgX = Math.Min(initialCursorPosition.X, finalCursorPosition.X);
            int minImgY = Math.Min(initialCursorPosition.Y, finalCursorPosition.Y);
            int maxImgX = Math.Max(initialCursorPosition.X, finalCursorPosition.X);
            int maxImgY = Math.Max(initialCursorPosition.Y, finalCursorPosition.Y);

            int width = maxImgX - minImgX;
            int height = maxImgY - minImgY;

            if (width <= 3 || height <= 3)
                return null;

            Bitmap bmp = Screen.getRegionScreenshot(minImgX, minImgY, width, height);

            OcrData ocrResponse = Network.queryOcrService(bmp, configDict["lang"], configDict["api_key"]);

            ocrResponse.location = new Point(minImgX, minImgY);
            ocrResponse.size = new Size(maxImgX - minImgX, maxImgY - minImgY);

            
            

            return ocrResponse;
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (currentMode == MODE.CAPTURE && (e.Button == MouseButtons.Left))
            {
                // store initial coordinates
                initialMouseLocation = e.Location;
                finalMouseLocation = e.Location;

                initialCursorPosition = Cursor.Position;
                finalCursorPosition = Cursor.Position;

                // switch to "crop" mode and return
                this.setCropMode();
                return;
            }

            if (currentMode == MODE.CROP && (e.Button == MouseButtons.Left))
            {
                // update only 2nd point  (final rectangle point)
                finalMouseLocation = e.Location;
                finalCursorPosition = Cursor.Position;
                this.Invalidate();
            }
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            // this is the visual feedback rectangle
            Rectangle cropRectangle = new Rectangle(Math.Min(finalMouseLocation.X, initialMouseLocation.X),
                                                    Math.Min(finalMouseLocation.Y, initialMouseLocation.Y),
                                                    Math.Abs(finalMouseLocation.X - initialMouseLocation.X),
                                                    Math.Abs(finalMouseLocation.Y - initialMouseLocation.Y));

            Rectangle borderRectangle = new Rectangle(cropRectangle.X - 1, cropRectangle.Y - 1, cropRectangle.Width + 1, cropRectangle.Height + 1);

            // draw a black border and red (transparencykey) background
            e.Graphics.DrawRectangle(Pens.White, borderRectangle);
            e.Graphics.FillRectangle(Brushes.Red, cropRectangle);

            // renders the "help" text
            if (showHelpText)
                e.Graphics.DrawString("[↵]: scan\n[esc]: reset", new Font("Arial Rounded MT Bold", 16), Brushes.White, new Point((finalMouseLocation.X + initialMouseLocation.X) / 2, Math.Max(finalMouseLocation.Y, initialMouseLocation.Y)));

        }

        /// <summary>
        /// This should occur once the user ended defining the final point of the cropping rectangle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            setCaptureMode(true);
            this.Invalidate();

        }
    }
}
