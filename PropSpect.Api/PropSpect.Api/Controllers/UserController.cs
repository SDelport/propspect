using PropSpect.Api.Authorize;
using PropSpect.Api.Models;
using PropSpect.Api.Models.Helpers;
using PropSpect.Api.Models.Request;
using PropSpect.Api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PropSpect.Api.Controllers
{
    public class UserController : Controller
    {

        DatabaseContext db = new DatabaseContext();

        public LoginRole GetUserRole(string identifier)
        {
            LoginRole type = LoginRole.None;

            //Try get from db
            type = LoginRole.Tenant;

            return type;
        }


        [Route("login")]
        public JsonResult Login(LoginRequest request)
        {
            LoginResponse response = new LoginResponse();
            response.Role = LoginRole.None;
            var k = db.Users.Where(x => x.Username.ToLower() == request.Username.ToLower());
            var users = k.ToList();

            string encoded = "";
            bool found = false;

            User loggedInUser = null;

            foreach (var user in users)
            {
                if (request.Password != null && user.Salt != null)
                    encoded = Encode(request.Password + user.Salt);

                if (encoded == user.Password || user.Password == null)
                {
                    found = true;
                    loggedInUser = user;
                    break;
                }

            }

            if (loggedInUser != null)
            {
                response.Username = loggedInUser.Username;
                response.Role = Associations.GetLoginRole(loggedInUser.Type);
                response.UserID = encoded;
            }


            return Json(response);
        }


        public static string Encode(string password)
        {
            byte[] encodedPassword = new UTF8Encoding().GetBytes(password);

            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
            string encoded = BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();

            return encoded;
        }


        [Route("api/user/get/{id}")]
        public JsonResult Get(int id)
        {
            UserResponse response = null;

            User user = db.Users.Where(x => x.UserID == id).FirstOrDefault();

            if (user != null)
            {
                response = new UserResponse();
                response.UserID = user.UserID;
                response.Username = user.Username;
                response.Language = user.Language;
                response.IsPasswordChanged = user.IsPasswordChanged == 'Y';
                if (!response.IsPasswordChanged)
                    response.Password = user.Password;
                response.Type = user.Type;
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("api/user/add")]
        public JsonResult Add(CreateUserRequest request)
        {
            if (request.UserID <= 0)
            {
                User user = new User();
                user.UserID = request.UserID;
                user.UserKey = request.UserKey;
                user.Type = request.Type;
                user.Username = request.Username;
                user.IsPasswordChanged = 'N';
                user.Language = request.Language;

                db.Users.Add(user);
                db.SaveChanges();
            }
            else
            {
                User user = db.Users.Where(x => x.UserID == request.UserID).FirstOrDefault();
                if (user != null)
                {
                    user.Type = request.Type;
                    user.Username = request.Username;

                    db.SaveChanges();
                }

            }

            return Json("true");
        }

        [Route("api/user/list/{type?}")]
        public JsonResult List(string type = "")
        {
            string realType = Associations.GetLoginRole(Associations.GetLoginRole(type));

            return Json(db.Users.Where(x => x.Type == realType || type == "").ToList().Select(x => new UserResponse()
            {
               
                Username = x.Username,
                Language = x.Language,
                IsPasswordChanged = x.IsPasswordChanged == 'Y',
                Password = x.Password,
                Type = x.Type,
                UserID = x.UserID,
                UserKey = x.UserKey
            }).ToList(), JsonRequestBehavior.AllowGet);
        }

    }
}