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
    public partial class AddEditBranches : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }
        protected void BtnAddStore_Click(object sender, EventArgs e)
        {
            HttpPostedFile postedFile = FileUpload1.PostedFile;
            string fileName = Path.GetFileName(postedFile.FileName);
            string fileExtention = Path.GetExtension(fileName);
            int fileSize = postedFile.ContentLength;

            if (fileExtention == ".jpg" || fileExtention == ".png" || fileExtention == ".gif" || fileExtention == ".bmp" || fileExtention == ".JPG" || fileExtention == ".PNG" || fileExtention == ".GIF" || fileExtention == ".BMP")
            {
                string filepath = Server.MapPath("~/stores");
                if (FileUpload1.HasFile)
                {
                    FileUpload1.SaveAs(filepath + "\\" + FileUpload1.FileName);
                }
                string conStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection conn = new SqlConnection(conStr);
                string query = "INSERT INTO StoreAddress (Store_ID,Store_Location,Store_Address,Contact_No,Store_Image) VALUES (" + TextBoxStoreId.Text + ",'" + DropDownListStoreLocation.SelectedValue + "','" + TextBoxStoreAddress.Text + "','" + TextBoxStoreContactNo.Text + "','" + "stores/" + fileName + "')";
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Store Added Successfully')", true);
                }
                catch (Exception exc)
                {
                    Response.Write(exc.ToString());
                }
                finally
                {
                    conn.Close();
                }
                GridViewStoreLocation.DataBind();
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('please select an image file')", true);
        }

        protected void GridViewStoreLocation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string deleteFilePath = Server.MapPath("~/"+ this.loadImagePath(Convert.ToInt32(GridViewStoreLocation.Rows[e.RowIndex].Cells[0].Text)));
            File.Delete(deleteFilePath);
        }
        private string loadImagePath(int id)
        {
            string imgPath = null;
            string conStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(conStr);
            string query = "select Store_ID, Store_Image from StoreAddress where Store_ID =" + id + " ";

            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    imgPath = reader["Store_Image"].ToString();
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
            return imgPath;
        }
    }
}