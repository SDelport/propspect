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
    public class LandlordTemplateAreaItemController : Controller
    {

        [Route("landlordtemplateareaitem/edit/{landlordtemplateareaitemID?}")]
        public ActionResult AddLandlordTemplateAreaItem(int landlordtemplateareaitemID = 0)
        {
            LandlordTemplateAreaItemResponse formModel = new LandlordTemplateAreaItemResponse();

            if (landlordtemplateareaitemID != 0)
            {
                LandlordTemplateAreaItemResponse landlordtemplateareaitem = ApiWrapper.Get<LandlordTemplateAreaItemResponse>("api/landlordtemplateareaitem/get/" + landlordtemplateareaitemID);
                formModel.LandlordTemplateAreaItemID = landlordtemplateareaitem.LandlordTemplateAreaItemID;
                formModel.ItemName = landlordtemplateareaitem.ItemName;
                formModel.ItemOrder = landlordtemplateareaitem.ItemOrder;
            }

            return View("Add", formModel);
        }

        [Route("landlordtemplateareaitem/add")]
        public JsonResult AddedLandlordTemplateAreaItem(LandlordTemplateAreaItemResponse model)
        {
            CreateLandlordTemplateAreaItemRequest request = new CreateLandlordTemplateAreaItemRequest();
            request.LandlordTemplateAreaItemID = model.LandlordTemplateAreaItemID;
            request.LandlordTemplateAreaItemID = model.LandlordTemplateAreaItemID;
            request.ItemName = model.ItemName;
            request.ItemOrder = model.ItemOrder;

            var result = ApiWrapper.Post<LandlordTemplateAreaItemResponse>("api/landlordtemplateareaitem/add", request);

            return Json(result);
        }

        [Route("template-area/manage")]
        public ActionResult List()
        {
            ManageAreaTemplates model = new ManageAreaTemplates();

            var response = ApiWrapper.Get<List<LandlordTemplateAreaResponse>>("api/get-templates");

            model.Areas = new List<LandlordTemplateArea>();
            foreach (var areaResponse in response)
            {
                LandlordTemplateArea area = new LandlordTemplateArea();

                area.Name = areaResponse.AreaName;
                area.Order = areaResponse.AreaOrder;

                area.Items = new List<LandlordTemplateAreaItem>();

                foreach (var responseItem in areaResponse.Items)
                {
                    LandlordTemplateAreaItem item = new LandlordTemplateAreaItem();
                    item.Name = responseItem.ItemName;
                    item.Order = responseItem.ItemOrder;

                    area.Items.Add(item);
                }

                model.Areas.Add(area);
            }

            return View("Manage", model);
        }

        [Route("template-area/save")]
        public JsonResult Save(List<LandlordTemplateArea> areas)
        {
            SaveLandlordTemplatesRequest request = new SaveLandlordTemplatesRequest();
            request.Areas = new List<CreateLandlordTemplateAreaRequest>();
            if (areas != null)
            {
                foreach (var area in areas)
                {
                    CreateLandlordTemplateAreaRequest areaRequest = new CreateLandlordTemplateAreaRequest();
                    areaRequest.AreaName = area.Name;
                    areaRequest.AreaOrder = area.Order;
                    areaRequest.Items = new List<CreateLandlordTemplateAreaItemRequest>();
                    if (area.Items != null)
                    {
                        foreach (var item in area.Items)
                        {
                            CreateLandlordTemplateAreaItemRequest itemRequest = new CreateLandlordTemplateAreaItemRequest();
                            itemRequest.ItemName = item.Name;
                            itemRequest.ItemOrder = item.Order;

                            areaRequest.Items.Add(itemRequest);
                        }
                    }
                    request.Areas.Add(areaRequest);
                }
            }
            var response = ApiWrapper.Post<bool>("api/save-templates", request);

            return Json(true);
        }
    }
}