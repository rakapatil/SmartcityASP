using SmartCityASP.App_Code.DAL;
using System;
using System.Data;
using System.Web.Configuration;

namespace SmartCityASP.App_Code.BAL
{
    public class RegisterShopBAL
    {
        DataAccessLogic objDAL = new DataAccessLogic();

        //Properties For Shop Registration
        public long PK_RegShopId { get; set; }
        public int SCFK_ID { get; set; }
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
        public int IsPaid { get; set; }

        //Properties For User Registration
        public long PK_RegId { get; set; }
        public string Name_M { get; set; }
        public string Name_E { get; set; }
        public string UserPassword { get; set; }
        public string EmailId { get; set; }
        public int LanguageId { get; set; }
        public string Pincode { get; set; }
        public decimal Lattitude { get; set; }
        public decimal Longitude { get; set; }
        public string ImeiNumber { get; set; }
        public string IpAddress { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string UserName { get; set; }

        private string _imageUploadUrl = WebConfigurationManager.AppSettings["websiteBaseUrl"] + @"/Images/ShopImages/";

        public string GetMaxId()
        {
            try
            {
                string sqlGetId = "SELECT MAX([PK_ShopRegId]) FROM [tblShopDetails]";
                int maxId = Convert.ToInt32(objDAL.ExecuteScalar(sqlGetId)) + 1;
                return maxId.ToString();
            }
            catch { return "1"; }
        }

        public DataSet GetCCDetailsbyParentId(int parentCategoryId)
        {
            string sqlGetData = "SELECT [PK_ID],[CName_M]+' ('+[CName_E]+')' AS CName FROM [tblChildCategory] WHERE [PFK_ID] = " + parentCategoryId + " AND [IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public int InsertShopDetails(RegisterShopBAL objRegShop)
        {
            try
            {
                string sqlInsertShop = "INSERT INTO [tblShopDetails] ([GFK_ID]" +
          ",[PFK_ID]" +
          ",[CFK_ID]" +
          ",[ShopName_M]" +
          ",[ShopName_E]" +
          ",[Name_E]" +
          ",[Name_M]" +
          ",[Description]" +
          ",[DetailAddress]" +
          ",[NearBy]" +
          ",[NearByName]" +
          ",[LandlineNumber]" +
          ",[MobileNumber]" +
          ",[AlternetMobileNumber]" +
          ",[OpenTime]" +
          ",[CloseTime]" +
          ",[Website]" +
          ",[Offers]" +
          ",[Package]" +
          ",[PackageName]" +
          ",[FK_RegId]" +
          ",[InsertBy]" +
          ",[InsertDate],[IsActive],[IsUpdate],[IsCall],[SCFK_ID],[IsPaid]) VALUES (" + objRegShop.GFK_ID + "," + objRegShop.PFK_ID + "," + objRegShop.CFK_ID + ",N'" + objRegShop.ShopName_M + "',N'" + objRegShop.ShopName_E + "',N'" + objRegShop.Name_E + "',N'" + objRegShop.Name_M + "',N'" + objRegShop.Description + "',N'" + objRegShop.DetailAddress + "'," + objRegShop.NearById + ",N'" + objRegShop.NearByName + "',N'" + objRegShop.LandlineNumber + "',N'" + objRegShop.MobileNumber + "',N'" + objRegShop.AlternetMobileNumber + "',N'" + objRegShop.OpenTime + "',N'" + objRegShop.CloseTime + "',N'" + objRegShop.WebSite + "',N'" + objRegShop.Offers + "'," + objRegShop.PackageId + ",N'" + objRegShop.PackageName + "','1','" + objRegShop.UserName + "','" + System.DateTime.Now + "',1,1," + objRegShop.IsCall + "," + objRegShop.SCFK_ID + "," + objRegShop.IsPaid + ")";
                objDAL.ExecuteNonQuery(sqlInsertShop);

                string sqlGetId = "SELECT MAX([PK_ShopRegId]) FROM [tblShopDetails]";
                int maxId = Convert.ToInt32(objDAL.ExecuteScalar(sqlGetId));

                string[] arrName = objRegShop.ImageName.Split(',');
                for (int i = 0; i < arrName.Length - 1; i++)
                {
                    objRegShop.ImageName = arrName[i].ToString();
                    objRegShop.ImagePath = _imageUploadUrl + arrName[i].ToString();

                    string sqlInsertImg = "INSERT INTO [tblShopImages] ([ImageName],[ImagePath],[FK_ShopRegId],[InsertDate]) VALUES ('" + objRegShop.ImageName + "','" + objRegShop.ImagePath + "','" + maxId + "','" + System.DateTime.Now + "')";
                    objDAL.ExecuteNonQuery(sqlInsertImg);
                    objRegShop.ImagePath = _imageUploadUrl;
                }
                return 1;
            }
            catch { return 0; }
        }

        public int UpdateShopDetails(RegisterShopBAL objRegShop)
        {
            try
            {
                string sqlUpdate = "UPDATE [tblShopDetails] SET [GFK_ID] = " + objRegShop.GFK_ID + "" +
          ",[PFK_ID] = " + objRegShop.PFK_ID + "" +
          ",[CFK_ID] = " + objRegShop.CFK_ID + "" +
          ",[ShopName_M] = N'" + objRegShop.ShopName_M + "'" +
          ",[ShopName_E] = N'" + objRegShop.ShopName_E + "'" +
          ",[Name_E] = N'" + objRegShop.Name_E + "'" +
          ",[Name_M] = N'" + objRegShop.Name_M + "'" +
          ",[Description] = N'" + objRegShop.Description + "'" +
          ",[DetailAddress] = N'" + objRegShop.DetailAddress + "'" +
          ",[NearBy] = " + objRegShop.NearById + "" +
          ",[NearByName] = N'" + objRegShop.NearByName + "'" +
          ",[LandlineNumber] = N'" + objRegShop.LandlineNumber + "'" +
          ",[MobileNumber] = N'" + objRegShop.MobileNumber + "'" +
          ",[AlternetMobileNumber] = N'" + objRegShop.AlternetMobileNumber + "'" +
          ",[OpenTime] = N'" + objRegShop.OpenTime + "'" +
          ",[CloseTime] = N'" + objRegShop.CloseTime + "'" +
          ",[Website] = N'" + objRegShop.WebSite + "'" +
          ",[Offers] = N'" + objRegShop.Offers + "'" +
          ",[Package] = " + objRegShop.PackageId + "" +
          ",[PackageName] = N'" + objRegShop.PackageName + "'" +
          ",[FK_RegId] = 1" +
          ",[ModifyBy] = '" + objRegShop.UserName + "'" +
          ",[ModifyDate] = '" + DateTime.Now + "',[SCFK_ID]=" + objRegShop.SCFK_ID + ",[IsUpdate] = 0,[IsPaid]=" + objRegShop.IsPaid + " WHERE [PK_ShopRegId] = " + objRegShop.PK_RegShopId + "";

                var delImages = DeleteShopImages(objRegShop.PK_RegShopId);

                string[] arrName = objRegShop.ImageName.Split(',');
                for (int i = 0; i < arrName.Length - 1; i++)
                {
                    objRegShop.ImageName = arrName[i].ToString();
                    objRegShop.ImagePath = _imageUploadUrl + arrName[i].ToString();

                    string sqlInsertImg = "INSERT INTO [tblShopImages] ([ImageName],[ImagePath],[FK_ShopRegId],[InsertDate]) VALUES ('" + objRegShop.ImageName + "','" + objRegShop.ImagePath + "','" + objRegShop.PK_RegShopId + "','" + System.DateTime.Now + "')";
                    objDAL.ExecuteNonQuery(sqlInsertImg);
                    objRegShop.ImagePath = _imageUploadUrl;
                }

                return objDAL.ExecuteNonQuery(sqlUpdate);
            }
            catch
            {
                return 0;
            }
        }

        public DataSet GetShopsDetails()
        {
            string sqlGetData = "SELECT [PK_ShopRegId],[GFK_ID],[PFK_ID],[CFK_ID],[SCFK_ID],[ShopName_M]+' ('+[ShopName_E]+')' AS ShopName,[Name_E]+' ('+[Name_M]+')' AS OwnerName,[Description],[DetailAddress],[NearBy]" +
      ",[NearByName],[LandlineNumber],[MobileNumber],[AlternetMobileNumber],[OpenTime],[CloseTime],[Website],[Offers],[Package],[PackageName],[FK_RegId]" +
      ",[InsertBy],[tblShopDetails].[InsertDate],[ModifyBy],[ModifyDate],[IsCall],[IsPaid],[PK_ImageId],[ImageName],[ImagePath],[FK_ShopRegId]" +
      " FROM [tblShopDetails] LEFT OUTER JOIN [tblShopImages] ON [FK_ShopRegId] = [PK_ShopRegId] WHERE [IsActive] = 1 ORDER BY [PK_ShopRegId] DESC";

            return objDAL.ExecuteDataset(sqlGetData);
        }

        public DataSet GetShopsDetails(string value)
        {
            string sqlGetData = "SELECT [PK_ShopRegId],[GFK_ID],[PFK_ID],[CFK_ID],[SCFK_ID],[ShopName_M]+' ('+[ShopName_E]+')' AS ShopName,[Name_E]+' ('+[Name_M]+')' AS OwnerName,[Description],[DetailAddress],[NearBy]" +
      ",[NearByName],[LandlineNumber],[MobileNumber],[AlternetMobileNumber],[OpenTime],[CloseTime],[Website],[Offers],[Package],[PackageName],[FK_RegId]" +
      ",[InsertBy],[tblShopDetails].[InsertDate],[ModifyBy],[ModifyDate],[IsCall],[IsPaid],[PK_ImageId],[ImageName],[ImagePath],[FK_ShopRegId]" +
      " FROM [tblShopDetails] LEFT OUTER JOIN [tblShopImages] ON [FK_ShopRegId] = [PK_ShopRegId] WHERE [IsActive] = 1 AND [ShopName_E] LIKE '%" + value + "%' ORDER BY [PK_ShopRegId] DESC";

            return objDAL.ExecuteDataset(sqlGetData);
        }

        public DataSet GetShopsDetails(int id)
        {
            string sqlGetData = "SELECT [PK_ShopRegId],[GFK_ID],[PFK_ID],[CFK_ID],[SCFK_ID],[ShopName_M],[ShopName_E],[Name_E],[Name_M],[Description],[DetailAddress],[NearBy]" +
      ",[NearByName],[LandlineNumber],[MobileNumber],[AlternetMobileNumber],[OpenTime],[CloseTime],[Website],[Offers],[Package],[PackageName],[FK_RegId]" +
      ",[InsertBy],[tblShopDetails].[InsertDate],[ModifyBy],[ModifyDate],[IsCall],[IsPaid]" +
      " FROM [tblShopDetails] WHERE [PK_ShopRegId] = " + id + " AND [IsActive] = 1 ";

            sqlGetData += "SELECT [PK_ImageId],[ImageName],[ImagePath],[FK_ShopRegId] FROM [tblShopImages] WHERE [FK_ShopRegId] = " + id + "";

            return objDAL.ExecuteDataset(sqlGetData);
        }

        public int DeleteShop(int id)
        {
            string sqlDelete = "UPDATE [tblShopDetails] SET [IsActive] = 0 WHERE [PK_ShopRegId] = " + id + "";
            return objDAL.ExecuteNonQuery(sqlDelete);
        }

        public DataSet GetNearBy()
        {
            string sqlNearBy = "SELECT [FieldItemId],[FieldItemName_M]+' ('+[FieldItemName_E]+')' AS FieldItemName FROM [tblFieldItemMaster] WHERE [FK_FieldId] = 1";
            return objDAL.ExecuteDataset(sqlNearBy);
        }

        public DataSet GetSubChildCategory(int childCategoryId)
        {
            string sqlSelect = "SELECT [PK_ID],[SCName_M]+' ('+[SCName_E]+')' AS SCName FROM [tblSubChildCategory] WHERE [CFK_ID] = " + childCategoryId + "";
            return objDAL.ExecuteDataset(sqlSelect);
        }

        public int DeleteShopImages(long shopId)
        {
            string query = "DELETE FROM [tblShopImages] WHERE [FK_ShopRegId] = " + shopId + "";
            return objDAL.ExecuteNonQuery(query);
        }
    }
}