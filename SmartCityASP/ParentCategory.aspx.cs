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
    public partial class ParentCategory : System.Web.UI.Page
    {
        ParentCategoryBAL objPCBAL = new ParentCategoryBAL();
        DataSet ds = new DataSet();
        int result = 0;
        CommonCode commonCode = new CommonCode();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblGCId.Text = "Parent CategoryID : " + objPCBAL.GetMaxId();
                BindGridView();
                BindDDLGrandCategory();
            }
        }

        public void BindGridView()
        {
            try
            {
                DataSet dsGrid = objPCBAL.GetPCDetails();
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
                lblGCId.Text = "Parent CategoryID : " + objPCBAL.GetMaxId();
                txtPName_E.Text = "";
                txtPName_M.Text = "";
                ddlGrandCategory.SelectedValue = "0";
            }
            catch
            {
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                objPCBAL.PName_E = txtPName_E.Text.Trim();
                objPCBAL.PName_M = txtPName_M.Text.Trim();

                string[] splitId = lblGCId.Text.Split(':');

                objPCBAL.PK_ID = Convert.ToInt32(splitId[1].Trim());
                objPCBAL.GFK_ID = Convert.ToInt32(ddlGrandCategory.SelectedValue);

                if (ImageUpload.HasFile)
                {
                    var allowedExtensions = new[] {
                                ".Jpg", ".png", ".jpg", ".jpeg",".Png",".PNG",".JPEG",".JPG"
                                  };
                    var ext = Path.GetExtension(ImageUpload.FileName);
                    int fileSize = ImageUpload.PostedFile.ContentLength;

                    if (allowedExtensions.Contains(ext)) //check what type of extension  
                    {
                        if (fileSize > 1048576)
                        {
                            ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Image Size Not More than 1 MB..!!!');", true);
                        }
                        else
                        {
                            string fileName = Path.GetFileName(ImageUpload.FileName);
                            string path = Path.Combine(Server.MapPath("~/Images/ParentCategory"), fileName);
                            ImageUpload.SaveAs(path);

                            objPCBAL.ImageName = fileName;
                            objPCBAL.ImagePath = commonCode.WebsiteBaseUrl + @"/Images/ParentCategory/" + fileName;
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Image should be proper extension..!!!');", true);
                        objPCBAL.ImageName = string.Empty;
                        objPCBAL.ImagePath = string.Empty;
                    }
                }
                else
                {
                    objPCBAL.ImageName = string.Empty;
                    objPCBAL.ImagePath = string.Empty;
                }

                if (btnSubmit.Text == "Submit")
                    result = objPCBAL.InsertParentCategory(objPCBAL);
                else
                {
                    if (string.IsNullOrEmpty(objPCBAL.ImageName))
                        objPCBAL.ImageName = hdnImageName.Value;

                    result = objPCBAL.UpdateParentCategory(objPCBAL);
                }

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

        protected void gvPCDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int IdValue = Convert.ToInt32(e.CommandArgument);
            string commandName = Convert.ToString(e.CommandName);
            btnSubmit.Text = "Update";
            if (commandName == "EditRow")
            {
                DataSet dset = objPCBAL.GetPCDetails(IdValue);
                if (dset.Tables[0].Rows.Count > 0)
                {
                    lblGCId.Text = "Parent CategoryID : " + dset.Tables[0].Rows[0]["PK_ID"].ToString();
                    txtPName_E.Text = dset.Tables[0].Rows[0]["PName_E"].ToString();
                    txtPName_M.Text = dset.Tables[0].Rows[0]["PName_M"].ToString();
                    hdnImageName.Value = dset.Tables[0].Rows[0]["ImageName"].ToString();

                    BindDDLGrandCategory();
                    ddlGrandCategory.SelectedValue = dset.Tables[0].Rows[0]["GFK_ID"].ToString();
                }
            }
            else
            {
                result = objPCBAL.DeletePCategory(IdValue);
                if (result != 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Record Deleted Successfully..!!!');", true);
                    BindGridView();
                }
                else
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Record Not Deleted..!!!');", true);

            }
        }

        protected void gvPCDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPCDetails.PageIndex = e.NewPageIndex;
            BindGridView();
        }
    }
}