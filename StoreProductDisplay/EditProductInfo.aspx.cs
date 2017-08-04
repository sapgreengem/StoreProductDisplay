using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;

namespace StoreProductDisplay
{
    public partial class EditProductInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string filePath = Server.MapPath("~/" + this.loadImagePath(Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[0].Text)));
            File.Delete(filePath);
        }

        private string loadImagePath(int id)
        {
            string imgPath = null;
            string conStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(conStr);
            string query = "select Product_ID, Product_Picture from ProductDetails where Product_ID =" + id + " ";

            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    imgPath = reader["Product_Picture"].ToString();
                }
            }
            catch (Exception exc)
            {
                Response.Write(exc.ToString());
            }
            finally
            {
                conn.Close();
            }
            return imgPath;
        }
    }
}