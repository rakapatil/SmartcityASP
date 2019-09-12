using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class HolyTouristPlaces
    {
        DataAccessLogic objDAL = new DataAccessLogic();

        public string PK_HolyId { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public string PlaceName_M { get; set; }
        public string PlaceName_E { get; set; }
        public string PlaceHistory { get; set; }
        public string PlaceFestivals { get; set; }
        public string DistanceFromCity { get; set; }
        public string RouteId { get; set; }
        public string PlaceTypeId { get; set; }

        public DataSet GetHolyTouristPlaceDetails()
        {
            string sqlGetData = "SELECT [PK_HTPId],[Name_M],[Name_E],[GFK_ID],[PFK_ID],[CFK_ID],[PlaceHistory],[PlaceUstav],[DistanceFromCity]," +
         "[tblHolyTouristPlaces].[InsertDate],[NearById],[NearByName],[IsActive],[RouteId],[PlaceTypeId],[PK_ImageId],[ImageName]," +
         "[ImagePath],[FK_HTPId]" +
         "FROM [tblHolyTouristPlaces] LEFT OUTER JOIN [tblTouristPlaceImages] ON [FK_HTPId] = [PK_HTPId]" +
         "WHERE [IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }
    }
}