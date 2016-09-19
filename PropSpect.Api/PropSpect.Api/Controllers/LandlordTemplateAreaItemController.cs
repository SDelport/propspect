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
    public class LandlordTemplateAreaItemController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        [Route("api/landlordtemplateareaitem/{id}")]
        public JsonResult Get(int id)
        {
            LandlordTemplateAreaItemResponse response = null;

            LandlordTemplateAreaItem landlordTemplateAreaItem = db.LandlordTemplateAreaItems.Where(x => x.LandlordTemplateAreaItemID == id).FirstOrDefault();

            if (landlordTemplateAreaItem != null)
            {
                response = new LandlordTemplateAreaItemResponse();
                response.LandlordTemplateAreaItemID = landlordTemplateAreaItem.LandlordTemplateAreaItemID;
                response.ItemName = landlordTemplateAreaItem.ItemName;
                response.ItemOrder = landlordTemplateAreaItem.ItemOrder;
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("api/arealandlordtemplateareaitem/add")]
        public JsonResult Add(CreateLandlordTemplateAreaItemRequest request)
        {
            if (request.LandlordTemplateAreaItemID <= 0)
            {
                LandlordTemplateAreaItem landlordTemplateAreaItem = new LandlordTemplateAreaItem();
                landlordTemplateAreaItem.LandlordTemplateAreaItemID = request.LandlordTemplateAreaItemID;
                landlordTemplateAreaItem.ItemName = request.ItemName;
                landlordTemplateAreaItem.ItemOrder = request.ItemOrder;

                db.LandlordTemplateAreaItems.Add(landlordTemplateAreaItem);
                db.SaveChanges();
            }
            else
            {
                LandlordTemplateAreaItem landlordTemplateAreaItem = db.LandlordTemplateAreaItems.Where(x => x.LandlordTemplateAreaItemID == request.LandlordTemplateAreaItemID).FirstOrDefault();
                if (landlordTemplateAreaItem != null)
                {
                    landlordTemplateAreaItem.LandlordTemplateAreaItemID = request.LandlordTemplateAreaItemID;
                    landlordTemplateAreaItem.ItemName = request.ItemName;
                    landlordTemplateAreaItem.ItemOrder = request.ItemOrder;


                    db.SaveChanges();
                }

            }

            return Json("true");
        }

        [Route("api/landlordtemplateareaitem")]
        public JsonResult List()
        {
            return Json(db.LandlordTemplateAreaItems.ToList().Select(x => new LandlordTemplateAreaItemResponse()
            {
                LandlordTemplateAreaItemID = x.LandlordTemplateAreaItemID,
                ItemName = x.ItemName,
                ItemOrder = x.ItemOrder
            }).ToList(), JsonRequestBehavior.AllowGet);
        }
        [Route("api/landlordtemplateareaitemforarea/{id}")]
        public JsonResult ListForArea(int id)
        {
            return Json(db.LandlordTemplateAreaItems.Where(x=> id==x.LandlordTemplateAreaID).ToList().Select(x => new LandlordTemplateAreaItemResponse()
            {
                LandlordTemplateAreaItemID = x.LandlordTemplateAreaItemID,
                ItemName = x.ItemName,
                ItemOrder = x.ItemOrder
            }).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}