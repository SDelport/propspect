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
        [Route("inspection/")]
        public ActionResult CreateInspection()
        {
            return View("InspectionRoom");
        }

        [Route("inspection/start-inspection")]
        public ActionResult SelectProperty()
        {
            return View("PreInspectionChecks");
        }


        [Route("inspection/confirmdetails")]
        public ActionResult ConfirmDetails()
        {
            return View("Confirm");
        }


    }
}