using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartCityASP.App_Code.DAL;
using System.Data;

namespace SmartCityASP.App_Code.BAL
{
    public class FiledItemMasterBAL
    {
        DataAccessLogic objDAL = new DataAccessLogic();

        public int PK_ID { get; set; }
        public int GFK_ID { get; set; }
        public string PName_E { get; set; }
        public string PName_M { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }

        public int InsertParentCategory(FiledItemMasterBAL objPCBAL)
        {
            string sqlInsert = "INSERT INTO [tblFieldItemMaster] ([FieldItemName_M],[FieldItemName_E],[FK_FieldId],[ImageName],[ImagePath],[IsActive]) " +
                               "VALUES (N'" + objPCBAL.PName_M + "',N'" + objPCBAL.PName_E + "'," + objPCBAL.GFK_ID + ",N'" + objPCBAL.ImageName + "',N'" + objPCBAL.ImagePath + "',1)";
            return objDAL.ExecuteNonQuery(sqlInsert);
        }

        public int UpdateParentCategory(FiledItemMasterBAL objPCBAL)
        {
            string sqlUpdate = "UPDATE [tblFieldItemMaster] SET [FieldItemName_M] = N'" + objPCBAL.PName_M + "',[FieldItemName_E] = N'" + objPCBAL.PName_E + "',[FK_FieldId] = " + objPCBAL.GFK_ID + " WHERE [FieldItemId] = " + objPCBAL.PK_ID + "";
            return objDAL.ExecuteNonQuery(sqlUpdate);
        }

        public string GetMaxId()
        {
            try
            {
                string sqlGetId = "SELECT MAX([FieldItemId]) FROM [tblFieldItemMaster]";
                int maxId = Convert.ToInt32(objDAL.ExecuteScalar(sqlGetId)) + 1;
                return maxId.ToString();
            }
            catch { return "1"; }
        }

        public DataSet GetPCDetails()
        {
            string sqlGetData = "SELECT * FROM [tblFieldItemMaster] WHERE [IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public DataSet GetPCDetails(int id)
        {
            string sqlGetData = "SELECT [FieldItemId],[FieldItemName_M],[FieldItemName_E],[FK_FieldId],[ImageName],[ImagePath] " +
                                "FROM   [tblFieldItemMaster] WHERE [FieldItemId] = " + id + " AND [IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public int DeletePCategory(int id)
        {
            string sqlDelete = "UPDATE [tblFieldItemMaster] SET [IsActive] = 0 WHERE [FieldItemId] = " + id + "";
            return objDAL.ExecuteNonQuery(sqlDelete);
        }
    }
}