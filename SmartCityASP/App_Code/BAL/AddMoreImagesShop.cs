using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartCityASP.App_Code.DAL;
using System.Data;


namespace SmartCityASP.App_Code.BAL
{
    public class AddMoreImagesShop
    {
        DataAccessLogic objDAL = new DataAccessLogic();

        public int SliderImageId { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public string maxId { get; set; }

        public string GetMaxId()
        {
            try
            {
                string sqlGetId = "SELECT MAX([PK_ImageId]) FROM [tblShopImages]";
                int maxId = Convert.ToInt32(objDAL.ExecuteScalar(sqlGetId)) + 1;
                return maxId.ToString();
            }
            catch { return "1"; }
        }

        public int InsertSliderImages(AddMoreImagesShop objSlider)
        {
            try
            {
                string[] arrName = objSlider.ImageName.Split(',');
                for (int i = 0; i < arrName.Length - 1; i++)
                {
                    objSlider.ImageName = arrName[i].ToString();
                    objSlider.ImagePath = objSlider.ImagePath + arrName[i].ToString();

                    string sqlInsertImg = "INSERT INTO [tblShopImages] ([ImageName],[ImagePath],[FK_ShopRegId],[InsertDate]) VALUES ('" + objSlider.ImageName + "','" + objSlider.ImagePath + "','" + objSlider.maxId + "','" + System.DateTime.Now + "')";
                    objDAL.ExecuteNonQuery(sqlInsertImg);
                    objSlider.ImagePath = @"http://jitendrapatil-001-site1.ctempurl.com/Images/ShopImages/";
                }
                return 1;
            }
            catch { return 0; }
        }

        public DataSet GetSliderImageDetails()
        {
            string sqlGetData = "SELECT [PK_ImageId],[ImageName],[ImagePath],[ShopName_M]+' ('+[ShopName_E]+')' AS ShopName " +
                                "FROM [tblShopDetails] INNER JOIN [tblShopImages] " +
                                "ON [FK_ShopRegId] = [PK_ShopRegId]" +
                                "WHERE [IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public DataSet GetSliderImageDetails(string shopName)
        {
            string sqlGetData = "SELECT [PK_ImageId],[ImageName],[ImagePath],[ShopName_M]+' ('+[ShopName_E]+')' AS ShopName " +
                                "FROM [tblShopDetails] INNER JOIN [tblShopImages] " +
                                "ON [FK_ShopRegId] = [PK_ShopRegId]" +
                                "WHERE [IsActive] = 1 AND [ShopName_E] LIKE '%" + shopName + "%'";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public DataSet GetShopDetails()
        {
            string sqlGetData = "SELECT [PK_ShopRegId],[ShopName_M]+' ('+[ShopName_E]+')' AS ShopName " +
                                "FROM [tblShopDetails] " +
                                "WHERE [IsActive] = 1 ORDER BY [PK_ShopRegId] DESC";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public int DeleteImage(int id)
        {
            string sqlDelete = "DELETE [tblShopImages] WHERE [PK_ImageId] = " + id + "";
            return objDAL.ExecuteNonQuery(sqlDelete);
        }
    }
}