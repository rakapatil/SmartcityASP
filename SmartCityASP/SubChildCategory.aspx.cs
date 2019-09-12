using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SmartCityASP.App_Code.BAL;
using System.IO;
using SmartCityASP.App_Code.DAL;

namespace SmartCityASP
{
    public partial class SubChildCategory : System.Web.UI.Page
    {
        SubChildCategoryBAL objSubC = new SubChildCategoryBAL();
        DataSet ds = new DataSet();
        int result = 0;
        CommonCode commonCode = new CommonCode();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblGCId.Text = "Sub ChildCategoryID : " + objSubC.GetMaxId();
                BindGridView();
                BindGrandCategory();
            }
        }

        public void BindGridView()
        {
            try
            {
                DataSet ds = objSubC.GetCCDetails();
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

        public void BindGrandCategory()
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

        public void BindParentCategory(int grandCategoryId)
        {
            ChildCategoryBAL objCCBAL = new ChildCategoryBAL();
            DataSet dsParent = objCCBAL.GetParentCategoryByGrand(grandCategoryId);

            ddlParentCategory.DataSource = dsParent.Tables[0];
            ddlParentCategory.DataValueField = "PK_ID";
            ddlParentCategory.DataTextField = "PName";
            ddlParentCategory.DataBind();
            ddlParentCategory.Items.Insert(0, new ListItem("Select", ""));
            ddlParentCategory.SelectedIndex = 0;
        }

        public void BindChildCategory(int parentCategory)
        {
            RegisterShopBAL objregshop = new RegisterShopBAL();
            DataSet dsChild = objregshop.GetCCDetailsbyParentId(parentCategory);

            ddlChildCategory.DataSource = dsChild.Tables[0];
            ddlChildCategory.DataValueField = "PK_ID";
            ddlChildCategory.DataTextField = "CName";
            ddlChildCategory.DataBind();
            ddlChildCategory.Items.Insert(0, new ListItem("Select", ""));
            ddlChildCategory.SelectedIndex = 0;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                objSubC.CName_E = txtCName_E.Text.Trim();
                objSubC.CName_M = txtCName_M.Text.Trim();

                string[] splitId = lblGCId.Text.Split(':');

                objSubC.PK_ID = Convert.ToInt32(splitId[1].Trim());
                objSubC.CFK_ID = Convert.ToInt32(ddlChildCategory.SelectedValue);
                objSubC.PFK_ID = Convert.ToInt32(ddlParentCategory.SelectedValue);
                objSubC.GFK_ID = Convert.ToInt32(ddlGrandCategory.SelectedValue);
                objSubC.IsCall = Convert.ToInt32(rdbContactOnly.SelectedValue);

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
                            string path = Path.Combine(Server.MapPath("~/Images/SubChildCategory"), fileName);
                            ImageUploadControl.SaveAs(path);

                            objSubC.ImageName = fileName;
                            objSubC.ImagePath = commonCode.WebsiteBaseUrl + @"/Images/SubChildCategory/" + fileName;
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Image should be proper extension..!!!');", true);
                        objSubC.ImageName = "0";
                        objSubC.ImagePath = "0";
                    }
                }
                else
                {
                    objSubC.ImageName = "0";
                    objSubC.ImagePath = "0";
                }

                if (btnSubmit.Text == "Submit")
                    result = objSubC.InsertChildCategory(objSubC);
                else
                    result = objSubC.UpdateChildCategory(objSubC);

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
                lblGCId.Text = "Sub ChildCategoryID : " + objSubC.GetMaxId();
                txtCName_E.Text = "";
                txtCName_M.Text = "";
                ddlGrandCategory.SelectedValue = "0";
                ddlParentCategory.SelectedValue = "0";
                ddlChildCategory.SelectedValue = "0";
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
                DataSet dset = objSubC.GetCCDetails(IdValue);
                if (dset.Tables[0].Rows.Count > 0)
                {
                    lblGCId.Text = "Sub ChildCategoryID : " + dset.Tables[0].Rows[0]["PK_ID"].ToString();
                    txtCName_E.Text = dset.Tables[0].Rows[0]["SCName_E"].ToString();
                    txtCName_M.Text = dset.Tables[0].Rows[0]["SCName_M"].ToString();
                    BindGrandCategory();
                    ddlGrandCategory.SelectedValue = dset.Tables[0].Rows[0]["GFK_ID"].ToString();

                    BindParentCategory(Convert.ToInt32(dset.Tables[0].Rows[0]["GFK_ID"].ToString()));
                    ddlParentCategory.SelectedValue = dset.Tables[0].Rows[0]["PFK_ID"].ToString();

                    BindChildCategory(Convert.ToInt32(dset.Tables[0].Rows[0]["PFK_ID"].ToString()));
                    ddlChildCategory.SelectedValue = dset.Tables[0].Rows[0]["CFK_ID"].ToString();

                    rdbContactOnly.SelectedValue = dset.Tables[0].Rows[0]["IsCall"].ToString();
                }
            }
            else
            {
                result = objSubC.DeleteCCategory(IdValue);
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

        protected void ddlParentCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindChildCategory(Convert.ToInt32(ddlParentCategory.SelectedValue));
        }

        protected void ddlGrandCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindParentCategory(Convert.ToInt32(ddlGrandCategory.SelectedValue));
        }
    }
}