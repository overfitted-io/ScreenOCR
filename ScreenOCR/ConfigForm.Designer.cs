
namespace ScreenOCR
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.languageTextBox = new System.Windows.Forms.TextBox();
            this.languageLabel = new System.Windows.Forms.Label();
            this.apiKeyLabel = new System.Windows.Forms.Label();
            this.apiKeyTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.pathLabel = new System.Windows.Forms.Label();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.launchAtStartupLabel = new System.Windows.Forms.Label();
            this.startupCheckBox = new System.Windows.Forms.CheckBox();
            this.getApiKeyLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // languageTextBox
            // 
            this.languageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.languageTextBox.BackColor = System.Drawing.Color.White;
            this.languageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.languageTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.languageTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.languageTextBox.Location = new System.Drawing.Point(19, 42);
            this.languageTextBox.Name = "languageTextBox";
            this.languageTextBox.Size = new System.Drawing.Size(195, 34);
            this.languageTextBox.TabIndex = 0;
            // 
            // languageLabel
            // 
            this.languageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.languageLabel.AutoSize = true;
            this.languageLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.languageLabel.ForeColor = System.Drawing.Color.Firebrick;
            this.languageLabel.Location = new System.Drawing.Point(14, 11);
            this.languageLabel.Name = "languageLabel";
            this.languageLabel.Size = new System.Drawing.Size(146, 28);
            this.languageLabel.TabIndex = 1;
            this.languageLabel.Text = "// Language";
            // 
            // apiKeyLabel
            // 
            this.apiKeyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.apiKeyLabel.AutoSize = true;
            this.apiKeyLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apiKeyLabel.ForeColor = System.Drawing.Color.Firebrick;
            this.apiKeyLabel.Location = new System.Drawing.Point(215, 11);
            this.apiKeyLabel.Name = "apiKeyLabel";
            this.apiKeyLabel.Size = new System.Drawing.Size(124, 28);
            this.apiKeyLabel.TabIndex = 2;
            this.apiKeyLabel.Text = "// API Key";
            // 
            // apiKeyTextBox
            // 
            this.apiKeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.apiKeyTextBox.BackColor = System.Drawing.Color.White;
            this.apiKeyTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.apiKeyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apiKeyTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.apiKeyTextBox.Location = new System.Drawing.Point(220, 42);
            this.apiKeyTextBox.Name = "apiKeyTextBox";
            this.apiKeyTextBox.PasswordChar = '*';
            this.apiKeyTextBox.Size = new System.Drawing.Size(417, 34);
            this.apiKeyTextBox.TabIndex = 3;
            this.apiKeyTextBox.Enter += new System.EventHandler(this.apiKeyTextBox_Enter);
            this.apiKeyTextBox.Leave += new System.EventHandler(this.apiKeyTextBox_Leave);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveButton.BackColor = System.Drawing.Color.AliceBlue;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.ForeColor = System.Drawing.Color.DodgerBlue;
            this.saveButton.Location = new System.Drawing.Point(569, 95);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(68, 65);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "💾";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // pathLabel
            // 
            this.pathLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pathLabel.AutoSize = true;
            this.pathLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathLabel.ForeColor = System.Drawing.Color.Firebrick;
            this.pathLabel.Location = new System.Drawing.Point(14, 101);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(84, 28);
            this.pathLabel.TabIndex = 6;
            this.pathLabel.Text = "// Path";
            // 
            // pathTextBox
            // 
            this.pathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pathTextBox.Enabled = false;
            this.pathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.pathTextBox.Location = new System.Drawing.Point(19, 132);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(544, 28);
            this.pathTextBox.TabIndex = 7;
            // 
            // launchAtStartupLabel
            // 
            this.launchAtStartupLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.launchAtStartupLabel.AutoSize = true;
            this.launchAtStartupLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.launchAtStartupLabel.ForeColor = System.Drawing.Color.Gray;
            this.launchAtStartupLabel.Location = new System.Drawing.Point(416, 166);
            this.launchAtStartupLabel.Name = "launchAtStartupLabel";
            this.launchAtStartupLabel.Size = new System.Drawing.Size(147, 20);
            this.launchAtStartupLabel.TabIndex = 8;
            this.launchAtStartupLabel.Text = "launch at startup";
            // 
            // startupCheckBox
            // 
            this.startupCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.startupCheckBox.AutoSize = true;
            this.startupCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startupCheckBox.Location = new System.Drawing.Point(392, 169);
            this.startupCheckBox.Name = "startupCheckBox";
            this.startupCheckBox.Size = new System.Drawing.Size(18, 17);
            this.startupCheckBox.TabIndex = 9;
            this.startupCheckBox.UseVisualStyleBackColor = true;
            // 
            // getApiKeyLabel
            // 
            this.getApiKeyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.getApiKeyLabel.AutoSize = true;
            this.getApiKeyLabel.Location = new System.Drawing.Point(338, 11);
            this.getApiKeyLabel.Name = "getApiKeyLabel";
            this.getApiKeyLabel.Size = new System.Drawing.Size(117, 17);
            this.getApiKeyLabel.TabIndex = 10;
            this.getApiKeyLabel.TabStop = true;
            this.getApiKeyLabel.Text = "[how to get one?]";
            this.getApiKeyLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.getApiKeyLabel_LinkClicked);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(656, 193);
            this.Controls.Add(this.getApiKeyLabel);
            this.Controls.Add(this.startupCheckBox);
            this.Controls.Add(this.launchAtStartupLabel);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.apiKeyTextBox);
            this.Controls.Add(this.apiKeyLabel);
            this.Controls.Add(this.languageLabel);
            this.Controls.Add(this.languageTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConfigForm";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigForm_FormClosing);
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ConfigForm_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox languageTextBox;
        private System.Windows.Forms.Label languageLabel;
        private System.Windows.Forms.Label apiKeyLabel;
        private System.Windows.Forms.TextBox apiKeyTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Label launchAtStartupLabel;
        private System.Windows.Forms.CheckBox startupCheckBox;
        private System.Windows.Forms.LinkLabel getApiKeyLabel;
    }
}