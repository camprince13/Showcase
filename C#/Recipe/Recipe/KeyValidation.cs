using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Recipe
{
    public partial class KeyValidation : Form
    {
        public KeyValidation()
        {
            InitializeComponent();
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            if (ckKey(txtSet1.Text, txtSet2.Text) && txtName.Text != "")
            {
                //key manipulation
                string stuff = "Key: " + txtSet1.Text + "-" + txtSet2.Text + "\nName: " + txtName.Text;
                string encrypt = encry("qwertyuioplmnbvcxzasdfghjk", stuff);
                FiCre temp = new FiCre();
                temp.write2Lic(encrypt);
                this.Close();
            }
            else { lblOutput.Text = "Error: Either name is empty or key is invalid."; }

        }//End button



        private string encry(string pass, string str2encry)
        {
            string output1 = "";
            if (pass != "" && str2encry != "")
            {
                string x = pass;
                string y = str2encry;
                output1 = _001_encrypt.service.EncryptString(y, x);
            }
            else
            { output1 = "Error: Either the passphrase or message to encrypt is empty."; }
            return output1;
        }//End encrypt

        public string decry(string pass, string str2Decry)
        {
            string output1 = "";
            if (pass != "" && str2Decry != "")
            {
                try
                {
                    string x = pass;
                    string y = str2Decry;
                    output1 = _000_Decrypt.Service.DecryptString(y, x);
                }
                catch { output1 = "Error: the message could not be decrypted. The message or passphrase could be wrong."; }
            }
            else
            { output1 = "Error: Either the passphrase or message to decrypt is empty."; }
            return output1;
        }//end decrypt

        private bool ckKey(string s1, string s2) {
            bool valid = false;
            int err = 0;
            if (s1.Length == 6 && s2.Length == 6) { }
            else err += 1;

            //string[] set1 = s1.Split('');
            //string[] set2 = s2.Split("");

            char[] set1 = s1.ToCharArray();
            char[] set2 = s2.ToCharArray();

            if (validation.IsNumber(s1) && err == 0 && validation.IsNumber(set2[0].ToString()) && validation.IsNumber(set2[1].ToString()))
            {
                
                int[] set1Int = set1.Select(x => int.Parse(x.ToString())).ToArray();
                int[] set2Int = new int[2];
                set2Int[0] = int.Parse(set2[0].ToString());
                set2Int[1] = int.Parse(set2[1].ToString());

                if (set1Int[1] != set1Int[0] + 3) { err += 1; }
                int testVar = (set1Int[0] + set1Int[2] + set1Int[4]) / 3;
                if (testVar != set2Int[0]) { err += 1; }
                testVar = (set1Int[1] + set1Int[3] + set1Int[5]) / 3;
                if (testVar != set2Int[1]) { err += 1; }
                if (err == 0) { valid = true; }
            }
            else { valid = false; }

            return valid;
        }//end ckKey


    }//End class
}//End namespace
