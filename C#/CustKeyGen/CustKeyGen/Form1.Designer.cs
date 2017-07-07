namespace CustKeyGen
{
    partial class Form1
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
            this.btnNewKey = new System.Windows.Forms.Button();
            this.lblOutput = new System.Windows.Forms.Label();
            this.btnManyKeys = new System.Windows.Forms.Button();
            this.pgs = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnNewKey
            // 
            this.btnNewKey.Location = new System.Drawing.Point(48, 100);
            this.btnNewKey.Name = "btnNewKey";
            this.btnNewKey.Size = new System.Drawing.Size(75, 23);
            this.btnNewKey.TabIndex = 0;
            this.btnNewKey.Text = "1 Key";
            this.btnNewKey.UseVisualStyleBackColor = true;
            this.btnNewKey.Click += new System.EventHandler(this.btnNewKey_Click);
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(56, 52);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(35, 13);
            this.lblOutput.TabIndex = 1;
            this.lblOutput.Text = "label1";
            // 
            // btnManyKeys
            // 
            this.btnManyKeys.Location = new System.Drawing.Point(48, 148);
            this.btnManyKeys.Name = "btnManyKeys";
            this.btnManyKeys.Size = new System.Drawing.Size(75, 23);
            this.btnManyKeys.TabIndex = 2;
            this.btnManyKeys.Text = "Many Keys";
            this.btnManyKeys.UseVisualStyleBackColor = true;
            this.btnManyKeys.Click += new System.EventHandler(this.btnManyKeys_Click);
            // 
            // pgs
            // 
            this.pgs.Location = new System.Drawing.Point(12, 177);
            this.pgs.Name = "pgs";
            this.pgs.Size = new System.Drawing.Size(295, 23);
            this.pgs.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 241);
            this.Controls.Add(this.pgs);
            this.Controls.Add(this.btnManyKeys);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.btnNewKey);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNewKey;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Button btnManyKeys;
        private System.Windows.Forms.ProgressBar pgs;
    }
}

