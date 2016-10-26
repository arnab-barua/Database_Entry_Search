using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Sql;

namespace DataTest
{
    public partial class Default : System.Web.UI.Page
    { 
        string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            TextId.Enabled = false;
            UpdateButton.Enabled = false;
            if (IsPostBack == false)
            {
                lebel1.Text = "________________________________________";
                using (SqlConnection sqlCon = new SqlConnection(conn))
                {
                    sqlCon.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "SELECT * FROM nexa";
                        cmd.Connection = sqlCon;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    if (String.Compare(Request.QueryString["id"],null)!=0)
                    {
                        if (String.Compare(Request.QueryString["act"], "upd") == 0)
                        {
                            InsertButton.Enabled = false;
                            UpdateButton.Enabled = true;
                            using (SqlCommand cmd = new SqlCommand())
                            {
                                cmd.CommandText = "SELECT * FROM nexa WHERE ID=@ID";
                                cmd.Connection = sqlCon;
                                cmd.Parameters.AddWithValue("ID", Request.QueryString["id"]);
                                SqlDataReader reader = cmd.ExecuteReader();

                                if (reader.HasRows)
                                {
                                    reader.Read();
                                    TextId.Text = reader["Id"].ToString();
                                    TextName.Text = reader["Name"].ToString();
                                    TextAge.Text = reader["Age"].ToString();
                                    reader.Close();
                                }
                            }
                        }
                        if (String.Compare(Request.QueryString["act"], "del") == 0)
                        {
                            int ids = Convert.ToInt32(Request.QueryString["id"]);
                            using (SqlCommand cmd = new SqlCommand())
                                {
                                    cmd.CommandText = "DELETE FROM nexa WHERE Id = @Id";
                                    cmd.Parameters.AddWithValue("@Id", ids);
                                    cmd.Connection = sqlCon;
                                    cmd.ExecuteNonQuery();
                                    sqlCon.Close();
                                }
                            Response.Redirect("~/Default.aspx", true);
                        }
                        sqlCon.Close();
                    }
                }
            }
        }

        protected void InsertButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                SqlConnection sqlCon = new SqlConnection(conn);
                SqlCommand cmd = new SqlCommand("insertrecord", sqlCon);
                cmd.Parameters.AddWithValue("@Name", TextName.Text);
                cmd.Parameters.AddWithValue("@Age", TextAge.Text);
                sqlCon.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                SqlConnection sqlCon = new SqlConnection(conn);
                SqlCommand cmd = new SqlCommand("updaterecord", sqlCon);
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = TextName.Text;
                cmd.Parameters.Add("@Age", SqlDbType.VarChar).Value = TextAge.Text;
                cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = TextId.Text;
                sqlCon.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                Response.Redirect("~/Default.aspx", true);
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/search.aspx", true);
        }

    }
}