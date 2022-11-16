using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenOCR
{
    public partial class ConfigForm : Form
    {
        // animatin timers
        private Timer showTimer = new Timer() { Interval = 10 };
        private Timer hideTimer = new Timer() { Interval = 10 };

        private const int SLIDE_VELOCITY = 10;
        private const int FORM_MAX_HEIGHT = 200;
        private const String REGISTRATION_URL = "https://overfitted.io/get-started";

        MainForm mainForm;

        public ConfigForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            this.ShowInTaskbar = false;

            // fetches the existing config parameters from the file (if available)
            Dictionary<String, String> configDict = mainForm.getConfigDict();

            // places them in the ConfigForm
            this.apiKeyTextBox.Text = configDict["api_key"];
            this.languageTextBox.Text = configDict["lang"];
            this.startupCheckBox.Checked = configDict["startup"] == "y" ? true : false;
            this.pathTextBox.Text = Config.getConfigPath();

            if (configDict["startup"] == "y")
                Startup.addIfNotExists(Application.ExecutablePath);
            else
                Startup.delete();

            // moves the ConfigForm in the upper screen region and sets its height to 0
            this.Size = new Size(this.Size.Width, 0);
            this.Location = new Point(this.Location.X, 0);

            // animate form sliding into the visible screen area
            showTimer.Tick += (_sender, _e) => { if (this.Size.Height < FORM_MAX_HEIGHT) this.Size = new Size(this.Size.Width, this.Size.Height + SLIDE_VELOCITY); else { showTimer.Stop(); this.Invalidate(); } };
            hideTimer.Tick += (_sender, _e) => { if (this.Size.Height >= SLIDE_VELOCITY) this.Size = new Size(this.Size.Width, this.Size.Height - SLIDE_VELOCITY); else { this.Hide(); hideTimer.Stop(); } };

        }

        /// <summary>
        /// Saves the configs found in the ConfigForm into a file & hides the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            Config.saveConfig(this.languageTextBox.Text, this.apiKeyTextBox.Text, startupCheckBox.Checked ? "y" : "n");


            if (startupCheckBox.Checked)
                Startup.addIfNotExists(Application.ExecutablePath);
            else
                Startup.delete();

            // also notify main form to reload config
            mainForm.fetchConfigDict();

            this.animateHide();
        }

        /// <summary>
        /// Prevents true form closing and instead hides it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfigForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.animateHide();
            e.Cancel = true;
        }

        /// <summary>
        /// Draws form border
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfigForm_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r = this.DisplayRectangle;
            r.Width -= 1;
            r.Height -= 1;
            e.Graphics.DrawRectangle(new Pen(Color.LightGray, 1), r);
        }


        public void animateShow()
        {
            this.hideTimer.Stop();
            this.Show();
            this.showTimer.Start();
        }

        public void animateHide()
        {
            this.showTimer.Stop();
            this.hideTimer.Start();
        }

        /// <summary>
        /// When the apiKey textbox is focused, display the actual API key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void apiKeyTextBox_Enter(object sender, EventArgs e)
        {
            this.apiKeyTextBox.PasswordChar = '\0';
        }

        /// <summary>
        /// If not focused, mask the key to prevent accidental disclosure through, e.g., screen sharing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void apiKeyTextBox_Leave(object sender, EventArgs e)
        {
            this.apiKeyTextBox.PasswordChar = '*';
        }

        private void getApiKeyLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(REGISTRATION_URL);
        }
    }
}
