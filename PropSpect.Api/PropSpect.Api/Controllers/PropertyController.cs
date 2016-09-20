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
            var data = db.Properties.AsQueryable();
            search = search.ToLower();
            foreach (var word in search.Trim().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries))
            {
                data = data.Where(x =>
                x.City.ToLower().Contains(word) ||
                x.ComplexName.ToLower().Contains(word) ||
                x.PostalCode.ToString().ToLower().Contains(word) ||
                x.StreetName.ToLower().Contains(word) ||
                x.StreetNumber.ToLower().Contains(word) ||
                x.Suburb.ToLower().Contains(word) ||
                x.UnitNumber.ToLower().Contains(word)
                );
            }

            return Json(data.Take(20).Select(x => new PropertyResponse()
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

        [Route("api/property/getID/{id}")]
        public JsonResult GetPropertyFromID(int id)
        {
            return Json(db.Properties.Where(y => y.PropertyID == id).ToList().Select(x => new PropertyResponse()
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
            }).FirstOrDefault(), JsonRequestBehavior.AllowGet);
        }

        [Route("api/property/search/exclude-owner/{ownerID}")]
        public JsonResult ListOwnerExlude(int ownerID)
        {
            var q = from tbl in db.Properties
                    let po = db.PropertyOwners.Where(x => x.OwnerID == ownerID).Select(x => x.PropertyID).ToList()
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

        [Route("api/property/search/exclude-tenant/{tenantID}")]
        public JsonResult ListTenantExlude(int tenantID)
        {
            var q = from tbl in db.Properties
                    let pt = db.PropertyTenants.Where(x => x.TenantID == tenantID).Select(x => x.PropertyID).ToList()
                    where !pt.Contains(tbl.PropertyID)
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

        [Route("api/property/searchowner/exclude-property/{propertyID}")]
        public JsonResult ListPropertyOwnerExlude(int propertyID)
        {
            var q = from tbl in db.Owners
                    let pt = db.PropertyOwners.Where(x => x.PropertyID == propertyID).Select(x => x.OwnerID).ToList()
                    where !pt.Contains(tbl.OwnerID)
                    select tbl;

            return Json(q.ToList().Select(x => new OwnerResponse()
            {
                OwnerID = x.OwnerID,
                Type = x.Type,
                Name = x.Name,
                UnitNr = x.UnitNr,
                ComplexName = x.ComplexName,
                StreetNumber = x.StreetNumber,
                StreeName = x.StreetName,
                Suburb = x.Suburb,
                City = x.City,
                PostalCode = x.PostalCode,
                TelWork = x.TelWork,
                TelMobile = x.TelMobile,
                Fax = x.Fax,
                Email = x.Email,
                Website = x.Website,
                Title = x.Title,
                FirstName = x.FirstName,
                SecondName = x.SecondName,
                ThirdName = x.ThirdName,
                LastName = x.LastName,
                IDNumber = x.IDNumber
            }).ToList(), JsonRequestBehavior.AllowGet);
        }

        [Route("api/property/searchtenant/exclude-property/{propertyID}")]
        public JsonResult ListPropertyTenantExlude(int propertyID)
        {
            var q = from tbl in db.Tenants
                    let pt = db.PropertyTenants.Where(x => x.PropertyID == propertyID).Select(x => x.TenantID).ToList()
                    where !pt.Contains(tbl.TenantID)
                    select tbl;

            return Json(q.ToList().Select(x => new TenantResponse()
            {
                TenantID = x.TenantID,
                Email = x.Email,
                FirstName = x.FirstName,
                IDNumber = x.IDNumber,
                LastName = x.LastName,
                PreferredName = x.PreferredName,
                SecondName = x.SecondName,
                TelMobile = x.TelMobile,
                TelWork = x.TelWork,
                ThirdName = x.ThirdName,
                Title = x.Title,
                Website = x.Website
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


        [Route("api/property/tenant/{tenantID}")]
        public JsonResult PropertiesByTenant(int tenantID)
        {
            var q = from tbl in db.Properties
                    join po in db.PropertyTenants on tbl.PropertyID equals po.PropertyID
                    where po.TenantID == tenantID
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

        [Route("api/property/propertyowner/{propertyID}")]
        public JsonResult OwnersByProperties(int propertyID)
        {
            var q = from tbl in db.Owners
                    join po in db.PropertyOwners on tbl.OwnerID equals po.OwnerID
                    where po.PropertyID == propertyID
                    select tbl;

            return Json(q.ToList().Select(x => new OwnerResponse()
            {
                OwnerID = x.OwnerID,
                Type = x.Type,
                Name = x.Name,
                UnitNr = x.UnitNr,
                ComplexName = x.ComplexName,
                StreetNumber = x.StreetNumber,
                StreeName = x.StreetName,
                Suburb = x.Suburb,
                City = x.City,
                PostalCode = x.PostalCode,
                TelWork = x.TelWork,
                TelMobile = x.TelMobile,
                Fax = x.Fax,
                Email = x.Email,
                Website = x.Website,
                Title = x.Title,
                FirstName = x.FirstName,
                SecondName = x.SecondName,
                ThirdName = x.ThirdName,
                LastName = x.LastName,
                IDNumber = x.IDNumber
            }).ToList(), JsonRequestBehavior.AllowGet);
        }

        [Route("api/property/propertytenant/{propertyID}")]
        public JsonResult TenantsByProperties(int propertyID)
        {
            var q = from tbl in db.Tenants
                    join po in db.PropertyTenants on tbl.TenantID equals po.TenantID
                    where po.PropertyID == propertyID
                    select tbl;

            return Json(q.ToList().Select(x => new TenantResponse()
            {
                TenantID = x.TenantID,
                Email = x.Email,
                FirstName = x.FirstName,
                IDNumber = x.IDNumber,
                LastName = x.LastName,
                PreferredName = x.PreferredName,
                SecondName = x.SecondName,
                TelMobile = x.TelMobile,
                TelWork = x.TelWork,
                ThirdName = x.ThirdName,
                Title = x.Title,
                Website = x.Website
            }).ToList(), JsonRequestBehavior.AllowGet);
        }


        [Route("api/property/assign-owner/{propertyID}/{ownerID}")]
        public JsonResult AssignPropertyOwner(int propertyID, int ownerID)
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

        [Route("api/property/unassign-owner/{propertyID}/{ownerID}")]
        public JsonResult UnassignPropertyOwner(int propertyID, int ownerID)
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

        [Route("api/property/assign-tenant/{propertyID}/{tenantID}")]
        public JsonResult AssignPropertyTenant(int propertyID, int tenantID)
        {
            var property = db.Properties.Where(x => x.PropertyID == propertyID).FirstOrDefault();
            var tenant = db.Tenants.Where(x => x.TenantID == tenantID).FirstOrDefault();
            bool assigned = false;
            if (tenant != null && property != null)
            {
                PropertyTenant propertyTenant = new PropertyTenant();

                propertyTenant.PropertyID = propertyID;
                propertyTenant.TenantID = tenantID;

                db.PropertyTenants.Add(propertyTenant);
                db.SaveChanges();
                assigned = true;
            }

            return Json(assigned, JsonRequestBehavior.AllowGet);
        }

        [Route("api/property/unassign-tenant/{propertyID}/{tenantID}")]
        public JsonResult UnassignPropertyTenant(int propertyID, int tenantID)
        {
            var propertyTenant = db.PropertyTenants.Where(x => x.PropertyID == propertyID && x.TenantID == tenantID).FirstOrDefault();
            bool unassigned = false;
            if (propertyTenant != null)
            {
                db.PropertyTenants.Remove(propertyTenant);
                db.SaveChanges();
                unassigned = true;
            }

            return Json(unassigned, JsonRequestBehavior.AllowGet);
        }

    }
}