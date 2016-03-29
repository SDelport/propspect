using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropSpect.Web.Controllers.Helpers
{
    public class LoggedIn : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if( httpContext.Request.Cookies["userID"] != null)
            {
                
                return true;
            }

            return false;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.RouteData.Values.Add("tried", true);
            filterContext.Result = new RedirectResult("/login");
         
        }
    }
}