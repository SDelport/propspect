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
    public class AreaController : Controller
    {

        [Route("area/edit/{areaID?}")]
        public ActionResult AddArea(int areaID = 0)
        {
            AreaResponse formModel = new AreaResponse();

            if (areaID != 0)
            {
                AreaResponse area = ApiWrapper.Get<AreaResponse>("api/area/get/" + areaID);
                formModel.AreaID = area.AreaID;
                formModel.Name = area.Name;
            }

            return View("Add", formModel);
        }

        [Route("area/add")]
        public JsonResult AddedArea(AreaResponse model)
        {
            CreateAreaRequest request = new CreateAreaRequest();
            request.AreaID = model.AreaID;
            request.Name = model.Name;

            var result = ApiWrapper.Post<AreaResponse>("api/area/add", request);

            return Json(result);
        }

        [Route("area")]
        public ActionResult List()
        {
            List<Area> areas = new List<Area>();

            areas = Area.CreateList(ApiWrapper.Get<List<AreaResponse>>("api/area/list"));

            ListAsyncFormModel formModel = ListAsyncFormModel.Create(areas);

            return View("List", formModel);
        }
        [HttpPost]
        [Route("property/editAreaData/")]
        public ActionResult editAreaData(string submit, string Name, int AreaID = 0)
        {
            AreaResponse area = ApiWrapper.Get<AreaResponse>("api/area/get/" + AreaID);
            if (AreaID != 0 && submit != null)
            {
                submit = submit.ToLower();
                CreateAreaRequest request = new CreateAreaRequest();
                request.AreaID = AreaID;
                request.Name = Name;
                if (submit == "save")
                {
                    var result = ApiWrapper.Post<AreaResponse>("api/area/add", request);
                }
                else if (submit == "delete")
                {
                    var result = ApiWrapper.Post<bool>("api/area/remove", request);
                }
            }
            else
            {
                return Redirect("/property/list");
            }
            return Redirect("/property/manageAreas/" + area.PropertyID);
        }
        [HttpPost]
        [Route("property/selectAreaToAdd/{propertyID}/Add")]
        public ActionResult SelectAreaToAdd(int propertyID, int AreaTemplateID)
        {
            var response = ApiWrapper.Get<bool>(("api/area/addFromTemplate/" + AreaTemplateID + "/" + propertyID));
            return Redirect("/property/manageAreas/" + propertyID);
        }
        [Route("property/manageAreas/{propertyID}")]
        public ActionResult ManageAreas(int propertyID)
        {
            var propertyAreaResponse = ApiWrapper.Get<List<AreaResponse>>("api/area/selectForProperty/" + propertyID);
            List<Area> areas = Area.CreateList(propertyAreaResponse);
            return View("ManageAreas", new ManagePropertyAreas(areas, SelectPropertyFromID(propertyID)));
        }

        [Route("property/selectAreaToAdd/{propertyID}")]
        public ActionResult SelectAreaToAdd(int propertyID)
        {
            var response = LandlordTemplateArea.CreateList(ApiWrapper.Get<List<LandlordTemplateAreaResponse>>(("api/get-templates")));
            return View("selectAreaToAdd", new AddAreaItems(propertyID, response));
        }
        public Property SelectPropertyFromID(int id)
        {
            return Property.Create(ApiWrapper.Get<PropertyResponse>(("api/property/getID/" + id)));
        }
    }
}