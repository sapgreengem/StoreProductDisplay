using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreProductDisplay
{
    public class adminImgArray
    {
        public string Product_Name { get; set; }
        public string Product_Picture { get; set; }
        public string Product_Price { get; set; }
    }
    public partial class AdminHome : System.Web.UI.Page
    {
        public static List<adminImgArray> myCollection = new List<adminImgArray>();
        private void image()
        {
            string conStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(conStr);
            string query = " select Product_Name, Product_Picture, Product_Price from ProductDetails ";
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                adminImgArray obj;
                while (reader.Read())
                {
                    obj = new adminImgArray();
                    obj.Product_Name = reader["Product_Name"].ToString();
                    obj.Product_Picture = reader["Product_Picture"].ToString();
                    obj.Product_Price = reader["Product_Price"].ToString();
                    myCollection.Add(obj);
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
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                this.image();
                if (Session["login"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
    }
}