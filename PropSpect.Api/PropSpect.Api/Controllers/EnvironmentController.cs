using PropSpect.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropSpect.Api.Controllers
{
    public class EnvironmentController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        [Route("api/environment/all")]
        public JsonResult GetAllEnvironmentValues()
        {
            var values = db.EnvironmentValues.ToList();

            return Json(values, JsonRequestBehavior.AllowGet);
        }
    }
}