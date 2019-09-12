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
    public class MasterController : ApiController
    {
        DataAccessLogic objDAL = new DataAccessLogic();
        SendSMSApi objSMS = new SendSMSApi();

        [HttpPost]
        public HttpResponseMessage GetGrandCategories([FromBody]int? randomId)
        {
            List<GetGrandCategory> list = new List<GetGrandCategory>();
            ApiResponse<GetGrandCategory> apiResponse = new ApiResponse<GetGrandCategory>();

            try
            {
                string sqlSelect = "SELECT * FROM [tblGrandCategory](NOLOCK) WHERE [IsActive] = 1";
                DataSet dsGrand = objDAL.ExecuteDataset(sqlSelect);
                var listItem = new List<GetGrandCategory>();

                if (dsGrand.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = dsGrand.Tables[0];

                    list = (from DataRow dr in dt.Rows
                            select new GetGrandCategory()
                            {
                                PK_ID = dr["PK_ID"].ToString(),
                                GCName_M = dr["GName_M"].ToString(),
                                GCName_E = dr["GName_E"].ToString()

                            }).ToList();
                    listItem = list;

                    apiResponse.Status = true;
                    apiResponse.Message = "Grand Categories List";
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

        public class parent { public string grandId { get; set; } public string maxId { get; set; } }

        [HttpPost]
        public HttpResponseMessage GetParentCategories([FromBody]parent objparent)
        {
            List<GetParentCategory> list = new List<GetParentCategory>();
            ApiResponse<GetParentCategory> apiResponse = new ApiResponse<GetParentCategory>();
            try
            {
                string sqlSelect = "SELECT * FROM [tblParentCategory](NOLOCK) WHERE [IsActive] = 1 AND [GFK_ID] = " + objparent.grandId + " AND [PK_ID] > " + objparent.maxId + "";
                DataSet dsGrand = objDAL.ExecuteDataset(sqlSelect);
                var listItem = new List<GetParentCategory>();

                if (dsGrand.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = dsGrand.Tables[0];

                    list = (from DataRow dr in dt.Rows
                            select new GetParentCategory()
                            {
                                PK_ID = dr["PK_ID"].ToString(),
                                GFK_ID = dr["GFK_ID"].ToString(),
                                PCName_M = dr["PName_M"].ToString(),
                                PCName_E = dr["PName_E"].ToString(),
                                ImageName = dr["ImageName"].ToString(),
                                ImagePath = dr["ImagePath"].ToString()

                            }).ToList();
                    listItem = list;

                    apiResponse.Status = true;
                    apiResponse.Message = "Parent Categories List";
                    apiResponse.DataList = listItem;

                    return Request.CreateResponse(HttpStatusCode.OK, apiResponse);
                }
                else
                {
                    apiResponse.Status = false;
                    apiResponse.Message = "No Record Found of Grand Id :" + objparent.grandId;
                    apiResponse.DataList = null;

                    return Request.CreateResponse(HttpStatusCode.NotFound, apiResponse);
                }
            }
            catch (Exception exception)
            {
                apiResponse.Status = false;
                apiResponse.Message = "Bad Request: " + exception.Message;
                apiResponse.DataList = null;

                return Request.CreateResponse(HttpStatusCode.BadRequest, apiResponse);
            }
        }

        public class Child
        {
            public string grandId { get; set; }
            public string parentId { get; set; }
            public string maxId { get; set; }
        }


        [HttpPost]
        public HttpResponseMessage GetChildCategories([FromBody]Child objchild)
        {
            List<GetChildCategory> list = new List<GetChildCategory>();
            ApiResponse<GetChildCategory> apiResponse = new ApiResponse<GetChildCategory>();

            try
            {
                string sqlSelect = "SELECT * FROM [tblChildCategory](NOLOCK) WHERE [IsActive] = 1 AND [PFK_ID] = " + objchild.parentId + " AND [PK_ID] > " + objchild.maxId + "";
                DataSet dsGrand = objDAL.ExecuteDataset(sqlSelect);
                var listItem = new List<GetChildCategory>();

                if (dsGrand.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = dsGrand.Tables[0];

                    list = (from DataRow dr in dt.Rows
                            select new GetChildCategory()
                            {
                                PK_ID = dr["PK_ID"].ToString(),
                                GFK_ID = dr["GFK_ID"].ToString(),
                                PFK_ID = dr["PFK_ID"].ToString(),
                                CCName_M = dr["CName_M"].ToString(),
                                CCName_E = dr["CName_E"].ToString(),
                                ImageName = dr["ImageName"].ToString(),
                                ImagePath = dr["ImagePath"].ToString(),
                                IsContactOnly = dr["IsCall"].ToString(),
                                HasSubCategory = dr["IsSubCategory"].ToString()

                            }).ToList();
                    listItem = list;

                    apiResponse.Status = true;
                    apiResponse.Message = "Child Categories List";
                    apiResponse.DataList = listItem;

                    return Request.CreateResponse(HttpStatusCode.OK, apiResponse);
                }
                else
                {
                    apiResponse.Status = false;
                    apiResponse.Message = "No Record Found of Parent Id :" + objchild.parentId;
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

        public class SubChild
        {
            public string grandId { get; set; }
            public string parentId { get; set; }
            public string childId { get; set; }
            public string maxId { get; set; }
        }

        [HttpPost]
        public HttpResponseMessage GetSubChildCategories([FromBody]SubChild objSub)
        {
            List<GetSubChildCategory> list = new List<GetSubChildCategory>();
            ApiResponse<GetSubChildCategory> apiResponse = new ApiResponse<GetSubChildCategory>();

            try
            {
                string sqlSelect = "SELECT * FROM [tblSubChildCategory](NOLOCK) WHERE [IsActive] = 1 AND [CFK_ID] = " + objSub.childId + " AND [PK_ID] > " + objSub.maxId + "";
                DataSet dsGrand = objDAL.ExecuteDataset(sqlSelect);
                var listItem = new List<GetSubChildCategory>();

                if (dsGrand.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = dsGrand.Tables[0];

                    list = (from DataRow dr in dt.Rows
                            select new GetSubChildCategory()
                            {
                                PK_ID = dr["PK_ID"].ToString(),
                                GFK_ID = dr["GFK_ID"].ToString(),
                                PFK_ID = dr["PFK_ID"].ToString(),
                                CFK_ID = dr["CFK_ID"].ToString(),
                                CCName_M = dr["SCName_M"].ToString(),
                                CCName_E = dr["SCName_E"].ToString(),
                                ImageName = dr["ImageName"].ToString(),
                                ImagePath = dr["ImagePath"].ToString(),
                                IsContactOnly = dr["IsCall"].ToString()

                            }).ToList();
                    listItem = list;

                    apiResponse.Status = true;
                    apiResponse.Message = "SubChild Categories List";
                    apiResponse.DataList = listItem;

                    return Request.CreateResponse(HttpStatusCode.OK, apiResponse);
                }
                else
                {
                    apiResponse.Status = false;
                    apiResponse.Message = "No Record Found of Child Id :" + objSub.childId;
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

        public class TokenDetails
        {
            public string MobileNumber { get; set; }
            public string Name { get; set; }
            public string FcmID { get; set; }
        }

        public class Error
        {
            public string Message { get; set; }
        }

        [HttpPost]
        public HttpResponseMessage PostTokenDetails([FromBody]TokenDetails objToken)
        {
            string msg = "Thanks for the using Smart Shirpur App." +
                         "For More Information Contact on - 02563255237 9527004008 " +
                         "www.smartshirpur.in " +
                         "Email-smartshirpurinfo@gmail.com";
            List<Error> objlist = new List<Error>();
            try
            {

                string sqlSelect = "SELECT [PK_ID] FROM [tblTokenDetails](NOLOCK) WHERE [MobileNumber] = '" + objToken.MobileNumber + "'";
                string idValue = objDAL.ExecuteScalar(sqlSelect);

                if (idValue == null || idValue == "")
                {
                    string sqlInsert = "INSERT INTO [tblTokenDetails] ([Name],[MobileNumber],[FcmId],[InsertDate])" +
                                      "VALUES (N'" + objToken.Name + "',N'" + objToken.MobileNumber + "',N'" + objToken.FcmID + "','" + System.DateTime.Now + "')";
                    objDAL.ExecuteNonQuery(sqlInsert);
                    objSMS.SendSMS(objToken.MobileNumber, msg);
                }
                else
                {
                    string sqlUpdate = "UPDATE [tblTokenDetails] SET [Name]=N'" + objToken.Name + "',[MobileNumber]=N'" + objToken.MobileNumber + "',[FcmId]=N'" + objToken.FcmID + "' WHERE [MobileNumber] = '" + objToken.MobileNumber + "'";
                    objDAL.ExecuteNonQuery(sqlUpdate);
                    objSMS.SendSMS(objToken.MobileNumber, msg);
                }

                objlist.Add(new Error() { Message = "1" });
                return Request.CreateResponse(HttpStatusCode.OK, objlist);
            }
            catch (Exception ex)
            {
                objlist.Add(new Error() { Message = "0" });
                return Request.CreateResponse(HttpStatusCode.OK, objlist);
            }
        }

        public class SlidingPatti
        {
            public string SliddingPatti { get; set; }
        }

        [HttpGet]
        public HttpResponseMessage GetSlidingPatti()
        {
            List<SlidingPatti> list = new List<SlidingPatti>();
            ApiResponse<SlidingPatti> apiResponse = new ApiResponse<SlidingPatti>();

            try
            {
                string sqlGetData = "SELECT * FROM [tblScrollingAds] WHERE [IsActive] = 1";
                DataSet dsGrand = objDAL.ExecuteDataset(sqlGetData);
                var listItem = new List<SlidingPatti>();

                if (dsGrand.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = dsGrand.Tables[0];

                    list = (from DataRow dr in dt.Rows
                            select new SlidingPatti()
                            {
                                SliddingPatti = dr["Description"].ToString()

                            }).ToList();
                    listItem = list;

                    apiResponse.Status = true;
                    apiResponse.Message = "Sliding Patti";
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
