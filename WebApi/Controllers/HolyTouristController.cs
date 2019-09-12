using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class HolyTouristController : ApiController
    {
        DataAccessLogic objDAL = new DataAccessLogic();
        HolyTouristPlaces objHoly = new HolyTouristPlaces();

        [HttpGet]
        public HttpResponseMessage GetHolyTouristPlaces()
        {
            List<HolyTouristPlaces> list = new List<HolyTouristPlaces>();
            ApiResponse<HolyTouristPlaces> apiResponse = new ApiResponse<HolyTouristPlaces>();

            try
            {
                var listItem = new List<HolyTouristPlaces>();
                DataSet dsShop = objHoly.GetHolyTouristPlaceDetails();
                if (dsShop.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = dsShop.Tables[0];

                    list = (from DataRow dr in dt.Rows
                            select new HolyTouristPlaces()
                            {
                                PK_HolyId = dr["PK_HTPId"].ToString(),
                                ImageName = dr["ImageName"].ToString(),
                                ImagePath = dr["ImagePath"].ToString(),
                                PlaceName_E = dr["Name_E"].ToString(),
                                PlaceName_M = dr["Name_M"].ToString(),
                                PlaceFestivals = dr["PlaceUstav"].ToString(),
                                PlaceHistory = dr["PlaceHistory"].ToString(),
                                DistanceFromCity = dr["DistanceFromCity"].ToString(),
                                PlaceTypeId = dr["PlaceTypeId"].ToString(),
                                RouteId = dr["RouteId"].ToString()

                            }).ToList();
                    listItem = list;

                    apiResponse.Status = true;
                    apiResponse.Message = "HolyTouristPlaces";
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
