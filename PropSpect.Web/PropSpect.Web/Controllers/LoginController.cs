using PropSpect.Api.Models.Helpers;
using PropSpect.Api.Models.Request;
using PropSpect.Api.Models.Response;
using PropSpect.Web.Controllers.Helpers;
using PropSpect.Web.Models.FormModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropSpect.Web.Controllers
{
    public class LoginController : Controller
    {
        [Route("login")]
        public ActionResult Login()
        {
            return View("Login");
        }

        [Route("login/post")]
        public ActionResult LoginPost(Login loginModel)
        {
            LoginResponse response = ApiWrapper.Post<LoginResponse>("login", loginModel);



            if (response.Role == LoginRole.None)
                return Redirect("/login");
            else
            {
                HttpContext.Response.Cookies.Add(new HttpCookie("userID", response.UserID));
                HttpContext.Response.Cookies.Add(new HttpCookie("role", Associations.GetLoginRole(response.Role)));
                HttpContext.Response.Cookies.Add(new HttpCookie("username", response.Username));

                return Redirect("/");

            }
        }

        [LoggedIn]
        [Route("users")]
        public ActionResult List()
        {
            List<User> users = new List<User>();

            users = PropSpect.Web.Models.FormModels.User.CreateList(ApiWrapper.Get<List<UserResponse>>("api/user"));

            ListAsyncFormModel formModel = ListAsyncFormModel.Create(users);


            formModel.ItemLists.Add("RoleItems", Enum.GetNames(typeof(LoginRole)).Select(x => new SelectListItem()
            {
                Text = x,
                Value = Associations.GetLoginRole(Associations.GetLoginRole(x))
            }).ToList());

            return View("List", formModel);
        }

        [LoggedIn]
        [Route("user/add")]
        public JsonResult AddedUser(UserResponse model)
        {
            CreateUserRequest request = new CreateUserRequest();
            request.UserID = model.UserID;
            request.Username = model.Username;
            request.Type = model.Type;


            var result = ApiWrapper.Post<bool>("api/user/add", request);

            return Json(result);
        }
    }
}