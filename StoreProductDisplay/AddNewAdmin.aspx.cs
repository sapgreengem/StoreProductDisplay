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
    public partial class AddNewAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }
        protected void ButtonAddAdmin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxAdminName.Text) || string.IsNullOrWhiteSpace(TextBoxEmail.Text) || string.IsNullOrWhiteSpace(TextBoxPassword.Text) || string.IsNullOrWhiteSpace(TextBoxConfirmPassword.Text))
            {
                Label5.Text = "Please Fill All Fields";
                Label5.Visible = true;
            }
            else
            {
                if (Page.IsValid)
                {
                    string conStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                    SqlConnection conn = new SqlConnection(conStr);
                    string query = "INSERT INTO AdminInfo (User_Name, Email,Password) VALUES ('" + TextBoxAdminName.Text + "','" + TextBoxEmail.Text + "','" + TextBoxConfirmPassword.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('New Admin Added')", true);
                    }
                    catch (Exception exc)
                    {
                        Response.Write(exc.ToString());
                    }
                    finally
                    {
                        conn.Close();
                    }
                    Response.Redirect("AddNewAdmin.aspx");
                }
            }
        }
    }
}