using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class GetShopDetails
    {
        DataAccessLogic objDAL = new DataAccessLogic();

        public long PK_RegShopId { get; set; }
        public int CFK_ID { get; set; }
        public int PFK_ID { get; set; }
        public int GFK_ID { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public string ShopName_M { get; set; }
        public string ShopName_E { get; set; }
        public string Description { get; set; }
        public string DetailAddress { get; set; }
        public int NearById { get; set; }
        public string NearByName { get; set; }
        public string LandlineNumber { get; set; }
        public string MobileNumber { get; set; }
        public string AlternetMobileNumber { get; set; }
        public string OpenTime { get; set; }
        public string CloseTime { get; set; }
        public string WebSite { get; set; }
        public string Offers { get; set; }
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public int IsCall { get; set; }

        public int Error { get; set; }

        public DataSet GetShopsDetails(string grandId, string parentId, string childId)
        {
            string sqlGetData = "SELECT [PK_ShopRegId],[GFK_ID],[PFK_ID],[CFK_ID],[ShopName_M],[ShopName_E],[Name_E],[Name_M],[Description],[DetailAddress],[NearBy]" +
      ",[NearByName],[LandlineNumber],[MobileNumber],[AlternetMobileNumber],[OpenTime],[CloseTime],[Website],[Offers],[Package],[PackageName],[FK_RegId]" +
      ",[InsertBy],[tblShopDetails].[InsertDate],[ModifyBy],[ModifyDate],[IsCall],[PK_ImageId],[ImageName],[ImagePath],[FK_ShopRegId]" +
      " FROM [tblShopDetails] INNER JOIN [tblShopImages] ON [FK_ShopRegId] = [PK_ShopRegId] WHERE [IsActive] = 1 AND [GFK_ID]=" + grandId + " AND [PFK_ID]=" + parentId + " AND [CFK_ID]=" + childId + "";

            return objDAL.ExecuteDataset(sqlGetData);
        }

        public DataSet GetShopsDetails(int id)
        {
            string sqlGetData = "SELECT [PK_ShopRegId],[GFK_ID],[PFK_ID],[CFK_ID],[ShopName_M],[ShopName_E],[Name_E],[Name_M],[Description],[DetailAddress],[NearBy]" +
      ",[NearByName],[LandlineNumber],[MobileNumber],[AlternetMobileNumber],[OpenTime],[CloseTime],[Website],[Offers],[Package],[PackageName],[FK_RegId]" +
      ",[InsertBy],[tblShopDetails].[InsertDate],[ModifyBy],[ModifyDate],[IsCall]" +
      " FROM [tblShopDetails] WHERE [PK_ShopRegId] = " + id + " AND [IsActive] = 1";

            return objDAL.ExecuteDataset(sqlGetData);
        }
    }
}