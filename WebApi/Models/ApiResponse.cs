using System.Collections.Generic;

namespace WebApi.Models
{
    public class ApiResponse<T>
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<T> DataList { get; set; }
    }
}