using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace WebApi.Models
{
    public class TravelsTimeTable
    {
        DataAccessLogic objDAL = new DataAccessLogic();
        public string TravelsId { get; set; }
        public string BusInformation { get; set; }
        public string RouteId { get; set; }
        public string DayPaharId { get; set; }
        public string DayPaharName { get; set; }
        public string Time { get; set; }

        public DataSet GetTravelsDetails(int routeId)
        {
            string sqlGetData = "SELECT * FROM [tblTravelTimeTable] WHERE [IsActive] = 1 AND [FK_RouteId]=" + routeId + "";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public DataSet GetRoutesDetails()
        {
            //string sqlGetData = "SELECT * FROM [tblRouteDetails] WHERE [IsActive] = 1";
            string sqlGetData = "SELECT [PK_RouteId],[SourcePlace_M],[DestinationPlace_M],[SourcePlace_E],[DestinationPlace_E]," +
                                "[PK_TravelId],[Time],[Description],[DayPaharId],[DayPaharName]" +
                                "FROM [tblRouteDetails] INNER JOIN [tblTravelTimeTable]" +
                                "ON [PK_RouteId] = [FK_RouteId]" +
                                "WHERE [tblRouteDetails].[IsActive] = 1 AND [tblTravelTimeTable].[IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }
    }
}