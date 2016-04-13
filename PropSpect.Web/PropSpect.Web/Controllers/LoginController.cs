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


            var result = ApiWrapper.Post<TenantResponse>("api/tenant/add", tenantRequest);

            request.UserKey = result.TenantID;
            var resultUser = ApiWrapper.Post<bool>("api/user/add", request);


            if (string.IsNullOrEmpty(Request.QueryString["returnurl"]))
                return Redirect("/user/list/t");
            else
                return Redirect(Request.QueryString["returnurl"]);
        }

        [LoggedIn]
        [Route("user/add-user/o")]
        public ActionResult AddUserOwner(Owner model)
        {

            CreateUserRequest request = new CreateUserRequest();
            request.UserID = model.UserID;
            request.Username = model.Username;
            request.Type = model.Type;

            CreateOwnerRequest ownerRequest = new CreateOwnerRequest();
            ownerRequest.OwnerID = model.OwnerID;
            ownerRequest.Type = model.OwnerType;
            ownerRequest.Name = model.Name;
            ownerRequest.UnitNr = model.UnitNr;
            ownerRequest.ComplexName = model.ComplexName;
            ownerRequest.StreetNumber = model.StreetNumber;
            ownerRequest.StreeName = model.StreetName;
            ownerRequest.Suburb = model.Suburb;
            ownerRequest.City = model.City;
            ownerRequest.PostalCode = model.PostalCode;
            ownerRequest.TelWork = model.TelWork;
            ownerRequest.TelMobile = model.TelMobile;
            ownerRequest.Fax = model.Fax;
            ownerRequest.Email = model.Email;
            ownerRequest.Website = model.Website;
            ownerRequest.Title = model.Title;
            ownerRequest.FirstName = model.FirstName;
            ownerRequest.SecondName = model.SecondName;
            ownerRequest.ThirdName = model.ThirdName;
            ownerRequest.LastName = model.LastName;
            ownerRequest.IDNumber = model.IDNumber;


            var result = ApiWrapper.Post<OwnerResponse>("api/owner/add", ownerRequest);

            request.UserKey = result.OwnerID;
            var resultUser = ApiWrapper.Post<bool>("api/user/add", request);


            if (string.IsNullOrEmpty(Request.QueryString["returnurl"]))
                return Redirect("/user/list/o");
            else
                return Redirect(Request.QueryString["returnurl"]);
        }

        [LoggedIn]
        [Route("user/add-user/ag")]
        public ActionResult AddUserAgent(LandlordAgent model)
        {

            CreateUserRequest request = new CreateUserRequest();
            request.UserID = model.UserID;
            request.Username = model.Username;
            request.Type = model.Type;

            CreateLandlordAgentRequest agentRequest = new CreateLandlordAgentRequest();
            agentRequest.LandlordAgentID = model.LandlordAgentID;
            agentRequest.TelWork = model.TelWork;
            agentRequest.TelMobile = model.TelMobile;
            agentRequest.Email = model.Email;
            agentRequest.FirstName = model.FirstName;
            agentRequest.LastName = model.LastName;
            agentRequest.IDNumber = model.IDNumber;
            agentRequest.UserKey = model.LandlordAgentID;


            var result = ApiWrapper.Post<LandlordAgentResponse>("api/landlordagent/add", agentRequest);

            request.UserKey = result.LandlordAgentID;
            var resultUser = ApiWrapper.Post<bool>("api/user/add", request);


            if (string.IsNullOrEmpty(Request.QueryString["returnurl"]))
                return Redirect("/user/list/ag");
            else
                return Redirect(Request.QueryString["returnurl"]);
        }

        [LoggedIn]
        [Route("user/add-user/a")]
        public ActionResult AddUserAdmin(LandlordAdmin model)
        {

            CreateUserRequest request = new CreateUserRequest();
            request.UserID = model.UserID;
            request.Username = model.Username;
            request.Type = model.Type;

            CreateLandlordAdminRequest adminRequest = new CreateLandlordAdminRequest();
            adminRequest.LandlordAdminID = model.LandlordAdminID;
            adminRequest.TelWork = model.TelWork;
            adminRequest.TelMobile = model.TelMobile;
            adminRequest.Email = model.Email;
            adminRequest.FirstName = model.FirstName;
            adminRequest.LastName = model.LastName;
            adminRequest.IDNumber = model.IDNumber;
            adminRequest.UserKey = model.LandlordAdminID;


            var result = ApiWrapper.Post<LandlordAdminResponse>("api/landlordadmin/add", adminRequest);

            request.UserKey = result.LandlordAdminID;
            var resultUser = ApiWrapper.Post<bool>("api/user/add", request);


            if (string.IsNullOrEmpty(Request.QueryString["returnurl"]))
                return Redirect("/user/list/a");
            else
                return Redirect(Request.QueryString["returnurl"]);
        }
    }
}