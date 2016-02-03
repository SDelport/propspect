using PropSpect.Web.Models.FormModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropSpect.Web.Controllers
{
    public class InspectionController : Controller
    {
        [Route("inspection/create")]
        public ActionResult CreateInspection()
        {
            return View();
        }

        [Route("inspection/{inspectionID}")]
        public ActionResult ViewInspection(int inspectionID)
        {
            return View();
        }

        [Route("inspection/{inspectionID}/{inspectionRoomID}")]
        public ActionResult ViewRoomInspection(int inspectionID, int inspectionRoomID)
        {
            ReviewItemFormModel model = new ReviewItemFormModel();
            model.Name = "Front Door";
            model.ReviewItemParts = new List<ReviewItemCharacteristicFormModel>();
            model.ReviewItemParts.Add(new ReviewItemCharacteristicFormModel() { Name = "Door" });
            model.ReviewItemParts.Add(new ReviewItemCharacteristicFormModel() { Name = "Door Frame" });
            model.ReviewItemParts.Add(new ReviewItemCharacteristicFormModel() { Name = "Door Lock" });
            model.ReviewItemParts.Add(new ReviewItemCharacteristicFormModel() { Name = "Door Key Code" });
            model.ReviewItemParts.Add(new ReviewItemCharacteristicFormModel() { Name = "Door Stopper" });
            model.ReviewItemParts.Add(new ReviewItemCharacteristicFormModel() { Name = "Outside Light" });

            model.ConditionItems = new List<SelectListItem>();
            model.ConditionItems.Add(new SelectListItem() { Text = "None..." });
            model.ConditionItems.Add(new SelectListItem() { Text = "Bad" });
            model.ConditionItems.Add(new SelectListItem() { Text = "Good" });
            model.ConditionItems.Add(new SelectListItem() { Text = "Great" });

            return View("InspectionRoom",model);
        }
    }
}