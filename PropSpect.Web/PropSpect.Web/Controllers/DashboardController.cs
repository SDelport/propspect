using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropSpect.Web.Controllers
{
    public class DashboardController : Controller
    {
        [Route("")]
        public ActionResult Dashboard()
        {
            return View("Dashboard");
        }
    }
}