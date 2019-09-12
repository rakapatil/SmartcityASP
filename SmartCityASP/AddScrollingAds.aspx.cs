using SmartCityASP.App_Code.BAL;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartCityASP
{
    public partial class AddScrollingAds : System.Web.UI.Page
    {
        ScrollingAdsBAL objScroll = new ScrollingAdsBAL();
        DataSet ds = new DataSet();
        int result = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblRegId.Text = "Unique ID : " + objScroll.GetMaxId();
                BindGridView();
            }
        }

        public void BindGridView()
        {
            try
            {
                DataSet ds = objScroll.GetScrollAdsDetails();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvScrollingAds.DataSource = ds.Tables[0];
                    gvScrollingAds.DataBind();
                }
                else
                {
                    gvScrollingAds.EmptyDataText = "NO RECORD FOUND..!!!";
                    gvScrollingAds.DataBind();
                }
            }
            catch
            {
                gvScrollingAds.EmptyDataText = "ERROR FOUND..!!!";
                gvScrollingAds.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string[] splitId = lblRegId.Text.Split(':');

                objScroll.ScrollAdId = Convert.ToInt32(splitId[1].Trim());
                objScroll.AdDescription = txtAdDescription.Text;

                if (btnSubmit.Text == "Submit")
                    result = objScroll.InsertScrollAds(objScroll);
                else
                    result = objScroll.UpdateScrollAds(objScroll);

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

        public void Clear()
        {
            try
            {
                lblRegId.Text = "Unique ID : " + objScroll.GetMaxId();
                txtAdDescription.Text = "";
            }
            catch
            {
            }
        }

        protected void gvScrollingAds_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int IdValue = Convert.ToInt32(e.CommandArgument);
            string commandName = Convert.ToString(e.CommandName);
            btnSubmit.Text = "Update";
            if (commandName == "EditRow")
            {
                DataSet dset = objScroll.GetScrollAdsDetails(IdValue);
                if (dset.Tables[0].Rows.Count > 0)
                {
                    lblRegId.Text = "Unique ID : " + dset.Tables[0].Rows[0]["PK_ScrollAdsId"].ToString();
                    txtAdDescription.Text = dset.Tables[0].Rows[0]["Description"].ToString();
                }
            }
            else
            {
                result = objScroll.DeleteAds(IdValue);
                if (result != 0)
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Record Deleted Successfully..!!!');", true);
                else
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Record Not Deleted..!!!');", true);
            }
        }

        protected void gvScrollingAds_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvScrollingAds.PageIndex = e.NewPageIndex;
            BindGridView();
        }
    }
}