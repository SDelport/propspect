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

        [Route("reset-password/{key}")]
        public ActionResult ResetPassword(string key, string message = "")
        {
            SetPassword model = new SetPassword();
            var response = ApiWrapper.Get<ForgotPasswordResponse>("api/user/reset");

            model.Email = response.Email;
            model.Key = key;
            model.Message = message;

            return View("SetPassword");
        }

        [Route("reset-password/post")]
        public ActionResult ResetPasswordPassword(SetPassword model)
        {
            ResetPasswordRequest request = new ResetPasswordRequest();

            var response = ApiWrapper.Post<ResetPasswordRequest>("api/user/reset", request);

            return View("/login");
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


        [Route("logout")]
        public ActionResult Logout()
        {
            if (HttpContext.Response.Cookies["userID"] != null)
                HttpContext.Response.Cookies["userID"].Expires = DateTime.Now.AddMinutes(-1);

            if (HttpContext.Response.Cookies["role"] != null)
                HttpContext.Response.Cookies["role"].Expires = DateTime.Now.AddMinutes(-1);

            if (HttpContext.Response.Cookies["username"] != null)
                HttpContext.Response.Cookies["username"].Expires = DateTime.Now.AddMinutes(-1);

            return Redirect("/");
        }

        [LoggedIn]
        [Route("users")]
        public ActionResult List()
        {
            List<User> users = new List<User>();

            users = PropSpect.Web.Models.FormModels.User.CreateList(ApiWrapper.Get<List<UserResponse>>("api/user/list"));

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

        [LoggedIn]
        [Route("user/add-user")]
        public ActionResult AddUser(UserResponse model)
        {
            CreateUserRequest request = new CreateUserRequest();
            request.UserID = model.UserID;
            request.Username = model.Username;
            request.Type = model.Type;


            var result = ApiWrapper.Post<bool>("api/user/add", request);

            if (string.IsNullOrEmpty(Request.QueryString["returnurl"]))
                return Redirect("/");
            else
                return Redirect(Request.QueryString["returnurl"]);
        }

        [LoggedIn]
        [Route("user/add-user/t")]
        public ActionResult AddUserTenant(Tenant model)
        {

            CreateUserRequest request = new CreateUserRequest();
            request.UserID = model.UserID;
            request.Username = model.Username;
            request.Type = model.Type;

            CreateTenantRequest tenantRequest = new CreateTenantRequest();
            tenantRequest.TenantID = model.TenantID;
            tenantRequest.Title = model.Title;
            tenantRequest.FirstName = model.FirstName;
            tenantRequest.SecondName = model.SecondName;
            tenantRequest.ThirdName = model.ThirdName;
            tenantRequest.PreferredName = model.PreferredName;
            tenantRequest.LastName = model.LastName;
            tenantRequest.IDNumber = model.IDNumber;
            tenantRequest.TelWork = model.TelWork;
            tenantRequest.TelMobile = model.TelMobile;
            tenantRequest.Email = model.Email;
            tenantRequest.Website = model.Website;


            var result = ApiWrapper.Post<string>("api/tenant/add", tenantRequest);

            request.UserKey = int.Parse(result);
            var resultUser = ApiWrapper.Post<bool>("api/user/add", request);


            if (string.IsNullOrEmpty(Request.QueryString["returnurl"]))
                return Redirect("/user/list/t");
            else
                return Redirect(Request.QueryString["returnurl"]);
        }
    }
}