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

        /// <summary>
        /// Returns the role of a user.
        /// </summary>
        /// <param name="identifier">unique identifier of the user</param>
        /// <returns></returns>
        public RoleType GetUserRole(string identifier)
        {
            return RoleType.Tenant;
        }
    }
}