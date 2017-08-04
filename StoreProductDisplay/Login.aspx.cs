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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["login"] != null)
            {
                Response.Redirect("Adminhome.aspx");
            }
        }

        protected void LoginLog()
        {
            string conStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(conStr);
            string query = " UPDATE AdminInfo SET Last_Login= '"+DateTime.Now+ "' WHERE Email='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'  ";
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
        protected void CheckAdmin()
        {
            if (string.IsNullOrWhiteSpace(TextBox1.Text) || string.IsNullOrWhiteSpace(TextBox2.Text))
            {
                Label3.Text = "Please Provide Email and Password";
                Label3.Visible = true;
                //Response.Write("Please Provide Email and Password");
            }
            else
            {
                string conStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection conn = new SqlConnection(conStr);
                string query = " select * from AdminInfo where Email='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "' ";
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        this.LoginLog();
                        Session["login"] = reader["Email"];
                        Response.Redirect("Adminhome.aspx");
                    }
                    else
                    {
                        Label3.Text = "Email or Password did not Match";
                        Label3.Visible = true;
                        //Response.Write("Email or Password did not Match");
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
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            this.CheckAdmin();
        }
    }
}