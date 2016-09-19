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
                response.PropertyID = area.PropertyID;         
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

        [Route("api/area/remove")]
        public JsonResult Remove(CreateAreaRequest request)
        {
            Area area = null;
            bool removed = false;
            if (request.AreaID > 0)
            {
                List<AreaItem> areaItems = db.AreaItems.Where(x => x.AreaID == request.AreaID).ToList();
                foreach (var areaitem in areaItems)
                {
                    db.AreaItems.Remove(areaitem);
                }
                area = db.Areas.Where(x => x.AreaID == request.AreaID).FirstOrDefault();
                db.Areas.Remove(area);
                db.SaveChanges();
                removed = true;
            }
            return Json(removed, JsonRequestBehavior.AllowGet);
        }

        [Route("api/area/addFromTemplate/{AreaTemplateID}/{PropertyID}")]
        public JsonResult AddFromTemplate(int AreaTemplateID,int PropertyID)
        {
            Area area = null;
            bool added = false;
            if (AreaTemplateID>0&&PropertyID>0)
            {
                area = new Area();
                LandlordTemplateArea templateArea = db.LandlordTemplateAreas.Where(x => x.LandlordTemplateAreaID == AreaTemplateID).FirstOrDefault();
                area.Name = templateArea.AreaName;
                area.PropertyID = PropertyID;
                db.Areas.Add(area);
                db.SaveChanges();
                List<LandlordTemplateAreaItem> templateAreaItems = db.LandlordTemplateAreaItems.Where(y => y.LandlordTemplateAreaID == AreaTemplateID).ToList();
                foreach (var templateAreaItem in templateAreaItems)
                {
                    AreaItem item = new AreaItem();
                    item.AreaID = area.AreaID;
                    item.RoomDescription = "";
                    item.RoomItem = templateAreaItem.ItemName;
                    db.AreaItems.Add(item);
                }
                db.SaveChanges();
                added = true;
            }
            return Json(added, JsonRequestBehavior.AllowGet);
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
        [Route("api/area/selectForProperty/{propertyID}")]
        public JsonResult GetForProperty(int propertyID)
        {
            return Json(db.Areas.Where(y => y.PropertyID==propertyID).ToList().Select(x => new AreaResponse()
            {
                AreaID = x.AreaID,
                PropertyID = x.PropertyID,
                Name = x.Name
            }).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}