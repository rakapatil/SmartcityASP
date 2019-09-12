using System;
using System.Collections.Generic;
using SmartCityASP.App_Code.DAL;
using System.Data;

namespace SmartCityASP.App_Code.BAL
{
    public class NotificationBAL
    {
#pragma warning disable CS0436 // Type conflicts with imported type
        DataAccessLogic objDAL = new DataAccessLogic();
#pragma warning restore CS0436 // Type conflicts with imported type

        public int NewsId { get; set; }
        public string NewsDetails { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }

#pragma warning disable CS0436 // Type conflicts with imported type
        public int InsertNewsDetails(NotificationBAL objNews)
#pragma warning restore CS0436 // Type conflicts with imported type
        {
            string sqlInsert = "INSERT INTO [tblImageTextNotifications] ([Description],[ImageName],[ImagePath],[IsActive])" +
                               "VALUES (N'" + objNews.NewsDetails + "',N'" + objNews.ImageName + "',N'" + objNews.ImagePath + "',1)";
            return objDAL.ExecuteNonQuery(sqlInsert);
        }

        public DataSet GetNewsDetails()
        {
            string sqlGetData = "SELECT [PK_NotifId],[Description],[ImageName],[ImagePath],[IsActive] FROM [tblImageTextNotifications](NOLOCK) WHERE [IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public DataSet GetNewsDetails(int pkNotifId)
        {
            string sqlGetData = "SELECT [PK_NotifId],[Description],[ImageName],[ImagePath],[IsActive] FROM [tblImageTextNotifications](NOLOCK) WHERE [IsActive] = 1 AND [PK_NotifId] = " + pkNotifId + "";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public string GetMaxId()
        {
            try
            {
                string sqlGetId = "SELECT MAX([PK_NotifId]) FROM [tblImageTextNotifications](NOLOCK)";
                int maxId = Convert.ToInt32(objDAL.ExecuteScalar(sqlGetId)) + 1;
                return maxId.ToString();
            }
            catch { return "1"; }
        }

        public int DeletePCategory(int id)
        {
            string sqlDelete = "UPDATE [tblImageTextNotifications] SET [IsActive] = 0 WHERE [PK_NotifId] = " + id + "";
            return objDAL.ExecuteNonQuery(sqlDelete);
        }

        public List<string> GetFcmIds()
        {
            List<string> listFcmIds = new List<string>();
            string sqlGetData = "SELECT [FcmId] FROM [tblTokenDetails]";
            DataSet dsFcmIds = objDAL.ExecuteDataset(sqlGetData);
            int counter = dsFcmIds.Tables[0].Rows.Count;

            if (counter > 0)
            {
                for (int i = 0; i < counter; i++)
                {
                    listFcmIds.Add(dsFcmIds.Tables[0].Rows[i]["FcmId"].ToString());
                }
            }
            else
            {
                listFcmIds.Add("f-BVmSAboKc:APA91bHq2BLKGzw7KAU8vJdX12YovDMnlucbeXLdfU-gV-suOrVnqSlQjYr5Ct93RxKYexuKOeYRG15Rylgwxw5d94de1YF6q0KL0Y3R4lF4PhLgROQ1uFMgeNRE7oBlw14RAalzTPWF");
            }
            return listFcmIds;
        }
    }
}