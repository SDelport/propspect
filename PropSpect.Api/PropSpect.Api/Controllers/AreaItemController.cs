﻿using PropSpect.Api.Models;
using PropSpect.Api.Models.Request;
using PropSpect.Api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropSpect.Api.Controllers
{
    public class AreaItemController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        [Route("api/areaitem/{id}")]
        public JsonResult Get(int id)
        {
            AreaItemResponse response = null;

            AreaItem areaItem = db.AreaItems.Where(x => x.AreaItemID == id).FirstOrDefault();

            if (areaItem != null)
            {
                response = new AreaItemResponse();
                response.AreaItemID = areaItem.AreaItemID;
                response.RoomDescription = areaItem.RoomDescription;
                response.RoomItem = areaItem.RoomItem;
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("api/areaitem/add")]
        public JsonResult Add(CreateAreaItemRequest request)
        {
            if (request.AreaItemID <= 0)
            {
                AreaItem areaItem = new AreaItem();
                areaItem.AreaItemID = request.AreaItemID;
                areaItem.RoomDescription = request.RoomDescription;
                areaItem.RoomItem = request.RoomItem;

                db.AreaItems.Add(areaItem);
                db.SaveChanges();
            }
            else
            {
                AreaItem areaItem = db.AreaItems.Where(x => x.AreaItemID == request.AreaItemID).FirstOrDefault();
                if (areaItem != null)
                {
                    areaItem.AreaItemID = request.AreaItemID;
                    areaItem.RoomDescription = request.RoomDescription;
                    areaItem.RoomItem = request.RoomItem;

                    db.SaveChanges();
                }

            }

            return Json("true");
        }

        [Route("api/areaitem")]
        public JsonResult List()
        {
            return Json(db.AreaItems.ToList().Select(x => new AreaItemResponse()
            {
                AreaItemID = x.AreaItemID,
                RoomDescription = x.RoomDescription,
                RoomItem = x.RoomItem
            }).ToList(), JsonRequestBehavior.AllowGet);
        }

    }
}