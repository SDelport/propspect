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
    public class LandlordTemplateAreaController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        [Route("api/landlordtemplatearea/{id}")]
        public JsonResult Get(int id)
        {
            LandlordTemplateAreaResponse response = null;

            LandlordTemplateArea landlordTemplateArea = db.LandlordTemplateAreas.Where(x => x.LandlordTemplateAreaID == id).FirstOrDefault();

            if (landlordTemplateArea != null)
            {
                response = new LandlordTemplateAreaResponse();
                response.LandlordTemplateAreaID = landlordTemplateArea.LandlordTemplateAreaID;
                response.AreaName = landlordTemplateArea.AreaName;
                response.AreaOrder = landlordTemplateArea.AreaOrder;
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("api/landlordtemplatearea/add")]
        public JsonResult Add(CreateLandlordTemplateAreaRequest request)
        {
            if (request.LandlordTemplateAreaID <= 0)
            {
                LandlordTemplateArea landlordTemplateArea = new LandlordTemplateArea();
                landlordTemplateArea.LandlordTemplateAreaID = request.LandlordTemplateAreaID;
                landlordTemplateArea.AreaName = request.AreaName;
                landlordTemplateArea.AreaOrder = request.AreaOrder;

                db.LandlordTemplateAreas.Add(landlordTemplateArea);
                db.SaveChanges();
            }
            else
            {
                LandlordTemplateArea landlordTemplateArea = db.LandlordTemplateAreas.Where(x => x.LandlordTemplateAreaID == request.LandlordTemplateAreaID).FirstOrDefault();
                if (landlordTemplateArea != null)
                {
                    landlordTemplateArea.LandlordTemplateAreaID = request.LandlordTemplateAreaID;
                    landlordTemplateArea.AreaName = request.AreaName;
                    landlordTemplateArea.AreaOrder = request.AreaOrder;

                    db.SaveChanges();
                }

            }

            return Json("true");
        }

        [Route("api/landlordtemplatearea")]
        public JsonResult List()
        {
            return Json(db.LandlordTemplateAreas.ToList().Select(x => new LandlordTemplateAreaResponse()
            {
                LandlordTemplateAreaID = x.LandlordTemplateAreaID,
                AreaName = x.AreaName,
                AreaOrder = x.AreaOrder
            }).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}