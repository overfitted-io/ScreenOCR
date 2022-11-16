
namespace ScreenOCR
{
    partial class ResultForm
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
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.linePanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // resultTextBox
            // 
            this.resultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.resultTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resultTextBox.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.resultTextBox.Location = new System.Drawing.Point(2, 1);
            this.resultTextBox.Multiline = true;
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.Size = new System.Drawing.Size(428, 425);
            this.resultTextBox.TabIndex = 0;
            this.resultTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.resultTextBox_KeyDown);
            // 
            // linePanel
            // 
            this.linePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.linePanel.BackColor = System.Drawing.Color.SeaGreen;
            this.linePanel.Location = new System.Drawing.Point(0, 0);
            this.linePanel.Name = "linePanel";
            this.linePanel.Size = new System.Drawing.Size(2, 428);
            this.linePanel.TabIndex = 3;
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(431, 427);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.linePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "ResultForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ResultForm";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ResultForm_FormClosing);
            this.Load += new System.EventHandler(this.ResultForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ResultForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.resultTextBox_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.Panel linePanel;
    }
}