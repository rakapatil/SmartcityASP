using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace SmartCityASP.App_Code.DAL
{
    public class PushNotification
    {
        string returnString = string.Empty;
        public string SendFcmNotification(PostNotif obj)
        {
            var SERVER_API_KEY = "AAAAH1uXWew:APA91bEp0qnqxMfoYnz-xRMR-1FgYBNY_pCKNI8aXxwG3YcNea_xjINaSuFaKG55BhHvbf9tjhjbom3SHd2hbO82IfH8AQpkzRwL0j3XUobvCUHjERZMNKh4HYnQ0kZ0yH2FmsVBWSN3";
            var SENDER_ID = "134680631788";
            var deviceId = obj.FCM_DeviceId;

            try
            {
                WebRequest trequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                trequest.Method = "POST";
                trequest.ContentType = "application/json";
                var dataDetails = new
                {
                    to = deviceId,
                    notification = new
                    {
                        body = "WelCome to my WORLD.!!!",
                        title = "SMART",
                        sound = "Hi",
                        click_action = "FcmNotifier",
                        icon = "http://api.androidhive.info/images/minion.jpg"
                    }
                };

                var serializer = new JavaScriptSerializer();
                string json = JsonConvert.SerializeObject(dataDetails);
                Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                trequest.Headers.Add(string.Format("Authorization: key={0}", SERVER_API_KEY));
                trequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                trequest.ContentLength = byteArray.Length;

                #region add
                trequest.UseDefaultCredentials = true;
                trequest.PreAuthenticate = true;
                trequest.Credentials = CredentialCache.DefaultCredentials;
                #endregion

                using (Stream dataStream = trequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = trequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                returnString = sResponseFromServer;
                            }
                        }
                    }
                }
                returnString = "SUCCESS:" + returnString;
            }
            catch (Exception ex)
            {
                returnString = "ERROR:" + ex.Message;
            }
            return returnString;
        }
    }
}
