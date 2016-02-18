using PropSpect.Web.Models.FormModels.LandLord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropSpect.Web.Controllers
{
    public class LandLordController : Controller
    {
        [Route("landlord/add")]
        public ActionResult AddLandLord()
        {
            AddLandLordFormModel formModel = new AddLandLordFormModel();

            return View("AddLandLord",formModel);
        }
    }
}