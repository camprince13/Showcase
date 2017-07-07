using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BaseNumCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            numBox.Maximum = Int32.MaxValue;
        }

        #region variables
        List<string> outp;
        #endregion

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            outp = new List<string>();
            toBaseX(Convert.ToInt32(numBox.Value));
            toTxtBx();
        }

        private void toBaseX(int num2Convert) 
        {

            char[] maxBase = new char[] { '0','1','2','3','4','5','6','7','8','9',
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};

            outp.Add(num2Convert +" in multiple base forms:");

            for (int i = 2; i < 62; i++)
            {

                char[] tmp = new char[i];
                for (int x = 0; x < i; x++ )
                { tmp[x] = maxBase[x]; }

                string outPut = "Base-"+i+": " +IntToString(num2Convert, tmp);
                outp.Add(outPut);

            }//end for

        }//end to base x


        private static string IntToString(int value, char[] baseChars)
        {
            string result = string.Empty;
            int targetBase = baseChars.Length;

            do
            {
                result = baseChars[value % targetBase] + result;
                value = value / targetBase;
            }
            while (value > 0);

            return result;
        }//end string conversion

        private void toTxtBx() 
        {
            txtOutput.Text = "";

            for (int i = 0; i < outp.Count; i++)
            { txtOutput.Text += outp[i] + Environment.NewLine; }
        }//end toTextBox

    }//end class
}//end namespace
