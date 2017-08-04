using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace StoreProductDisplay
{
    public partial class AddEditCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }
        protected void BtnAddCategory_Click(object sender, EventArgs e)
        {
            string conStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(conStr);
            string query = "INSERT INTO ProductCategory VALUES (" + TextBoxCategoryID.Text + ",'" + TextBoxCategoryName.Text + "')";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('New Category Added')", true);
            }
            catch (Exception exc)
            {
                Response.Write(exc.ToString());
            }
            finally
            {
                conn.Close();
            }
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[0].Text);
            List<string> imgUrl = new List<string>();
            string conStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(conStr);
            string query = "select ProductCategory.Category_ID, ProductDetails.Product_Picture from ProductCategory, ProductDetails where ProductCategory.Category_ID=ProductDetails.Category_ID and ProductCategory.Category_ID="+id+"";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    imgUrl.Add(reader["Product_Picture"].ToString());
                }
                foreach(string img in imgUrl)
                {
                    string fileUrl = Server.MapPath("~/" + img);
                    File.Delete(fileUrl);
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
        }
    }
}