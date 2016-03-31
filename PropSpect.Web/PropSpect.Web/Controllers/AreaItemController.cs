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
    public class AreaItemController : Controller
    {

        [Route("areaitem/edit/{areaitemID?}")]
        public ActionResult AddAreaItem(int areaitemID = 0)
        {
            AreaItemResponse formModel = new AreaItemResponse();

            if (areaitemID != 0)
            {
                AreaItemResponse areaitem = ApiWrapper.Get<AreaItemResponse>("api/areaitem/get/" + areaitemID);
                formModel.AreaItemID = areaitem.AreaItemID;
                formModel.RoomDescription = areaitem.RoomItem;
                formModel.AreaID = areaitem.AreaID;
                formModel.RoomDescription = areaitem.RoomDescription;
            }

            return View("Add", formModel);
        }

        [Route("areaitem/add")]
        public JsonResult AddedAreaItem(AreaItemResponse model)
        {
            CreateAreaItemRequest request = new CreateAreaItemRequest();
            request.AreaItemID = model.AreaItemID;
            request.RoomItem = model.RoomItem;
            request.AreaID = model.AreaID;
            request.RoomDescription = model.RoomDescription;

            var result = ApiWrapper.Post<AreaItemResponse>("api/areaitem/add", request);

            return Json(result);
        }

        [Route("areaitem")]
        public ActionResult List()
        {
            List<AreaItem> areaitems = new List<AreaItem>();

            areaitems = AreaItem.CreateList(ApiWrapper.Get<List<AreaItemResponse>>("api/areaitem/list"));

            ListAsyncFormModel formModel = ListAsyncFormModel.Create(areaitems);

            formModel.ItemLists.Add("AreaItems", ApiWrapper.Get<List<AreaResponse>>("api/area/list").Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.AreaID.ToString()
            }).ToList());

            return View("List", formModel);
        }
    }
}