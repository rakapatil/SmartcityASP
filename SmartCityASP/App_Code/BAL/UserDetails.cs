using System.Data;
using SmartCityASP.App_Code.DAL;

namespace SmartCityASP.App_Code.BAL
{
    public class UserDetails
    {
        DataAccessLogic objDAL = new DataAccessLogic();
        //Properties For User Registration
        public long PK_RegId { get; set; }
        public string Name_M { get; set; }
        public string Name_E { get; set; }
        public string UserPassword { get; set; }
        public string EmailId { get; set; }
        public int LanguageId { get; set; }
        public string Pincode { get; set; }
        public decimal Lattitude { get; set; }
        public decimal Longitude { get; set; }
        public string ImeiNumber { get; set; }
        public string IpAddress { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string MobileNumber { get; set; }

        public DataSet GetUserDetails(string mobileNumber, string userPassword)
        {
            string sqlSelect = "SELECT [PK_RegId],[Name_M],[Name_E],[MobileNumber],[userPassword],[RoleId],[RoleName],[EmailId],[DetailAddress]" +
                               ",[NearBy],[LanguageId],[Pincode],[Lattitude],[Longitude],[ImeiNumber],[IPAddress],[InsertBy],[InsertDate]" +
                               ",[ModifyBy],[ModifyDate],[IsActive],[IsUpdate]" +
                               "FROM [tblUserRegistration] WHERE [IsActive] = 1 AND [MobileNumber] = '" + mobileNumber + "' AND [userPassword] = '" + userPassword + "'";
            return objDAL.ExecuteDataset(sqlSelect);
        }
    }
}