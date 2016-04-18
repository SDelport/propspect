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

        [Route("api/get-templates")]
        public JsonResult List()
        {
            return Json(db.LandlordTemplateAreas.ToList().Select(x => new LandlordTemplateAreaResponse()
            {
                LandlordTemplateAreaID = x.LandlordTemplateAreaID,
                AreaName = x.AreaName,
                AreaOrder = x.AreaOrder,
                Items = db.LandlordTemplateAreaItems.Where(y => y.LandlordTemplateAreaID == x.LandlordTemplateAreaID).Select(y => new LandlordTemplateAreaItemResponse()
                {
                    ItemName = y.ItemName,
                    ItemOrder = y.ItemOrder,
                    LandlordTemplateAreaID = x.LandlordTemplateAreaID,
                    LandlordTemplateAreaItemID = y.LandlordTemplateAreaItemID
                }).OrderBy(y => y.ItemOrder).ToList()
            }).OrderBy(y => y.AreaOrder).ToList(), JsonRequestBehavior.AllowGet);
        }

        [Route("api/save-templates")]
        public JsonResult Save(SaveLandlordTemplatesRequest request)
        {
            List<int> UsedAreas = new List<int>();
            List<int> UsedItems = new List<int>();
            if (request.Areas != null)
            {
                foreach (var requestArea in request.Areas)
                {
                    LandlordTemplateArea area = db.LandlordTemplateAreas.Where(x => x.AreaName.ToLower() == requestArea.AreaName.ToLower()).FirstOrDefault(); ;
                    bool newArea = false;
                    if (area == null)
                    {
                        area = new LandlordTemplateArea();
                        newArea = true;
                    }

                    area.AreaName = requestArea.AreaName;
                    area.AreaOrder = requestArea.AreaOrder;

                    if (newArea)
                        db.LandlordTemplateAreas.Add(area);

                    db.SaveChanges();

                    UsedAreas.Add(area.LandlordTemplateAreaID);
                    if (requestArea.Items != null)
                    {
                        foreach (var itemRequest in requestArea.Items)
                        {
                            LandlordTemplateAreaItem item = db.LandlordTemplateAreaItems.Where(x => x.LandlordTemplateAreaID == area.LandlordTemplateAreaID && x.ItemName == itemRequest.ItemName).FirstOrDefault();
                            bool newItem = false;
                            if (item == null)
                            {
                                item = new LandlordTemplateAreaItem();
                                newItem = true;
                            }
                            item.ItemName = itemRequest.ItemName;
                            item.ItemOrder = itemRequest.ItemOrder;
                            item.LandlordTemplateAreaID = area.LandlordTemplateAreaID;
                            if (newItem)
                                db.LandlordTemplateAreaItems.Add(item);


                            db.SaveChanges();
                            UsedItems.Add(item.LandlordTemplateAreaItemID);
                        }
                    }
                }
            }
            db.LandlordTemplateAreas.RemoveRange(db.LandlordTemplateAreas.Where(x => !UsedAreas.Contains(x.LandlordTemplateAreaID)).ToList());
            db.LandlordTemplateAreaItems.RemoveRange(db.LandlordTemplateAreaItems.Where(x => !UsedItems.Contains(x.LandlordTemplateAreaItemID)).ToList());
            db.SaveChanges();
            return Json(true);
        }
    }
}