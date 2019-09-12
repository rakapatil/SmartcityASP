using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartCityASP.App_Code.DAL;
using System.Data;

namespace SmartCityASP.App_Code.BAL
{
    public class RoutesDetails
    {
        DataAccessLogic objDAL = new DataAccessLogic();

        public int RouteId { get; set; }
        public string SourcePlace_M { get; set; }
        public string SourcePlace_E { get; set; }
        public string DestinationPlace_M { get; set; }
        public string DestinationPlace_E { get; set; }

        public int InsertRoutes(RoutesDetails objRoute)
        {
            string sqlInsert = "INSERT INTO [tblRouteDetails] ([SourcePlace_M],[DestinationPlace_M],[SourcePlace_E],[DestinationPlace_E],[IsActive],[IsUpdate])" +
                               "VALUES (N'" + objRoute.SourcePlace_M + "',N'" + objRoute.DestinationPlace_M + "',N'" + objRoute.SourcePlace_E + "',N'" + objRoute.DestinationPlace_E + "',1,1)";
            return objDAL.ExecuteNonQuery(sqlInsert);
        }

        public int UpdateRoutes(RoutesDetails objRoute)
        {
            string sqlUpdate = "UPDATE [tblRouteDetails] SET [SourcePlace_M] = N'" + objRoute.SourcePlace_M + "',[DestinationPlace_M] = N'" + objRoute.DestinationPlace_M + "',[SourcePlace_E] = N'" + objRoute.SourcePlace_E + "',[DestinationPlace_E] = N'" + objRoute.DestinationPlace_E + "' WHERE [PK_RouteId] = " + objRoute.RouteId + "";
            return objDAL.ExecuteNonQuery(sqlUpdate);
        }

        public string GetMaxId()
        {
            try
            {
                string sqlGetId = "SELECT MAX([PK_RouteId]) FROM [tblRouteDetails]";
                int maxId = Convert.ToInt32(objDAL.ExecuteScalar(sqlGetId)) + 1;
                return maxId.ToString();
            }
            catch { return "1"; }
        }

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

        public int DeleteRoute(int id)
        {
            string sqlDelete = "UPDATE [tblRouteDetails] SET [IsActive] = 0 WHERE [PK_RouteId] = " + id + "";//"DELETE FROM [tblRouteDetails] WHERE [PK_RouteId] = " + id + "";
            return objDAL.ExecuteNonQuery(sqlDelete);
        }
    }
}