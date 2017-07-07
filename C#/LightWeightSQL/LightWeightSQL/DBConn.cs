
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient; //SQL database



//*******************Not Done


namespace LightWeightSQL
{
    class DBConn
    {



        //DataSet

        public DataSet RunQuer(string svr, string db, string user, string pass, string seequal, string table1)//SearchContacts
        {
            //Create a dataset to return filled
            DataSet ds = new DataSet();


            //Create a command for our SQL statement
            SqlCommand comm = new SqlCommand();


            //SQL Statement
            String strSQL = seequal;//"Select Person_ID, FName, MName, LName, Money, Suffix, Prefix, Addr1, Addr2, City, State, Zip, Area_Code, Phone, Email, Country FROM Persons WHERE 0=0";

            //If the First/Last Name is filled in include it as search criteria
            /*if (FName.Length > 0)
            {
                strSQL += " AND FName LIKE @FName";
                comm.Parameters.AddWithValue("@FName", "%" + FName + "%");
            }
            if (LName.Length > 0)
            {
                strSQL += " AND LName LIKE @LName";
                comm.Parameters.AddWithValue("@LName", "%" + LName + "%");
            }*/


            //Create DB tools and Configure
            //******************************************
            SqlConnection conn = new SqlConnection();

            string strConn = @GetConnected(svr, db, user, pass);//Connection String
            conn.ConnectionString = strConn;

            comm.Connection = conn;
            comm.CommandText = strSQL;

            //Create Data Adapter
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comm;

            //******************************************


            


            
            try
            {
                conn.Open();
                da.Fill(ds, table1);//"Person"
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                MessageBox.Show("Exception caught.\n"+e, "LightWeightSQL", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
            finally
            { conn.Close(); }

            return ds;
        }//End Search Contacts



        public static string GetConnected(string svr, string db, string user, string pass)
        {
            String result = @"Server=" + svr + ";Database=" + db +";User Id="+user+";Password="+pass+";";
            //string result = @"Server=sql.neit.edu;Database=SE255_CPrince;User Id=SE255_CPrince;Password=001295039;";
            return result;
        }//End getconn



    }//end class
}//end namespace
