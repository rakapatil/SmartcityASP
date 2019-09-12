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
    public partial class AddHolyTouristPlaces : System.Web.UI.Page
    {
        HolyTouristBAL objHoly = new HolyTouristBAL();
        DataSet ds = new DataSet();
        int result = 0;
        CommonCode commonCode = new CommonCode();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblHolyId.Text = "HolyTourist Place ID : " + objHoly.GetMaxId();
                lblHolyId1.Text = lblHolyId.Text;//"HolyTourist Place ID : " + objHoly.GetMaxId();
                //BindGrandCategory();
                MultiView1.ActiveViewIndex = 1;
                BindGridView();
                //BindNearBy();
                BindRouteDDL();
            }
        }

        public void BindGridView()
        {
            try
            {
                DataSet ds = objHoly.GetHolyTouristPlaceDetails();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvHolyPlaceDetails.DataSource = ds.Tables[0];
                    gvHolyPlaceDetails.DataBind();
                }
                else
                {
                    gvHolyPlaceDetails.EmptyDataText = "NO RECORD FOUND..!!!";
                    gvHolyPlaceDetails.DataBind();
                }
            }
            catch
            {
                gvHolyPlaceDetails.EmptyDataText = "ERROR FOUND..!!!";
                gvHolyPlaceDetails.DataBind();
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

        //public void BindNearBy()
        //{
        //    RegisterShopBAL objregshop = new RegisterShopBAL();
        //    DataSet dsNearby = objregshop.GetNearBy();

        //    ddlNearBy.DataSource = dsNearby.Tables[0];
        //    ddlNearBy.DataValueField = "FieldItemId";
        //    ddlNearBy.DataTextField = "FieldItemName";
        //    ddlNearBy.DataBind();
        //    ddlNearBy.Items.Insert(0, new ListItem("Select", ""));
        //    ddlNearBy.SelectedIndex = 0;
        //}

        //public void BindGrandCategory()
        //{
        //    GrandCategoryBAL objGCBAL = new GrandCategoryBAL();
        //    ds = objGCBAL.BindGrandCDetails();

        //    ddlGrandCategory.DataSource = ds.Tables[0];
        //    ddlGrandCategory.DataValueField = "PK_ID";
        //    ddlGrandCategory.DataTextField = "GName";
        //    ddlGrandCategory.DataBind();
        //    ddlGrandCategory.Items.Insert(0, new ListItem("Select", ""));
        //    ddlGrandCategory.SelectedIndex = 0;
        //}

        //public void BindParentCategory(int grandCategoryId)
        //{
        //    ChildCategoryBAL objCCBAL = new ChildCategoryBAL();
        //    DataSet dsParent = objCCBAL.GetParentCategoryByGrand(grandCategoryId);

        //    ddlParentCategory.DataSource = dsParent.Tables[0];
        //    ddlParentCategory.DataValueField = "PK_ID";
        //    ddlParentCategory.DataTextField = "PName";
        //    ddlParentCategory.DataBind();
        //    ddlParentCategory.Items.Insert(0, new ListItem("Select", ""));
        //    ddlParentCategory.SelectedIndex = 0;
        //}

        //public void BindChildCategory(int parentCategory)
        //{
        //    RegisterShopBAL objregshop = new RegisterShopBAL();
        //    DataSet dsChild = objregshop.GetCCDetailsbyParentId(parentCategory);

        //    ddlChildCategory.DataSource = dsChild.Tables[0];
        //    ddlChildCategory.DataValueField = "PK_ID";
        //    ddlChildCategory.DataTextField = "CName";
        //    ddlChildCategory.DataBind();
        //    ddlChildCategory.Items.Insert(0, new ListItem("Select", ""));
        //    ddlChildCategory.SelectedIndex = 0;
        //}

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string[] splitId = lblHolyId.Text.Split(':');

                objHoly.PK_HolyId = Convert.ToInt32(splitId[1].Trim());

                //objHoly.PFK_ID = Convert.ToInt32(ddlParentCategory.SelectedValue);
                //objHoly.GFK_ID = Convert.ToInt32(ddlGrandCategory.SelectedValue);
                //objHoly.CFK_ID = Convert.ToInt32(ddlChildCategory.SelectedValue);
                //objHoly.NearById = Convert.ToInt32(ddlNearBy.SelectedValue);
                //objHoly.NearByName = ddlNearBy.SelectedItem.Text;

                objHoly.RouteId = Convert.ToInt32(ddlRoute.SelectedValue);
                objHoly.PlaceName_E = txtPlaceName_E.Text.Trim();
                objHoly.PlaceName_M = txtPlaceName_M.Text.Trim();
                objHoly.PlaceFestivals = txtFestivals.Text;
                objHoly.PlaceHistory = txtHistory.Text;
                objHoly.DistanceFromCity = txtDistance.Text.Trim();
                objHoly.PlaceTypeId = Convert.ToInt32(rdbContactOnly.SelectedValue);

                if (ImageFileUpload.HasFile)
                {
                    foreach (HttpPostedFile postedFile in ImageFileUpload.PostedFiles)
                    {
                        string fileName = Path.GetFileName(postedFile.FileName);

                        var allowedExtensions = new[] {
           ".Jpg", ".png", ".jpg", ".jpeg",".Png",".PNG",".JPEG",".JPG"
        };
                        var ext = Path.GetExtension(postedFile.FileName);
                        if (allowedExtensions.Contains(ext)) //check what type of extension  
                        {
                            string path = Path.Combine(Server.MapPath("~/Images/HolyImages"), fileName);
                            postedFile.SaveAs(path);

                            objHoly.ImageName += fileName + ",";
                            objHoly.ImagePath = commonCode.WebsiteBaseUrl + @"/Images/HolyImages/";
                        }
                        else
                        {
                            objHoly.ImageName = "0";
                            objHoly.ImagePath = "0";
                        }
                    }
                }
                else
                {
                    objHoly.ImageName = "0";
                    objHoly.ImagePath = "0";
                }

                if (btnSubmit.Text == "Submit")
                    result = objHoly.InsertShopDetails(objHoly);
                else
                    result = objHoly.UpdateShopDetails(objHoly);

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
                lblHolyId.Text = "HolyTourist Place ID : " + objHoly.GetMaxId();
                lblHolyId1.Text = lblHolyId.Text;

                //ddlGrandCategory.SelectedValue = "0";
                //ddlParentCategory.SelectedValue = "0";
                //ddlChildCategory.SelectedValue = "0";

                ddlRoute.SelectedValue = "0";
                txtHistory.Text = "";
                txtFestivals.Text = "";
                txtDistance.Text = "";
                txtPlaceName_M.Text = "";
                txtPlaceName_E.Text = "";
            }
            catch
            {
            }
        }
        protected void gvHolyPlaceDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int IdValue = Convert.ToInt32(e.CommandArgument);
            string commandName = Convert.ToString(e.CommandName);
            btnSubmit.Text = "Update";
            if (commandName == "EditRow")
            {
                DataSet dset = objHoly.GetHolyTouristPlaceDetails(IdValue);
                if (dset.Tables[0].Rows.Count > 0)
                {
                    lblHolyId.Text = "HolyTourist Place ID : " + dset.Tables[0].Rows[0]["PK_HTPId"].ToString();
                    lblHolyId.Text = "HolyTourist Place ID : " + dset.Tables[0].Rows[0]["PK_HTPId"].ToString();

                    txtDistance.Text = dset.Tables[0].Rows[0]["DistanceFromCity"].ToString();
                    txtFestivals.Text = dset.Tables[0].Rows[0]["PlaceUstav"].ToString();
                    txtHistory.Text = dset.Tables[0].Rows[0]["PlaceHistory"].ToString();
                    txtPlaceName_E.Text = dset.Tables[0].Rows[0]["Name_E"].ToString();
                    txtPlaceName_M.Text = dset.Tables[0].Rows[0]["Name_M"].ToString();

                    BindRouteDDL();
                    ddlRoute.SelectedValue = dset.Tables[0].Rows[0]["RouteId"].ToString();
                    rdbContactOnly.SelectedValue = dset.Tables[0].Rows[0]["PlaceTypeId"].ToString();

                    //BindGrandCategory();
                    //ddlGrandCategory.SelectedValue = dset.Tables[0].Rows[0]["GFK_ID"].ToString();

                    //BindParentCategory(Convert.ToInt32(ddlGrandCategory.SelectedValue));
                    //ddlParentCategory.SelectedValue = dset.Tables[0].Rows[0]["PFK_ID"].ToString();

                    //BindChildCategory(Convert.ToInt32(ddlParentCategory.SelectedValue));
                    //ddlChildCategory.SelectedValue = dset.Tables[0].Rows[0]["CFK_ID"].ToString();

                    //BindNearBy();
                    //ddlNearBy.SelectedValue = Convert.ToString(dset.Tables[0].Rows[0]["NearById"].ToString());

                    MultiView1.ActiveViewIndex = 0;
                }
            }
            else
            {
                result = objHoly.DeletePlace(IdValue);
                if (result != 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Record Deleted Successfully..!!!');", true);
                    BindGridView();
                }
                else
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Record Not Deleted..!!!');", true);
            }
        }

        protected void gvHolyPlaceDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvHolyPlaceDetails.PageIndex = e.NewPageIndex;
            BindGridView();
        }

        //protected void ddlGrandCategory_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    BindParentCategory(Convert.ToInt32(ddlGrandCategory.SelectedValue));
        //}

        //protected void ddlParentCategory_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    BindChildCategory(Convert.ToInt32(ddlParentCategory.SelectedValue));
        //}

        protected void lnkbtnBackViews_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            Clear();
        }

        protected void btnViewList_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }
    }
}