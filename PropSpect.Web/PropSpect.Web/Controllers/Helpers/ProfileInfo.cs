using PropSpect.Api.Models.Helpers;
using PropSpect.Api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropSpect.Web.Controllers.Helpers
{
    public  class ProfileInfo
    {
        public LoginRole Role { get; set; }
        public string Username { get; set; }
        public string UserID { get; set; }

        public static ProfileInfo GetProfileInfo()
        {
            var userid = HttpContext.Current.Request.Cookies["userID"];
            var role = HttpContext.Current.Request.Cookies["role"];
            var username = HttpContext.Current.Request.Cookies["username"];

            ProfileInfo info = new ProfileInfo();
            info.UserID = userid?.Value;
            info.Username = username?.Value;
            info.Role = LoginRole.None;
            info.Role = Associations.GetLoginRole(role?.Value);

            return info;
        }
    }
}