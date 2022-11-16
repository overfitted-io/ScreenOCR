using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenOCR
{
    public partial class ResultForm : Form
    {
        // animation timers
        private Timer showTimer = new Timer() { Interval = 5 };
        private Timer hideTimer = new Timer() { Interval = 5 };

        private const float OPACITY_VELOCITY = 0.05f;

        private OcrData ocrResponse;

        public ResultForm()
        {
            InitializeComponent();
        }

        public ResultForm(OcrData ocrResponse)
        {
            InitializeComponent();
            this.ocrResponse = ocrResponse;
        }

        /// <summary>
        /// Prevent form closing and instead run hiding animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResultForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.animateHide();
            e.Cancel = true;
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            this.ShowInTaskbar = false;
            this.Opacity = 0;

            // update location to OCR region's location
            this.Location = ocrResponse.location;
            this.Size = ocrResponse.size;

            // adjust color according to the result
            if (ocrResponse.isError)
                this.linePanel.BackColor = Color.Firebrick;
            else
                this.linePanel.BackColor = Color.SeaGreen;


            // '\n' -> '\r\n' seems to be needed to preserve lines
            String ocrText = ocrResponse.message.Replace("\n", "\r\n");

            Font currentFont = this.resultTextBox.Font;

            // get text size using current font
            Size textSize = TextRenderer.MeasureText(ocrText, currentFont);
            

            // adjust font's size to have the text fitted inside the available space
            float textBoxHeight = (float)(this.resultTextBox.Height * 0.9);
            float textBoxWidth = (float)(this.resultTextBox.Width * 0.9);

            float heightRatio = Math.Min(textBoxHeight / textSize.Height, 2);
            float widthRatio = Math.Min(textBoxWidth / textSize.Width, 2);

            currentFont = new Font(currentFont.FontFamily, currentFont.Size * Math.Min(widthRatio, heightRatio), currentFont.Style);

            // update font and text inside textbox
            this.resultTextBox.Font = currentFont;
            this.resultTextBox.Text = ocrText;

            // prevent having all the text being selected by default
            this.resultTextBox.SelectionStart = 0;
            this.resultTextBox.SelectionLength = 0;

            // prevents accidentally modifying the text
            this.resultTextBox.ReadOnly = true;

            // fade in/out animation
            showTimer.Tick += (_sender, _e) => { if (this.Opacity < 1) { this.Opacity += OPACITY_VELOCITY; } else { showTimer.Stop();  } };
            hideTimer.Tick += (_sender, _e) => { if (this.Opacity > 0) { this.Opacity -= OPACITY_VELOCITY; } else { hideTimer.Stop(); this.Close(); } };

            animateShow();
        }

        
        private void ResultForm_Paint(object sender, PaintEventArgs e)
        {
            
            Rectangle r = this.DisplayRectangle;
            r.Width -= 1;
            r.Height -= 1;
            e.Graphics.DrawRectangle(new Pen(Color.LightGray, 1), r);
            
        }

        public void animateShow()
        {
            this.hideTimer.Stop();
            this.showTimer.Start();
        }

        public void animateHide()
        {
            this.showTimer.Stop();
            this.hideTimer.Start();
        }

        private void resultTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.animateHide();

            if (e.Control && e.KeyCode == Keys.A)
            {
                this.resultTextBox.SelectAll();
            }
        }

    }
}
