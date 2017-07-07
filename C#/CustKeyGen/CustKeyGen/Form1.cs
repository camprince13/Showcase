using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustKeyGen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnNewKey_Click(object sender, EventArgs e)
        {
            Key1 k = new Key1(5);
            lblOutput.Text = k.genAKey();
        }

        private void btnManyKeys_Click(object sender, EventArgs e)
        {
            int numOfKeys = 999;
            Key1 k = new Key1(numOfKeys);
            string[] temp = k.genAllKeys(this.pgs);
            string temp2 = "";

            for (int i = 0; i < temp.Length; i++) {
                temp2 += temp[i] + Environment.NewLine;
            }

            //MessageBox.Show(temp2);
            FileIO f = new FileIO();
            f.FileCreater("keys",temp2,null);

        }


    }//end class
}//end namespace
