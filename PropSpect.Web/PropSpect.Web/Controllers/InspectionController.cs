using PropSpect.Api.Models.Request;
using PropSpect.Api.Models.Response;
using PropSpect.Web.Controllers.Helpers;
using PropSpect.Web.Models.FormModels;
using System;
using System.Collections.Generic;
using System.IO;
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
                    ItemCondition = item.ItemCondition ?? "",
                    ItemDescription = item.ItemDescription ?? "",
                    ItemRepair = item.ItemRepair ?? "",
                    ItemID = item.ItemID
                });
            }
            InspectionAreaItemsCheck model = new InspectionAreaItemsCheck(page==0,true, areaItem, "","#",page==0?"#":""+(page-1));
            if (areaItem.Count>0)
            {
                try
                {
                    int AreaID = ApiWrapper.Get<InspectionAreaResponse>("/api/inspectionarea/" + areaItem[0].InspectionAreaID).AreaID;
                    model.AreaName = ApiWrapper.Get<AreaResponse>("api/area/get/" + AreaID).Name;
                }
                catch (Exception)
                {
                }
                List<InspectionAreaItemResponse> response2 = ApiWrapper.Get<List<InspectionAreaItemResponse>>("/api/inspection/inspectionRoomDetails/" + inspectionID + "/" + page+1);
                if (response2.Count>0)
                {
                    model.lastPage = false;
                    model.nextLink = ""+(page + 1);
                }
        }
            return View("InspectionRoom",model);
        }

        [Route("inspection/view/list")]
        public ActionResult List()
        {
            List<InspectionResponse> response = ApiWrapper.Get<List<InspectionResponse>>("/api/inspection");
            ListAsyncFormModel formModel = ListAsyncFormModel.Create(InspectionItem.ToList(response));
            return View("List",formModel);
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

        [Route("inspection/prepost")]
        public ActionResult ConfirmDetails(string inspectiontype, string latitude,string longitude,int propertyID, int tenantID, int ownerID)
        {
            CreateInspectionRequest request = new CreateInspectionRequest()
            {
                Latitude = latitude,
                Longitude = longitude,
                OwnerID = ownerID,
                PropertyID = propertyID,
                TenantID = tenantID
            };

            var response = ApiWrapper.Post<InspectionResponse>("api/inspection/add", request);
                
            return Redirect("/inspection/"+response.InspectionID+"/0");
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
        [HttpPost]
        [Route("inspection/submitimage/{InspectionAreaItemID}")]
        public JsonResult SubmitImage(HttpPostedFileBase file,int InspectionAreaItemID)
        {
            MemoryStream target = new MemoryStream();
            file.InputStream.CopyTo(target);
            byte[] data = target.ToArray();
            return data != null ? Json(new { success = true, responseText = "Successfuly sent the information!" }, JsonRequestBehavior.AllowGet) : Json(new { success = false, responseText = "Failed to send the information!" }, JsonRequestBehavior.AllowGet);
        }
    }
}