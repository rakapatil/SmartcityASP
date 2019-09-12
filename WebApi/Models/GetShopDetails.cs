using System.Data;
using System.Data.SqlClient;

namespace WebApi.Models
{
    public class GetShopDetails
    {
        DataAccessLogic objDAL = new DataAccessLogic();

        public string PK_RegShopId { get; set; }
        public string CFK_ID { get; set; }
        public string PFK_ID { get; set; }
        public string GFK_ID { get; set; }
        public string SCFK_ID { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public string ShopName_M { get; set; }
        public string ShopName_E { get; set; }
        public string Description { get; set; }
        public string DetailAddress { get; set; }
        public string NearById { get; set; }
        public string NearByName { get; set; }
        public string LandlineNumber { get; set; }
        public string MobileNumber { get; set; }
        public string AlternetMobileNumber { get; set; }
        public string OpenTime { get; set; }
        public string CloseTime { get; set; }
        public string WebSite { get; set; }
        public string Offers { get; set; }
        public string PackageId { get; set; }
        public string PackageName { get; set; }
        public string IsCall { get; set; }


        public DataSet GetShopsDetails(string grandId, string parentId, string childId, string subChildId, string maxId)
        {
            //      string sqlGetData = "SELECT [PK_ShopRegId],[GFK_ID],[PFK_ID],[CFK_ID],[ShopName_M],[ShopName_E],[Name_E],[Name_M],[Description],[DetailAddress],[NearBy]" +
            //",[NearByName],[LandlineNumber],[MobileNumber],[AlternetMobileNumber],[OpenTime],[CloseTime],[Website],[Offers],[Package],[PackageName],[FK_RegId]" +
            //",[InsertBy],[tblShopDetails].[InsertDate],[ModifyBy],[ModifyDate],[IsCall],[SCFK_ID],[PK_ImageId],[ImageName],[ImagePath],[FK_ShopRegId]" +
            //" FROM [tblShopDetails] LEFT OUTER JOIN [tblShopImages] ON [FK_ShopRegId] = [PK_ShopRegId] WHERE [IsActive] = 1 AND [GFK_ID]=" + grandId + " AND [PFK_ID]=" + parentId + " AND [CFK_ID]=" + childId + " AND [SCFK_ID] = " + subChildId + " AND [PK_ShopRegId] > " + maxId + "";

            string sqlGetData = "GetShopDetails";
            SqlParameter[] parameter = new SqlParameter[]
                        {
                            new SqlParameter("@grandId",grandId),
                            new SqlParameter("@parentId",parentId),
                            new SqlParameter("@childId",childId),
                            new SqlParameter("@subChildId",subChildId),
                            new SqlParameter("@maxId",maxId)
                        };

            return objDAL.ExecuteDataset(sqlGetData, CommandType.StoredProcedure, parameter);
        }

        public DataSet GetUpdatedShops()
        {
            string sqlGetData = "SELECT [PK_ShopRegId],[GFK_ID],[PFK_ID],[CFK_ID],[ShopName_M],[ShopName_E],[Name_E],[Name_M],[Description],[DetailAddress],[NearBy]" +
                 ",[NearByName],[LandlineNumber],[MobileNumber],[AlternetMobileNumber],[OpenTime],[CloseTime],[Website],[Offers],[Package],[PackageName],[FK_RegId]" +
                 ",[InsertBy],[tblShopDetails].[InsertDate],[ModifyBy],[ModifyDate],[IsCall],[SCFK_ID],[PK_ImageId],[ImageName],[ImagePath],[FK_ShopRegId]" +
                 " FROM [tblShopDetails] LEFT OUTER JOIN [tblShopImages] ON [FK_ShopRegId] = [PK_ShopRegId] WHERE [IsActive] = 1 AND [IsUpdate] = 0";

            return objDAL.ExecuteDataset(sqlGetData);
        }

        public DataSet GetSliderImages()
        {
            string sqlGetData = "SELECT [PK_SliderId],[Caption],[ImageName],[ImagePath],[IsActive] FROM [tblSliderImages] WHERE [IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public DataSet GetScrollingAds()
        {
            string sqlGetData = "SELECT [PK_ScrollAdsId],[Description],[IsActive] FROM [tblSliderImages] WHERE [IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public DataSet GetDeletedShopsId()
        {
            string sqlGetData = "SELECT DISTINCT [PK_ShopRegId] FROM [tblShopDetails] WHERE [IsActive] = 0";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public DataSet GetMoreShopImages(string ShopId)
        {
            string sqlGetData = "SELECT [FK_ShopRegId] AS ShopId,[ImageName] FROM [tblShopImages] WHERE [FK_ShopRegId] = " + ShopId + "";
            return objDAL.ExecuteDataset(sqlGetData);
        }
    }
}