using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Note_Taker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            FileIO temp = new FileIO();
            temp.GetDirectories(txtDir.Text);
        }//end btnSubmit

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            if (txtFileNm.Text == "") { valOutP(); }
            else
            {
                FileIO temp = new FileIO();
                txtContent.Text = temp.ReadFile(txtFileNm.Text, txtDir.Text);//("example");
            }

        }//End btnreaadfile

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtFileNm.Text == "") { valOutP(); }
            else
            {
            FileIO temp = new FileIO();
            temp.FileCreater(txtFileNm.Text, txtContent.Text, txtDir.Text);
             }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileIO temp = new FileIO();
            temp.GetFileList(txtDir.Text);
        }

        private void btnDelFile_Click(object sender, EventArgs e)
        {
            if (txtFileNm.Text == "") { valOutP(); }
            else
            {
            FileIO temp = new FileIO();
            temp.DelFile(txtFileNm.Text, txtDir.Text);
             }
        }

        private void valOutP() { MessageBox.Show("The file name is blank."); }

    }//End class
}//End namespace
