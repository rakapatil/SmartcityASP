using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web.Configuration;

namespace SmartCityASP.App_Code.DAL
{
    public class CommonCode
    {
        private string aid = "639128";
        private string pin = "M@h123";

        string DESKey = "AQWSEDRF";
        string DESIV = "HGFEDCBA";

        private WebProxy objProxy1 = null;

        public string WebsiteBaseUrl = WebConfigurationManager.AppSettings["websiteBaseUrl"];

        public string MulitipleSenders(List<string> regIds, string message)
        {
            // applicationID means google Api key                                                                                                     
            // var applicationID = "AIzaSyCm3Z-UbwmxR0P3bmRxos-cbFiNCxzm7Rg";
            var applicationID = "AAAAH1uXWew:APA91bEp0qnqxMfoYnz-xRMR-1FgYBNY_pCKNI8aXxwG3YcNea_xjINaSuFaKG55BhHvbf9tjhjbom3SHd2hbO82IfH8AQpkzRwL0j3XUobvCUHjERZMNKh4HYnQ0kZ0yH2FmsVBWSN3";

            // SENDER_ID is nothing but your ProjectID (from API Console- google code)//                                          
            //var SENDER_ID = "273504352189";
            var SENDER_ID = "134680631788";

            var value = message; //message text box                                                                               

            PostData pdata = new PostData(applicationID, SENDER_ID, value, regIds);

            pdata.collapse_key = "score_update";
            pdata.time_to_live = 108;
            pdata.delay_while_idle = true;

            string request = JsonConvert.SerializeObject(pdata);

            WebRequest tRequest;

            // tRequest = WebRequest.Create("https://android.googleapis.com/gcm/send");

            tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");

            tRequest.Method = "post";

            tRequest.ContentType = " application/json";

            tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));

            tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));

            //Data post to server                                                                                                                                         

            Byte[] byteArray = Encoding.UTF8.GetBytes(request);

            tRequest.ContentLength = byteArray.Length;

            Stream dataStream = tRequest.GetRequestStream();

            dataStream.Write(byteArray, 0, byteArray.Length);

            dataStream.Close();

            WebResponse tResponse = tRequest.GetResponse();

            dataStream = tResponse.GetResponseStream();

            StreamReader tReader = new StreamReader(dataStream);

            String sResponseFromServer = tReader.ReadToEnd();   //Get response from GCM server.

            //Assigning GCM response to Label text 

            tReader.Close();

            dataStream.Close();
            tResponse.Close();
            return sResponseFromServer;    //Assigning GCM response to Label text 
        }

        public string DESDecrypt(string stringToDecrypt)//Decrypt the content
        {

            byte[] key;
            byte[] IV;

            byte[] inputByteArray;
            try
            {

                key = Convert2ByteArray(DESKey);
                IV = Convert2ByteArray(DESIV);

                stringToDecrypt = stringToDecrypt.Replace(" ", "+");

                int len = stringToDecrypt.Length;
                inputByteArray = Convert.FromBase64String(stringToDecrypt);

                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                Encoding encoding = Encoding.UTF8; return encoding.GetString(ms.ToArray());
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Encrypt the normal string with the DES to Encrypted string 
        /// </summary>
        /// <param name="stringToEncrypt">Normal String  to Encrypt</param>
        /// <returns></returns>
        public string DESEncrypt(string stringToEncrypt)// Encrypt the content
        {

            byte[] key;
            byte[] IV;

            byte[] inputByteArray;
            try
            {

                key = Convert2ByteArray(DESKey);
                IV = Convert2ByteArray(DESIV);
                inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream(); CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }

            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        static byte[] Convert2ByteArray(string strInput)
        {

            int intCounter; char[] arrChar;
            arrChar = strInput.ToCharArray();

            byte[] arrByte = new byte[arrChar.Length];

            for (intCounter = 0; intCounter <= arrByte.Length - 1; intCounter++)
                arrByte[intCounter] = Convert.ToByte(arrChar[intCounter]);

            return arrByte;
        }

        public string SendSMS(string Mobile_Number, string Message)
        {
            //Mobile_Number = "91" + Mobile_Number;
            //System.Object stringpost = "aid=" + aid + "&pin=" + pin + "&mnumber=" + Mobile_Number + "&message=" + Message + "&signature=MAHSEC";

            System.Object stringpost = "key=58d0faec10526&type=text&contacts=" + Mobile_Number + "&senderid=adzwld&msg=" + Message + "";

            HttpWebRequest objWebRequest = null;
            HttpWebResponse objWebResponse = null;
            StreamWriter objStreamWriter = null;
            StreamReader objStreamReader = null;

            try
            {
                string stringResult = null;
                //http://softsms.in/app/smsapi/index.php?key=58d0faec10526&type=text&contacts=9158696413&senderid=adzwld&msg=hello

                //objWebRequest = (HttpWebRequest)WebRequest.Create(" http://otp.zone:7501/failsafe/HttpLink?aid=639128&pin=M@h123&mnumber=91XXXXXXXXXX&message=test&signature=MAHSEC");
                //objWebRequest = (HttpWebRequest)WebRequest.Create("http://otp.zone:7501/failsafe/HttpLink");

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
                return (stringResult);
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
            finally
            {

                if ((objStreamWriter != null))
                {
                    objStreamWriter.Close();
                }
                if ((objStreamReader != null))
                {
                    objStreamReader.Close();
                }
                objWebRequest = null;
                objWebResponse = null;
                objProxy1 = null;
            }
        }
    }
}