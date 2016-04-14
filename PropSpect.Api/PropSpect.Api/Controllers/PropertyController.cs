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
    public class PropertyController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        [Route("api/property/{id}")]
        public JsonResult Get(int id)
        {
            PropertyResponse response = null;

            Property property = db.Properties.Where(x => x.PropertyID == id).FirstOrDefault();

            if (property != null)
            {
                response = new PropertyResponse();

                response.PropertyID = property.PropertyID;
                response.PropertyType = property.PropertyType;
                response.UnitNumber = property.UnitNumber;
                response.ComplexName = property.ComplexName;
                response.StreetNumber = property.StreetNumber;
                response.StreetName = property.StreetName;
                response.Suburb = property.Suburb;
                response.City = property.City;
                response.PostalCode = property.PostalCode;
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("api/property/add")]
        public JsonResult Add(CreatePropertyRequest request)
        {
            Property property = null;

            if (request.PropertyID <= 0)
            {
                property = new Property();
                property.PropertyID = request.PropertyID;
                property.PropertyType = request.PropertyType;
                property.UnitNumber = request.UnitNumber;
                property.ComplexName = request.ComplexName;
                property.StreetNumber = request.StreetNumber;
                property.StreetName = request.StreetName;
                property.Suburb = request.Suburb;
                property.City = request.City;
                property.PostalCode = request.PostalCode;

                db.Properties.Add(property);
                db.SaveChanges();
            }
            else
            {
                property = db.Properties.Where(x => x.PropertyID == request.PropertyID).FirstOrDefault();
                if (property != null)
                {
                    property.PropertyID = request.PropertyID;
                    property.PropertyType = request.PropertyType;
                    property.UnitNumber = request.UnitNumber;
                    property.ComplexName = request.ComplexName;
                    property.StreetNumber = request.StreetNumber;
                    property.StreetName = request.StreetName;
                    property.Suburb = request.Suburb;
                    property.City = request.City;
                    property.PostalCode = request.PostalCode;

                    db.SaveChanges();
                }

            }

            return Json(property);
        }


        [Route("api/property/list")]
        public JsonResult List()
        {
            return Json(db.Properties.ToList().Select(x => new PropertyResponse()
            {
                PropertyID = x.PropertyID,
                PropertyType = x.PropertyType,
                UnitNumber = x.UnitNumber,
                ComplexName = x.ComplexName,
                StreetNumber = x.StreetNumber,
                StreetName = x.StreetName,
                Suburb = x.Suburb,
                City = x.City,
                PostalCode = x.PostalCode
            }).ToList(), JsonRequestBehavior.AllowGet);
        }

        [Route("api/property/search/{search?}")]
        public JsonResult Search(string search = "")
        {
            return Json(db.Properties.ToList().Select(x => new PropertyResponse()
            {
                PropertyID = x.PropertyID,
                PropertyType = x.PropertyType,
                UnitNumber = x.UnitNumber,
                ComplexName = x.ComplexName,
                StreetNumber = x.StreetNumber,
                StreetName = x.StreetName,
                Suburb = x.Suburb,
                City = x.City,
                PostalCode = x.PostalCode
            }).ToList(), JsonRequestBehavior.AllowGet);
        }


        [Route("api/property/search/exclude-owner/{ownerID}")]
        public JsonResult ListOwnerExlude(int ownerID)
        {
            var q = from tbl in db.Properties
                    let po = db.PropertyOwners.Where(x=>x.OwnerID == ownerID).Select(x=>x.PropertyID).ToList()
                    where !po.Contains(tbl.PropertyID)
                    select tbl;

            return Json(q.ToList().Select(x => new PropertyResponse()
            {
                PropertyID = x.PropertyID,
                PropertyType = x.PropertyType,
                UnitNumber = x.UnitNumber,
                ComplexName = x.ComplexName,
                StreetNumber = x.StreetNumber,
                StreetName = x.StreetName,
                Suburb = x.Suburb,
                City = x.City,
                PostalCode = x.PostalCode
            }).ToList(), JsonRequestBehavior.AllowGet);
        }

        [Route("api/property/owner/{ownerID}")]
        public JsonResult PropertiesByOwner(int ownerID)
        {
            var q = from tbl in db.Properties
                    join po in db.PropertyOwners on tbl.PropertyID equals po.PropertyID
                    where po.OwnerID == ownerID
                    select tbl;

            return Json(q.ToList().Select(x => new PropertyResponse()
            {
                PropertyID = x.PropertyID,
                PropertyType = x.PropertyType,
                UnitNumber = x.UnitNumber,
                ComplexName = x.ComplexName,
                StreetNumber = x.StreetNumber,
                StreetName = x.StreetName,
                Suburb = x.Suburb,
                City = x.City,
                PostalCode = x.PostalCode
            }).ToList(), JsonRequestBehavior.AllowGet);
        }

        [Route("api/property/assign/{propertyID}/{ownerID}")]
        public JsonResult AssignProperty(int propertyID, int ownerID)
        {
            var property = db.Properties.Where(x => x.PropertyID == propertyID).FirstOrDefault();
            var owner = db.Owners.Where(x => x.OwnerID == ownerID).FirstOrDefault();
            bool assigned = false;
            if (owner != null && property != null)
            {
                PropertyOwner propertyOwner = new PropertyOwner();

                propertyOwner.PropertyID = propertyID;
                propertyOwner.OwnerID = ownerID;

                db.PropertyOwners.Add(propertyOwner);
                db.SaveChanges();
                assigned = true;
            }

            return Json(assigned, JsonRequestBehavior.AllowGet);
        }

        [Route("api/property/unassign/{propertyID}/{ownerID}")]
        public JsonResult UnassignProperty(int propertyID, int ownerID)
        {
            var propertyOwner = db.PropertyOwners.Where(x => x.PropertyID == propertyID && x.OwnerID == ownerID).FirstOrDefault();
            bool unassigned = false;
            if (propertyOwner != null)
            {
                db.PropertyOwners.Remove(propertyOwner);
                db.SaveChanges();
                unassigned = true;
            }

            return Json(unassigned, JsonRequestBehavior.AllowGet);
        }


    }
}