namespace Recipe
{
    partial class Settings
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
            this.btnShowKey = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnShowKey
            // 
            this.btnShowKey.Location = new System.Drawing.Point(12, 12);
            this.btnShowKey.Name = "btnShowKey";
            this.btnShowKey.Size = new System.Drawing.Size(75, 53);
            this.btnShowKey.TabIndex = 0;
            this.btnShowKey.Text = "Show Key";
            this.btnShowKey.UseVisualStyleBackColor = true;
            this.btnShowKey.Click += new System.EventHandler(this.btnShowKey_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 286);
            this.Controls.Add(this.btnShowKey);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShowKey;
    }
}