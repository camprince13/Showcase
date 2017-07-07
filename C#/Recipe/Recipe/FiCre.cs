using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
//using System.IO.Directory;
using System.Data.OleDb;
using System.Windows.Forms;
using ADOX; //Requires Microsoft ADO Ext. 2.8 for DDL and Security
using ADODB; // requires Microsoft ActiveX Data Objects 2.X Library

namespace Recipe
{
    class FiCre
    {

        public void DtaFldCre() {
            string MainP = @"Data";
            string ImgP = @"Data\Image";
            bool exists = System.IO.Directory.Exists((MainP));
            if (!exists)
                System.IO.Directory.CreateDirectory((MainP));
            exists = System.IO.Directory.Exists((ImgP));
            if (!exists)
                System.IO.Directory.CreateDirectory((ImgP));
            DtaDbCre();
        }

        public void DtaDbCre() {
            if (!File.Exists(@"Data\Data.accdb"))
            {
                ADOX.Catalog cat = new ADOX.Catalog();
                ADOX.Table table = new ADOX.Table();

                try
                {
                    cat.Create("Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=Data\\Data.accdb; Jet OLEDB:Engine Type=5");

                    //Now Close the database
                    ADODB.Connection con = cat.ActiveConnection as ADODB.Connection;
                    if (con != null)
                        con.Close();

                    //result = true;
                }
                catch //(Exception ex)
                {
                }
                cat = null;
                TblCre();
            }//End if


            

        }//End dbCre

        public void TblCre() {

            OleDbConnection conn = new OleDbConnection();
            OleDbCommand comm = new OleDbCommand();
            string strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data\Data.accdb;Persist Security Info=False;";//@SqlDb_Game.GetConnected();
            //string sqlString = "CREATE TABLE RecipeTable ([id] AUTOINCREMENT NOT NULL, [rName] nvarchar(50), [rDesc] nvarchar(100), [type] nvarchar(50), [ingr] nvarchar(200), [recipe] nvarchar(max), [notes] nvarchar(200), [favorite] bit, PRIMARY KEY (id));";

            string sqlString = "CREATE TABLE RecipeTable ([id] AUTOINCREMENT NOT NULL, [rName] text(50), [rDesc] text(100), [type] text(50), [ingr] memo, [recipe] memo, [notes] memo, [favorite] BIT, PRIMARY KEY (id));";
            
            conn.ConnectionString = strConn;
            comm.Connection = conn;
            comm.CommandText = sqlString;
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }


        public void chIfTableExists() {
            bool exists = false;

            OleDbConnection conn = new OleDbConnection();
            OleDbCommand comm = new OleDbCommand();
            string strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data\Data.accdb;Persist Security Info=False;";//@SqlDb_Game.GetConnected();
            //string sqlString = "CREATE TABLE RecipeTable ([id] AUTOINCREMENT NOT NULL, [rName] nvarchar(50), [rDesc] nvarchar(100), [type] nvarchar(50), [ingr] nvarchar(200), [recipe] nvarchar(max), [notes] nvarchar(200), [favorite] bit, PRIMARY KEY (id));";

            string sqlString = @"SELECT COUNT(*) FROM RecipeTable";

            conn.ConnectionString = strConn;
            comm.Connection = conn;
            comm.CommandText = sqlString;
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                exists = true;
            }
            catch
            {
                exists = false;
            }
            finally { conn.Close(); }


            if (exists == false) { TblCre(); }
        }//end chIfTableExists

        public void write2Lic(string input) {
            string path = @"Data\licence.rec";
            if (!File.Exists(path))
            {
                //File.Create(path);
                //TextWriter tw = new StreamWriter(path);
                //tw.Write(input);
                //tw.Close();

                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.Write(input);
                }	


            }
            else if (File.Exists(path))
            {
                //TextWriter tw = new StreamWriter(path, true);
                //tw.Write(input);
                //tw.Close();

                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.Write(input);
                }

            }
        }//End write2Lic

        public string ReadLic() {
            string text = System.IO.File.ReadAllText(@"Data\licence.rec");
            // Display the file contents to the console. Variable text is a string.
            return text;
        }

    }//End class
}//End namespace
