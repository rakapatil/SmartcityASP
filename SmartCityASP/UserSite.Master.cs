using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartCityASP
{
    public partial class UserSite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    if (Session["LoginId"].ToString() != null || Session["LoginId"].ToString() != "")
                    {
                        lblName1.Text = Session["Name_M"].ToString();
                        lblName2.Text = Session["Name_M"].ToString();
                        lblName3.Text = Session["Name_M"].ToString();
                    }
                    else
                    {
                        Response.Redirect("~/Login.aspx");
                    }
                }
                catch
                { Response.Redirect("~/Login.aspx"); }
            }
        }
    }
}