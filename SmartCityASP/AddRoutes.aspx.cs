using SmartCityASP.App_Code.BAL;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartCityASP
{
    public partial class AddRoutes : System.Web.UI.Page
    {
        RoutesDetails objRoutes = new RoutesDetails();
        DataSet ds = new DataSet();
        int result = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblRegId.Text = "Route ID : " + objRoutes.GetMaxId();
                BindGridView();
            }
        }

        public void BindGridView()
        {
            try
            {
                DataSet dsGrid = objRoutes.GetRoutesDetails();
                if (dsGrid.Tables[0].Rows.Count > 0)
                {
                    gvRouteDetails.DataSource = dsGrid.Tables[0];
                    gvRouteDetails.DataBind();
                }
                else
                {
                    gvRouteDetails.EmptyDataText = "NO RECORD FOUND..!!!";
                    gvRouteDetails.DataBind();
                }
            }
            catch
            {
                gvRouteDetails.EmptyDataText = "ERROR FOUND..!!!";
                gvRouteDetails.DataBind();
            }
        }

        public void Clear()
        {
            try
            {
                lblRegId.Text = "Route ID : " + objRoutes.GetMaxId();
                txtDestinationE.Text = "";
                txtDestinationM.Text = "";
                txtSourceE.Text = "";
                txtSourceM.Text = "";
            }
            catch
            {
            }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                objRoutes.SourcePlace_E = txtSourceE.Text;
                objRoutes.SourcePlace_M = txtSourceM.Text;
                objRoutes.DestinationPlace_E = txtDestinationE.Text;
                objRoutes.DestinationPlace_M = txtDestinationM.Text;

                string[] splitId = lblRegId.Text.Split(':');

                objRoutes.RouteId = Convert.ToInt32(splitId[1].Trim());

                if (btnSubmit.Text == "Submit")
                    result = objRoutes.InsertRoutes(objRoutes);
                else
                    result = objRoutes.UpdateRoutes(objRoutes);

                if (result != 0)
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Record Added/Updated Successfully..!!!');", true);
                else
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Record Not Added/Updated..!!!');", true);

                btnSubmit.Text = "Submit";
                Clear();
                BindGridView();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Error :" + ex + "');", true);
            }
        }

        protected void gvRouteDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int IdValue = Convert.ToInt32(e.CommandArgument);
            string commandName = Convert.ToString(e.CommandName);
            btnSubmit.Text = "Update";
            if (commandName == "EditRow")
            {
                DataSet dset = objRoutes.GetRoutesDetails(IdValue);
                if (dset.Tables[0].Rows.Count > 0)
                {
                    lblRegId.Text = "Route ID : " + dset.Tables[0].Rows[0]["PK_RouteId"].ToString();
                    txtDestinationE.Text = dset.Tables[0].Rows[0]["DestinationPlace_E"].ToString();
                    txtDestinationM.Text = dset.Tables[0].Rows[0]["DestinationPlace_M"].ToString();
                    txtSourceM.Text = dset.Tables[0].Rows[0]["SourcePlace_M"].ToString();
                    txtSourceE.Text = dset.Tables[0].Rows[0]["SourcePlace_E"].ToString();
                }
            }
            else
            {
                result = objRoutes.DeleteRoute(IdValue);
                BindGridView();
                if (result != 0)
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Record Deleted Successfully..!!!');", true);
                else
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Record Not Deleted..!!!');", true);
            }
        }

        protected void gvRouteDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRouteDetails.PageIndex = e.NewPageIndex;
            BindGridView();
        }
    }
}