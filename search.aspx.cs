using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;
using ExtensionMethods;

namespace NexaSearch
{

    public partial class search : System.Web.UI.Page
    {
        string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        static string MinifyB(string p)
        {
            StringBuilder b = new StringBuilder(p);
            b.Replace(Environment.NewLine, string.Empty);
            b.Replace("  ", string.Empty);
            b.Replace("\\t", string.Empty);
            b.Replace(" {", "");
            b.Replace(" :", "");
            b.Replace(": ", "");
            b.Replace(", ", "");
            b.Replace("; ", "");
            b.Replace(";}", "");
            b.Replace(" is "," ");
            b.Replace(" was ", " ");
            b.Replace(" am ", " ");
            b.Replace(" were ", " ");
            b.Replace(" are ", " ");
            b.Replace(" will ", " ");
            b.Replace(" shall ", " ");
            b.Replace(" should ", " ");
            b.Replace(" would ", " ");
            b.Replace(" could ", " ");
            b.Replace(" might ", " ");
            b.Replace(" on ", " ");
            b.Replace(" in ", " ");
            b.Replace(" into ", " ");
            b.Replace(" with ", " ");
            b.Replace(" to ", " ");
            b.Replace(" from ", " ");
            return b.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String str1 = TextBox1.Text;
            str1 = Regex.Replace(str1, " {2,}", " ");
            string str2 = MinifyB(str1);
            string str = str2.Replace(" ", "  ");
            String[] arr = str.Split(' ');
            int c = arr.Count();
            String[] output = new String[500];
            int m = -1;
            for (int k = 0; k < c; k++)
            {
                output[++m] = arr[k];
                for (int i = k + 1; i < c; i++)
                {
                    output[++m] = output[m - 1] + " " + arr[i];
                }
            }
            
            string inp = "";
            String test = "";
            for (int i = 0; i <= m; i++)
            {
                test += output[i] + ",";
            }
            inp = test.Replace(", ", ",");

            SqlConnection sqlCon = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand("lastOne", sqlCon);
            sqlCon.Open();
            cmd.Parameters.Add("@word", SqlDbType.VarChar).Value = inp;
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Label1.Text = Convert.ToString(dt.Rows.Count) + " matches found";
            GridView1.DataSource = dt;
            GridView1.DataBind();
            sqlCon.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx", true);
        }

    }
}


