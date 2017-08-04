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
    public class imgArray
    {
        public string Category_Name { get; internal set; }
        public string Product_ID { get; set; }
        public string Product_Name { get; set; }
        public string Product_Picture { get; set; }
        public string Product_Price { get; set; }
        public string Category_ID { get; set; }
    }
    public partial class Home : System.Web.UI.Page
    {
        public static List<imgArray> myCollection = new List<imgArray>();

        private void image()
        {
            string conStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(conStr);
            string query = " select * from ProductDetails ";
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                imgArray obj;
                while (reader.Read())
                {
                    obj = new imgArray();
                    obj.Product_ID = reader["Product_ID"].ToString();
                    obj.Product_Name = reader["Product_Name"].ToString();
                    obj.Product_Picture = reader["Product_Picture"].ToString();
                    obj.Product_Price = reader["Product_Price"].ToString();
                    obj.Category_ID = reader["Category_ID"].ToString();
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

        private void LoadCategory()
        {
            string conStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(conStr);
            string query = "select * from ProductCategory";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DropDownListProductCategory1.DataTextField = "Category_Name";
                DropDownListProductCategory1.DataValueField = "Category_ID";
                DropDownListProductCategory1.DataSource = reader;
                DropDownListProductCategory1.DataBind();
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
            this.image();

            if (!IsPostBack)
            {
                this.LoadCategory();
            }
        }
        protected void SelectFromCategory()
        {
            if (DropDownListProductCategory1.SelectedValue!="0")
            {
                string conStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection conn = new SqlConnection(conStr);
                string query = " select * from ProductDetails where Category_ID=" + DropDownListProductCategory1.SelectedValue + "";
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    imgArray obj;
                    while (reader.Read())
                    {
                        obj = new imgArray();
                        obj.Product_ID = reader["Product_ID"].ToString();
                        obj.Product_Name = reader["Product_Name"].ToString();
                        obj.Product_Picture = reader["Product_Picture"].ToString();
                        obj.Product_Price = reader["Product_Price"].ToString();
                        obj.Category_ID = reader["Category_ID"].ToString();
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
            else
            {
                this.image();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            myCollection.Clear();

            string conStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(conStr);
            string query = "   select * from ProductDetails where Product_Price between "+TextBox1.Text+" and "+TextBox2.Text+" ";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                imgArray obj;
                while (reader.Read())
                {
                    obj = new imgArray();
                    obj.Product_ID = reader["Product_ID"].ToString();
                    obj.Product_Name = reader["Product_Name"].ToString();
                    obj.Product_Picture = reader["Product_Picture"].ToString();
                    obj.Product_Price = reader["Product_Price"].ToString();
                    obj.Category_ID = reader["Category_ID"].ToString();
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

        protected void DropDownListProductCategory1_SelectedIndexChanged(object sender, EventArgs e)
        {
            myCollection.Clear();
            this.SelectFromCategory();
        }
    }
}