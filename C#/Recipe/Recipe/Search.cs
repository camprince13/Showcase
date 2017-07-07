using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Recipe
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //get data
            RecipeClass temp = new RecipeClass();
            //preform search

            RecipeClass temp2 = new RecipeClass();
            temp2.Name = txtRname.Text;
            temp2.Ingr = txtIngr.Text;
            temp2.Favorite = chkBxFav.Checked;
            try { temp2.Id = Convert.ToInt32(txtID.Text); }
            catch { temp2.Id = -1; }
            temp2.Type = cboType.Text;

            DataSet ds = temp.SearchRec(temp2);
            //DataSet ds = temp.SearchRec(txtRname.Text);

            //display data
            gv_results.DataSource = ds;
            gv_results.DataMember = ds.Tables["RecipeTable"].ToString();//.DataSource
        }

        private void gv_results_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string RecID = gv_results.Rows[e.RowIndex].Cells[0].Value.ToString();

            int Recid = Convert.ToInt32(RecID);

            NewRec Editor = new NewRec(Recid);
            Editor.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }//End Class
}//End Namespace
