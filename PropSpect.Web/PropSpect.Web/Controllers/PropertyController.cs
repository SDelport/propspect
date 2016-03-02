using Newtonsoft.Json;
using PropSpect.Api.Models.Request;
using PropSpect.Api.Models.Response;
using PropSpect.Web.Controllers.Helpers;
using PropSpect.Web.Models.FormModels.LandLord;
using PropSpect.Web.Models.FormModels.Property;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PropSpect.Web.Controllers
{
    public class PropertyController : Controller
    {
        [Route("property/add")]
        [Route("property/edit/{propertyID?}")]
        public ActionResult AddProperty(int propertyID = 0)
        {
            AddPropertyFormModel formModel = new AddPropertyFormModel();

            if (propertyID != 0)
            {
                PropertyResponse property = ApiWrapper.Get<PropertyResponse>("api/property/" + propertyID);
                formModel.PropertyID = property.PropertyID;
                formModel.PropertyType = property.PropertyType;
                formModel.UnitNumber = property.UnitNumber;
                formModel.ComplexName = property.ComplexName;
                formModel.StreetNumber = property.StreetNumber;
                formModel.StreetName = property.StreetName;
                formModel.Suburb = property.Suburb;
                formModel.City = property.City;
                formModel.PostalCode = property.PostalCode;
            }


            return View("Add", formModel);
        }

        [Route("property/added")]
        public ActionResult AddedProperty(AddPropertyFormModel model)
        {
            CreatePropertyRequest request = new CreatePropertyRequest();
            request.PropertyID = model.PropertyID;
            request.PropertyType = model.PropertyType;
            request.UnitNumber = model.UnitNumber;
            request.ComplexName = model.ComplexName;
            request.StreetNumber = model.StreetNumber;
            request.StreetName = model.StreetName;
            request.Suburb = model.Suburb;
            request.City = model.City;
            request.PostalCode = model.PostalCode;

            ApiWrapper.Post<bool>("api/property/add", request);

            return Redirect("/property");
        }

        [Route("property")]
        public ActionResult List()
        {
            List<PropertyResponse> properties = new List<PropertyResponse>();

            properties = ApiWrapper.Get<List<PropertyResponse>>("api/property");

            return View("List", properties);
        }
    }
}