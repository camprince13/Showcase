using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb; //access database
using System.Globalization;//regex
using System.Text.RegularExpressions;//regex
using System.IO;

namespace Recipe
{
    public partial class NewRec : Form
    {
        public NewRec()
        {
            InitializeComponent();
            cboType.SelectedIndex = 0;
            btnUpdate.Enabled = false;
            btnUpdate.Visible = false;
            btnDelete.Enabled = false;
            btnDelete.Visible = false;
        }


        //OVERLOADED CONSTRUCTOR - Meant to pull up existing data
        public NewRec(Int32 intR_ID)
        {
            InitializeComponent();
            cboType.SelectedIndex = 0;
            btnSub.Enabled = false;
            btnSub.Visible = false;

            //Gather info about this one person and store it in a datareader
            RecipeClass temp = new RecipeClass();
            OleDbDataReader dr = temp.FindOneRecipe(intR_ID);

            //Use that info to fill out the form
            //Loop through the records
            while (dr.Read())
            {
                //Take the Name(s) from the datareader and copy them
                // into the appropriate text fields
                txtDesc.Text = dr["rDesc"].ToString();
                txtIngr.Text = dr["ingr"].ToString();
                txtName.Text = dr["rName"].ToString();
                txtNotes.Text = dr["notes"].ToString();
                txtRecipe.Text = dr["recipe"].ToString();
                cboType.Text = dr["type"].ToString();

                if (Boolean.Parse(dr["favorite"].ToString()) == true)
                ckbxFav.Checked=true;

                //added to store the ID in a label
                lblID.Text = dr["id"].ToString();

                string curFile = @"Data\Image\"+txtName.Text+".bmp";//@"Data\Image\" +txtName.Text+".bmp"

                if (File.Exists(curFile))
                { //pictureBox1.Image = Image.FromFile(curFile); 
                    Image image = Image.FromFile(curFile);
                    // Set the PictureBox image property to this image.
                    // ... Then, adjust its height and width properties.
                    pictureBox1.Image = image.GetThumbnailImage(257, 163, null, new IntPtr());
                    //pictureBox1.Height = image.Height = 163;
                    //pictureBox1.Width = image.Width = 257;
                }//end if
            }//End wile

        }




        private void btnSub_Click(object sender, EventArgs e)
        {
            //Create an instance of a person
            RecipeClass temp = new RecipeClass();

            //Assign the instance of a person a name
            //temp.Feedback = "";
            //temp.Id = txtFName.Text;
            temp.Name = txtName.Text;// txtMName.Text;
            temp.Desc = txtDesc.Text;// txtLName.Text;
            temp.Ingr = txtIngr.Text;
            temp.Favorite = ckbxFav.Checked;
            temp.Notes = txtNotes.Text;
            temp.Reci = txtRecipe.Text;
            temp.Type = cboType.Text;

            if (temp.validEntry())
            {
                label1.Text = temp.AddRecipe();
                if (label1.Text == "1Record(s) Added") this.Close();
            }
            else MessageBox.Show("More data must be entered.");

        }//End 

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtName.Text))
            { MessageBox.Show("Enter a name."); }
            else
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    Image img = new Bitmap(open.FileName);
                    string imagename = open.SafeFileName;
                    //Txt_countrylogo.Text = imagename;
                    pictureBox1.Image = img.GetThumbnailImage(257, 163, null, new IntPtr());
                    open.RestoreDirectory = true;

                    //img.Save(@"d:\temp\" + imagename);
                    try
                    {
                        img.Save(@"Data\Image\" + txtName.Text + ".bmp");
                    }
                    catch { }
                }
            }
        }//End picbox

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            RecipeClass temp = new RecipeClass();

            temp.Name = txtName.Text;// txtMName.Text;
            temp.Desc = txtDesc.Text;// txtLName.Text;
            temp.Ingr = txtIngr.Text;
            temp.Favorite = ckbxFav.Checked;
            temp.Notes = txtNotes.Text;
            temp.Reci = txtRecipe.Text;
            temp.Type = cboType.Text;
            temp.Id = Int32.Parse(lblID.Text);

            if (temp.validEntry())
            {
                label1.Text = temp.UpdateRec();
            }
            else MessageBox.Show("More data must be entered.");

            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            pictureBox1.InitialImage = null;
            pictureBox1.Image = null;

            RecipeClass temp = new RecipeClass();
            Int32 intG_ID = Convert.ToInt32(lblID.Text);
            Int32 intRecords = temp.DeleteOneRec(intG_ID);
            MessageBox.Show(intRecords.ToString() + " Records Deleted.");

            this.Close();
        }//End delete

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DelImg(string text)
        {
            if (File.Exists(@"Data\Image\" + text + ".bmp"))
            {
                File.Delete(@"Data\Image\" + text + ".bmp");
            }
        }

    }
}
