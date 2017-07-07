namespace PersonalEncrypter
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
            this.btnEncry = new System.Windows.Forms.Button();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.cboEnDe = new System.Windows.Forms.ComboBox();
            this.cboFolders = new System.Windows.Forms.ComboBox();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.btnRefreshList = new System.Windows.Forms.Button();
            this.lblOutput = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnEncry
            // 
            this.btnEncry.Location = new System.Drawing.Point(12, 238);
            this.btnEncry.Name = "btnEncry";
            this.btnEncry.Size = new System.Drawing.Size(75, 23);
            this.btnEncry.TabIndex = 0;
            this.btnEncry.Text = "EnCry";
            this.btnEncry.UseVisualStyleBackColor = true;
            this.btnEncry.Click += new System.EventHandler(this.btnEncry_Click);
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(12, 25);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(399, 20);
            this.txtKey.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 141);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(399, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Encryption/Decryption Key:";
            // 
            // cboEnDe
            // 
            this.cboEnDe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEnDe.FormattingEnabled = true;
            this.cboEnDe.Items.AddRange(new object[] {
            "Encrypt",
            "Decrypt"});
            this.cboEnDe.Location = new System.Drawing.Point(12, 87);
            this.cboEnDe.Name = "cboEnDe";
            this.cboEnDe.Size = new System.Drawing.Size(121, 21);
            this.cboEnDe.TabIndex = 4;
            this.cboEnDe.SelectedIndexChanged += new System.EventHandler(this.cboEnDe_SelectedIndexChanged_1);
            // 
            // cboFolders
            // 
            this.cboFolders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFolders.FormattingEnabled = true;
            this.cboFolders.Location = new System.Drawing.Point(12, 114);
            this.cboFolders.Name = "cboFolders";
            this.cboFolders.Size = new System.Drawing.Size(399, 21);
            this.cboFolders.TabIndex = 5;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(12, 170);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(399, 23);
            this.progressBar2.TabIndex = 6;
            // 
            // btnRefreshList
            // 
            this.btnRefreshList.Location = new System.Drawing.Point(320, 85);
            this.btnRefreshList.Name = "btnRefreshList";
            this.btnRefreshList.Size = new System.Drawing.Size(91, 23);
            this.btnRefreshList.TabIndex = 7;
            this.btnRefreshList.Text = "Refresh Folders";
            this.btnRefreshList.UseVisualStyleBackColor = true;
            this.btnRefreshList.Click += new System.EventHandler(this.btnRefreshList_Click);
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(12, 205);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(89, 13);
            this.lblOutput.TabIndex = 8;
            this.lblOutput.Text = "Output goes here";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 297);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.btnRefreshList);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.cboFolders);
            this.Controls.Add(this.cboEnDe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.btnEncry);
            this.Name = "Form1";
            this.Text = "Encry";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEncry;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboEnDe;
        private System.Windows.Forms.ComboBox cboFolders;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Button btnRefreshList;
        private System.Windows.Forms.Label lblOutput;
    }
}

