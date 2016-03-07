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
    public class PropertyTenantController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        [Route("api/propertytenat/{id}")]
        public JsonResult Get(int id)
        {
            PropertyTenantResponse response = null;

            PropertyTenant propertyTenant = db.PropertyTenants.Where(x => x.PropertyTenantID == id).FirstOrDefault();

            if (propertyTenant != null)
            {
                response = new PropertyTenantResponse();
                response.PropertyTenantID = propertyTenant.PropertyTenantID;
                response.TenantID = propertyTenant.TenantID;
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("api/propertytenat/add")]
        public JsonResult Add(CreatePropertyTenantRequest request)
        {
            if (request.PropertyTenantID <= 0)
            {
                PropertyTenant propertyTenant = new PropertyTenant();
                propertyTenant.PropertyTenantID = request.PropertyTenantID;
                propertyTenant.TenantID = request.TenantID;

                db.PropertyTenants.Add(propertyTenant);
                db.SaveChanges();
            }
            else
            {
                PropertyTenant propertyTenant = db.PropertyTenants.Where(x => x.PropertyTenantID == request.PropertyTenantID).FirstOrDefault();
                if (propertyTenant != null)
                {
                    propertyTenant.PropertyTenantID = request.PropertyTenantID;
                    propertyTenant.TenantID = request.TenantID;

                    db.SaveChanges();
                }

            }

            return Json("true");
        }

        [Route("api/propertytenat")]
        public JsonResult List()
        {
            return Json(db.PropertyTenants.ToList().Select(x => new PropertyTenantResponse()
            {
                PropertyTenantID = x.PropertyTenantID,
                TenantID = x.TenantID
            }).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}