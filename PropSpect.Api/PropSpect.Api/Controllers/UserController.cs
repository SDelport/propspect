using PropSpect.Api.Authorize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropSpect.Api.Controllers
{
    public class UserController : Controller
    {
        public RoleType GetUserRole(string identifier)
        {
            RoleType type = RoleType.Unknown;

            //Try get from db
            type = RoleType.Tenant;

            return RoleType.Tenant;
        }
    }
}