using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace Recipe
{
    class RecipeClass
    {
        private int id;
        private string name;
        private string desc;
        private string type;
        private string ingr;
        private string recipe;
        //[pic]	
        private bool favorite;
        private string notes;

        public int Id
        {
            get
            { return id; }
            set
            { id = value; }
        }

        public string Name
        {
            get
            { return name; }
            set
            { name = value; }
        }

        public string Desc
        {
            get
            { return desc; }
            set
            { desc = value; }
        }

        public string Type
        {
            get
            { return type; }
            set
            { type = value; }
        }

        public string Ingr
        {
            get
            { return ingr; }
            set
            { ingr = value; }
        }

        public string Reci
        {
            get
            { return recipe; }
            set
            { recipe = value; }
        }

        public bool Favorite
        {
            get
            { return favorite; }
            set
            { favorite = value; }
        }

        public string Notes
        {
            get
            { return notes; }
            set
            { notes = value; }
        }

        //-----------End Setters/Getters

        public string AddRecipe()
        {
            string strFeedback = "";

            string strSQL = "INSERT INTO RecipeTable (rName, rDesc, type, ingr, recipe, notes, favorite) VALUES (@Name, @Desc, @Type, @Ingr, @Rec, @Notes, @Fav)";
            
            OleDbConnection conn = new OleDbConnection();

            string strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data\Data.accdb;Persist Security Info=False;";
            conn.ConnectionString = strConn;

            OleDbCommand comm = new OleDbCommand();
            comm.CommandText = strSQL;
            comm.Connection = conn;


            //comm.Parameters.AddWithValue("@Id", id);
            comm.Parameters.AddWithValue("@Name", name);
            comm.Parameters.AddWithValue("@Desc", desc);
            comm.Parameters.AddWithValue("@Type", type);
            comm.Parameters.AddWithValue("@Ingr", ingr);
            comm.Parameters.AddWithValue("@Rec", recipe);
            comm.Parameters.AddWithValue("@Notes", notes);
            comm.Parameters.AddWithValue("@Fav", favorite);
            

            try
            {
                conn.Open();
                strFeedback = comm.ExecuteNonQuery().ToString() + "Record(s) Added";
            }

            catch (Exception err)
            {strFeedback = "Error: " + err.Message;}

            finally { conn.Close(); }

            return strFeedback;

        }//End add Recipe



        //DataSet

        public DataSet SearchRec(RecipeClass temp)//String RecName)
        {
            //Create a dataset to return filled
            DataSet ds = new DataSet();


            //Create a command for our SQL statement
            OleDbCommand comm = new OleDbCommand();


            //SQL Statement
            String strSQL = "Select id as ID, rName as Recipe_Name, rDesc as Recipe_Description, type as Type, ingr as Ingredients, recipe as Recipe, favorite as Favorite FROM RecipeTable WHERE 0=0";

            //If the First/Last Name is filled in include it as search criteria
            if (temp.name.Length > 0)
            {
                strSQL += " AND rName LIKE @RecName";
                comm.Parameters.AddWithValue("@RecName", "%" + temp.name + "%");
            }

            if (temp.id != null && temp.id > 0)
            {
                strSQL += " AND id LIKE @id";
                comm.Parameters.AddWithValue("@id", "%" + temp.id + "%");
            }

            if (temp.type.Length > 0)
            {
                strSQL += " AND type LIKE @ty";
                comm.Parameters.AddWithValue("@ty", "%" + temp.type + "%");
            }

            if (temp.ingr.Length > 0)
            {
                strSQL += " AND ingr LIKE @ing";
                comm.Parameters.AddWithValue("@ing", "%" + temp.ingr + "%");
            }

            if (temp.favorite == true)
            {
                strSQL += " AND favorite LIKE @fv";
                comm.Parameters.AddWithValue("@fv", "%" + -1 + "%");
            }

            //Create DB tools and Configure
            //************************************************
            OleDbConnection conn = new OleDbConnection();

            string strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data\Data.accdb;Persist Security Info=False;";//@SqlDb_Game.GetConnected();
            conn.ConnectionString = strConn;

            comm.Connection = conn;
            comm.CommandText = strSQL;

            //Create Data Adapter
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = comm;

            //************************************************

            //Get Data
            conn.Open();
            da.Fill(ds, "RecipeTable");
            conn.Close();


            return ds;
        }//End Search Game



        public OleDbDataReader FindOneRecipe(int Rid)
        {
            //Create and Initialize the DB Tools we need
            OleDbConnection conn = new OleDbConnection();
            OleDbCommand comm = new OleDbCommand();

            //Connection String
            string strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data\Data.accdb;Persist Security Info=False;";//@SqlDb_Game.GetConnected();

            //SQL command string to pull up one person's data
            string sqlString =
           "Select id, rName, rDesc, type, ingr, recipe, notes, favorite FROM RecipeTable WHERE id = @r_ID;";

            conn.ConnectionString = strConn;

            //Give info
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@r_ID", Rid);

            //Open the DataBase
            conn.Open();

            //Return feedback
            return comm.ExecuteReader();

        }//End Find One recipe

        public string UpdateRec()
        {
            //Int32 intRecords = 0;

            //SQL command
            string strSQL = "UPDATE RecipeTable SET rName = @name, rDesc = @desc, type = @type, ingr = @ingr, recipe = @rec, notes = @not, favorite = @fav WHERE id = @id;";

            //connection to DB
            OleDbConnection conn = new OleDbConnection();

            string strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data\Data.accdb;Persist Security Info=False;";//@SqlDb_Game.GetConnected();

            conn.ConnectionString = strConn;

            OleDbCommand comm = new OleDbCommand();
            comm.CommandText = strSQL;
            comm.Connection = conn;

            comm.Parameters.AddWithValue("@name", name);
            comm.Parameters.AddWithValue("@desc", desc);
            comm.Parameters.AddWithValue("@type", type);
            comm.Parameters.AddWithValue("@ingr", ingr);
            comm.Parameters.AddWithValue("@rec", recipe);
            comm.Parameters.AddWithValue("@not", notes);
            comm.Parameters.AddWithValue("@fav", favorite);
            comm.Parameters.AddWithValue("@id", id);

            string strFeedback = "";
            try
            {
                conn.Open();
                strFeedback = comm.ExecuteNonQuery().ToString();
                //comm.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception err)
            {
                strFeedback = "Error: " + err.Message;
            }
            return strFeedback;
        }//EndUpdateGame


        public Int32 DeleteOneRec(int rid)
        {
            Int32 intRecords = 0;

           OleDbConnection conn = new OleDbConnection();
           OleDbCommand comm = new OleDbCommand();

           string strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Data\Data.accdb;Persist Security Info=False;";//@SqlDb_Game.GetConnected();

            string sqlString =
           "DELETE FROM RecipeTable WHERE id = @r_ID;";

            conn.ConnectionString = strConn;

            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@r_ID", rid);

            conn.Open();

            intRecords = comm.ExecuteNonQuery();

            conn.Close();

            return intRecords;

        }//DeleteOneRec



        public bool validEntry()
        {
            int err = 0;
            bool bal = false;
            if (!validation.IsFilledIn(name))
            { err = 1; }

            if (!validation.IsFilledIn(ingr))
            { err = 1; }

            if (!validation.IsFilledIn(recipe))
            { err = 1; }

            if (type == "Choose a recipe type:")
            { err = 1; }

            if (err != 0)
            { bal = false; }
            else bal = true;

            return bal;

        }


    }//End Class
}//End Namespace
