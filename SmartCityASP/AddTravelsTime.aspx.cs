using SmartCityASP.App_Code.BAL;
using SmartCityASP.App_Code.DAL;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartCityASP
{
    public partial class AddTravelsTime : System.Web.UI.Page
    {
        TravelsTimeTable objTravel = new TravelsTimeTable();
        DataSet ds = new DataSet();
        int result = 0;
        CommonCode commonCode = new CommonCode();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!Page.IsPostBack)
                {
                    lblTimeTable.Text = "Travel TimeTable ID : " + objTravel.GetMaxId();
                    BindGridView();
                    BindRouteDDL();
                }
            }
        }

        public void BindGridView()
        {
            try
            {
                DataSet dsGrid = objTravel.GetTravelsDetails();
                if (dsGrid.Tables[0].Rows.Count > 0)
                {
                    gvTravelsDetails.DataSource = dsGrid.Tables[0];
                    gvTravelsDetails.DataBind();
                }
                else
                {
                    gvTravelsDetails.EmptyDataText = "NO RECORD FOUND..!!!";
                    gvTravelsDetails.DataBind();
                }
            }
            catch
            {
                gvTravelsDetails.EmptyDataText = "ERROR FOUND..!!!";
                gvTravelsDetails.DataBind();
            }
        }

        public void BindRouteDDL()
        {
            RoutesDetails objRoute = new RoutesDetails();
            ds = objRoute.GetRoutesDetails();

            ddlRoute.DataSource = ds.Tables[0];
            ddlRoute.DataValueField = "PK_RouteId";
            ddlRoute.DataTextField = "DestinationPlace_M";
            ddlRoute.DataBind();
            ddlRoute.Items.Insert(0, new ListItem("Select", ""));
            ddlRoute.SelectedIndex = 0;
        }

        public void Clear()
        {
            try
            {
                lblTimeTable.Text = "Travel TimeTable ID : " + objTravel.GetMaxId();
                txtTime.Text = "";
                txtTravelDesc.Text = "";
                ddlRoute.SelectedValue = "0";
                ddlPahar.SelectedValue = "0";
            }
            catch
            {
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                objTravel.DayPaharId = Convert.ToInt32(ddlPahar.SelectedValue);
                objTravel.DayPaharName = ddlPahar.SelectedItem.Text;
                objTravel.BusInformation = txtTravelDesc.Text;
                objTravel.Time = txtTime.Text;

                string[] splitId = lblTimeTable.Text.Split(':');

                objTravel.TravelsId = Convert.ToInt32(splitId[1].Trim());
                objTravel.RouteId = Convert.ToInt32(ddlRoute.SelectedValue);

                if (btnSubmit.Text == "Submit")
                    result = objTravel.InsertTravelTime(objTravel);
                else
                    result = objTravel.UpdateTravelTime(objTravel);

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

        protected void gvTravelsDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int IdValue = Convert.ToInt32(e.CommandArgument);
            string commandName = Convert.ToString(e.CommandName);
            btnSubmit.Text = "Update";
            if (commandName == "EditRow")
            {
                DataSet dset = objTravel.GetTravelsDetails(IdValue);
                if (dset.Tables[0].Rows.Count > 0)
                {
                    lblTimeTable.Text = "Travel TimeTable ID : " + dset.Tables[0].Rows[0]["PK_TravelId"].ToString();
                    txtTime.Text = dset.Tables[0].Rows[0]["Time"].ToString();
                    txtTravelDesc.Text = dset.Tables[0].Rows[0]["Description"].ToString();
                    BindRouteDDL();
                    ddlRoute.SelectedValue = dset.Tables[0].Rows[0]["FK_RouteId"].ToString();
                    ddlPahar.SelectedValue = dset.Tables[0].Rows[0]["DayPaharId"].ToString();
                }
            }
            else
            {
                result = objTravel.DeleteTravelsTime(IdValue);
                BindGridView();
                if (result != 0)
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Record Deleted Successfully..!!!');", true);
                else
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Record Not Deleted..!!!');", true);
            }
        }

        protected void gvTravelsDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTravelsDetails.PageIndex = e.NewPageIndex;
            BindGridView();
        }
    }
}