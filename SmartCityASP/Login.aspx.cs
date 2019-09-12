using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SmartCityASP.App_Code.BAL;

namespace SmartCityASP
{
    public partial class Login : System.Web.UI.Page
    {
        UserDetails objUser = new UserDetails();
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session.Clear();
                Session.Abandon();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                ds = objUser.GetUserDetails(txtUserName.Text, txtPassword.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["LoginId"] = ds.Tables[0].Rows[0]["PK_RegId"].ToString();
                    Session["Name_M"] = ds.Tables[0].Rows[0]["Name_M"].ToString();
                    Session["RoleId"] = ds.Tables[0].Rows[0]["RoleId"].ToString();
                    Session["RoleName"] = ds.Tables[0].Rows[0]["RoleName"].ToString();
                    Session["MobileNumber"] = ds.Tables[0].Rows[0]["MobileNumber"].ToString();

                    Response.Redirect("~/default.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Please Enter Valid UserName or Password..!!!');", true);
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Please Enter Valid UserName or Password...!!!');", true);
            }
        }
    }
}