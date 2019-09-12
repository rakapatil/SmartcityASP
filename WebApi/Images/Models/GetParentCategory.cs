using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class GetParentCategory
    {
        public string PK_ID { get; set; }
        public string GFK_ID { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public string PCName_M { get; set; }
        public string PCName_E { get; set; }
        public string InsertDate { get; set; }
        public string InsertBy { get; set; }
        public int IsActive { get; set; }
        public int IsUpdate { get; set; }
        public int Error { get; set; }
    }
}