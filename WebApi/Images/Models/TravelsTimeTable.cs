using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class TravelsTimeTable
    {
        DataAccessLogic objDAL = new DataAccessLogic();

        //Public Properties For Routes Details
        public string RouteId { get; set; }
        public string SourcePlace_M { get; set; }
        public string SourcePlace_E { get; set; }
        public string DestinationPlace_M { get; set; }
        public string DestinationPlace_E { get; set; }

        //Public Properties For Travels Time
        public string TravelsId { get; set; }
        public string BusInformation { get; set; }
        //public int RouteId { get; set; }
        public string DayPaharId { get; set; }
        public string DayPaharName { get; set; }
        public string Time { get; set; }

        public int Error { get; set; }

        public DataSet GetRoutesDetails()
        {
            string sqlGetData = "SELECT * FROM [tblRouteDetails] WHERE [IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public DataSet GetRoutesDetails(int id)
        {
            string sqlGetData = "SELECT [PK_RouteId],[SourcePlace_M],[DestinationPlace_M],[SourcePlace_E],[DestinationPlace_E] " +
                                "FROM   [tblRouteDetails] WHERE [PK_RouteId] = " + id + " AND [IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public DataSet GetTravelsDetails()
        {
            string sqlGetData = "SELECT * FROM [tblTravelTimeTable] WHERE [IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public DataSet GetTravelsDetails(int id)
        {
            string sqlGetData = "SELECT [PK_TravelId],[FK_RouteId],[Time],[Description],[DayPaharId],[DayPaharName] " +
                                "FROM   [tblTravelTimeTable] WHERE [FK_RouteId] = " + id + " AND [IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }

    }
}