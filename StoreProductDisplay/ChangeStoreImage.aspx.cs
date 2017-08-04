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
    public partial class ChangeStoreImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                int Store_ID = Convert.ToInt32(Request.QueryString["id"]);
                Image1.ImageUrl = "~/" + this.loadStoreImage(Store_ID); 
            }
        }
        protected string loadStoreImage(int id)
        {
            string StoreImage=null;
            string conStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(conStr);
            string query = " select * from StoreAddress where Store_ID=" + id + " ";
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    StoreImage = reader["Store_Image"].ToString();
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
            return StoreImage;
        }

        protected void UpdateImageNameInDB(string StoreImg, int StoreID)
        {
            string conStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(conStr);
            string query = "UPDATE StoreAddress SET Store_Image = '" + "stores/" + StoreImg + "' WHERE Store_ID =" + StoreID + "";
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

            int Store_ID = Convert.ToInt32(Request.QueryString["id"]);

            string newFileUrl = Server.MapPath("~/stores");

            if (FileUpload1.HasFile)
            {
                if (fileExtention == ".jpg" || fileExtention == ".png" || fileExtention == ".gif" || fileExtention == ".bmp" || fileExtention == ".JPG" || fileExtention == ".PNG" || fileExtention == ".GIF" || fileExtention == ".BMP")
                {
                    string fileToBeDelete = Server.MapPath("~/" + this.loadStoreImage(Store_ID));
                    File.Delete(fileToBeDelete);
                    //Response.Write(fileToBeDelete);

                    this.UpdateImageNameInDB(FileUpload1.FileName.ToString(), Store_ID);

                    FileUpload1.SaveAs(newFileUrl + "\\" + FileUpload1.FileName);
                    //Response.Write(newFileUrl + "\\" + FileUpload1.FileName + "<br>");

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Image Changed')", true);
                    Response.Redirect("~/AddEditBranches.aspx"); 
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