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

        [HttpPost]
        [Route("api/inspection/add")]
        public JsonResult Add(CreateLandLordRequest request)
        {
            if (request.LandlordID <= 0)
            {
                Landlord landlord = new Landlord();
                landlord.Title = request.Title;
                landlord.Name = request.Name;
                landlord.FirstName = request.FirstName;
                landlord.LastName = request.LastName;
                landlord.SecondName = request.SecondName;
                landlord.ThirdName = request.ThirdName;
                landlord.Type = request.Type;
                landlord.IDNumber = request.IDNumber;
                landlord.AddressUnitNr = request.AddressUnitNr;
                landlord.ComplexName = request.ComplexName;
                landlord.StreetNumber = request.StreetNumber;
                landlord.StreetName = request.StreetName;
                landlord.CityName = request.CityName;
                landlord.PostalCode = request.PostalCode;
                landlord.TelWork = request.TelWork;
                landlord.TelMobile = request.TelMobile;
                landlord.Fax = request.Fax;
                landlord.Email = request.Email;
                landlord.Website = request.Website;
                landlord.RegNumber = request.RegNumber;
                landlord.VatNumber = request.VatNumber;
                

                db.LandLords.Add(landlord);
                db.SaveChanges();
            }
            else
            {
                Landlord landlord = db.LandLords.Where(x => x.LandlordID == request.LandlordID).FirstOrDefault();
                if (landlord != null)
                {
                    landlord.Title = request.Title;
                    landlord.Name = request.Name;
                    landlord.FirstName = request.FirstName;
                    landlord.LastName = request.LastName;
                    landlord.SecondName = request.SecondName;
                    landlord.ThirdName = request.ThirdName;
                    landlord.Type = request.Type;
                    landlord.IDNumber = request.IDNumber;
                    landlord.AddressUnitNr = request.AddressUnitNr;
                    landlord.ComplexName = request.ComplexName;
                    landlord.StreetNumber = request.StreetNumber;
                    landlord.StreetName = request.StreetName;
                    landlord.CityName = request.CityName;
                    landlord.PostalCode = request.PostalCode;
                    landlord.TelWork = request.TelWork;
                    landlord.TelMobile = request.TelMobile;
                    landlord.Fax = request.Fax;
                    landlord.Email = request.Email;
                    landlord.Website = request.Website;
                    landlord.RegNumber = request.RegNumber;
                    landlord.VatNumber = request.VatNumber;

                    db.SaveChanges();
                }

            }

            return Json("true");
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
                PoolClean = x.PoolClean,
                PoolComments = x.PoolComments,
                OverallComments = x.OverallComments
            }).ToList(), JsonRequestBehavior.AllowGet);
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
            catch (IndexOutOfRangeException)
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
                OverallComments = x.OverallComments
            }).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}