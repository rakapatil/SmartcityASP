using SmartCityASP.App_Code.BAL;
using SmartCityASP.App_Code.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartCityASP
{
    public partial class ImageTextNotification : System.Web.UI.Page
    {
        NotificationBAL objNews = new NotificationBAL();

        DataSet ds = new DataSet();
        int result = 0;
        CommonCode commonCode = new CommonCode();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblRegId.Text = "Notification ID : " + objNews.GetMaxId();
                BindGridView();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                objNews.NewsDetails = txtDescription.Text.Trim();

                string[] splitId = lblRegId.Text.Split(':');

                objNews.NewsId = Convert.ToInt32(splitId[1].Trim());

                if (ImageFileUpload.HasFile)
                {
                    var allowedExtensions = new[] {
          ".Jpg", ".png", ".jpg", ".jpeg",".Png",".PNG",".JPEG",".JPG"
        };
                    var ext = Path.GetExtension(ImageFileUpload.FileName);
                    int fileSize = ImageFileUpload.PostedFile.ContentLength;

                    if (allowedExtensions.Contains(ext)) //check what type of extension  
                    {
                        if (fileSize > 1048576)
                        {
                            ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Image Size Not More than 1 MB..!!!');", true);
                        }
                        else
                        {
                            string fileName = Path.GetFileName(ImageFileUpload.FileName);
                            string path = Path.Combine(Server.MapPath("~/Images/NotificationImages"), fileName);
                            ImageFileUpload.SaveAs(path);

                            objNews.ImageName = fileName;
                            objNews.ImagePath = commonCode.WebsiteBaseUrl + @"/Images/NotificationImages/" + fileName;
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Image should be proper extension..!!!');", true);
                        objNews.ImageName = "0";
                        objNews.ImagePath = "0";
                    }
                }
                else
                {
                    objNews.ImageName = "0";
                    objNews.ImagePath = "0";
                }

                if (btnSubmit.Text == "Submit")
                    result = objNews.InsertNewsDetails(objNews);

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

        public void BindGridView()
        {
            try
            {
                DataSet dsGrid = objNews.GetNewsDetails();
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

        public void Clear()
        {
            try
            {
                lblRegId.Text = "Notification ID : " + objNews.GetMaxId();
                txtDescription.Text = "";
            }
            catch
            {
            }
        }

        protected void gvPCDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int IdValue = Convert.ToInt32(e.CommandArgument);
            string commandName = Convert.ToString(e.CommandName);
            if (commandName == "EditRow")
            {
                //HERE WRITE THE CODE FOR SEND NOTIFICATION
                var objPushNotif = new PushNotification();
                List<string> list = objNews.GetFcmIds();
                DataSet dsNotif = objNews.GetNewsDetails(IdValue);
                foreach (var n in list)
                {
                    PostNotif objP = new PostNotif()
                    {
                        FCM_DeviceId = n,
                        ImageUrl = dsNotif.Tables[0].Rows[0]["ImagePath"].ToString(),
                        Message = dsNotif.Tables[0].Rows[0]["Description"].ToString(),
                        TagMsg = "Smart Shirpur City"
                    };
                    var result = objPushNotif.SendFcmNotification(objP);
                }
            }
            else
            {
                result = objNews.DeletePCategory(IdValue);
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
    }
}