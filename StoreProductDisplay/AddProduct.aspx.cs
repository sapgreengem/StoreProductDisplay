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
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategory();
                if (Session["login"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        private void LoadCategory()
        {
            string conStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(conStr);
            string query = "select Category_ID, Category_Name from ProductCategory";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DropDownListProductCategory.DataTextField = "Category_Name";
                DropDownListProductCategory.DataValueField = "Category_ID";
                DropDownListProductCategory.DataSource = reader;
                DropDownListProductCategory.DataBind();
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

        protected void BtnAddProduct_Click(object sender, EventArgs e)
        {
            string productSize = "";
            for (int i = 0; i < CheckBoxListProductSize.Items.Count; i++)
            {
                if (CheckBoxListProductSize.Items[i].Selected == true)
                {
                    productSize += CheckBoxListProductSize.Items[i].Text + ", ";
                }
            }
            if (productSize != string.Empty)
            {
                productSize = productSize.Substring(0, productSize.Length - 2);
            }

            HttpPostedFile postedFile = FileUploadImage.PostedFile;
            string fileName = Path.GetFileName(postedFile.FileName);
            string fileExtention = Path.GetExtension(fileName);
            int fileSize = postedFile.ContentLength;

            if (fileExtention == ".jpg" || fileExtention == ".png" || fileExtention == ".gif" || fileExtention == ".bmp" || fileExtention == ".JPG" || fileExtention == ".PNG" || fileExtention == ".GIF" || fileExtention == ".BMP")
            {
                string filepath = Server.MapPath("~/uploads");
                if (FileUploadImage.HasFile)
                {
                    FileUploadImage.SaveAs(filepath + "\\" + FileUploadImage.FileName);
                }

                string conStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection conn = new SqlConnection(conStr);
                string query = "INSERT INTO ProductDetails VALUES (" + TextBoxProductId.Text + ",'" + TextBoxProductName.Text + "','" + TextBoxProductCode.Text + "'," + DropDownListProductCategory.SelectedValue + ",'" + productSize + "','" + TextBoxProductColor.Text + "','" + TextBoxProductPrice.Text + "','" + "uploads/" + fileName + "','"+DateTime.Now+"')";
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('New Product Added')", true);
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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Select an Image File')", true);
        }
    }
}