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

        [Route("property/manageAreaItems/{areaID}")]
        public ActionResult ManageAreaItems(int areaID)
        {
            var propertyAreaResponse = ApiWrapper.Get<List<AreaItemResponse>>("api/area/selectForPropertyArea/" + areaID);
            List<AreaItem> areaItems = AreaItem.CreateList(propertyAreaResponse);
            return View("ManageAreaItems", new ManageAreaItems(areaItems, SelectAreaItemFromID(areaID)));
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

        [HttpPost]
        [Route("property/editAreaItemData/")]
        public ActionResult editAreaItemData(string submit, string Name,string Description, string isAreaID, int AreaItemID = 0)
        {
            AreaItemResponse areaItem = ApiWrapper.Get<AreaItemResponse>("api/areaitem/get/" + AreaItemID);
            CreateAreaItemRequest request = new CreateAreaItemRequest();
            if (submit != null)
            {
                submit = submit.ToLower();
                if (isAreaID.ToLower()!="false")
                {
                    request.AreaID = AreaItemID;
                    request.AreaItemID = 0;
                }
                else
                {
                    request.AreaID = areaItem.AreaID;
                    request.AreaItemID = areaItem.AreaItemID;
                }
                request.RoomItem = Name;
                request.RoomDescription = Description;
                if (submit == "save")
                {
                    var result = ApiWrapper.Post<String>("api/areaitem/add", request);
                }
                else if (submit == "delete" && AreaItemID != 0)
                {
                    var result = ApiWrapper.Post<bool>("api/areaitem/remove", request);
                }
            }
            else
            {
                return Redirect("/property/list");
            }
            return Redirect("/property/manageAreaItems/" + request.AreaID);
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
        public Area SelectAreaItemFromID(int id)
        {
            return Area.Create(ApiWrapper.Get<AreaResponse>(("api/area/get/" + id)));
        }
    }
}