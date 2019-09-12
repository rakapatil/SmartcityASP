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
    public class ShopController : ApiController
    {
        GetShopDetails objShop = new GetShopDetails();
        DataAccessLogic objDAL = new DataAccessLogic();

        public class MastersDetails
        {
            public string GrandId { get; set; }
            public string ParentId { get; set; }
            public string ChildId { get; set; }
            public string SubChildId { get; set; }
            public string maxId { get; set; }
        }

        [HttpPost]
        public HttpResponseMessage ShopDetails([FromBody]MastersDetails objMasters)
        {
            List<GetShopDetails> list = new List<GetShopDetails>();
            ApiResponse<GetShopDetails> apiResponse = new ApiResponse<GetShopDetails>();

            try
            {
                var listItem = new List<GetShopDetails>();
                DataSet dsShop = objShop.GetShopsDetails(objMasters.GrandId, objMasters.ParentId, objMasters.ChildId, objMasters.SubChildId, objMasters.maxId);

                if (dsShop.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = dsShop.Tables[0];

                    list = (from DataRow dr in dt.Rows
                            select new GetShopDetails()
                            {
                                PK_RegShopId = dr["PK_ShopRegId"].ToString(),
                                CFK_ID = dr["CFK_ID"].ToString(),
                                PFK_ID = dr["PFK_ID"].ToString(),
                                GFK_ID = dr["GFK_ID"].ToString(),
                                SCFK_ID = dr["SCFK_ID"].ToString(),
                                ImageName = dr["ImageName"].ToString(),
                                ImagePath = dr["ImagePath"].ToString(),
                                ShopName_E = dr["ShopName_E"].ToString(),
                                ShopName_M = dr["ShopName_M"].ToString(),
                                Description = dr["Description"].ToString(),
                                DetailAddress = dr["DetailAddress"].ToString(),
                                NearById = dr["NearBy"].ToString(),
                                NearByName = dr["NearByName"].ToString(),
                                LandlineNumber = dr["LandlineNumber"].ToString(),
                                AlternetMobileNumber = dr["AlternetMobileNumber"].ToString(),
                                MobileNumber = dr["MobileNumber"].ToString(),
                                OpenTime = dr["OpenTime"].ToString(),
                                CloseTime = dr["CloseTime"].ToString(),
                                Offers = dr["Offers"].ToString(),
                                PackageId = dr["Package"].ToString(),
                                PackageName = dr["PackageName"].ToString(),
                                WebSite = dr["Website"].ToString(),
                                IsCall = dr["IsCall"].ToString()

                            }).ToList();
                    listItem = list;

                    apiResponse.Status = true;
                    apiResponse.Message = "Shop Details";
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

        [HttpGet]
        public HttpResponseMessage UpdatedShopDetails()
        {
            List<GetShopDetails> list = new List<GetShopDetails>();
            ApiResponse<GetShopDetails> apiResponse = new ApiResponse<GetShopDetails>();

            try
            {
                var listItem = new List<GetShopDetails>();
                DataSet dsShop = objShop.GetUpdatedShops();
                if (dsShop.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = dsShop.Tables[0];

                    list = (from DataRow dr in dt.Rows
                            select new GetShopDetails()
                            {
                                PK_RegShopId = dr["PK_ShopRegId"].ToString(),
                                CFK_ID = dr["CFK_ID"].ToString(),
                                PFK_ID = dr["PFK_ID"].ToString(),
                                GFK_ID = dr["GFK_ID"].ToString(),
                                SCFK_ID = dr["SCFK_ID"].ToString(),
                                ImageName = dr["ImageName"].ToString(),
                                ImagePath = dr["ImagePath"].ToString(),
                                ShopName_E = dr["ShopName_E"].ToString(),
                                ShopName_M = dr["ShopName_M"].ToString(),
                                Description = dr["Description"].ToString(),
                                DetailAddress = dr["DetailAddress"].ToString(),
                                NearById = dr["NearBy"].ToString(),
                                NearByName = dr["NearByName"].ToString(),
                                LandlineNumber = dr["LandlineNumber"].ToString(),
                                AlternetMobileNumber = dr["AlternetMobileNumber"].ToString(),
                                MobileNumber = dr["MobileNumber"].ToString(),
                                OpenTime = dr["OpenTime"].ToString(),
                                CloseTime = dr["CloseTime"].ToString(),
                                Offers = dr["Offers"].ToString(),
                                PackageId = dr["Package"].ToString(),
                                PackageName = dr["PackageName"].ToString(),
                                WebSite = dr["Website"].ToString(),
                                IsCall = dr["IsCall"].ToString()

                            }).ToList();
                    listItem = list;

                    apiResponse.Status = true;
                    apiResponse.Message = "Shop Details";
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

        public class SliderImages
        {
            public string Caption { get; set; }
            public string ImageName { get; set; }
            public string ImagePath { get; set; }
        }


        [HttpGet]
        public HttpResponseMessage GetSliderImages()
        {
            List<SliderImages> list = new List<SliderImages>();
            ApiResponse<SliderImages> apiResponse = new ApiResponse<SliderImages>();

            try
            {
                var listItem = new List<SliderImages>();
                DataSet dsShop = objShop.GetSliderImages();
                if (dsShop.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = dsShop.Tables[0];

                    list = (from DataRow dr in dt.Rows
                            select new SliderImages()
                            {
                                Caption = dr["Caption"].ToString(),
                                ImageName = dr["ImageName"].ToString(),
                                ImagePath = dr["ImagePath"].ToString()

                            }).ToList();
                    listItem = list;

                    apiResponse.Status = true;
                    apiResponse.Message = "Slider Images";
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

        public class ScrollingAds
        {
            public string AdsId { get; set; }
            public string Description { get; set; }
        }

        [HttpGet]
        public HttpResponseMessage GetScrollingAds()
        {
            List<ScrollingAds> list = new List<ScrollingAds>();
            ApiResponse<ScrollingAds> apiResponse = new ApiResponse<ScrollingAds>();

            try
            {
                var listItem = new List<ScrollingAds>();
                DataSet dsShop = objShop.GetSliderImages();
                if (dsShop.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = dsShop.Tables[0];

                    list = (from DataRow dr in dt.Rows
                            select new ScrollingAds()
                            {
                                AdsId = dr["PK_ScrollAdsId"].ToString(),
                                Description = dr["Description"].ToString()

                            }).ToList();
                    listItem = list;

                    apiResponse.Status = true;
                    apiResponse.Message = "Slider Images";
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

        public class Error
        {
            public string Message { get; set; }
        }

        public class SendLikesShopId
        { public long shopId { get; set; } }

        [HttpPost]
        public HttpResponseMessage SendLikeCount([FromBody]SendLikesShopId objshopId)
        {
            List<Error> objlist = new List<Error>();
            try
            {
                string sqlInsert = "INSERT INTO [tblShopLikes] ([ShopId],[SeenBy],[InsertDate]) VALUES (" + objshopId.shopId + ",'0','" + DateTime.Now.ToString("dd-mm-yyyy") + "')";
                objDAL.ExecuteNonQuery(sqlInsert);

                string sqlSelect = "SELECT COUNT(1) FROM [tblShopLikes] WHERE [ShopId]=" + objshopId.shopId + "";
                string count = objDAL.ExecuteScalar(sqlSelect);

                objlist.Add(new Error() { Message = count });
                return Request.CreateResponse(HttpStatusCode.OK, objlist);
            }
            catch
            {
                objlist.Add(new Error() { Message = "0" });
                return Request.CreateResponse(HttpStatusCode.OK, objlist);
            }
        }

        public class GetLikesDetails
        {
            public string GrandId { get; set; }
            public string ParentId { get; set; }
            public string ChildId { get; set; }
        }

        public class GetShopLikesClass
        {
            public string ShopId { get; set; }
            public string Likes { get; set; }
        }

        [HttpPost]
        public HttpResponseMessage GetShopLikes([FromBody]GetLikesDetails objLikes)
        {
            List<GetShopLikesClass> list = new List<GetShopLikesClass>();
            ApiResponse<GetShopLikesClass> apiResponse = new ApiResponse<GetShopLikesClass>();

            try
            {
                string sqlSelect = "SELECT [ShopId],COUNT([PK_ID]) AS CountValue FROM [tblShopLikes] GROUP BY [ShopId] HAVING [ShopId] IN " +
                                   "(SELECT [PK_ShopRegId] FROM [tblShopDetails] " +
                                   "WHERE [GFK_ID] = " + objLikes.GrandId + " AND [PFK_ID] = " + objLikes.ParentId + " AND [CFK_ID] = " + objLikes.ChildId + ")";

                var listItem = new List<GetShopLikesClass>();
                DataSet dsShop = objDAL.ExecuteDataset(sqlSelect);

                if (dsShop.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = dsShop.Tables[0];

                    list = (from DataRow dr in dt.Rows
                            select new GetShopLikesClass()
                            {
                                ShopId = dr["ShopId"].ToString(),
                                Likes = dr["CountValue"].ToString()

                            }).ToList();
                    listItem = list;

                    apiResponse.Status = true;
                    apiResponse.Message = "Slider Images";
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

        public class DeleteShopsIDs
        {
            public string ShopsIDs { get; set; }
        }

        [HttpGet]
        public HttpResponseMessage DeleteShops()
        {
            List<DeleteShopsIDs> list = new List<DeleteShopsIDs>();
            ApiResponse<DeleteShopsIDs> apiResponse = new ApiResponse<DeleteShopsIDs>();

            try
            {
                var listItem = new List<DeleteShopsIDs>();
                DataSet dsShop = objShop.GetDeletedShopsId();
                if (dsShop.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = dsShop.Tables[0];

                    list = (from DataRow dr in dt.Rows
                            select new DeleteShopsIDs()
                            {
                                ShopsIDs = dr["PK_ShopRegId"].ToString()
                            }).ToList();
                    listItem = list;

                    apiResponse.Status = true;
                    apiResponse.Message = "Slider Images";
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

        public class MoreShopImages
        {
            public string ShopId { get; set; }
        }

        public class ShopImages
        {
            public string ShopId { get; set; }
            public string ImageName { get; set; }
        }

        [HttpPost]
        public HttpResponseMessage GetMoreShopImages([FromBody]MoreShopImages objImages)
        {
            List<ShopImages> list = new List<ShopImages>();
            ApiResponse<ShopImages> apiResponse = new ApiResponse<ShopImages>();

            try
            {
                var listItem = new List<ShopImages>();
                DataSet dsShop = objShop.GetMoreShopImages(objImages.ShopId);
                if (dsShop.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = dsShop.Tables[0];

                    list = (from DataRow dr in dt.Rows
                            select new ShopImages()
                            {
                                ShopId = dr["ShopId"].ToString(),
                                ImageName = dr["ImageName"].ToString()

                            }).ToList();
                    listItem = list;

                    apiResponse.Status = true;
                    apiResponse.Message = "Shop Images";
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
