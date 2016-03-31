using PropSpect.Api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropSpect.Web.Models.FormModels
{
    public class AdminAddUser
    {
        public LoginRole Type { get; set; }
        public List<User> Users { get; set; }
    }
}