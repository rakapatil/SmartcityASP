using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace WebApi.Models
{
    public class SendSMSApi
    {
        private WebProxy objProxy1 = null;
        public string SendSMS(string Mobile_Number, string Message)
        {
            object stringpost = "key=58d0faec10526&type=text&contacts=" + Mobile_Number + "&senderid=adzwld&msg=" + Message + "";

            HttpWebRequest objWebRequest = null;
            HttpWebResponse objWebResponse = null;
            StreamWriter objStreamWriter = null;
            StreamReader objStreamReader = null;

            try
            {
                string stringResult = null;

                objWebRequest = (HttpWebRequest)WebRequest.Create("http://softsms.in/app/smsapi/index.php");
                objWebRequest.Method = "POST";

                if ((objProxy1 != null))
                {
                    objWebRequest.Proxy = objProxy1;
                }

                objWebRequest.ContentType = "application/x-www-form-urlencoded";
                objStreamWriter = new StreamWriter(objWebRequest.GetRequestStream());
                objStreamWriter.Write(stringpost);

                objStreamWriter.Flush();
                objStreamWriter.Close();

                objWebResponse = (HttpWebResponse)objWebRequest.GetResponse();
                objStreamReader = new StreamReader(objWebResponse.GetResponseStream());

                stringResult = objStreamReader.ReadToEnd();

                objStreamReader.Close();

                return stringResult;
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
            finally
            {

                if (objStreamWriter != null)
                    objStreamWriter.Close();
                if (objStreamReader != null)
                    objStreamReader.Close();

                objWebRequest = null;
                objWebResponse = null;
                objProxy1 = null;
            }
        }

        public void NewSendSMS()
        {
            string msg = "Thanks for the using Smart Shirpur App." +
                         "For More Information Contact on - 02563255237 9527004008 " +
                         "www.smartshirpur.in " +
                         "Email-smartshirpurinfo@gmail.com";
            //Your authentication key
            string authKey = "58d0faec10526";
            //Multiple mobiles numbers separated by comma
            string mobileNumber = "9158696413";
            //Sender ID,While using route4 sender id should be 6 characters long.
            string senderId = "adzwld";
            //Your message to send, Add URL encoding here.
            string message = HttpUtility.UrlEncode(msg);
            //Your SMS Type
            string smsType = "text";

            //Prepare you post parameters
            StringBuilder sbPostData = new StringBuilder();
            sbPostData.AppendFormat("key={0}", authKey);
            sbPostData.AppendFormat("&type={0}", smsType);
            sbPostData.AppendFormat("&contacts={0}", mobileNumber);
            sbPostData.AppendFormat("&senderid={0}", senderId);
            sbPostData.AppendFormat("&msg={0}", message);

            try
            {
                //Call Send SMS API
                string sendSMSUri = "http://softsms.in/app/smsapi/index.php";
                //Create HTTPWebrequest
                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
                //Prepare and Add URL Encoded data
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] data = encoding.GetBytes(sbPostData.ToString());
                //Specify post method
                httpWReq.Method = "POST";
                httpWReq.ContentType = "application/x-www-form-urlencoded";
                httpWReq.ContentLength = data.Length;
                using (Stream stream = httpWReq.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                //Get the response
                HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string responseString = reader.ReadToEnd();

                //Close the response
                reader.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}