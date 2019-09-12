using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartCityASP.App_Code.DAL;
using System.Data;

namespace SmartCityASP.App_Code.BAL
{
    public class ChildCategoryBAL
    {
        DataAccessLogic objDAL = new DataAccessLogic();

        public int PK_ID { get; set; }
        public int PFK_ID { get; set; }
        public string CName_E { get; set; }
        public string CName_M { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public int GFK_ID { get; set; }
        public int IsCall { get; set; }
        public int IsSubCategory { get; set; }

        public int InsertChildCategory(ChildCategoryBAL objCCBAL)
        {
            string sqlInsert = "INSERT INTO [tblChildCategory] ([CName_M],[CName_E],[PFK_ID],[GFK_ID],[ImageName],[ImagePath],[InsertBy],[InsertDate],[IsCall],[IsActive],[IsUpdate],[IsSubCategory]) " +
                               "VALUES (N'" + objCCBAL.CName_M + "',N'" + objCCBAL.CName_E + "'," + objCCBAL.PFK_ID + "," + objCCBAL.GFK_ID + ",N'" + objCCBAL.ImageName + "',N'" + objCCBAL.ImagePath + "','9158696413','" + System.DateTime.Now + "'," + objCCBAL.IsCall + ",'1','1'," + objCCBAL.IsSubCategory + ")";
            return objDAL.ExecuteNonQuery(sqlInsert);
        }

        public int UpdateChildCategory(ChildCategoryBAL objCCBAL)
        {
            string sqlUpdate = "UPDATE [tblChildCategory] SET [CName_M] = N'" + objCCBAL.CName_M + "',[CName_E] = N'" + objCCBAL.CName_E + "',[PFK_ID] = " + objCCBAL.PFK_ID + ",[GFK_ID] = " + objCCBAL.GFK_ID + ",[IsCall] = " + objCCBAL.IsCall + ",[IsSubCategory] = " + objCCBAL.IsSubCategory + " WHERE [PK_ID] = " + objCCBAL.PK_ID + "";
            return objDAL.ExecuteNonQuery(sqlUpdate);
        }

        public string GetMaxId()
        {
            try
            {
                string sqlGetId = "SELECT MAX([PK_ID]) FROM [tblChildCategory]";
                int maxId = Convert.ToInt32(objDAL.ExecuteScalar(sqlGetId)) + 1;
                return maxId.ToString();
            }
            catch { return "1"; }
        }

        public DataSet GetCCDetails()
        {
            string sqlGetData = "SELECT * FROM [tblChildCategory] WHERE [IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public DataSet GetParentCategoryByGrand(int grandCategoryId)
        {
            string sqlGetData = "SELECT [PK_ID],[PName_M]+' ('+[PName_E]+')' AS PName FROM [tblParentCategory] WHERE [GFK_ID] = " + grandCategoryId + " AND [IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public DataSet GetCCDetails(int id)
        {
            string sqlGetData = "SELECT [PK_ID],[CName_M],[CName_E],[PFK_ID],[GFK_ID],[ImageName],[ImagePath],[InsertBy],[InsertDate],[IsCall],[IsSubCategory] " +
                                "FROM   [tblChildCategory] WHERE [PK_ID] = " + id + " AND [IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public int DeleteCCategory(int id)
        {
            string sqlDelete = "UPDATE [tblChildCategory] SET [IsActive] = 0 WHERE [PK_ID] = " + id + "";//"DELETE FROM [tblChildCategory] WHERE [PK_ID] = " + id + "";
            return objDAL.ExecuteNonQuery(sqlDelete);
        }
    }
}