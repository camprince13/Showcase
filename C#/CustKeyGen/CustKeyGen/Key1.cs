using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustKeyGen
{
    class Key1
    {
        String[] key;
        int keyNum = 0;
        int max = 0;

        public Key1(int i) { key = new string[i];
        max = i;}

        public string genAKey() {

            string k = "";
            int temp1 = RandNum(1, 6);
            int temp2 = temp1 + 3;
            int temp3 = RandNum(1, 9);
            int temp4 = RandNum(1, 9);

            k += temp1;
            k += temp2;
            k += "-";
            k += temp3;
            k += temp4;
            k += "-";

            temp1 = (temp1 + temp3) / 2;
            temp2 = (temp2 + temp4) / 2;

            k += temp1;
            k += temp2;
            k += RandLettr(4);

            return k;
        }//End gen key

        private void StoreKey(string k) {
            if (keyNum < max)
            {
                if (!key.Contains(k))
                {
                    key[keyNum] = k;
                    keyNum++;
                }//End 2nd if
            }//end first if
        }//end store

        public string[] genAllKeys(ProgressBar par ) {

            string tempKey = "";
            for (int i = 0; keyNum < max; i++) {
                tempKey = genAKey();
                StoreKey(tempKey);
                par.Value = Convert.ToInt16(keyNum/max) * 100;
            }//end for
        return key;
        }

        private int RandNum(int low, int high)
        {
            Random rnd = new Random();
            int num = rnd.Next(low, high+1);
            return num;
        }

        private string RandLettr(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";//0123456789
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }


    }//end class
}//end namespace