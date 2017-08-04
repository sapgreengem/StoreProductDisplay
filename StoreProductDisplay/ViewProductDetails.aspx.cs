using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
namespace StoreProductDisplay
{
    public partial class ViewProductDetails : System.Web.UI.Page
    {
        public static string conStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.loadCategoryName();
            this.loadProductDetails();
        }
        protected string loadCategoryName(int ID)
        {
            //int cID = Convert.ToInt32(Request.QueryString["category_id"]);
            string catagory_name = "";

            SqlConnection conn = new SqlConnection(conStr);
            //string query = " select * from ProductCategory where Category_ID="+cID+" ";
            string query = " select * from ProductCategory where Category_ID=" + ID + " ";
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    catagory_name = reader["Category_Name"].ToString();
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
            return catagory_name.ToString();
            //CategoryNameLabel.Text = catagory_name.ToString();
        }
        protected void loadProductDetails()
        {
            int Product_ID = Convert.ToInt32(Request.QueryString["product_id"]);
            SqlConnection conn = new SqlConnection(conStr);
            string query = " select * from ProductDetails where Product_ID=" + Product_ID + " ";
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LabelName.Text = reader["Product_Name"].ToString();
                    LabelColor.Text = reader["Product_Color"].ToString();
                    LabelSize.Text = reader["Product_Size"].ToString();
                    LabelPrice.Text = reader["Product_Price"].ToString()+" TK";
                    CategoryNameLabel.Text = this.loadCategoryName(Convert.ToInt32(reader["Category_ID"]));
                    Image1.ImageUrl = reader["Product_Picture"].ToString();
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