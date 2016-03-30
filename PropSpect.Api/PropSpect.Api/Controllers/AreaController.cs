using PropSpect.Api.Authorize;
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
   
    public class AreaController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        [Route("api/area/get/{id}")]
        public JsonResult Get(int id)
        {
            AreaResponse response = null;

            Area area = db.Areas.Where(x => x.AreaID == id).FirstOrDefault();

            if (area != null)
            {
                response = new AreaResponse();
                response.AreaID = area.AreaID;
                response.Name = area.Name;            
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("api/area/add")]
        public JsonResult Add(CreateAreaRequest request)
        {
            Area area = null;
            if (request.AreaID <= 0)
            {
                area = new Area();
                area.AreaID = request.AreaID;
                area.Name = request.Name;

                db.Areas.Add(area);
                db.SaveChanges();
            }
            else
            {
                 area = db.Areas.Where(x => x.AreaID == request.AreaID).FirstOrDefault();
                if (area != null)
                {
                    area.AreaID = request.AreaID;
                    area.Name = request.Name;                    

                    db.SaveChanges();
                }

            }

            return Json(area);
        }

        [Route("api/area/list")]
        public JsonResult List()
        {
            return Json(db.Areas.ToList().Select(x => new AreaResponse()
            {
                AreaID = x.AreaID,           
                Name = x.Name
            }).ToList(), JsonRequestBehavior.AllowGet);
        }

    }
}