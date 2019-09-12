using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class TravelsTimeTableController : ApiController
    {
        TravelsTimeTable objTimeTable = new TravelsTimeTable();

        public class TravelsRoutes
        {
            public string RouteId { get; set; }
            public string SourcePlace_M { get; set; }
            public string SourcePlace_E { get; set; }
            public string DestinationPlace_M { get; set; }
            public string DestinationPlace_E { get; set; }

            public string TravelsId { get; set; }
            public string BusInformation { get; set; }
            public string DayPaharId { get; set; }
            public string DayPaharName { get; set; }
            public string Time { get; set; }
        }

        [HttpGet]
        public HttpResponseMessage GetRoutes()
        {
            List<TravelsRoutes> list = new List<TravelsRoutes>();
            ApiResponse<TravelsRoutes> apiResponse = new ApiResponse<TravelsRoutes>();

            try
            {
                var listItem = new List<TravelsRoutes>();
                DataSet ds = objTimeTable.GetRoutesDetails();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[0];

                    list = (from DataRow dr in dt.Rows
                            select new TravelsRoutes()
                            {
                                RouteId = dr["PK_RouteId"].ToString(),
                                SourcePlace_E = dr["SourcePlace_E"].ToString(),
                                SourcePlace_M = dr["SourcePlace_M"].ToString(),
                                DestinationPlace_E = dr["DestinationPlace_E"].ToString(),
                                DestinationPlace_M = dr["DestinationPlace_M"].ToString(),

                                TravelsId = dr["PK_TravelId"].ToString(),
                                BusInformation = dr["Description"].ToString(),
                                DayPaharId = dr["DayPaharId"].ToString(),
                                DayPaharName = dr["DayPaharName"].ToString(),
                                Time = dr["Time"].ToString()

                            }).ToList();
                    listItem = list;

                    apiResponse.Status = true;
                    apiResponse.Message = "TravelsRoutes";
                    apiResponse.DataList = listItem;

                    return Request.CreateResponse(HttpStatusCode.OK, apiResponse);
                }
                else
                {
                    apiResponse.Status = false;
                    apiResponse.Message = "No Record Found";
                    apiResponse.DataList = null;

                    return Request.CreateResponse(HttpStatusCode.NotFound, apiResponse);
                }
            }
            catch (Exception ex)
            {
                apiResponse.Status = false;
                apiResponse.Message = "Bad Request: " + ex.Message;
                apiResponse.DataList = null;

                return Request.CreateResponse(HttpStatusCode.BadRequest, apiResponse);
            }
        }

        public class RouteDetails { public int RouteID { get; set; } }

        [HttpPost]
        public HttpResponseMessage GetBusInformation([FromBody]RouteDetails objRoutes)
        {
            List<TravelsTimeTable> list = new List<TravelsTimeTable>();
            ApiResponse<TravelsTimeTable> apiResponse = new ApiResponse<TravelsTimeTable>();

            try
            {
                var listItem = new List<TravelsTimeTable>();
                DataSet ds = objTimeTable.GetTravelsDetails(objRoutes.RouteID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[0];

                    list = (from DataRow dr in dt.Rows
                            select new TravelsTimeTable()
                            {
                                TravelsId = dr["PK_TravelId"].ToString(),
                                BusInformation = dr["Description"].ToString(),
                                DayPaharId = dr["DayPaharId"].ToString(),
                                DayPaharName = dr["DayPaharName"].ToString(),
                                Time = dr["Time"].ToString(),
                                RouteId = dr["FK_RouteId"].ToString()

                            }).ToList();
                    listItem = list;

                    apiResponse.Status = true;
                    apiResponse.Message = "TravelsTimeTable";
                    apiResponse.DataList = listItem;

                    return Request.CreateResponse(HttpStatusCode.OK, apiResponse);
                }
                else
                {
                    apiResponse.Status = false;
                    apiResponse.Message = "No Record Found";
                    apiResponse.DataList = null;

                    return Request.CreateResponse(HttpStatusCode.NotFound, apiResponse);
                }
            }
            catch (Exception ex)
            {
                apiResponse.Status = false;
                apiResponse.Message = "Bad Request: " + ex.Message;
                apiResponse.DataList = null;

                return Request.CreateResponse(HttpStatusCode.BadRequest, apiResponse);
            }
        }
    }
}
