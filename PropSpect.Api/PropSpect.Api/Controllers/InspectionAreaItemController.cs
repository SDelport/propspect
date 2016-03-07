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
    public class InspectionAreaItemController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        [Route("api/inspectionareaitem/{id}")]
        public JsonResult Get(int id)
        {
            InspectionAreaItemResponse response = null;

            InspectionAreaItem inspectionAreaItem = db.InspectionAreaItems.Where(x => x.InspectionAreaItemID == id).FirstOrDefault();

            if (inspectionAreaItem != null)
            {
                response = new InspectionAreaItemResponse();
                response.InspectionAreaItemID = inspectionAreaItem.InspectionAreaItemID;
                response.ItemCondition = inspectionAreaItem.ItemCondition;
                response.ItemDescription = inspectionAreaItem.ItemDescription;
                response.ItemID = inspectionAreaItem.ItemID;
                response.ItemRepair = inspectionAreaItem.ItemRepair;

            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("api/inspectionareaitem/add")]
        public JsonResult Add(CreateInspectionAreaItemRequest request)
        {
            if (request.InspectionAreaItemID <= 0)
            {
                InspectionAreaItem inspectionAreaItem = new InspectionAreaItem();
                inspectionAreaItem.InspectionAreaItemID = request.InspectionAreaItemID;
                inspectionAreaItem.ItemCondition = request.ItemCondition;
                inspectionAreaItem.ItemDescription = request.ItemDescription;
                inspectionAreaItem.ItemID = request.ItemID;
                inspectionAreaItem.ItemRepair = request.ItemRepair;


                db.InspectionAreaItems.Add(inspectionAreaItem);
                db.SaveChanges();
            }
            else
            {
                InspectionAreaItem inspectionAreaItem = db.InspectionAreaItems.Where(x => x.InspectionAreaItemID == request.InspectionAreaItemID).FirstOrDefault();
                if (inspectionAreaItem != null)
                {
                    inspectionAreaItem.InspectionAreaItemID = request.InspectionAreaItemID;
                    inspectionAreaItem.ItemCondition = request.ItemCondition;
                    inspectionAreaItem.ItemDescription = request.ItemDescription;
                    inspectionAreaItem.ItemID = request.ItemID;
                    inspectionAreaItem.ItemRepair = request.ItemRepair;

                    db.SaveChanges();
                }

            }

            return Json("true");
        }

        [Route("api/inspectionareaitem")]
        public JsonResult List()
        {
            return Json(db.InspectionAreaItems.ToList().Select(x => new InspectionAreaItemResponse()
            {
                InspectionAreaItemID = x.InspectionAreaItemID,
                ItemCondition = x.ItemCondition,
                ItemDescription = x.ItemDescription,
                ItemID = x.ItemID,
                ItemRepair = x.ItemRepair
            }).ToList(), JsonRequestBehavior.AllowGet);
        }

    }
}