using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartCityASP.App_Code.DAL;
using System.Data;

namespace SmartCityASP.App_Code.BAL
{
    public class ScrollingAdsBAL
    {
        DataAccessLogic objDAL = new DataAccessLogic();

        public int ScrollAdId { get; set; }
        public string AdDescription { get; set; }

        public string GetMaxId()
        {
            try
            {
                string sqlGetId = "SELECT MAX([PK_ScrollAdsId]) FROM [tblScrollingAds]";
                int maxId = Convert.ToInt32(objDAL.ExecuteScalar(sqlGetId)) + 1;
                return maxId.ToString();
            }
            catch { return "1"; }
        }

        public int InsertScrollAds(ScrollingAdsBAL objScrollAd)
        {
            try
            {
                string sqlInsert = "INSERT INTO [tblScrollingAds] ([Description],[IsActive]) VALUES (N'" + objScrollAd.AdDescription + "',1)";
                objDAL.ExecuteNonQuery(sqlInsert);

                return 1;
            }
            catch { return 0; }
        }

        public int UpdateScrollAds(ScrollingAdsBAL objScrollAd)
        {
            try
            {
                string sqlUpdate = "UPDATE [tblScrollingAds] SET [Description] = N'" + objScrollAd.AdDescription + "' WHERE [PK_ScrollAdsId] = " + objScrollAd.ScrollAdId + "";
                objDAL.ExecuteNonQuery(sqlUpdate);
                return 1;
            }
            catch
            { return 0; }
        }

        public DataSet GetScrollAdsDetails()
        {
            string sqlGetData = "SELECT * FROM [tblScrollingAds] WHERE [IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public DataSet GetScrollAdsDetails(int id)
        {
            string sqlGetData = "SELECT [PK_ScrollAdsId],[Description],[IsActive] FROM [tblScrollingAds] WHERE [PK_ScrollAdsId] = '" + id + "' AND [IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public int DeleteAds(int id)
        {
            string sqlDelete = "UPDATE [tblScrollingAds] SET [IsActive] = 0 WHERE [PK_ScrollAdsId] = " + id + "";
            return objDAL.ExecuteNonQuery(sqlDelete);
        }
    }
}