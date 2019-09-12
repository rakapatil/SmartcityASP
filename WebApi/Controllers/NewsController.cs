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
    public class NewsController : ApiController
    {
        DataAccessLogic objDAL = new DataAccessLogic();

        public class ImageWithText
        {
            public string NewsId { get; set; }
            public string NewsHeading { get; set; }
            public string NewsDetails { get; set; }
            public string ImageName { get; set; }
            public string ImagePath { get; set; }
            public string NewsSource { get; set; }
            public string NewsDate { get; set; }
        }

        [HttpGet]
        public HttpResponseMessage GetImageWithText()
        {
            List<ImageWithText> list = new List<ImageWithText>();
            ApiResponse<ImageWithText> apiResponse = new ApiResponse<ImageWithText>();

            try
            {
                var listItem = new List<ImageWithText>();

                string sqlGetNews = "SELECT [NewsId],[NewsHeading],[NewsDetails],[ImageName],[ImagePath],[InsertBy],[InsertDate],[IsActive],[NewsSourceId],[NewsSourceName],[NewsDate]" +
                                    "FROM [tblImageWithTextNews] WHERE [IsActive] = 1 AND [NewsDate] >= '" + CurrentDateMinusTwoDays() + "'";

                DataSet dsShop = objDAL.ExecuteDataset(sqlGetNews);

                if (dsShop.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = dsShop.Tables[0];

                    list = (from DataRow dr in dt.Rows
                            select new ImageWithText()
                            {
                                NewsId = dr["NewsId"].ToString(),
                                NewsDate = dr["NewsDate"].ToString(),
                                NewsDetails = dr["NewsDetails"].ToString(),
                                NewsHeading = dr["NewsHeading"].ToString(),
                                NewsSource = dr["NewsSourceName"].ToString(),
                                ImageName = dr["ImageName"].ToString(),
                                ImagePath = dr["ImagePath"].ToString()

                            }).ToList();
                    listItem = list;

                    apiResponse.Status = true;
                    apiResponse.Message = "ImageWithText";
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

        public string CurrentDateMinusTwoDays()
        {
            string date = DateTime.Now.AddDays(-2).ToString("dd-mm-yyyy");
            return date;
        }

        //public class TextNews
        //{
        //    public string NewsId { get; set; }
        //    public string NewsHeading { get; set; }
        //    public string NewsDetails { get; set; }
        //    public string NewsSource { get; set; }
        //    public string NewsDate { get; set; }
        //}

        //[HttpGet]
        //public HttpResponseMessage GetTextNews([FromBody]int? randomId)
        //{
        //    List<TextNews> list = new List<TextNews>();
        //    try
        //    {
        //        var listItem = new List<TextNews>();

        //        string sqlGetNews = "SELECT [NewsId],[NewsHeading],[NewsDetails],[InsertBy],[InsertDate],[IsActive],[NewsSourceId],[NewsSourceName],[NewsDate]" +
        //                            "FROM [tblTextNews] WHERE [IsActive] = 1 AND [NewsDate] =";

        //        DataSet dsShop = objDAL.ExecuteDataset(sqlGetNews);

        //        if (dsShop.Tables[0].Rows.Count > 0)
        //        {
        //            DataTable dt = dsShop.Tables[0];

        //            list = (from DataRow dr in dt.Rows
        //                    select new TextNews()
        //                    {
        //                        NewsId = dr["NewsId"].ToString(),
        //                        NewsDate = dr["NewsDate"].ToString(),
        //                        NewsDetails = dr["NewsDetails"].ToString(),
        //                        NewsHeading = dr["NewsHeading"].ToString(),
        //                        NewsSource = dr["NewsSourceName"].ToString()

        //                    }).ToList();
        //            listItem = list;
        //            return Request.CreateResponse(HttpStatusCode.OK, listItem);
        //        }
        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Record Found");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}

        public class VideoNews
        {
            public string NewsId { get; set; }
            public string NewsHeading { get; set; }
            public string NewsDetails { get; set; }
            public string VideoName { get; set; }
            public string VideoPath { get; set; }
            public string NewsSource { get; set; }
            public string NewsDate { get; set; }
        }

        [HttpGet]
        public HttpResponseMessage GetVideoNews()
        {
            List<VideoNews> list = new List<VideoNews>();
            ApiResponse<VideoNews> apiResponse = new ApiResponse<VideoNews>();

            try
            {
                var listItem = new List<VideoNews>();

                string sqlGetNews = "SELECT [NewsId],[NewsHeading],[NewsDetails],[NewsSourceId],[NewsSourceName],[VideoName],[VideoPath],[NewsDate],[InsertBy],[InsertDate],[IsActive]" +
                                    "FROM [tblVideoNews] WHERE [IsActive] = 1 AND [NewsDate] >= '" + CurrentDateMinusTwoDays() + "'";

                DataSet dsShop = objDAL.ExecuteDataset(sqlGetNews);

                if (dsShop.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = dsShop.Tables[0];

                    list = (from DataRow dr in dt.Rows
                            select new VideoNews()
                            {
                                NewsId = dr["NewsId"].ToString(),
                                NewsDate = dr["NewsDate"].ToString(),
                                NewsDetails = dr["NewsDetails"].ToString(),
                                NewsHeading = dr["NewsHeading"].ToString(),
                                NewsSource = dr["NewsSourceName"].ToString(),
                                VideoName = dr["VideoName"].ToString(),
                                VideoPath = dr["VideoPath"].ToString()

                            }).ToList();
                    listItem = list;

                    apiResponse.Status = true;
                    apiResponse.Message = "VideoNews";
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
