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
        public JsonResult SubmitPart(List<InspectionPart> Data, string Signature)
        {
            CreateInspectionAreaItemRequest request = new CreateInspectionAreaItemRequest();
            request.ItemRepair = "n";
            foreach (var item in Data)
            {
                if (item.name == "areaID")
                    request.AreaID = int.Parse(item.value);
                else if (item.name == "name")
                    request.ItemDescription = item.value;
                else if (item.name == "condition")
                    request.ItemCondition = item.value.Substring(3);
                else if (item.name == "repair-needed")
                    request.ItemRepair = "y";
                else if (item.name == "inspectionAreaItemID")
                    request.InspectionAreaItemID = int.Parse(item.value);
            }

            var response = ApiWrapper.Post<CreateInspectionAreaItemRequest>("api/inspection/editPart", request);

            return response!=null?Json(new { success = true, responseText= "Successfuly sent the information!"}, JsonRequestBehavior.AllowGet): Json(new { success = false, responseText = "Failed to send the information!" }, JsonRequestBehavior.AllowGet);
        }

    }
}