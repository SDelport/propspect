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
    public class TenantController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        [Route("api/tenant/{id}")]
        public JsonResult Get(int id)
        {
            TenantResponse response = null;

            Tenant tenant = db.Tenants.Where(x => x.TenantID == id).FirstOrDefault();

            if (tenant != null)
            {
                response = new TenantResponse();
                response.TenantID = tenant.TenantID;
                response.Email = tenant.Email;
                response.FirstName = tenant.FirstName;
                response.IDNumber = tenant.IDNumber;
                response.LastName = tenant.LastName;
                response.PreferredName = tenant.PreferredName;
                response.SecondName = tenant.SecondName;
                response.TelMobile = tenant.TelMobile;
                response.TelWork = tenant.TelWork;
                response.ThirdName = tenant.ThirdName;
                response.Title = tenant.Title;
                response.Website = tenant.Website;
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [Route("api/tenant/delete/{id}")]
        public JsonResult Delete(int id)
        {
            Tenant tenant = db.Tenants.Where(x => x.TenantID == id).FirstOrDefault();
            bool result = false;
            if (tenant != null)
            {
                db.Tenants.Remove(tenant);
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("api/tenant/add")]
        public JsonResult Add(CreateTenantRequest request)
        {
            Tenant tenant = null;
            if (request.TenantID <= 0)
            {
                tenant = new Tenant();
                tenant.TenantID = request.TenantID;
                tenant.Email = request.Email;
                tenant.FirstName = request.FirstName;
                tenant.IDNumber = request.IDNumber;
                tenant.LastName = request.LastName;
                tenant.PreferredName = request.PreferredName;
                tenant.SecondName = request.SecondName;
                tenant.TelMobile = request.TelMobile;
                tenant.TelWork = request.TelWork;
                tenant.ThirdName = request.ThirdName;
                tenant.Title = request.Title;
                tenant.Website = request.Website;

                db.Tenants.Add(tenant);
                db.SaveChanges();

                

            }
            else
            {
                tenant = db.Tenants.Where(x => x.TenantID == request.TenantID).FirstOrDefault();
                if (tenant != null)
                {
                    tenant.TenantID = request.TenantID;
                    tenant.Email = request.Email;
                    tenant.FirstName = request.FirstName;
                    tenant.IDNumber = request.IDNumber;
                    tenant.LastName = request.LastName;
                    tenant.PreferredName = request.PreferredName;
                    tenant.SecondName = request.SecondName;
                    tenant.TelMobile = request.TelMobile;
                    tenant.TelWork = request.TelWork;
                    tenant.ThirdName = request.ThirdName;
                    tenant.Title = request.Title;
                    tenant.Website = request.Website;

                    db.SaveChanges();
                }

            }

            return Json(tenant);
        }

        [Route("api/tenant")]
        public JsonResult List()
        {
            return Json(db.Tenants.ToList().Select(x => new TenantResponse()
            {
                TenantID = x.TenantID,
                Email = x.Email,
                FirstName = x.FirstName,
                IDNumber = x.IDNumber,
                LastName = x.LastName,
                PreferredName = x.PreferredName,
                SecondName = x.SecondName,
                TelMobile = x.TelMobile,
                TelWork = x.TelWork,
                ThirdName = x.ThirdName,
                Title = x.Title,
                Website = x.Website
            }).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}