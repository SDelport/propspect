using PropSpect.Api.Models;
using PropSpect.Api.Models.Request;
using PropSpect.Api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropSpect.Api.Controllers
{
    public class LandlordAdminController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        [Route("api/landlordadmin/{id}")]
        public JsonResult Get(int id)
        {
            LandlordAdminResponse response = null;

            LandlordAdmin landlordAdmin = db.LandlordAdmins.Where(x => x.LandlordAdminID == id).FirstOrDefault();

            if (landlordAdmin != null)
            {
                response = new LandlordAdminResponse();
                response.LandlordAdminID = landlordAdmin.LandlordAdminID;
                response.FirstName = landlordAdmin.FirstName;
                response.PreferredName = landlordAdmin.FirstName;
                response.LastName = landlordAdmin.LastName;
                response.IDNumber = landlordAdmin.IDNumber;
                response.TelWork = landlordAdmin.TelWork;
                response.TelMobile = landlordAdmin.TelMobile;
                response.Email = landlordAdmin.Email;
                response.UserKey = landlordAdmin.LandlordAdminID;
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [Route("api/landlordadmin/delete/{id}")]
        public JsonResult Delete(int id)
        {
            LandlordAdmin landlordAdmin = db.LandlordAdmins.Where(x => x.LandlordAdminID == id).FirstOrDefault();
            bool result = false;
            if (landlordAdmin != null)
            {
                db.LandlordAdmins.Remove(landlordAdmin);
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("api/landlordadmin/add")]
        public JsonResult Add(CreateLandlordAdminRequest request)
        {
            LandlordAdmin landlordAdmin = null;
            if (request.LandlordAdminID <= 0)
            {
                landlordAdmin = new LandlordAdmin();
                landlordAdmin.LandlordAdminID = request.LandlordAdminID;
                landlordAdmin.FirstName = request.FirstName;
                landlordAdmin.PreferredName = request.FirstName;
                landlordAdmin.LastName = request.LastName;
                landlordAdmin.IDNumber = request.IDNumber;
                landlordAdmin.TelWork = request.TelWork;
                landlordAdmin.TelMobile = request.TelMobile;
                landlordAdmin.Email = request.Email;
                landlordAdmin.UserKey = request.LandlordAdminID;

                db.LandlordAdmins.Add(landlordAdmin);
                db.SaveChanges();



            }
            else
            {
                landlordAdmin = db.LandlordAdmins.Where(x => x.LandlordAdminID == request.LandlordAdminID).FirstOrDefault();
                if (landlordAdmin != null)
                {
                    landlordAdmin.LandlordAdminID = request.LandlordAdminID;
                    landlordAdmin.FirstName = request.FirstName;
                    landlordAdmin.PreferredName = request.FirstName;
                    landlordAdmin.LastName = request.LastName;
                    landlordAdmin.IDNumber = request.IDNumber;
                    landlordAdmin.TelWork = request.TelWork;
                    landlordAdmin.TelMobile = request.TelMobile;
                    landlordAdmin.Email = request.Email;
                    landlordAdmin.UserKey = request.LandlordAdminID;

                    db.SaveChanges();
                }

            }

            return Json(landlordAdmin);
        }

        [Route("api/landlordadmin")]
        public JsonResult List()
        {
            return Json(db.LandlordAdmins.ToList().Select(x => new LandlordAdminResponse()
            {
                LandlordAdminID = x.LandlordAdminID,
                FirstName = x.FirstName,
                PreferredName = x.FirstName,
                LastName = x.LastName,
                IDNumber = x.IDNumber,
                TelWork = x.TelWork,
                TelMobile = x.TelMobile,
                Email = x.Email,
                UserKey = x.LandlordAdminID
            }).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}