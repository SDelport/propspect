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
    public class EntityController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        [Route("api/entity/{id}")]
        public JsonResult Get(int id)
        {
            EntityResponse response = null;

            Entity entity = db.Enities.Where(x => x.PropertyEntityID == id).FirstOrDefault();

            if (entity != null)
            {
                response = new EntityResponse();
                response.PropertyEntityID = entity.PropertyEntityID;
                response.EntityType = entity.EntityType;
                response.EntityID = entity.EntityID;

            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("api/entity/add")]
        public JsonResult Add(CreateEntityRequest request)
        {
            if (request.PropertyEntityID <= 0)
            {
                Entity entity = new Entity();
                entity.PropertyEntityID = request.PropertyEntityID;
                entity.EntityType = request.EntityType;
                entity.EntityID = request.EntityID;

                db.Enities.Add(entity);
                db.SaveChanges();
            }
            else
            {
                Entity entity = db.Enities.Where(x => x.PropertyEntityID == request.PropertyEntityID).FirstOrDefault();
                if (entity != null)
                {
                    entity.PropertyEntityID = request.PropertyEntityID;
                    entity.EntityType = request.EntityType;
                    entity.EntityID = request.EntityID;

                    db.SaveChanges();
                }

            }

            return Json("true");
        }

        [Route("api/entity")]
        public JsonResult List()
        {
            return Json(db.Enities.ToList().Select(x => new EntityResponse()
            {
                PropertyEntityID = x.PropertyEntityID,
                EntityType = x.EntityType,
                EntityID = x.EntityID
            }).ToList(), JsonRequestBehavior.AllowGet);
        }

    }
}