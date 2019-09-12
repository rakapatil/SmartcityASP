using SmartCityASP.App_Code.DAL;
using System;
using System.Web.UI;

namespace SmartCityASP
{
    public partial class ViewShopDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }

        CommonCode cc = new CommonCode();

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //List<string> objListGcmId = new List<string>();
            //objListGcmId.Add(txtGCMID.Text);
            //cc.MulitipleSenders(objListGcmId, txtMessage.Text);

            //PostData obj = new PostData();
            //obj.TagMsg = txtGCMID.Text;
            //obj.Message = txtMessage.Text;
            //PushNotification objPush = new PushNotification();
            //  CommonCode cc = new CommonCode();
            string msg = "Thanks for the using Smart Shirpur App." +
                         "For More Information Contact on - 02563255237 9527004008" +
                         "www.smartshirpur.in" +
                         "Email-smartshirpurinfo@gmail.com";
            //cc.SendSMS("9158696413", msg);
        }
    }
}