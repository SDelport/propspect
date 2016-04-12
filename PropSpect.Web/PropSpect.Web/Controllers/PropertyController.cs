using Newtonsoft.Json;
using PropSpect.Api.Models.Request;
using PropSpect.Api.Models.Response;
using PropSpect.Web.Controllers.Helpers;
using PropSpect.Web.Controllers.Helpers.CustomWebViewPageEngine;
using PropSpect.Web.Models.FormModels;

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
    [LoggedIn]
    public class PropertyController : Controller
    {

        [Route("property/edit/{propertyID?}")]
        public ActionResult AddProperty(int propertyID = 0)
        {
            PropertyResponse formModel = new PropertyResponse();

            if (propertyID != 0)
            {
                PropertyResponse property = ApiWrapper.Get<PropertyResponse>("api/property/" + propertyID);
                formModel.PropertyID = property.PropertyID;
                formModel.StreetName = property.StreetName;
                formModel.StreetNumber = property.StreetNumber;
                formModel.City = property.City;
                formModel.ComplexName = property.ComplexName;
                formModel.PostalCode = property.PostalCode;
                formModel.PropertyID = property.PropertyID;
                formModel.PropertyType = property.PropertyType;
                formModel.UnitNumber = property.UnitNumber;
            }


            return View("Add", formModel);
        }

        [Route("property/add")]
        public JsonResult AddedProperty(PropertyResponse model)
        {
            CreatePropertyRequest request = new CreatePropertyRequest();
            request.PropertyID = model.PropertyID;
            request.StreetName = model.StreetName;
            request.StreetNumber = model.StreetNumber;
            request.City = model.City;
            request.ComplexName = model.ComplexName;
            request.PostalCode = model.PostalCode;
            request.PropertyID = model.PropertyID;
            request.PropertyType = model.PropertyType;
            request.UnitNumber = model.UnitNumber;

            var result = ApiWrapper.Post<PropertyResponse>("api/property/add", request);

            return Json(result);
        }

        [Route("property/list")]
        public ActionResult List()
        {
            List<Property> propertys = new List<Property>();

            propertys = Property.CreateList(ApiWrapper.Get<List<PropertyResponse>>("api/property/list"));

            ListAsyncFormModel formModel = ListAsyncFormModel.Create(propertys);


            formModel.ItemLists.Add("CityItems", EnvironmentCache.GetDisplayValues("CITY").Select(x => new SelectListItem()
            {
                Text = x.Display,
                Value = x.ID
            }).ToList());

            return View("List", formModel);
        }

        [Route("property/search/{search}")]
        public JsonResult Search(string search)
        {
            List<Property> propertys = new List<Property>();

            propertys = Property.CreateList(ApiWrapper.Get<List<PropertyResponse>>("api/property/list/" + search));

            return Json(propertys, JsonRequestBehavior.AllowGet);

        }
    }
}