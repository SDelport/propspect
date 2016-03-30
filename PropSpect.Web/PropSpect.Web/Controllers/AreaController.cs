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
    }
}