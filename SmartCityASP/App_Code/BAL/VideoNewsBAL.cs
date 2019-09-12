using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartCityASP.App_Code.DAL;
using System.Data;


namespace SmartCityASP.App_Code.BAL
{
    public class VideoNewsBAL
    {
        DataAccessLogic objDAL = new DataAccessLogic();

        public int NewsId { get; set; }
        public string NewsHeading { get; set; }
        public string NewsDetails { get; set; }
        public string InsertBy { get; set; }
        public int NewsSourceId { get; set; }
        public string NewsSourceName { get; set; }
        public string VideoName { get; set; }
        public string VideoPath { get; set; }
        public string NewsDate { get; set; }

        public int InsertNewsDetails(VideoNewsBAL objNews)
        {
            string sqlInsert = "INSERT INTO [tblVideoNews] ([NewsHeading],[NewsDetails],[NewsSourceId],[NewsSourceName],[VideoName],[VideoPath],[NewsDate],[InsertBy],[InsertDate],[IsActive])" +
                               "VALUES (N'" + objNews.NewsHeading + "',N'" + objNews.NewsDetails + "','" + objNews.NewsSourceId + "',N'" + objNews.NewsSourceName + "',N'" + objNews.VideoName + "',N'" + objNews.VideoPath + "','" + objNews.NewsDate + "',N'" + objNews.InsertBy + "','" + System.DateTime.Now + "',1)";
            return objDAL.ExecuteNonQuery(sqlInsert);
        }

        public int UpdateNewsDetails(VideoNewsBAL objNews)
        {
            string sqlUpdate = "UPDATE [tblVideoNews] SET [NewsHeading] = N'" + objNews.NewsHeading + "',[NewsDetails] = N'" + objNews.NewsDetails + "',[NewsSourceId]='" + objNews.NewsSourceId + "',[NewsSourceName] = N'" + objNews.NewsSourceName + "',[VideoName] = N'" + objNews.VideoName + "',[VideoPath] = N'" + objNews.VideoPath + "',[NewsDate]='" + objNews.NewsDate + "' WHERE [NewsId] = " + objNews.NewsId + "";
            return objDAL.ExecuteNonQuery(sqlUpdate);
        }

        public string GetMaxId()
        {
            try
            {
                string sqlGetId = "SELECT MAX([NewsId]) FROM [tblVideoNews](NOLOCK)";
                int maxId = Convert.ToInt32(objDAL.ExecuteScalar(sqlGetId)) + 1;
                return maxId.ToString();
            }
            catch { return "1"; }
        }

        public DataSet GetChannels()
        {
            string sqlGetData = "SELECT [FieldItemId],[FieldItemName_M]+' ('+[FieldItemName_E]+')' AS FieldName FROM [tblFieldItemMaster](NOLOCK) WHERE [IsActive] = 1 AND [FK_FieldId] IN (3,4)";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public DataSet GetNewsDetails()
        {
            string sqlGetData = "SELECT * FROM [tblVideoNews](NOLOCK) WHERE [IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public DataSet GetNewsDetails(int id)
        {
            string sqlGetData = "SELECT [NewsId],[NewsHeading],[NewsDetails],[NewsSourceId],[NewsSourceName],[VideoName],[VideoPath],[NewsDate],[InsertBy],[InsertDate],[IsActive] " +
                                "FROM   [tblVideoNews](NOLOCK) WHERE [NewsId] = " + id + " AND [IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public int DeletePCategory(int id)
        {
            string sqlDelete = "UPDATE [tblVideoNews] SET [IsActive] = 0 WHERE [NewsId] = " + id + "";
            return objDAL.ExecuteNonQuery(sqlDelete);
        }
    }
}