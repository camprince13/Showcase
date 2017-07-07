//Cameron Prince
//Original 10/26/2015
//Modified 10/26/2015
//A lightweight SQL Application

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient; //SQL database

//**************************Not done


namespace LightWeightSQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }//End Exit button

        private void btnRunSql_Click(object sender, EventArgs e)
        {
            if(!isEmpty(txtServer.Text) && !isEmpty(txtDB.Text) && !isEmpty(txtUname.Text) && !isEmpty(txtPass.Text) && !isEmpty(txtSQL.Text) && !isEmpty(txtTable.Text))
            {DBConn temp = new DBConn();
            DataSet ds = temp.RunQuer(txtServer.Text, txtDB.Text, txtUname.Text, txtPass.Text, txtSQL.Text, txtTable.Text);

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = ds.Tables[txtTable.Text].ToString();//"Person"
            }
            else
            { lblPan1Output.Text = "Fill in all text boxes."; }
        }
        

        private Boolean isEmpty(String temp)
        {Boolean res = false;
        if (temp == "")
        {res=true;}
        else
        { res = false; }
         return res;}


        


    }//End Class
}//End Namespace
