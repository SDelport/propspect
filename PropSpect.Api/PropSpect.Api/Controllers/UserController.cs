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
        public AuthorizationLevel.RoleType GetUserRole(string identifier)
        {
            AuthorizationLevel.RoleType type = AuthorizationLevel.RoleType.Unknown;

            //Try get from db
            type = AuthorizationLevel.RoleType.Tenant;

            return type;
        }
    }
}