using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreProductDisplay
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void SiteMapPath1_ItemCreated(object sender, SiteMapNodeItemEventArgs e)
        {
            if (e.Item.ItemType == SiteMapNodeItemType.Root || (e.Item.ItemType == SiteMapNodeItemType.PathSeparator && e.Item.ItemIndex == 1))
            {
                e.Item.Visible = false;
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxSearch.Text))
            {
                Label1.Text = "Enter Text to search";
            }
            else
            {
                string conStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection conn = new SqlConnection(conStr);
                string query = "Select * from ProductDetails where Product_Name like '%" + TextBoxSearch.Text + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                try
                {
                    conn.Open();
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "ProductDetails");
                    Cache["DATASET"] = ds;
                    Response.Redirect("~/SearchResult.aspx");
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
}