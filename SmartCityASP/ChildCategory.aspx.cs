using SmartCityASP.App_Code.BAL;
using SmartCityASP.App_Code.DAL;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartCityASP
{
    public partial class ChildCategory : System.Web.UI.Page
    {
        ChildCategoryBAL objCCBAL = new ChildCategoryBAL();
        DataSet ds = new DataSet();
        int result = 0;
        CommonCode commonCode = new CommonCode();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblGCId.Text = "Child CategoryID : " + objCCBAL.GetMaxId();
                BindGridView();
                BindDDLGrandCategory();
            }
        }

        public void BindGridView()
        {
            try
            {
                DataSet ds = objCCBAL.GetCCDetails();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvCCDetails.DataSource = ds.Tables[0];
                    gvCCDetails.DataBind();
                }
                else
                {
                    gvCCDetails.EmptyDataText = "NO RECORD FOUND..!!!";
                    gvCCDetails.DataBind();
                }
            }
            catch
            {
                gvCCDetails.EmptyDataText = "ERROR FOUND..!!!";
                gvCCDetails.DataBind();
            }
        }

        public void BindDDLGrandCategory()
        {
            GrandCategoryBAL objGCBAL = new GrandCategoryBAL();
            ds = objGCBAL.BindGrandCDetails();

            ddlGrandCategory.DataSource = ds.Tables[0];
            ddlGrandCategory.DataValueField = "PK_ID";
            ddlGrandCategory.DataTextField = "GName";
            ddlGrandCategory.DataBind();
            ddlGrandCategory.Items.Insert(0, new ListItem("Select", ""));
            ddlGrandCategory.SelectedIndex = 0;
        }

        public void Clear()
        {
            try
            {
                lblGCId.Text = "Child CategoryID : " + objCCBAL.GetMaxId();
                txtCName_E.Text = "";
                txtCName_M.Text = "";
                ddlGrandCategory.SelectedValue = "0";
                ddlParentCategory.SelectedValue = "0";
            }
            catch
            {
            }
        }

        protected void gvCCDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int IdValue = Convert.ToInt32(e.CommandArgument);
            string commandName = Convert.ToString(e.CommandName);
            btnSubmit.Text = "Update";
            if (commandName == "EditRow")
            {
                DataSet dset = objCCBAL.GetCCDetails(IdValue);
                if (dset.Tables[0].Rows.Count > 0)
                {
                    lblGCId.Text = "Child CategoryID : " + dset.Tables[0].Rows[0]["PK_ID"].ToString();
                    txtCName_E.Text = dset.Tables[0].Rows[0]["CName_E"].ToString();
                    txtCName_M.Text = dset.Tables[0].Rows[0]["CName_M"].ToString();

                    BindDDLGrandCategory();
                    ddlGrandCategory.SelectedValue = dset.Tables[0].Rows[0]["GFK_ID"].ToString();

                    BindParentCategory(Convert.ToInt32(dset.Tables[0].Rows[0]["GFK_ID"].ToString()));
                    ddlParentCategory.SelectedValue = dset.Tables[0].Rows[0]["PFK_ID"].ToString();

                    rdbContactOnly.SelectedValue = dset.Tables[0].Rows[0]["IsCall"].ToString();
                    rdoHasSubCategory.SelectedValue = dset.Tables[0].Rows[0]["IsSubCategory"].ToString();
                }
            }
            else
            {
                result = objCCBAL.DeleteCCategory(IdValue);
                if (result != 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Record Deleted Successfully..!!!');", true);
                    BindGridView();
                }
                else
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Record Not Deleted..!!!');", true);
            }
        }

        protected void gvCCDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCCDetails.PageIndex = e.NewPageIndex;
            BindGridView();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                objCCBAL.CName_E = txtCName_E.Text.Trim();
                objCCBAL.CName_M = txtCName_M.Text.Trim();

                string[] splitId = lblGCId.Text.Split(':');

                objCCBAL.PK_ID = Convert.ToInt32(splitId[1].Trim());
                objCCBAL.PFK_ID = Convert.ToInt32(ddlParentCategory.SelectedValue);
                objCCBAL.GFK_ID = Convert.ToInt32(ddlGrandCategory.SelectedValue);
                objCCBAL.IsCall = Convert.ToInt32(rdbContactOnly.SelectedValue);
                objCCBAL.IsSubCategory = Convert.ToInt32(rdoHasSubCategory.SelectedValue);

                if (ImageUploadControl.HasFile)
                {
                    var allowedExtensions = new[] {
            ".Jpg", ".png", ".jpg", ".jpeg",".Png",".PNG",".JPEG",".JPG"
        };
                    var ext = Path.GetExtension(ImageUploadControl.FileName);
                    int fileSize = ImageUploadControl.PostedFile.ContentLength;

                    if (allowedExtensions.Contains(ext)) //check what type of extension  
                    {
                        if (fileSize > 1048576)
                        {
                            ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Image Size Not More than 1 MB..!!!');", true);
                        }
                        else
                        {
                            string fileName = Path.GetFileName(ImageUploadControl.FileName);
                            string path = Path.Combine(Server.MapPath("~/Images/ChildCategory"), fileName);
                            ImageUploadControl.SaveAs(path);

                            objCCBAL.ImageName = fileName;
                            objCCBAL.ImagePath = commonCode.WebsiteBaseUrl + @"/Images/ChildCategory/" + fileName;
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Image should be proper extension..!!!');", true);
                        objCCBAL.ImageName = "0";
                        objCCBAL.ImagePath = "0";
                    }
                }
                else
                {
                    objCCBAL.ImageName = "0";
                    objCCBAL.ImagePath = "0";
                }

                if (btnSubmit.Text == "Submit")
                    result = objCCBAL.InsertChildCategory(objCCBAL);
                else
                    result = objCCBAL.UpdateChildCategory(objCCBAL);

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

        public void BindParentCategory(int grandCategoryId)
        {
            ChildCategoryBAL objCCBAL = new ChildCategoryBAL();
            DataSet dsChild = objCCBAL.GetParentCategoryByGrand(grandCategoryId);

            ddlParentCategory.DataSource = dsChild.Tables[0];
            ddlParentCategory.DataValueField = "PK_ID";
            ddlParentCategory.DataTextField = "PName";
            ddlParentCategory.DataBind();
            ddlParentCategory.Items.Insert(0, new ListItem("Select", ""));
            ddlParentCategory.SelectedIndex = 0;
        }

        protected void ddlGrandCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindParentCategory(Convert.ToInt32(ddlGrandCategory.SelectedValue));
        }
    }
}