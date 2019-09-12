using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class GetGrandCategory
    {
        public string  PK_ID { get; set; }
        public string GCName_M { get; set; }
        public string GCName_E { get; set; }
        public string InsertDate { get; set; }
        public string InsertBy { get; set; }
        public int IsActive { get; set; }
        public int IsUpdate { get; set; }
    }
}