using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Recipe
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void btnShowKey_Click(object sender, EventArgs e)
        {

            FiCre asdf = new FiCre();
            KeyValidation temp = new KeyValidation();
            try
            {
                string mm = asdf.ReadLic();
                if (mm != "")
                {
                    string path = @"Data\licence.rec";
                    string readFromFile = "";
                    using (StreamReader sr = File.OpenText(path))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            //Console.WriteLine(s);
                            readFromFile += s;
                        }
                    }//end using
                    string tester = temp.decry("qwertyuioplmnbvcxzasdfghjk", readFromFile);
                    if (tester.Contains("Error")) { temp.ShowDialog(); }
                    else { MessageBox.Show(tester); }//debug

                }//end if
                else { temp.ShowDialog(); }

            }//End try
            catch
            {
                temp.ShowDialog();
            }


        }//End button



    }//End class
}//End namespace
