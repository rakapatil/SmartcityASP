using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartCityASP.App_Code.DAL;
using System.Data;

namespace SmartCityASP.App_Code.BAL
{
    public class GrandCategoryBAL
    {
        DataAccessLogic objDAL = new DataAccessLogic();
        public int PK_ID { get; set; }
        public string GName_E { get; set; }
        public string GName_M { get; set; }

        public int InsertGrandCategory(GrandCategoryBAL objGCBAL)
        {
            string sqlInsert = "INSERT INTO [tblGrandCategory] ([GName_M],[GName_E],[InsertBy],[InserDate],[IsActive],[IsUpdate]) " +
            "VALUES (N'" + objGCBAL.GName_M + "',N'" + objGCBAL.GName_E + "','9158696413','" + System.DateTime.Now + "',1,1)";
            return objDAL.ExecuteNonQuery(sqlInsert);
        }

        public int UpdateGrandCategory(GrandCategoryBAL objGCBAL)
        {
            string sqlUpdate = "UPDATE [tblGrandCategory] SET [GName_M] = N'" + objGCBAL.GName_M + "',[GName_E] = N'" + objGCBAL.GName_E + "' WHERE [PK_ID] = " + objGCBAL.PK_ID + "";
            return objDAL.ExecuteNonQuery(sqlUpdate);
        }

        public string GetMaxId()
        {
            try
            {
                string sqlGetId = "SELECT MAX([PK_ID]) FROM [tblGrandCategory]";
                int maxId = Convert.ToInt32(objDAL.ExecuteScalar(sqlGetId)) + 1;
                return maxId.ToString();
            }
            catch { return "1"; }
        }

        public DataSet GetGCDetails()
        {
            string sqlGetData = "SELECT * FROM [tblGrandCategory] WHERE [IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public DataSet BindGrandCDetails()
        {
            string sqlGetData = "SELECT [PK_ID],[GName_M]+' ('+[GName_E]+')' AS GName FROM [tblGrandCategory] WHERE [IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public DataSet GetGCDetails(int id)
        {
            string sqlGetData = "SELECT [PK_ID],[GName_M],[GName_E],[InsertBy],[InserDate] FROM [tblGrandCategory] WHERE [PK_ID] = " + id + " AND [IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public int DeleteGCategory(int id)
        {
            string sqlDelete = "UPDATE [tblGrandCategory] SET [IsActive] = 0 WHERE [PK_ID] = " + id + "";//"DELETE FROM [tblGrandCategory] WHERE [PK_ID] = " + id + "";
            return objDAL.ExecuteNonQuery(sqlDelete);
        }
    }
}