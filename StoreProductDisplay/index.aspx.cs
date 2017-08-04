using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace StoreProductDisplay
{
    
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadImage();
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            this.LoadImage();
        }

        private void LoadImage()
        {
            List<string> img = new List<string>();
            int counter = 0;
            string conStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(conStr);
            string query = " select * from ProductDetails where Product_Add_Date between '"+DateTime.Today.AddMonths(-1)+"' and '"+DateTime.Today+"' ";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    img.Add(reader["Product_Picture"].ToString());
                    counter ++;
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

            if (!img.Any())
            {
                LabelInfo.Text = "No Products To be Shown";
            }
            else
            {
                if (ViewState["ImageDisplayed"] == null)
                {
                    Image1.ImageUrl = "~/" + img[0].ToString();
                    ViewState["ImageDisplayed"] = 1;
                    Label1.Text = "Displaying Image - " + ViewState["ImageDisplayed"];
                }
                else
                {
                    int i = (int)ViewState["ImageDisplayed"];
                    if (i == counter)
                    {
                        Image1.ImageUrl = "~/" + img[0].ToString();
                        ViewState["ImageDisplayed"] = 1;
                        Label1.Text = "Displaying Image - " + ViewState["ImageDisplayed"];
                    }
                    else
                    {
                        i++;
                        Image1.ImageUrl = "~/" + img[i - 1].ToString();
                        ViewState["ImageDisplayed"] = i;
                        Label1.Text = "Displaying Image - " + ViewState["ImageDisplayed"];
                    }
                } 
            }
        }
    }
}