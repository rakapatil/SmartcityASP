namespace SmartCityASP.App_Code.DAL
{
    public class PostNotif
    {
        public string Message { get; set; }
        public string TagMsg { get; set; }
        public string ImageUrl { get; set; }
        public string FCM_DeviceId { get; set; }
    }

    public class Payload
    {
        public string score { get; set; }
        public string team { get; set; }
    }

    public class Data
    {
        public string image { get; set; }
        public bool is_background { get; set; }
        public Payload payload { get; set; }
        public string title { get; set; }
        public string message { get; set; }
        public string timestamp { get; set; }
    }

    public class RootObject
    {
        public Data data { get; set; }
        public string to { get; set; }
    }
}