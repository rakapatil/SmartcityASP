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
    public partial class AddFieldItem : System.Web.UI.Page
    {
        FieldItemBAL objGCBAL = new FieldItemBAL();
        DataSet ds = new DataSet();
        int result = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblGCId.Text = "Field ID : " + objGCBAL.GetMaxId();
                BindGridView();
            }
        }

        public void BindGridView()
        {
            try
            {
                DataSet ds = objGCBAL.GetGCDetails();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvGCDetails.DataSource = ds.Tables[0];
                    gvGCDetails.DataBind();
                }
                else
                {
                    gvGCDetails.EmptyDataText = "NO RECORD FOUND..!!!";
                    gvGCDetails.DataBind();
                }
            }
            catch
            {
                gvGCDetails.EmptyDataText = "ERROR FOUND..!!!";
                gvGCDetails.DataBind();
            }
        }

        public void Clear()
        {
            try
            {
                lblGCId.Text = "Field ID : " + objGCBAL.GetMaxId();
                txtGName_E.Text = "";
                txtGName_M.Text = "";
            }
            catch
            {
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                objGCBAL.GName_E = txtGName_E.Text.Trim();
                objGCBAL.GName_M = txtGName_M.Text.Trim();
                string[] splitId = lblGCId.Text.Split(':');

                objGCBAL.PK_ID = Convert.ToInt32(splitId[1].Trim());

                if (btnSubmit.Text == "Submit")
                    result = objGCBAL.InsertGrandCategory(objGCBAL);
                else
                    result = objGCBAL.UpdateGrandCategory(objGCBAL);

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

        protected void gvGCDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int IdValue = Convert.ToInt32(e.CommandArgument);
            string commandName = Convert.ToString(e.CommandName);
            btnSubmit.Text = "Update";
            if (commandName == "EditRow")
            {
                ds = objGCBAL.GetGCDetails(IdValue);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblGCId.Text = "Field ID : " + ds.Tables[0].Rows[0]["FieldId"].ToString();
                    txtGName_E.Text = ds.Tables[0].Rows[0]["FieldName_E"].ToString();
                    txtGName_M.Text = ds.Tables[0].Rows[0]["FieldName_M"].ToString();
                }
            }
            else
            {
                result = objGCBAL.DeleteGCategory(IdValue);
                if (result != 0)
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Record Deleted Successfully..!!!');", true);
                else
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Record Not Deleted..!!!');", true);
                BindGridView();
            }
        }

        protected void gvGCDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGCDetails.PageIndex = e.NewPageIndex;
            BindGridView();
        }
    }
}