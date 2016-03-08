using PropSpect.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropSpect.Api.Authorize
{
    public class AuthorizationLevel : AuthorizeAttribute
    {        
        public RoleType[] AuthRoleType { get; set; }
        UserController User = new UserController();
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            if (AuthRoleType.Contains(User.GetUserRole("I dont know what to put in here...")))
            {
                return true;
            }
            return false;
        }

        public AuthorizationLevel(params RoleType[] roles)
        {
            AuthRoleType = roles;
        }
    }

    public enum RoleType
    {
        SuperAdmin,
        Admin,
        Tenant,
        Landlord
    }
}