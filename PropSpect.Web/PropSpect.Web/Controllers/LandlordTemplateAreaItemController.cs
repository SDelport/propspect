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

            return View("Manage", model);
        }
    }
}