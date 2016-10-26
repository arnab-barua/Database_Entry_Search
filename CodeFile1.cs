/*protected void InsertButton_Click(object sender, EventArgs e)
        {
            string name = TextName.Text;
            int age = Convert.ToInt32(TextAge.Text);
            int IsAdded;
            using (SqlConnection sqlCon = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "INSERT INTO nexa(Name,Age)VALUES(@Name,@Age)";
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Connection = sqlCon;
                    sqlCon.Open();
                    IsAdded = cmd.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }
            lebel1.Text = "Record added";
            Response.Redirect(Request.RawUrl);
        }


        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            int ids = Convert.ToInt32(TextId.Text);
            string name = TextName.Text;
            int age = Convert.ToInt32(TextAge.Text);
            int IsAdded;
            using (SqlConnection sqlCon = new SqlConnection(conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "UPDATE nexa SET Name = @Name, Age = @Age WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Id", ids);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Connection = sqlCon;
                    sqlCon.Open();
                    IsAdded = cmd.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }
            lebel1.Text = "Record Updated";
            Response.Redirect(Request.RawUrl);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
            }
            lebel1.Text = "Record added";
        }*/