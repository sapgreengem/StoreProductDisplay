using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreProductDisplay
{
    public partial class SearchResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Cache["DATASET"] == null)
            {
                Label1.Text = "Nothing To Show";
            }
            else
            {
                DataSet ds = (DataSet)Cache["DATASET"];
                if (ds.Tables[0].Rows.Count == 0)
                {
                    Label1.Text = "No Match Found";
                }
                else
                {
                    GridView1.DataSource = ds.Tables["ProductDetails"];
                    GridView1.DataBind();
                    Cache.Remove("DATASET");
                }
            }
            
        }
    }
}