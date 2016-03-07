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
    public class LandlordTemplateController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        [Route("api/landlordtemplate/{id}")]
        public JsonResult Get(int id)
        {
            LandlordTemplateResponse response = null;

            LandlordTemplate landlordTemplate = db.LandlordTemplates.Where(x => x.LandlordTemplateID == id).FirstOrDefault();

            if (landlordTemplate != null)
            {
                response = new LandlordTemplateResponse();
                response.LandlordTemplateID = landlordTemplate.LandlordTemplateID;
                response.TemplateName = landlordTemplate.TemplateName;
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("api/landlordtemplate/add")]
        public JsonResult Add(CreateLandlordTemplateRequest request)
        {
            if (request.LandlordTemplateID <= 0)
            {
                LandlordTemplate landlordTemplate = new LandlordTemplate();
                landlordTemplate.LandlordTemplateID = request.LandlordTemplateID;
                landlordTemplate.TemplateName = request.TemplateName;

                db.LandlordTemplates.Add(landlordTemplate);
                db.SaveChanges();
            }
            else
            {
                LandlordTemplate landlordTemplate = db.LandlordTemplates.Where(x => x.LandlordTemplateID == request.LandlordTemplateID).FirstOrDefault();
                if (landlordTemplate != null)
                {
                    landlordTemplate.LandlordTemplateID = request.LandlordTemplateID;
                    landlordTemplate.TemplateName = request.TemplateName;

                    db.SaveChanges();
                }

            }

            return Json("true");
        }

        [Route("api/landlordtemplate")]
        public JsonResult List()
        {
            return Json(db.LandlordTemplates.ToList().Select(x => new LandlordTemplateResponse()
            {
                LandlordTemplateID = x.LandlordTemplateID,
                TemplateName = x.TemplateName
            }).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}