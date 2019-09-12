using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class GetSubChildCategory
    {
        public string PK_ID { get; set; }
        public string GFK_ID { get; set; }
        public string PFK_ID { get; set; }
        public string CFK_ID { get; set; }
        public string CCName_M { get; set; }
        public string CCName_E { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public string IsContactOnly { get; set; }
    }
}