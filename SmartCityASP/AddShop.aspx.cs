using SmartCityASP.App_Code.BAL;
using SmartCityASP.App_Code.DAL;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartCityASP
{
    public partial class AddShop : System.Web.UI.Page
    {
        RegisterShopBAL objRegshopBAL = new RegisterShopBAL();
        DataSet ds = new DataSet();
        int result = 0;
        CommonCode commonCode = new CommonCode();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblShopId.Text = "Register Shop ID : " + objRegshopBAL.GetMaxId();
                lblShopId1.Text = "Register Shop ID : " + objRegshopBAL.GetMaxId();
                BindGrandCategory();
                MultiView1.ActiveViewIndex = 1;
                BindGridView("NA");
                BindNearBy();
            }
        }

        public void BindGridView(string value)
        {
            try
            {
                DataSet ds = new DataSet();
                if (value == "NA")
                    ds = objRegshopBAL.GetShopsDetails();
                else
                    ds = objRegshopBAL.GetShopsDetails(value);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvShopDetails.DataSource = ds.Tables[0];
                    gvShopDetails.DataBind();
                }
                else
                {
                    gvShopDetails.EmptyDataText = "NO RECORD FOUND..!!!";
                    gvShopDetails.DataBind();
                }
            }
            catch
            {
                gvShopDetails.EmptyDataText = "ERROR FOUND..!!!";
                gvShopDetails.DataBind();
            }
        }

        public void BindNearBy()
        {
            RegisterShopBAL objregshop = new RegisterShopBAL();
            DataSet dsNearby = objregshop.GetNearBy();

            ddlNearby.DataSource = dsNearby.Tables[0];
            ddlNearby.DataValueField = "FieldItemId";
            ddlNearby.DataTextField = "FieldItemName";
            ddlNearby.DataBind();
            ddlNearby.Items.Insert(0, new ListItem("Select", ""));
            ddlNearby.SelectedIndex = 0;
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

        public void BindSubChildCategory(int childCategoryId)
        {
            RegisterShopBAL objregshop = new RegisterShopBAL();
            DataSet dsChild = objregshop.GetSubChildCategory(childCategoryId);

            ddlSubChildCategory.DataSource = dsChild.Tables[0];
            ddlSubChildCategory.DataValueField = "PK_ID";
            ddlSubChildCategory.DataTextField = "SCName";
            ddlSubChildCategory.DataBind();
            ddlSubChildCategory.Items.Insert(0, new ListItem("Select", ""));
            ddlSubChildCategory.SelectedIndex = 0;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string[] splitId = lblShopId1.Text.Split(':');

                objRegshopBAL.PK_RegShopId = Convert.ToInt32(splitId[1].Trim());
                objRegshopBAL.PFK_ID = Convert.ToInt32(ddlParentCategory.SelectedValue);
                objRegshopBAL.GFK_ID = Convert.ToInt32(ddlGrandCategory.SelectedValue);
                objRegshopBAL.CFK_ID = Convert.ToInt32(ddlChildCategory.SelectedValue);

                if (ddlSubChildCategory.SelectedValue != "")
                    objRegshopBAL.SCFK_ID = Convert.ToInt32(ddlSubChildCategory.SelectedValue);
                else
                    objRegshopBAL.SCFK_ID = 0;

                if (rdbContactOnly.SelectedValue == "0")
                {
                    if (ddlNearby.SelectedValue == "0" || txtOwnerName_E.Text == "" || txtOwnerName_M.Text == "" || txtAddress.Text == "")
                    {
                        ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('All * Fields are Mandatory.');", true);
                    }
                    else
                    {
                        objRegshopBAL.AlternetMobileNumber = txtMobileNumberTwo.Text.Trim();
                        objRegshopBAL.CloseTime = txtClosetime.Text.Trim();
                        objRegshopBAL.Description = txtDescription.Text.Trim();
                        objRegshopBAL.DetailAddress = txtAddress.Text.Trim();
                        objRegshopBAL.EmailId = @"abc@gmail.com";
                        objRegshopBAL.ImeiNumber = "0";
                        objRegshopBAL.IpAddress = "0";
                        objRegshopBAL.LandlineNumber = txtTelephone.Text.Trim();
                        objRegshopBAL.LanguageId = 1;
                        objRegshopBAL.Lattitude = (decimal)(10.1234);
                        objRegshopBAL.Longitude = (decimal)(10.1234);
                        objRegshopBAL.MobileNumber = txtMobileNumberOne.Text.Trim();
                        objRegshopBAL.Name_E = txtOwnerName_E.Text.Trim();
                        objRegshopBAL.Name_M = txtOwnerName_M.Text.Trim();
                        objRegshopBAL.NearById = Convert.ToInt32(ddlNearby.SelectedValue);
                        objRegshopBAL.NearByName = ddlNearby.SelectedItem.Text;
                        objRegshopBAL.Offers = txtOffers.Text.Trim();
                        objRegshopBAL.OpenTime = txtOpentime.Text.Trim();
                        objRegshopBAL.PackageId = Convert.ToInt32(ddlPackage.SelectedValue);
                        objRegshopBAL.PackageName = ddlPackage.SelectedItem.Text;
                        objRegshopBAL.Pincode = "123456";
                        objRegshopBAL.RoleId = Convert.ToInt32(Session["RoleId"].ToString());
                        objRegshopBAL.RoleName = Session["RoleName"].ToString();
                        objRegshopBAL.ShopName_E = txtShopName_E.Text.Trim();
                        objRegshopBAL.ShopName_M = txtShopName_M.Text.Trim();
                        objRegshopBAL.WebSite = @"http://www.abc.com";
                        objRegshopBAL.IsCall = Convert.ToInt32(rdbContactOnly.SelectedValue);
                        //objRegshopBAL.SCFK_ID = Convert.ToInt32(ddlSubChildCategory.SelectedValue);
                        objRegshopBAL.IsPaid = Convert.ToInt32(rdbIsPaid.SelectedValue);

                        if (ImageFileUpload.HasFile)
                        {
                            foreach (HttpPostedFile postedFile in ImageFileUpload.PostedFiles)
                            {
                                string fileName = Path.GetFileName(postedFile.FileName);

                                var allowedExtensions = new[] {
            ".Jpg", ".png", ".jpg", ".jpeg",".Png",".PNG",".JPEG",".JPG"
        };
                                var ext = Path.GetExtension(postedFile.FileName);
                                int fileSize = ImageFileUpload.PostedFile.ContentLength;

                                if (allowedExtensions.Contains(ext))
                                {
                                    if (fileSize > 1048576)
                                    {
                                        ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Image Size Not More than 1 MB..!!!');", true);
                                    }
                                    else
                                    {
                                        string path = Path.Combine(Server.MapPath("~/Images/ShopImages"), fileName);
                                        postedFile.SaveAs(path);

                                        objRegshopBAL.ImageName += fileName + ",";
                                        objRegshopBAL.ImagePath = commonCode.WebsiteBaseUrl + @"/Images/ShopImages/";
                                    }
                                }
                                else
                                {
                                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Image should be proper extension..!!!');", true);
                                    objRegshopBAL.ImageName = string.Empty;
                                    objRegshopBAL.ImagePath = string.Empty;
                                }
                            }
                        }
                        else
                        {
                            objRegshopBAL.ImageName = string.Empty;
                            objRegshopBAL.ImagePath = string.Empty;
                        }

                        if (btnSubmit.Text == "Submit")
                            result = objRegshopBAL.InsertShopDetails(objRegshopBAL);
                        else
                        {
                            if (string.IsNullOrEmpty(objRegshopBAL.ImageName))
                                objRegshopBAL.ImageName = hdnImageName.Value;
                            result = objRegshopBAL.UpdateShopDetails(objRegshopBAL);
                        }
                        if (result != 0)
                            ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Record Added/Updated Successfully..!!!');", true);
                        else
                            ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Record Not Added/Updated..!!!');", true);

                        btnSubmit.Text = "Submit";
                        Clear();
                        BindGridView("NA");
                    }
                }
                else
                {
                    objRegshopBAL.AlternetMobileNumber = txtMobileNumberTwo.Text.Trim();
                    objRegshopBAL.CloseTime = txtClosetime.Text.Trim();
                    objRegshopBAL.Description = txtDescription.Text.Trim();
                    objRegshopBAL.DetailAddress = txtAddress.Text.Trim();
                    objRegshopBAL.EmailId = "abc@gmail.com";
                    objRegshopBAL.ImeiNumber = "0";
                    objRegshopBAL.IpAddress = "0";
                    objRegshopBAL.LandlineNumber = txtTelephone.Text.Trim();
                    objRegshopBAL.LanguageId = 1;
                    objRegshopBAL.Lattitude = (decimal)(10.1234);
                    objRegshopBAL.Longitude = (decimal)(10.1234);
                    objRegshopBAL.MobileNumber = txtMobileNumberOne.Text.Trim();
                    objRegshopBAL.Name_E = txtOwnerName_E.Text.Trim();
                    objRegshopBAL.Name_M = txtOwnerName_M.Text.Trim();
                    objRegshopBAL.NearById = 1;
                    objRegshopBAL.NearByName = "0";
                    objRegshopBAL.Offers = txtOffers.Text.Trim();
                    objRegshopBAL.OpenTime = txtOpentime.Text.Trim();
                    objRegshopBAL.PackageId = Convert.ToInt32(ddlPackage.SelectedValue);
                    objRegshopBAL.PackageName = ddlPackage.SelectedItem.Text;
                    objRegshopBAL.Pincode = "123456";
                    objRegshopBAL.RoleId = 1;
                    objRegshopBAL.RoleName = Session["RoleName"].ToString();
                    objRegshopBAL.ShopName_E = txtShopName_E.Text.Trim();
                    objRegshopBAL.ShopName_M = txtShopName_M.Text.Trim();
                    objRegshopBAL.WebSite = txtWebsite.Text.Trim();
                    objRegshopBAL.IsCall = Convert.ToInt32(rdbContactOnly.SelectedValue);
                    // objRegshopBAL.SCFK_ID = Convert.ToInt32(ddlSubChildCategory.SelectedValue);
                    objRegshopBAL.IsPaid = Convert.ToInt32(rdbIsPaid.SelectedValue);

                    if (ImageFileUpload.HasFile)
                    {
                        foreach (HttpPostedFile postedFile in ImageFileUpload.PostedFiles)
                        {
                            string fileName = Path.GetFileName(postedFile.FileName);
                            int fileSize = ImageFileUpload.PostedFile.ContentLength;

                            var allowedExtensions = new[] {
            ".Jpg", ".png", ".jpg", ".jpeg",".Png",".PNG",".JPEG",".JPG"
        };
                            var ext = Path.GetExtension(postedFile.FileName);
                            if (allowedExtensions.Contains(ext)) //check what type of extension  
                            {
                                if (fileSize > 1048576)
                                {
                                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Image Size Not More than 1 MB..!!!');", true);
                                }
                                else
                                {
                                    string path = Path.Combine(Server.MapPath("~/Images/ShopImages"), fileName);

                                    postedFile.SaveAs(path);

                                    objRegshopBAL.ImageName += fileName + ",";
                                    objRegshopBAL.ImagePath = commonCode.WebsiteBaseUrl + @"/Images/ShopImages/";
                                }
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Image should be proper extension..!!!');", true);
                                objRegshopBAL.ImageName = string.Empty;
                                objRegshopBAL.ImagePath = string.Empty;
                            }
                        }
                    }
                    else
                    {
                        objRegshopBAL.ImageName = string.Empty;
                        objRegshopBAL.ImagePath = string.Empty;
                    }

                    if (btnSubmit.Text == "Submit")
                        result = objRegshopBAL.InsertShopDetails(objRegshopBAL);
                    else
                    {
                        if (string.IsNullOrEmpty(objRegshopBAL.ImageName))
                            objRegshopBAL.ImageName = hdnImageName.Value;

                        result = objRegshopBAL.UpdateShopDetails(objRegshopBAL);
                    }
                    if (result != 0)
                        ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Record Added/Updated Successfully..!!!');", true);
                    else
                        ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Record Not Added/Updated..!!!');", true);

                    btnSubmit.Text = "Submit";
                    Clear();
                    BindGridView("NA");
                }
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
                lblShopId.Text = "Register Shop ID : " + objRegshopBAL.GetMaxId();
                lblShopId1.Text = "Register Shop ID : " + objRegshopBAL.GetMaxId();

                BindGrandCategory();
                BindParentCategory(0);
                BindSubChildCategory(0);
                BindChildCategory(0);

                //ddlGrandCategory.SelectedItem.Text = "Select";
                //ddlParentCategory.SelectedItem.Text = "Select";
                //ddlChildCategory.SelectedItem.Text = "Select";
                //ddlSubChildCategory.SelectedItem.Text = "Select";

                txtShopName_M.Text = "";
                txtShopName_E.Text = "";
                txtTelephone.Text = "";
                txtWebsite.Text = "";
                txtOwnerName_E.Text = "";
                txtOwnerName_M.Text = "";
                txtOpentime.Text = "";
                txtOffers.Text = "";
                txtMobileNumberTwo.Text = "";
                txtMobileNumberOne.Text = "";
                txtDescription.Text = "";
                txtClosetime.Text = "";
                txtAddress.Text = "";

                BindNearBy();
                //ddlNearby.SelectedValue = "0";
                ddlNearby.SelectedItem.Text = "Select";

                ddlPackage.SelectedValue = "0";
            }
            catch
            {
            }
        }

        protected void ddlParentCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindChildCategory(Convert.ToInt32(ddlParentCategory.SelectedValue));
        }

        protected void ddlGrandCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindParentCategory(Convert.ToInt32(ddlGrandCategory.SelectedValue));
        }

        protected void gvShopDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int IdValue = Convert.ToInt32(e.CommandArgument);
            string commandName = Convert.ToString(e.CommandName);
            btnSubmit.Text = "Update";
            if (commandName == "EditRow")
            {
                DataSet dset = objRegshopBAL.GetShopsDetails(IdValue);
                if (dset.Tables[0].Rows.Count > 0)
                {
                    lblShopId.Text = "Register Shop ID : " + dset.Tables[0].Rows[0]["PK_ShopRegId"].ToString();
                    lblShopId1.Text = "Register Shop ID : " + dset.Tables[0].Rows[0]["PK_ShopRegId"].ToString();

                    txtAddress.Text = dset.Tables[0].Rows[0]["DetailAddress"].ToString();
                    txtClosetime.Text = dset.Tables[0].Rows[0]["CloseTime"].ToString();
                    txtDescription.Text = dset.Tables[0].Rows[0]["Description"].ToString();
                    txtMobileNumberOne.Text = dset.Tables[0].Rows[0]["MobileNumber"].ToString();
                    txtMobileNumberTwo.Text = dset.Tables[0].Rows[0]["AlternetMobileNumber"].ToString();
                    txtOffers.Text = dset.Tables[0].Rows[0]["Offers"].ToString();
                    txtOpentime.Text = dset.Tables[0].Rows[0]["OpenTime"].ToString();
                    txtOwnerName_E.Text = dset.Tables[0].Rows[0]["Name_E"].ToString();
                    txtOwnerName_M.Text = dset.Tables[0].Rows[0]["Name_M"].ToString();
                    txtShopName_E.Text = dset.Tables[0].Rows[0]["ShopName_E"].ToString();
                    txtShopName_M.Text = dset.Tables[0].Rows[0]["ShopName_M"].ToString();
                    txtTelephone.Text = dset.Tables[0].Rows[0]["LandlineNumber"].ToString();
                    txtWebsite.Text = dset.Tables[0].Rows[0]["Website"].ToString();
                    rdbContactOnly.SelectedValue = dset.Tables[0].Rows[0]["IsCall"].ToString();
                    rdbIsPaid.SelectedValue = dset.Tables[0].Rows[0]["IsPaid"].ToString();

                    if (dset.Tables[1].Rows.Count > 0)
                    {
                        for (int i = 0; i < dset.Tables[1].Rows.Count; i++)
                        {
                            hdnImageName.Value += dset.Tables[1].Rows[i]["ImageName"].ToString() + ",";
                        }
                    }

                    BindGrandCategory();
                    ddlGrandCategory.SelectedValue = dset.Tables[0].Rows[0]["GFK_ID"].ToString();

                    BindParentCategory(Convert.ToInt32(dset.Tables[0].Rows[0]["GFK_ID"].ToString()));
                    ddlParentCategory.SelectedValue = dset.Tables[0].Rows[0]["PFK_ID"].ToString();

                    BindChildCategory(Convert.ToInt32(dset.Tables[0].Rows[0]["PFK_ID"].ToString()));
                    ddlChildCategory.SelectedValue = dset.Tables[0].Rows[0]["CFK_ID"].ToString();

                    BindSubChildCategory(Convert.ToInt32(dset.Tables[0].Rows[0]["CFK_ID"].ToString()));
                    if (dset.Tables[0].Rows[0]["SCFK_ID"].ToString() == "0")
                    { }
                    else
                    {
                        ddlSubChildCategory.SelectedValue = dset.Tables[0].Rows[0]["SCFK_ID"].ToString();
                    }

                    BindNearBy();
                    ddlNearby.SelectedValue = Convert.ToString(dset.Tables[0].Rows[0]["NearBy"].ToString());
                    ddlPackage.SelectedValue = Convert.ToString(dset.Tables[0].Rows[0]["Package"].ToString());

                    if (rdbContactOnly.SelectedValue == "0")
                    {
                        txtOwnerName_E.Visible = true;
                        txtOwnerName_M.Visible = true;
                        txtOffers.Visible = true;
                        txtMobileNumberTwo.Visible = true;
                        txtClosetime.Visible = true;
                        txtAddress.Visible = true;
                        txtOpentime.Visible = true;
                        txtTelephone.Visible = true;
                        txtWebsite.Visible = true;
                        ddlNearby.Visible = true;
                        ImageFileUpload.Visible = true;

                        lblAddress.Visible = true;
                        lblAlternetMob.Visible = true;
                        lblCloseTime.Visible = true;
                        lblImageUpload.Visible = true;
                        lblNearBy.Visible = true;
                        lblOffers.Visible = true;
                        lblOpenTime.Visible = true;
                        lblOwnerName_E.Visible = true;
                        lblOwnerName_M.Visible = true;
                        lblWebSite.Visible = true;
                        lblTelephone.Visible = true;
                    }
                    else
                    {
                        txtOwnerName_E.Visible = false;
                        txtOwnerName_M.Visible = false;
                        txtOffers.Visible = false;
                        txtMobileNumberTwo.Visible = false;
                        txtClosetime.Visible = false;
                        txtAddress.Visible = false;
                        txtOpentime.Visible = false;
                        txtTelephone.Visible = false;
                        txtWebsite.Visible = false;
                        ddlNearby.Visible = false;
                        ImageFileUpload.Visible = false;

                        lblAddress.Visible = false;
                        lblAlternetMob.Visible = false;
                        lblCloseTime.Visible = false;
                        lblImageUpload.Visible = false;
                        lblNearBy.Visible = false;
                        lblOffers.Visible = false;
                        lblOpenTime.Visible = false;
                        lblOwnerName_E.Visible = false;
                        lblOwnerName_M.Visible = false;
                        lblWebSite.Visible = false;
                        lblTelephone.Visible = false;
                    }

                    MultiView1.ActiveViewIndex = 0;
                }
            }
            else
            {
                result = objRegshopBAL.DeleteShop(IdValue);
                if (result != 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Record Deleted Successfully..!!!');", true);
                    BindGridView("NA");
                }
                else
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Record Not Deleted..!!!');", true);
            }
        }

        protected void gvShopDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShopDetails.PageIndex = e.NewPageIndex;
            if (hdnQuery.Value != "" || hdnQuery.Value != null)
                BindGridView(hdnQuery.Value);
            else
                BindGridView("NA");
        }

        protected void lnkbtnBackViews_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            Clear();
            btnSubmit.Text = "Submit";
        }

        protected void rdbContactOnly_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbContactOnly.SelectedValue == "1")
                {
                    txtOwnerName_E.Visible = false;
                    txtOwnerName_M.Visible = false;
                    txtOffers.Visible = false;
                    txtMobileNumberTwo.Visible = false;
                    txtClosetime.Visible = false;
                    txtAddress.Visible = false;
                    txtOpentime.Visible = false;
                    txtTelephone.Visible = false;
                    txtWebsite.Visible = false;
                    ddlNearby.Visible = false;
                    ImageFileUpload.Visible = false;

                    lblAddress.Visible = false;
                    lblAlternetMob.Visible = false;
                    lblCloseTime.Visible = false;
                    lblImageUpload.Visible = false;
                    lblNearBy.Visible = false;
                    lblOffers.Visible = false;
                    lblOpenTime.Visible = false;
                    lblOwnerName_E.Visible = false;
                    lblOwnerName_M.Visible = false;
                    lblWebSite.Visible = false;
                    lblTelephone.Visible = false;
                }
                else
                {
                    txtOwnerName_E.Visible = true;
                    txtOwnerName_M.Visible = true;
                    txtOffers.Visible = true;
                    txtMobileNumberTwo.Visible = true;
                    txtClosetime.Visible = true;
                    txtAddress.Visible = true;
                    txtOpentime.Visible = true;
                    txtTelephone.Visible = true;
                    txtWebsite.Visible = true;
                    ddlNearby.Visible = true;
                    ImageFileUpload.Visible = true;

                    lblAddress.Visible = true;
                    lblAlternetMob.Visible = true;
                    lblCloseTime.Visible = true;
                    lblImageUpload.Visible = true;
                    lblNearBy.Visible = true;
                    lblOffers.Visible = true;
                    lblOpenTime.Visible = true;
                    lblOwnerName_E.Visible = true;
                    lblOwnerName_M.Visible = true;
                    lblWebSite.Visible = true;
                    lblTelephone.Visible = true;
                }
            }
            catch
            {
            }
        }

        protected void btnViewList_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void ddlChildCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSubChildCategory(Convert.ToInt32(ddlChildCategory.SelectedValue));
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            hdnQuery.Value = txtSearch.Text;
            if (hdnQuery.Value != "" || hdnQuery.Value != null)
                BindGridView(hdnQuery.Value);
        }
    }
}