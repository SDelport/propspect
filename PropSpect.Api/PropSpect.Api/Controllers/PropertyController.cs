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
            if (request.PropertyID <= 0)
            {
                Property property = new Property();
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
                Property property = db.Properties.Where(x => x.PropertyID == request.PropertyID).FirstOrDefault();
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

            return Json("true");
        }


        [Route("api/property")]
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


    }
}