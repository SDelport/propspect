using PropSpect.Api.Models.Helpers;
using PropSpect.Api.Models.Response;
using PropSpect.Web.Controllers.Helpers;
using PropSpect.Web.Models.FormModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PropSpect.Web.Controllers
{
    public class UserController : Controller
    {
        [Route("user/add/admin")]
        public ActionResult AddAdmin()
        {
            Models.FormModels.User user = new Models.FormModels.User();
            user.Type = Associations.GetLoginRole(LoginRole.Admin);

            return View("Create", user);
        }

        [Route("user/add/tenant")]
        public ActionResult AddTenant()
        {
            Models.FormModels.User user = new Models.FormModels.User();
            user.Type = Associations.GetLoginRole(LoginRole.Tenant);

            return View("Create", user);
        }

        [Route("user/add/agent")]
        public ActionResult AddAgent()
        {
            User user = new Models.FormModels.User();
            user.Type = Associations.GetLoginRole(LoginRole.Agent);

            return View("Create", user);
        }

        [Route("user/add/owner")]
        public ActionResult AddOwner()
        {
            User user = new Models.FormModels.User();
            user.Type = Associations.GetLoginRole(LoginRole.Owner);

            return View("Create", user);
        }

        [Route("user/list/{type?}")]
        public ActionResult ViewUsers(string type = "")
        {
            List<User> users = new List<User>();
            users = Models.FormModels.User.CreateList(ApiWrapper.Get<List<UserResponse>>("api/user/list/" + type));

            return View("List", users);
        }
    }
}