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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Recipe Program V0.5";
            FiCre asdf = new FiCre();
            asdf.DtaFldCre();
            asdf.chIfTableExists();

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
                    //else { MessageBox.Show(tester); }//debug

                }//end if
                else { temp.ShowDialog(); }

            }//End try
            catch
            {
                temp.ShowDialog();
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NewRec temp = new NewRec();
            temp.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Search temp = new Search();
            temp.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search temp = new Search();
            temp.ShowDialog();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings temp = new Settings();
            temp.ShowDialog();
        }

    }
}
