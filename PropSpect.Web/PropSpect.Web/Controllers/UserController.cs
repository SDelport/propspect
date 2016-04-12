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
        [Route("user/add/a")]
        public ActionResult AddAdmin()
        {
            Models.FormModels.User user = new Models.FormModels.User();
            user.Type = Associations.GetLoginRole(LoginRole.Admin);

            return View("Create", user);
        }

        [Route("user/add/t")]
        [Route("user/add/tenant")]
        public ActionResult AddTenant()
        {
            Models.FormModels.Tenant tenant = new Models.FormModels.Tenant();
            tenant.Type = Associations.GetLoginRole(LoginRole.Tenant);

            return View("Tenant\\Create", tenant);
        }

        [Route("user/add/ag")]
        public ActionResult AddAgent()
        {
            User user = new Models.FormModels.User();
            user.Type = Associations.GetLoginRole(LoginRole.Agent);

            return View("Create", user);
        }

        [Route("user/add/o")]
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
            AdminAddUser model = new AdminAddUser();
            model.Users = users;
            if (!string.IsNullOrEmpty(type))
                model.Type = Associations.GetLoginRole(type);
            return View("List", model);
        }
    }
}