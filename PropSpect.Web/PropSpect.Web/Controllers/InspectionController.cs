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
        [Route("inspection/{inspectionID}/{page}")]
        public ActionResult CreateInspection(int inspectionID, int page)
        {
            List<InspectionAreaItemResponse> response = new List<InspectionAreaItemResponse>();
            response = ApiWrapper.Get<List<InspectionAreaItemResponse>>("/api/inspection/inspectionRoomDetails/" + inspectionID + "/" + page);
            response.Clear();
            response.Add(new InspectionAreaItemResponse()
            {
                InspectionAreaID = 0,
                InspectionAreaItemID = 0,
                ItemCondition = "Good",
                ItemDescription = "Kettle",
                ItemID = 0,
                ItemRepair = "Yes"
            });
            response.Add(new InspectionAreaItemResponse()
            {
                InspectionAreaID = 0,
                InspectionAreaItemID = 0,
                ItemCondition = "Bad",
                ItemDescription = "Door",
                ItemID = 0,
                ItemRepair = "No"
            });
            List<InspectionAreaItem> areaItem = new List<InspectionAreaItem>();
            foreach (var item in response)
            {
                areaItem.Add(new InspectionAreaItem()
                {
                    InspectionAreaID = item.InspectionAreaID,
                    InspectionAreaItemID = item.InspectionAreaItemID,
                    ItemCondition = item.ItemCondition,
                    ItemDescription = item.ItemDescription,
                    ItemRepair = item.ItemRepair,
                    ItemID = item.ItemID
                });
            }
            return View("InspectionRoom",areaItem);
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