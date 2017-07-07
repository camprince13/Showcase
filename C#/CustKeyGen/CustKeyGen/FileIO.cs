using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace CustKeyGen
{
    class FileIO
    {

        public static String all; //String used to output in aboutreader

        public string ReadFile(string filenm, string dir)
        {
            if (!File.Exists(@"Data\" + dir + filenm + ".txt"))
            { return "No file found..."; }
            else
            {
                all = "";
                // Read each line of the file into a string array. Each element 
                // of the array is one line of the file. 
                string[] about = System.IO.File.ReadAllLines(@"Data\" + dir + filenm + ".txt");
                // Display the file contents by using a foreach loop.
                foreach (string line in about)
                {// Use a new line to indent each line of the file.
                    all += (line + Environment.NewLine);
                }
                return (all.ToString());
            }
        }//End aboutreader

        public static void addlog(string logged)//Adds a log to the log file, when passed the message
        {
            DateTime now = DateTime.Now;
            string log = now + "\t" + logged;
            File.AppendAllText(@"Logs\Logs.log", log + Environment.NewLine);
        }//End addlog


        //private void BuildFile(string path) { File.Create(path);}

        public void FileCreater(string filenm, String text, string dir)
        {

            string path = @"Data\" +dir+ filenm+ ".txt";
            string pa = @"Data\" + dir;

            if (!File.Exists(path))
            {
                if (!System.IO.Directory.Exists(pa)){System.IO.Directory.CreateDirectory(pa); }

                File.Create(path).Close();
                System.IO.File.WriteAllText(path, text);

                //TextWriter tw = new StreamWriter(path);
                //tw.WriteLine(text);
                //tw.Close();

            }
            else if (File.Exists(path))
            {
                //TextWriter tw = new StreamWriter(path);
                //tw.WriteLine("The next line!");
                //tw.Close();
                System.IO.File.WriteAllText(path, text);
            }

        }//end FileCreater



        public void GetDirectories(string dir)
        {
            int directoryCount = System.IO.Directory.GetDirectories(@"Data\"+dir).Length;

            string[] folders = System.IO.Directory.GetDirectories(@"Data\" + dir, "*", System.IO.SearchOption.AllDirectories);
            string all1 = "";
            for (int i = 0; i < directoryCount; i++) { all1 += folders[i] + "\n"; }

                MessageBox.Show(all1);
            //return folders;
        }//GetDirectories


        public void GetFileList(string dir)
        {
            int directoryCount = System.IO.Directory.GetFiles(@"Data\" + dir).Length;

            string[] files = System.IO.Directory.GetFiles(@"Data\" + dir);
            string all1 = "";
            for (int i = 0; i < directoryCount; i++) { all1 += files[i] + "\n"; }

            if (all1 == "") { all1 = "No files found..."; }

            MessageBox.Show(all1);
            //return folders;
        }//GetDirectories

        public void DelFile(string filenm, string dir) {

            string path = @"Data\" +dir+ filenm + ".txt";

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }//End DelFile


    }//End class
}//End namespace
