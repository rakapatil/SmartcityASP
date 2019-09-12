using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartCityASP.App_Code.DAL;
using System.Data;

namespace SmartCityASP.App_Code.BAL
{
    public class SliderImagesBAL
    {
        DataAccessLogic objDAL = new DataAccessLogic();

        public int SliderImageId { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public string Caption { get; set; }

        public string GetMaxId()
        {
            try
            {
                string sqlGetId = "SELECT MAX([PK_SliderId]) FROM [tblSliderImages]";
                int maxId = Convert.ToInt32(objDAL.ExecuteScalar(sqlGetId)) + 1;
                return maxId.ToString();
            }
            catch { return "1"; }
        }

        public int InsertSliderImages(SliderImagesBAL objSlider)
        {
            try
            {
                string[] arrName = objSlider.ImageName.Split(',');
                for (int i = 0; i < arrName.Length - 1; i++)
                {
                    objSlider.ImageName = arrName[i].ToString();
                    objSlider.ImagePath = objSlider.ImagePath + arrName[i].ToString();

                    string sqlInsertImg = "INSERT INTO [tblSliderImages] ([Caption],[ImageName],[ImagePath],[IsActive]) VALUES (N'" + objSlider.Caption + "',N'" + objSlider.ImageName + "',N'" + objSlider.ImagePath + "',1)";
                    objDAL.ExecuteNonQuery(sqlInsertImg);
                    objSlider.ImagePath = @"http://jitendrapatil-001-site1.ctempurl.com/Images/SliderImages/";
                }
                return 1;
            }
            catch { return 0; }
        }

        public int UpdateSliderImages(SliderImagesBAL objSlider)
        {
            try
            {
                string sqlUpdate = "UPDATE [tblSliderImages] SET [Caption] = N'" + objSlider.Caption + "' WHERE [PK_SliderId] = " + objSlider.SliderImageId + "";
                objDAL.ExecuteNonQuery(sqlUpdate);
                return 1;
            }
            catch
            { return 0; }
        }

        public DataSet GetSliderImageDetails()
        {
            string sqlGetData = "SELECT * FROM [tblSliderImages] WHERE [IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public DataSet GetSliderImageDetails(int id)
        {
            string sqlGetData = "SELECT [PK_SliderId],[Caption],[ImageName],[ImagePath],[IsActive] FROM [tblSliderImages] WHERE [PK_SliderId] = '" + id + "' AND [IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public int DeleteImage(int id)
        {
            string sqlDelete = "UPDATE [tblSliderImages] SET [IsActive] = 0 WHERE [PK_SliderId] = " + id + "";
            return objDAL.ExecuteNonQuery(sqlDelete);
        }
    }
}