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


    }
}