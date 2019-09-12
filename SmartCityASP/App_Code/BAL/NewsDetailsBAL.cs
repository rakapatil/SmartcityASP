using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartCityASP.App_Code.DAL;
using System.Data;

namespace SmartCityASP.App_Code.BAL
{
    public class NewsDetailsBAL
    {
        DataAccessLogic objDAL = new DataAccessLogic();

        public int NewsId { get; set; }
        public string NewsHeading { get; set; }
        public string NewsDetails { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public string InsertBy { get; set; }
        public int NewsSourceId { get; set; }
        public string NewsSourceName { get; set; }
        public string NewsDate { get; set; }

        public int InsertNewsDetails(NewsDetailsBAL objNews)
        {
            string sqlInsert = "INSERT INTO [tblImageWithTextNews] ([NewsHeading],[NewsDetails],[ImageName],[ImagePath],[InsertBy],[InsertDate],[IsActive],[NewsSourceId],[NewsSourceName],[NewsDate])" +
                               "VALUES (N'" + objNews.NewsHeading + "',N'" + objNews.NewsDetails + "',N'" + objNews.ImageName + "',N'" + objNews.ImagePath + "','" + objNews.InsertBy + "','" + System.DateTime.Now + "',1," + objNews.NewsSourceId + ",N'" + objNews.NewsSourceName + "','" + objNews.NewsDate + "')";
            return objDAL.ExecuteNonQuery(sqlInsert);
        }

        public int UpdateNewsDetails(NewsDetailsBAL objNews)
        {
            string sqlUpdate = "UPDATE [tblImageWithTextNews] SET [NewsHeading] = N'" + objNews.NewsHeading + "',[NewsDetails] = N'" + objNews.NewsDetails + "',[ImageName] = N'" + objNews.ImageName + "',[ImagePath] = N'" + objNews.ImagePath + "',[NewsSourceId]=" + objNews.NewsSourceId + ",[NewsSourceName] = N'" + objNews.NewsSourceName + "',[NewsDate]='" + objNews.NewsDate + "' WHERE [NewsId] = " + objNews.NewsId + "";
            return objDAL.ExecuteNonQuery(sqlUpdate);
        }

        public string GetMaxId()
        {
            try
            {
                string sqlGetId = "SELECT MAX([NewsId]) FROM [tblImageWithTextNews](NOLOCK)";
                int maxId = Convert.ToInt32(objDAL.ExecuteScalar(sqlGetId)) + 1;
                return maxId.ToString();
            }
            catch { return "1"; }
        }

        public DataSet GetNewsDetails()
        {
            string sqlGetData = "SELECT [NewsId],[NewsHeading],[NewsDetails],[ImageName],[ImagePath],[InsertBy],[InsertDate],[IsActive],[NewsSourceId],[NewsSourceName],[NewsDate] FROM [tblImageWithTextNews](NOLOCK) WHERE [IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public DataSet GetNewsDetails(int id)
        {
            string sqlGetData = "SELECT [NewsId],[NewsHeading],[NewsDetails],[ImageName],[ImagePath],[InsertBy],[InsertDate],[IsActive],[NewsSourceId],[NewsSourceName],[NewsDate] " +
                                "FROM   [tblImageWithTextNews] WHERE [NewsId] = " + id + " AND [IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public int DeletePCategory(int id)
        {
            string sqlDelete = "UPDATE [tblImageWithTextNews] SET [IsActive] = 0 WHERE [NewsId] = " + id + "";
            return objDAL.ExecuteNonQuery(sqlDelete);
        }
    }
}