using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartCityASP.App_Code.DAL;
using System.Data;

namespace SmartCityASP.App_Code.BAL
{
    public class FieldItemBAL
    {
        DataAccessLogic objDAL = new DataAccessLogic();
        public int PK_ID { get; set; }
        public string GName_E { get; set; }
        public string GName_M { get; set; }

        public int InsertGrandCategory(FieldItemBAL objGCBAL)
        {
            string sqlInsert = "INSERT INTO [tblFieldItem] ([FieldName_M],[FieldName_E],[IsActive]) " +
            "VALUES (N'" + objGCBAL.GName_M + "',N'" + objGCBAL.GName_E + "',1)";
            return objDAL.ExecuteNonQuery(sqlInsert);
        }

        public int UpdateGrandCategory(FieldItemBAL objGCBAL)
        {
            string sqlUpdate = "UPDATE [tblFieldItem] SET [FieldName_M] = N'" + objGCBAL.GName_M + "',[FieldName_E] = N'" + objGCBAL.GName_E + "' WHERE [FieldId] = " + objGCBAL.PK_ID + "";
            return objDAL.ExecuteNonQuery(sqlUpdate);
        }

        public string GetMaxId()
        {
            try
            {
                string sqlGetId = "SELECT MAX([FieldId]) FROM [tblFieldItem]";
                int maxId = Convert.ToInt32(objDAL.ExecuteScalar(sqlGetId)) + 1;
                return maxId.ToString();
            }
            catch { return "1"; }
        }

        public DataSet GetGCDetails()
        {
            string sqlGetData = "SELECT * FROM [tblFieldItem] WHERE [IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public DataSet BindGrandCDetails()
        {
            string sqlGetData = "SELECT [FieldId],[FieldName_M]+' ('+[FieldName_E]+')' AS GName FROM [tblFieldItem] WHERE [IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public DataSet GetGCDetails(int id)
        {
            string sqlGetData = "SELECT [FieldId],[FieldName_M],[FieldName_E] FROM [tblFieldItem] WHERE [FieldId] = " + id + " AND [IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public int DeleteGCategory(int id)
        {
            string sqlDelete = "UPDATE [tblFieldItem] SET [IsActive] = 0 WHERE [FieldId] = " + id + "";
            return objDAL.ExecuteNonQuery(sqlDelete);
        }
    }
}