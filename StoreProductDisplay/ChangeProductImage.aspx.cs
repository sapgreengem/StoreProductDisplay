using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoreProductDisplay
{
    public partial class ChangeProductImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                int Product_ID = Convert.ToInt32(Request.QueryString["id"]);
                Image1.ImageUrl = "~/" + this.loadProductImage(Product_ID); 
            }
        }

        protected string loadProductImage(int id)
        {
            string ProductPicture = null;
            string conStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(conStr);
            string query = " select * from ProductDetails where Product_ID=" + id + " ";
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductPicture = reader["Product_Picture"].ToString();
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
            return ProductPicture;
        }

        protected void UpdateProductImageNameInDB(string ProductImg, int ProductID)
        {
            string conStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(conStr);
            string query = "UPDATE ProductDetails SET Product_Picture = '" + "uploads/" + ProductImg + "' WHERE Product_ID =" + ProductID + "";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpPostedFile postedFile = FileUpload1.PostedFile;
            string fileName = Path.GetFileName(postedFile.FileName);
            string fileExtention = Path.GetExtension(fileName);
            int fileSize = postedFile.ContentLength;

            int Product_ID = Convert.ToInt32(Request.QueryString["id"]);

            string newFileUrl = Server.MapPath("~/uploads");

            if (FileUpload1.HasFile)
            {
                if (fileExtention == ".jpg" || fileExtention == ".png" || fileExtention == ".gif" || fileExtention == ".bmp" || fileExtention == ".JPG" || fileExtention == ".PNG" || fileExtention == ".GIF" || fileExtention == ".BMP")
                {
                    string fileToBeDelete = Server.MapPath("~/" + this.loadProductImage(Product_ID));
                    File.Delete(fileToBeDelete);
                    //Response.Write(fileToBeDelete);

                    this.UpdateProductImageNameInDB(FileUpload1.FileName.ToString(), Product_ID);

                    FileUpload1.SaveAs(newFileUrl + "\\" + FileUpload1.FileName);
                    //Response.Write(newFileUrl + "\\" + FileUpload1.FileName + "<br>");

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Image Changed')", true);
                    Response.Redirect("~/EditProductInfo.aspx"); 
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('please select an image file')", true);
                }

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Select File')", true);
            }
        }
    }
}