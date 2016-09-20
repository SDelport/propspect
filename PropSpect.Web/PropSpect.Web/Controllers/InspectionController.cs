using PropSpect.Api.Models.Request;
using PropSpect.Api.Models.Response;
using PropSpect.Web.Controllers.Helpers;
using PropSpect.Web.Models.FormModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropSpect.Web.Controllers
{
    [LoggedIn]
    public class InspectionController : Controller
    {
        [Route("inspection/{inspectionTemplateID}/{inspectionAreaID}/{page}")]
        public ActionResult CreateInspection(int inspectionTemplateID, int inspectionAreaID, int page)
        {
            InspectionDetailsResponse response = new InspectionDetailsResponse();

            response = ApiWrapper.Get<InspectionDetailsResponse>("/api/inspection/details/" + inspectionTemplateID + "/" + inspectionAreaID);

            return View("InspectionRoom");
        }

        [Route("inspection/start-inspection")]
        public ActionResult SelectProperty()
        {
            PreInspection model = new PreInspection();
            model.Properties = new List<PropertyResponse>();
            model.Tenants = new List<TenantResponse>();
            model.Owners = new List<OwnerResponse>();


            return View("PreInspectionChecks",model);
        }


        [Route("inspection/confirmdetails")]
        public ActionResult ConfirmDetails()
        {
            return View("Confirm");
        }


        [Route("inspection/submitpart")]
        public ActionResult SubmitPart(List<InspectionPart> Data, string Signature)
        {
            CreateInspectionAreaItemRequest request = new CreateInspectionAreaItemRequest();

            foreach (var item in Data)
            {
                if (item.name == "areaID")
                    request.AreaID = int.Parse(item.value);
                else if (item.name == "name")
                    request.ItemDescription = item.value;
                else if (item.name == "condition")
                    request.ItemCondition = item.value;
                else if (item.name == "repair")
                    request.ItemRepair = item.value;
            }

            var response = ApiWrapper.Post<AreaItemResponse>("api/areaitem/add", request);

            return View("Confirm");
        }

    }
}