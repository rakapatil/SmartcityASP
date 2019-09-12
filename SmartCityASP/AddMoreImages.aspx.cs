﻿using SmartCityASP.App_Code.BAL;
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
    public partial class AddMoreImages : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        int result = 0;
        AddMoreImagesShop objSlider = new AddMoreImagesShop();
        DataAccessLogic objDAL = new DataAccessLogic();
        CommonCode commonCode = new CommonCode();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblRegId.Text = "Unique ID : " + objSlider.GetMaxId();
                BindGridView("NA");
                BindShops();
            }
        }

        public void BindShops()
        {
            ds = objSlider.GetShopDetails();
            ddlShopName.DataSource = ds.Tables[0];
            ddlShopName.DataValueField = "PK_ShopRegId";
            ddlShopName.DataTextField = "ShopName";
            ddlShopName.DataBind();
            ddlShopName.Items.Insert(0, new ListItem("Select", ""));
            ddlShopName.SelectedIndex = 0;
        }

        public void BindGridView(string value)
        {
            try
            {
                DataSet ds = new DataSet();
                if (value == "NA")
                    ds = objSlider.GetSliderImageDetails();
                else
                    ds = objSlider.GetSliderImageDetails(value);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvSliderImages.DataSource = ds.Tables[0];
                    gvSliderImages.DataBind();
                }
                else
                {
                    gvSliderImages.EmptyDataText = "NO RECORD FOUND..!!!";
                    gvSliderImages.DataBind();
                }
            }
            catch
            {
                gvSliderImages.EmptyDataText = "ERROR FOUND..!!!";
                gvSliderImages.DataBind();
            }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string[] splitId = lblRegId.Text.Split(':');

                objSlider.SliderImageId = Convert.ToInt32(splitId[1].Trim());
                objSlider.maxId = ddlShopName.SelectedValue;

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
                                if (File.Exists(path))
                                {
                                    File.Delete(path);
                                    postedFile.SaveAs(path);
                                }
                                else
                                {
                                    postedFile.SaveAs(path);
                                }
                                objSlider.ImageName += fileName + ",";
                                objSlider.ImagePath = commonCode.WebsiteBaseUrl + @"/Images/ShopImages/";
                            }
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Image should be proper extension..!!!');", true);
                            objSlider.ImageName = "0";
                            objSlider.ImagePath = "0";
                        }
                    }
                }
                else
                {
                    objSlider.ImageName = "0";
                    objSlider.ImagePath = "0";
                }

                if (btnSubmit.Text == "Submit")
                    result = objSlider.InsertSliderImages(objSlider);
                //else
                //    result = objSlider.UpdateSliderImages(objSlider);

                if (result != 0)
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Record Added/Updated Successfully..!!!');", true);
                else
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Record Not Added/Updated..!!!');", true);

                btnSubmit.Text = "Submit";
                Clear();
                BindGridView("NA");
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
                lblRegId.Text = "Unique ID : " + objSlider.GetMaxId();
                //txtCaption.Text = "";
            }
            catch
            {
            }
        }

        protected void gvSliderImages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int IdValue = Convert.ToInt32(e.CommandArgument);
            string commandName = Convert.ToString(e.CommandName);
            //btnSubmit.Text = "Update";
            //if (commandName == "EditRow")
            //{
            //    DataSet dset = objSlider.GetSliderImageDetails(IdValue);
            //    if (dset.Tables[0].Rows.Count > 0)
            //    {
            //        lblRegId.Text = "Unique ID : " + dset.Tables[0].Rows[0]["PK_SliderId"].ToString();
            //        txtCaption.Text = dset.Tables[0].Rows[0]["Caption"].ToString();
            //    }
            //}
            //else
            //{
            result = objSlider.DeleteImage(IdValue);
            if (result != 0)
                ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Record Deleted Successfully..!!!');", true);
            else
                ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Record Not Deleted..!!!');", true);
            BindGridView("NA");
            // }
        }

        protected void gvSliderImages_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSliderImages.PageIndex = e.NewPageIndex;

            if (hdnQuery.Value != "" || hdnQuery.Value != null)
                BindGridView(hdnQuery.Value);
            else
                BindGridView("NA");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            hdnQuery.Value = txtSearch.Text;
            if (hdnQuery.Value != "" || hdnQuery.Value != null)
                BindGridView(hdnQuery.Value);
        }
    }
}