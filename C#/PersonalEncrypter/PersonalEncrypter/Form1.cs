using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PersonalEncrypter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cboEnDe.SelectedIndex = 0;
        }

        private void btnEncry_Click(object sender, EventArgs e)
        {
            string s = Convert.ToString(cboFolders.SelectedItem);

            if (s != "" && txtKey.Text != "" && btnEncry.Text == "Encrypt")
            {
                int numFiles = FileIO.GetFileListNum(s);
                string[] files = FileIO.GetFileList(Convert.ToString(cboFolders.SelectedItem));
                lblOutput.Text = numFiles + " Files; Reading file...";//FileIO.GetFileListNum(s) + " Files";

                string[] temp_file = null;
                for(int i = 0; i < numFiles; i++){

                lblOutput.Text = numFiles + " Files; Reading file...; " + i + " files encrypted;";

                temp_file = FileIO.ReadFile(files[i]);
                lblOutput.Text = numFiles + " Files; Encrypting file...; "+i+" files encrypted;";

                for (int j = 0; j < temp_file.Length; j++)
                { temp_file[j] = encrypt(temp_file[j]); }

                lblOutput.Text = numFiles + " Files; Writing file...; " + i + " files encrypted;";

                FileIO.FileCreater(temp_file, files[i]);

                lblOutput.Text = numFiles + " Files; Done writing file...; " + i + " files encrypted;";

                }//end outer for

                lblOutput.Text = numFiles + " Files; Done writing file...; " + numFiles + " files encrypted;";

            }//end if

            else if (s != "" && txtKey.Text != "" && btnEncry.Text == "Decrypt")
            {
                int numFiles = FileIO.GetFileListNum(s);
                string[] files = FileIO.GetFileList(Convert.ToString(cboFolders.SelectedItem));
                lblOutput.Text = numFiles + " Files; Reading file...";//FileIO.GetFileListNum(s) + " Files";

                string[] temp_file = null;
                for (int i = 0; i < numFiles; i++)
                {

                    lblOutput.Text = numFiles + " Files; Reading file...; " + i + " files decrypted;";

                    temp_file = FileIO.ReadFile(files[i]);
                    lblOutput.Text = numFiles + " Files; Decrypting file...; " + i + " files decrypted;";

                    for (int j = 0; j < temp_file.Length; j++)
                    { temp_file[j] = decrypt(temp_file[j]); }

                    lblOutput.Text = numFiles + " Files; Writing file...; " + i + " files decrypted;";

                    FileIO.FileCreater(temp_file, files[i]);

                    lblOutput.Text = numFiles + " Files; Done writing file...; " + i + " files decrypted;";

                }//end outer for

                lblOutput.Text = numFiles + " Files; Done writing file...; " + numFiles + " files decrypted;";

            }//end else if

            else { lblOutput.Text = "Error"; }

            

        }//End encrypt button

        private void cboEnDe_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cboEnDe.SelectedIndex == 0)
            { btnEncry.Text = "Encrypt"; }
            if (cboEnDe.SelectedIndex == 1)
            { btnEncry.Text = "Decrypt"; }
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            cboFolders.Items.Clear();
            string path = Directory.GetCurrentDirectory();
            int directoryCount = System.IO.Directory.GetDirectories(@path).Length;

            string[] folders = System.IO.Directory.GetDirectories(@path, "*", System.IO.SearchOption.AllDirectories);
            //string[] files = System.IO.Directory.GetFiles(@"C:\Testing");

            this.cboFolders.Items.AddRange(folders);
            cboFolders.SelectedIndex = 0;
        }

        private string encrypt(string str)
        {

            string temp = "";

            if (str != "")
            {
                string x = txtKey.Text;//@DBLogin.Passphr();
                string y = str;
                temp = _001_encrypt.service.EncryptString(y, x);
            }
            else
            { temp = ""; }

            return temp;
        }//end encry

        private string decrypt(string str)
        {
            string temp = "";
            if (str != "")
            {
                try
                {
                    string x = txtKey.Text;//@DBLogin.Passphr();
                    string y = str;
                    temp = _000_Decrypt.Service.DecryptString(y, x);
                }
                catch { temp = "Error: the message could not be decrypted. The message or passphrase could be wrong."; }
            }
            else
            { temp = ""; }

            return temp;

        }//end decrypt

    }//end class
}//end namespace
