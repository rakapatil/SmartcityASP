using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SmartCityASP.App_Code.BAL;
using System.IO;

namespace SmartCityASP
{
    public partial class TextNewsDescription : System.Web.UI.Page
    {
        TextNewsBAL objTextNews = new TextNewsBAL();
        DataSet ds = new DataSet();
        int result = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblRegId.Text = "News ID : " + objTextNews.GetMaxId();
                BindGridView();
                BindChannels();
            }
        }

        public void BindGridView()
        {
            try
            {
                DataSet dsGrid = objTextNews.GetNewsDetails();
                if (dsGrid.Tables[0].Rows.Count > 0)
                {
                    gvPCDetails.DataSource = dsGrid.Tables[0];
                    gvPCDetails.DataBind();
                }
                else
                {
                    gvPCDetails.EmptyDataText = "NO RECORD FOUND..!!!";
                    gvPCDetails.DataBind();
                }
            }
            catch
            {
                gvPCDetails.EmptyDataText = "ERROR FOUND..!!!";
                gvPCDetails.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                objTextNews.NewsHeading = txtNewsHeading.Text.Trim();
                objTextNews.NewsDetails = txtDescription.Text.Trim();
                objTextNews.InsertBy = Session["MobileNumber"].ToString();
                objTextNews.NewsDate = ddlDay.SelectedItem.Text + "-" + ddlMonth.SelectedItem.Text + "-" + ddlYear.SelectedItem.Text;
                objTextNews.NewsSourceId = Convert.ToInt32(ddlChannels.SelectedValue);
                objTextNews.NewsSourceName = ddlChannels.SelectedItem.Text;

                string[] splitId = lblRegId.Text.Split(':');

                objTextNews.NewsId = Convert.ToInt32(splitId[1].Trim());

                if (btnSubmit.Text == "Submit")
                    result = objTextNews.InsertTextNewsDetails(objTextNews);
                else
                    result = objTextNews.UpdateTextNewsDetails(objTextNews);

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
                lblRegId.Text = "News ID : " + objTextNews.GetMaxId();
                txtDescription.Text = "";
                txtNewsHeading.Text = "";
                ddlChannels.SelectedValue = "0";
               // txtNewsDate.Text = "";
            }
            catch
            {
            }
        }

        public void BindChannels()
        {
            VideoNewsBAL objGCBAL = new VideoNewsBAL();
            ds = objGCBAL.GetChannels();

            ddlChannels.DataSource = ds.Tables[0];
            ddlChannels.DataValueField = "FieldItemId";
            ddlChannels.DataTextField = "FieldName";
            ddlChannels.DataBind();
            ddlChannels.Items.Insert(0, new ListItem("Select", ""));
            ddlChannels.SelectedIndex = 0;
        }

        protected void gvPCDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int IdValue = Convert.ToInt32(e.CommandArgument);
            string commandName = Convert.ToString(e.CommandName);
            btnSubmit.Text = "Update";
            if (commandName == "EditRow")
            {
                DataSet dset = objTextNews.GetNewsDetails(IdValue);
                if (dset.Tables[0].Rows.Count > 0)
                {
                    lblRegId.Text = "News ID : " + dset.Tables[0].Rows[0]["NewsId"].ToString();
                    txtNewsHeading.Text = dset.Tables[0].Rows[0]["NewsHeading"].ToString();
                    txtDescription.Text = dset.Tables[0].Rows[0]["NewsDetails"].ToString();

                    string[] dateValue = (dset.Tables[0].Rows[0]["NewsDate"].ToString()).Split('-');
                    ddlDay.SelectedItem.Text = dateValue[0];
                    ddlMonth.SelectedItem.Text = dateValue[1];
                    ddlYear.SelectedItem.Text = dateValue[2];

                    BindChannels();
                    ddlChannels.SelectedValue = dset.Tables[0].Rows[0]["NewsSourceId"].ToString();
                }
            }
            else
            {
                result = objTextNews.DeletePCategory(IdValue);
                BindGridView();

                if (result != 0)
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Record Deleted Successfully..!!!');", true);
                else
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Record Not Deleted..!!!');", true);

            }
        }

        protected void gvPCDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPCDetails.PageIndex = e.NewPageIndex;
            BindGridView();
        }

        protected void ddlChannels_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}