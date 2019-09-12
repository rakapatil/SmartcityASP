using SmartCityASP.App_Code.DAL;
using System;
using System.Data;
using System.Web.Configuration;

namespace SmartCityASP.App_Code.BAL
{
    public class ParentCategoryBAL
    {
        DataAccessLogic objDAL = new DataAccessLogic();

        public int PK_ID { get; set; }
        public int GFK_ID { get; set; }
        public string PName_E { get; set; }
        public string PName_M { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }

        private string _imageUploadUrl = WebConfigurationManager.AppSettings["websiteBaseUrl"] + @"/Images/ParentCategory/";

        public int InsertParentCategory(ParentCategoryBAL objPCBAL)
        {
            string sqlInsert = "INSERT INTO [tblParentCategory] ([PName_M],[PName_E],[GFK_ID],[ImageName],[ImagePath],[InsertBy],[InsertDate],[IsActive],[IsUpdate]) " +
                               "VALUES (N'" + objPCBAL.PName_M + "',N'" + objPCBAL.PName_E + "'," + objPCBAL.GFK_ID + ",N'" + objPCBAL.ImageName + "',N'" + objPCBAL.ImagePath + "','9158696413','" + System.DateTime.Now + "',1,1)";
            return objDAL.ExecuteNonQuery(sqlInsert);
        }

        public int UpdateParentCategory(ParentCategoryBAL objPCBAL)
        {
            string sqlUpdate = string.Empty;
            if (string.IsNullOrEmpty(objPCBAL.ImageName))
            {
                sqlUpdate = "UPDATE [tblParentCategory] SET [PName_M] = N'" + objPCBAL.PName_M + "',[PName_E] = N'" + objPCBAL.PName_E + "',[GFK_ID] = " + objPCBAL.GFK_ID + " WHERE [PK_ID] = " + objPCBAL.PK_ID + "";
            }
            else
            {
                sqlUpdate = "UPDATE [tblParentCategory] SET " +
                    "[PName_M] = N'" + objPCBAL.PName_M + "'," +
                    "[PName_E] = N'" + objPCBAL.PName_E + "'," +
                    "[GFK_ID] = " + objPCBAL.GFK_ID + "," +
                    "[ImageName] = N'" + objPCBAL.ImageName + "'," +
                    "[ImagePath] = N'" + _imageUploadUrl + objPCBAL.ImageName + "'" +
                    " WHERE [PK_ID] = " + objPCBAL.PK_ID + "";
            }

            return objDAL.ExecuteNonQuery(sqlUpdate);
        }

        public string GetMaxId()
        {
            try
            {
                string sqlGetId = "SELECT MAX([PK_ID]) FROM [tblParentCategory]";
                int maxId = Convert.ToInt32(objDAL.ExecuteScalar(sqlGetId)) + 1;
                return maxId.ToString();
            }
            catch { return "1"; }
        }

        public DataSet GetPCDetails()
        {
            string sqlGetData = "SELECT * FROM [tblParentCategory] WHERE [IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public DataSet GetPCDetails(int id)
        {
            string sqlGetData = "SELECT [PK_ID],[PName_M],[PName_E],[GFK_ID],[ImageName],[ImagePath],[InsertBy],[InsertDate] " +
                                "FROM   [tblParentCategory] WHERE [PK_ID] = " + id + " AND [IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public int DeletePCategory(int id)
        {
            string sqlDelete = "UPDATE [tblParentCategory] SET [IsActive] = 0 WHERE [PK_ID] = " + id + "";//"DELETE FROM [tblParentCategory] WHERE [PK_ID] = " + id + "";
            return objDAL.ExecuteNonQuery(sqlDelete);
        }
    }
}