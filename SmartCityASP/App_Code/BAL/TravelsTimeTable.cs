using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartCityASP.App_Code.DAL;
using System.Data;

namespace SmartCityASP.App_Code.BAL
{
    public class TravelsTimeTable
    {
        DataAccessLogic objDAL = new DataAccessLogic();

        public int TravelsId { get; set; }
        public string BusInformation { get; set; }
        public int RouteId { get; set; }
        public int DayPaharId { get; set; }
        public string DayPaharName { get; set; }
        public string Time { get; set; }

        public int InsertTravelTime(TravelsTimeTable objTravel)
        {
            string sqlInsert = "INSERT INTO [tblTravelTimeTable] ([FK_RouteId],[Time],[Description],[DayPaharId],[DayPaharName],[IsActive],[IsUpdate]) " +
                               "VALUES (" + objTravel.RouteId + ",N'" + objTravel.Time + "',N'" + objTravel.BusInformation + "'," + objTravel.DayPaharId + ",N'" + objTravel.DayPaharName + "',1,1)";
            return objDAL.ExecuteNonQuery(sqlInsert);
        }

        public int UpdateTravelTime(TravelsTimeTable objTravel)
        {
            string sqlUpdate = "UPDATE [tblTravelTimeTable] SET [FK_RouteId] = " + objTravel.RouteId + "" +
      ",[Time] = N'" + objTravel.Time + "'" +
      ",[Description] = N'" + objTravel.BusInformation + "'" +
      ",[DayPaharId] = " + objTravel.DayPaharId + "" +
      ",[DayPaharName] = N'" + objTravel.DayPaharName + "' WHERE [PK_TravelId] = " + objTravel.TravelsId + "";

            return objDAL.ExecuteNonQuery(sqlUpdate);

        }

        public string GetMaxId()
        {
            try
            {
                string sqlGetId = "SELECT MAX([PK_TravelId]) FROM [tblTravelTimeTable]";
                int maxId = Convert.ToInt32(objDAL.ExecuteScalar(sqlGetId)) + 1;
                return maxId.ToString();
            }
            catch { return "1"; }
        }

        public DataSet GetTravelsDetails()
        {
            string sqlGetData = "SELECT * FROM [tblTravelTimeTable] WHERE [IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public DataSet GetTravelsDetails(int id)
        {
            string sqlGetData = "SELECT [PK_TravelId],[FK_RouteId],[Time],[Description],[DayPaharId],[DayPaharName] " +
                                "FROM   [tblTravelTimeTable] WHERE [PK_TravelId] = " + id + " AND [IsActive] = 1";
            return objDAL.ExecuteDataset(sqlGetData);
        }

        public int DeleteTravelsTime(int id)
        {
            string sqlDelete = "UPDATE [tblTravelTimeTable] SET [IsActive] = 0 WHERE [PK_TravelId] = " + id + "";//"DELETE FROM [tblTravelTimeTable] WHERE [PK_TravelId] = " + id + "";
            return objDAL.ExecuteNonQuery(sqlDelete);
        }
    }
}