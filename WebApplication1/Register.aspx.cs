using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string userno = txtUserNo.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(userno))
            {
                string script = "alert('Username and User No must not be empty!');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }else
            {
                Database db = new Database();
                try
                {
                    db.CreateRegister(username, userno);
                    string script = "alert('Data successfully insert!');";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);

                    txtUserName.Text = string.Empty;
                    txtUserNo.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    db.Disconnect();
                }
            }
        }
    }
}