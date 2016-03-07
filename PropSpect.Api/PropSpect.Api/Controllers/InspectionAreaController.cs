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
    public class InspectionAreaController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        [Route("api/inspectionarea/{id}")]
        public JsonResult Get(int id)
        {
            InspectionAreaResponse response = null;

            InspectionArea inspectionArea = db.InspectionAreas.Where(x => x.InspectionAreaID == id).FirstOrDefault();

            if (inspectionArea != null)
            {
                response = new InspectionAreaResponse();
                response.InspectionAreaID = inspectionArea.InspectionAreaID;
                response.AreaID = inspectionArea.AreaID;
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("api/inspectionarea/add")]
        public JsonResult Add(CreateInspectionAreaRequest request)
        {
            if (request.InspectionAreaID <= 0)
            {
                InspectionArea inspectionArea = new InspectionArea();
                inspectionArea.InspectionAreaID = request.InspectionAreaID;
                inspectionArea.AreaID = request.AreaID;

                db.InspectionAreas.Add(inspectionArea);
                db.SaveChanges();
            }
            else
            {
                InspectionArea inspectionArea = db.InspectionAreas.Where(x => x.InspectionAreaID == request.InspectionAreaID).FirstOrDefault();
                if (inspectionArea != null)
                {
                    inspectionArea.InspectionAreaID = request.InspectionAreaID;
                    inspectionArea.AreaID = request.AreaID;

                    db.SaveChanges();
                }

            }

            return Json("true");
        }

        [Route("api/inspectionarea")]
        public JsonResult List()
        {
            return Json(db.InspectionAreas.ToList().Select(x => new InspectionAreaResponse()
            {
                InspectionAreaID = x.InspectionAreaID,
                AreaID = x.AreaID
            }).ToList(), JsonRequestBehavior.AllowGet);
        }

    }
}