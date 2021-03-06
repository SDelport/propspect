﻿using PropSpect.Api.Models;
using PropSpect.Api.Models.Request;
using PropSpect.Api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropSpect.Api.Controllers
{
    public class InspectionController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        [Route("api/inspection/{id}")]
        public JsonResult Get(int id)
        {
            LandlordResponse response = null;
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [Route("api/inspection/{id}/completed")]
        public JsonResult Completed(int id)
        {
            Inspection inspection = db.Inspections.Where(x => x.InspectionID == id).FirstOrDefault();
            inspection.Completed = true;
            db.SaveChanges();
            InspectionResponse response = new InspectionResponse()
            {
                InspectionID = inspection.InspectionID,
                Type = inspection.Type,
                Date = inspection.Date,
                EntityType = inspection.EntityType,
                EntityID = inspection.EntityID,
                HouseClean = inspection.HouseClean,
                HouseComments = inspection.HouseComments,
                CarpetsClean = inspection.CarpetsClean,
                CarpetsComments = inspection.CarpetsComments,
                GardenClean = inspection.GardenClean,
                GardenComments = inspection.GardenComments,
                PropertyID = inspection.PropertyID,
                PoolClean = inspection.PoolClean,
                PoolComments = inspection.PoolComments,
                OverallComments = inspection.OverallComments,
                Completed = inspection.Completed
            };
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [Route("api/inspection/add")]
        public JsonResult Add(CreateInspectionRequest request)
        {
            Inspection inspection = new Inspection()
            {
                PropertyID = request.PropertyID,
                OverallComments = "Test on " + DateTime.Now.ToShortTimeString()
            };

            db.Inspections.Add(inspection);
            db.SaveChanges();

            var propertyAreas = db.Areas.Where(x => x.PropertyID == request.PropertyID).ToList();

            foreach (var propertyArea in propertyAreas)
            {
                InspectionArea area = new InspectionArea()
                {
                    InspectionID = inspection.InspectionID,
                    AreaID = propertyArea.AreaID
                };

                db.InspectionAreas.Add(area);
                db.SaveChanges();

                var areaItems = db.AreaItems.Where(x => x.AreaID == propertyArea.AreaID).ToList();

                foreach (var areaItem in areaItems)
                {
                    InspectionAreaItem item = new InspectionAreaItem()
                    {
                        InspectionAreaID = area.InspectionAreaID,
                        ItemID = areaItem.AreaItemID,
                        ItemDescription = areaItem.RoomItem,
                    };

                    db.InspectionAreaItems.Add(item);
                    db.SaveChanges();
                }
                
            }

            InspectionResponse response = new InspectionResponse();
            response.InspectionID = inspection.InspectionID;
            response.Completed = false;
            return Json(response);
        }


        [Route("api/inspection")]
        public JsonResult List()
        {
            return Json(db.Inspections.ToList().Select(x => new InspectionResponse()
            {
                InspectionID = x.InspectionID,
                Type = x.Type,
                Date = x.Date,
                EntityType = x.EntityType,
                EntityID = x.EntityID,
                HouseClean = x.HouseClean,
                HouseComments = x.HouseComments,
                CarpetsClean = x.CarpetsClean,
                CarpetsComments = x.CarpetsComments,
                GardenClean = x.GardenClean,
                GardenComments = x.GardenComments,
                PropertyID = x.PropertyID,
                PoolClean = x.PoolClean,
                PoolComments = x.PoolComments,
                OverallComments = x.OverallComments,
                Completed = x.Completed
            }).ToList(), JsonRequestBehavior.AllowGet);
        }

        [Route("api/inspection/areas/{InspectionID}")]
        public JsonResult GetInspectionAreas(int InspectionID)
        {    
            return Json(db.InspectionAreas.Where(x => x.InspectionID == InspectionID).ToList().Select(x => new InspectionAreaResponse()
            {
                AreaID = x.AreaID,
                InspectionAreaID = x.InspectionAreaID,
                InspectionID = x.InspectionID
            }), JsonRequestBehavior.AllowGet);
        }

        [Route("api/inspection/areaItems/{AreaID}")]
        public JsonResult GetInspectionAreaItems(int AreaID)
        {
            return Json(db.InspectionAreaItems.Where(x => x.InspectionAreaID == AreaID).ToList().Select(x => new InspectionAreaItemResponse()
            {
                InspectionAreaID = x.InspectionAreaItemID,
                InspectionAreaItemID = x.InspectionAreaItemID,
                ItemCondition = x.ItemCondition,
                ItemDescription = x.ItemDescription,
                ItemID = x.ItemID,
                ItemRepair = x.ItemRepair
               
            }), JsonRequestBehavior.AllowGet);
        }

        [Route("api/inspection/inspectionRoomDetails/{InspectionID}/{page}")]
        public JsonResult GetInspectionRoomPersistent(int InspectionID, int page)
        {
            InspectionArea area = null;
            List<InspectionAreaItem> areaItems = new List<InspectionAreaItem>();
            try
            {
                List<InspectionArea> areas = db.InspectionAreas.Where(x => x.InspectionID == InspectionID).ToList();
                area = areas[page];
            }
            catch (Exception)
            {
                return Json(new List<InspectionAreaItem>(), JsonRequestBehavior.AllowGet);
            }
            areaItems = db.InspectionAreaItems.Where(x => x.InspectionAreaID == area.InspectionAreaID).ToList();
            List<InspectionAreaItemResponse> response = new List<InspectionAreaItemResponse>();
            foreach (var item in areaItems)
            {
                response.Add(new InspectionAreaItemResponse()
                {
                    InspectionAreaID = item.InspectionAreaID,
                    InspectionAreaItemID = item.InspectionAreaItemID,
                    ItemCondition = item.ItemCondition,
                    ItemDescription = item.ItemDescription,
                    ItemID = item.ItemID,
                    ItemRepair = item.ItemRepair??"n"
                });
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("api/inspection/editPart/")]
        public JsonResult editPart(CreateInspectionAreaItemRequest request)
        {
            InspectionAreaItem item = db.InspectionAreaItems.Where(x => x.InspectionAreaItemID == request.InspectionAreaItemID).FirstOrDefault();
            item.ItemCondition = request.ItemCondition;
            item.ItemRepair = request.ItemRepair;
            db.SaveChanges();
            return Json(item, JsonRequestBehavior.AllowGet);
        }

        [Route("api/inspection/details/{inspectionTemplateID}/{inspectionAreaID}")]
        public JsonResult List(int inspectionTemplateID, int inspectionAreaID)
        {
            InspectionDetailsResponse response = new InspectionDetailsResponse();
            response.CurrentPage = inspectionAreaID;
            response.TotalPages = 8;
            response.Items = new List<InspectionAreaItemResponse>()
            {
                new InspectionAreaItemResponse()
                {
                    InspectionAreaItemID=1,
                    ItemID = inspectionAreaID
                }
            };
            return Json(db.Inspections.ToList().Select(x => new InspectionResponse()
            {
                InspectionID = x.InspectionID,
                Type = x.Type,
                Date = x.Date,
                EntityType = x.EntityType,
                EntityID = x.EntityID,
                HouseClean = x.HouseClean,
                HouseComments = x.HouseComments,
                CarpetsClean = x.CarpetsClean,
                CarpetsComments = x.CarpetsComments,
                GardenClean = x.GardenClean,
                GardenComments = x.GardenComments,
                PoolClean = x.PoolClean,
                PoolComments = x.PoolComments,
                OverallComments = x.OverallComments,
                Completed = x.Completed
            }).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}