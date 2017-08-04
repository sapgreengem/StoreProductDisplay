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
    public class storeImg
    {
        public string Store_Address { get; set; }
        public string Store_Location { get; set; }
        public string Contact_No { get; set; }
        public string Store_Image { get; set; }
    }
    public partial class ViewStoreLocation : System.Web.UI.Page
    {
        public static List<storeImg> myStorCollection = new List<storeImg>();

        private void storeImage()
        {
            string conStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(conStr);
            string query = " select Store_Address,Store_Location,Contact_No,Store_Image from StoreAddress ";
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                storeImg obj;
                while (reader.Read())
                {
                    obj = new storeImg();
                    obj.Store_Address = reader["Store_Address"].ToString();
                    obj.Store_Location = reader["Store_Location"].ToString();
                    obj.Contact_No = reader["Contact_No"].ToString();
                    obj.Store_Image = reader["Store_Image"].ToString();
                    myStorCollection.Add(obj);
                }

                foreach (storeImg obja in myStorCollection)
                {

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
            this.storeImage();
        }
    }
}