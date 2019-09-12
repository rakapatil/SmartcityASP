using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartCityASP.App_Code.DAL;
using System.Data;

namespace SmartCityASP.App_Code.BAL
{
    public class HolyTouristBAL
    {
        DataAccessLogic objDAL = new DataAccessLogic();

        //Properties 
        public long PK_HolyId { get; set; }
        public int CFK_ID { get; set; }
        public int PFK_ID { get; set; }
        public int GFK_ID { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public string PlaceName_M { get; set; }
        public string PlaceName_E { get; set; }
        public string PlaceHistory { get; set; }
        public string PlaceFestivals { get; set; }
        public int NearById { get; set; }
        public string NearByName { get; set; }
        public string DistanceFromCity { get; set; }
        public int RouteId { get; set; }
        public int PlaceTypeId { get; set; }

        public string GetMaxId()
        {
            try
            {
                string sqlGetId = "SELECT MAX([PK_ImageId]) FROM [tblHolyTouristPlaces]";
                int maxId = Convert.ToInt32(objDAL.ExecuteScalar(sqlGetId)) + 1;
                return maxId.ToString();
            }
            catch { return "1"; }
        }

        public int InsertShopDetails(HolyTouristBAL objHoly)
        {
            try
            {
                string sqlInsertShop = "INSERT INTO [tblHolyTouristPlaces] ([Name_M]" +
      ",[Name_E]" +
      ",[GFK_ID]" +
      ",[PFK_ID]" +
      ",[CFK_ID]" +
      ",[PlaceHistory]" +
      ",[PlaceUstav]" +
      ",[DistanceFromCity]" +
      ",[InsertDate],[IsActive],[RouteId],[PlaceTypeId]) VALUES (N'" + objHoly.PlaceName_M + "',N'" + objHoly.PlaceName_E + "'," + objHoly.GFK_ID + "," + objHoly.PFK_ID + "," + objHoly.CFK_ID + ",N'" + objHoly.PlaceHistory + "',N'" + objHoly.PlaceFestivals + "',N'" + objHoly.DistanceFromCity + "','" + System.DateTime.Now + "',1," + objHoly.RouteId + "," + objHoly.PlaceTypeId + ")";
                objDAL.ExecuteNonQuery(sqlInsertShop);

                string sqlGetId = "SELECT MAX([PK_HTPId]) FROM [tblHolyTouristPlaces]";
                int maxId = Convert.ToInt32(objDAL.ExecuteScalar(sqlGetId));

                string[] arrName = objHoly.ImageName.Split(',');
                for (int i = 0; i < arrName.Length - 1; i++)
                {
                    objHoly.ImageName = arrName[i].ToString();
                    objHoly.ImagePath = objHoly.ImagePath + arrName[i].ToString();

                    string sqlInsertImg = "INSERT INTO [tblTouristPlaceImages] ([ImageName],[ImagePath],[FK_HTPId],[InsertDate]) VALUES (N'" + objHoly.ImageName + "',N'" + objHoly.ImagePath + "','" + maxId + "','" + System.DateTime.Now + "')";
                    objDAL.ExecuteNonQuery(sqlInsertImg);
                    objHoly.ImagePath = @"http://jitendrapatil-001-site1.ctempurl.com/Images/HolyImages/";
                }
                return 1;
            }
            catch { return 0; }
        }

        public int UpdateShopDetails(HolyTouristBAL objHoly)
        {
            try
            {
                string sqlUpdate = "UPDATE [tblHolyTouristPlaces] SET [Name_M] = N'" + objHoly.PlaceName_M + "'" +
      ",[Name_E] = N'" + objHoly.PlaceName_E + "'" +
      ",[GFK_ID] = " + objHoly.GFK_ID + "" +
      ",[PFK_ID] = " + objHoly.PFK_ID + "" +
      ",[CFK_ID] = " + objHoly.CFK_ID + "" +
      ",[PlaceHistory] = N'" + objHoly.PlaceHistory + "'" +
      ",[PlaceUstav] = N'" + objHoly.PlaceFestivals + "'" +
      ",[DistanceFromCity] = N'" + objHoly.DistanceFromCity + "',[RouteId]=" + objHoly.RouteId + ",[PlaceTypeId]=" + objHoly.PlaceTypeId + " WHERE [PK_HTPId] = " + objHoly.PK_HolyId + "";
                return objDAL.ExecuteNonQuery(sqlUpdate);
            }
            catch
            { return 0; }
        }

        public DataSet GetHolyTouristPlaceDetails()
        {
            string sqlGetData = "SELECT [PK_HTPId],[Name_M]+' ('+[Name_E]+')' AS HolyName,[GFK_ID],[PFK_ID],[CFK_ID],[PlaceHistory],[PlaceUstav],[DistanceFromCity]," +
         "[tblHolyTouristPlaces].[InsertDate],[NearById],[NearByName],[IsActive],[RouteId],[PlaceTypeId],[PK_ImageId],[ImageName]," +
         "[ImagePath],[FK_HTPId]" +
         "FROM [tblHolyTouristPlaces] LEFT OUTER JOIN [tblTouristPlaceImages] ON [FK_HTPId] = [PK_HTPId]" +
         "WHERE [IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public DataSet GetHolyTouristPlaceDetails(int id)
        {
            string sqlGetData = "SELECT [PK_HTPId],[Name_M],[Name_E],[GFK_ID],[PFK_ID],[CFK_ID],[PlaceHistory],[PlaceUstav],[DistanceFromCity],[InsertDate],[NearById],[NearByName],[RouteId],[PlaceTypeId] FROM [tblHolyTouristPlaces] WHERE [PK_HTPId] = '" + id + "' AND [IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public int DeletePlace(int id)
        {
            string sqlDelete = "UPDATE [tblHolyTouristPlaces] SET [IsActive] = 0 WHERE [PK_HTPId] = " + id + "";
            return objDAL.ExecuteNonQuery(sqlDelete);
        }
    }
}