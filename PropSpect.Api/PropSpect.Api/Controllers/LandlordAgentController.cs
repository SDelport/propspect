using PropSpect.Api.Models;
using PropSpect.Api.Models.Request;
using PropSpect.Api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropSpect.Api.Controllers
{
    public class LandlordAgentController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        [Route("api/landlordagent/{id}")]
        public JsonResult Get(int id)
        {
            LandlordAgentResponse response = null;

            LandlordAgent landlordAgent = db.LandlordAgents.Where(x => x.LandlordAgentID == id).FirstOrDefault();

            if (landlordAgent != null)
            {
                response = new LandlordAgentResponse();
                response.LandlordAgentID = landlordAgent.LandlordAgentID;
                response.FirstName = landlordAgent.FirstName;
                response.PreferredName = landlordAgent.FirstName;
                response.LastName = landlordAgent.LastName;
                response.IDNumber = landlordAgent.IDNumber;
                response.TelWork = landlordAgent.TelWork;
                response.TelMobile = landlordAgent.TelMobile;
                response.Email = landlordAgent.Email;
                response.UserKey = landlordAgent.LandlordAgentID;
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [Route("api/landlordagent/delete/{id}")]
        public JsonResult Delete(int id)
        {
            LandlordAgent landlordAgent = db.LandlordAgents.Where(x => x.LandlordAgentID == id).FirstOrDefault();
            bool result = false;
            if (landlordAgent != null)
            {
                db.LandlordAgents.Remove(landlordAgent);
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("api/landlordagent/add")]
        public JsonResult Add(CreateLandlordAgentRequest request)
        {
            LandlordAgent landlordAgent = null;
            if (request.LandlordAgentID <= 0)
            {
                landlordAgent = new LandlordAgent();
                landlordAgent.LandlordAgentID = request.LandlordAgentID;
                landlordAgent.FirstName = request.FirstName;
                landlordAgent.PreferredName = request.FirstName;
                landlordAgent.LastName = request.LastName;
                landlordAgent.IDNumber = request.IDNumber;
                landlordAgent.TelWork = request.TelWork;
                landlordAgent.TelMobile = request.TelMobile;
                landlordAgent.Email = request.Email;
                landlordAgent.UserKey = request.LandlordAgentID;

                db.LandlordAgents.Add(landlordAgent);
                db.SaveChanges();



            }
            else
            {
                landlordAgent = db.LandlordAgents.Where(x => x.LandlordAgentID == request.LandlordAgentID).FirstOrDefault();
                if (landlordAgent != null)
                {
                    landlordAgent.LandlordAgentID = request.LandlordAgentID;
                    landlordAgent.FirstName = request.FirstName;
                    landlordAgent.PreferredName = request.FirstName;
                    landlordAgent.LastName = request.LastName;
                    landlordAgent.IDNumber = request.IDNumber;
                    landlordAgent.TelWork = request.TelWork;
                    landlordAgent.TelMobile = request.TelMobile;
                    landlordAgent.Email = request.Email;
                    landlordAgent.UserKey = request.LandlordAgentID;

                    db.SaveChanges();
                }

            }

            return Json(landlordAgent);
        }

        [Route("api/landlordagent")]
        public JsonResult List()
        {
            return Json(db.LandlordAgents.ToList().Select(x => new LandlordAgentResponse()
            {
                LandlordAgentID = x.LandlordAgentID,
                FirstName = x.FirstName,
                PreferredName = x.FirstName,
                LastName = x.LastName,
                IDNumber = x.IDNumber,
                TelWork = x.TelWork,
                TelMobile = x.TelMobile,
                Email = x.Email,
                UserKey = x.LandlordAgentID
            }).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}