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
    public class OwnerController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        [Route("api/owner/get/{id}")]
        public JsonResult Get(int id)
        {
            OwnerResponse response = null;

            Owner owner = db.Owners.Where(x => x.OwnerID == id).FirstOrDefault();

            if (owner != null)
            {
                response = new OwnerResponse();
                response.OwnerID = owner.OwnerID;
                response.Type = owner.Type;
                response.Name = owner.Name;
                response.UnitNr = owner.UnitNr;
                response.ComplexName = owner.ComplexName;
                response.StreetNumber = owner.StreetNumber;
                response.StreeName = owner.StreetName;
                response.Suburb = owner.Suburb;
                response.City = owner.City;
                response.PostalCode = owner.PostalCode;
                response.TelWork = owner.TelWork;
                response.TelMobile = owner.TelMobile;
                response.Fax = owner.Fax;
                response.Email = owner.Email;
                response.Website = owner.Website;
                response.Title = owner.Title;
                response.FirstName = owner.FirstName;
                response.SecondName = owner.SecondName;
                response.ThirdName = owner.ThirdName;
                response.LastName = owner.LastName;
                response.IDNumber = owner.IDNumber;

            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [Route("api/owner/delete/{id}")]
        public JsonResult Delete(int id)
        {
            Owner owner = db.Owners.Where(x => x.OwnerID == id).FirstOrDefault();
            bool result = false;
            if (owner != null)
            {
                db.Owners.Remove(owner);
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("api/owner/add")]
        public JsonResult Add(CreateOwnerRequest request)
        {
            Owner owner = null;
            if (request.OwnerID <= 0)
            {
                owner = new Owner();
                owner.OwnerID = request.OwnerID;
                owner.Type = request.Type;
                owner.Name = request.Name;
                owner.UnitNr = request.UnitNr;
                owner.ComplexName = request.ComplexName;
                owner.StreetNumber = request.StreetNumber;
                owner.StreetName = request.StreeName;
                owner.Suburb = request.Suburb;
                owner.City = request.City;
                owner.PostalCode = request.PostalCode;
                owner.TelWork = request.TelWork;
                owner.TelMobile = request.TelMobile;
                owner.Fax = request.Fax;
                owner.Email = request.Email;
                owner.Website = request.Website;
                owner.Title = request.Title;
                owner.FirstName = request.FirstName;
                owner.SecondName = request.SecondName;
                owner.ThirdName = request.ThirdName;
                owner.LastName = request.LastName;
                owner.IDNumber = request.IDNumber;

                db.Owners.Add(owner);
                db.SaveChanges();


            }
            else
            {
                owner = db.Owners.Where(x => x.OwnerID == request.OwnerID).FirstOrDefault();
                if (owner != null)
                {
                    owner.OwnerID = request.OwnerID;
                    owner.Type = request.Type;
                    owner.Name = request.Name;
                    owner.UnitNr = request.UnitNr;
                    owner.ComplexName = request.ComplexName;
                    owner.StreetNumber = request.StreetNumber;
                    owner.StreetName = request.StreeName;
                    owner.Suburb = request.Suburb;
                    owner.City = request.City;
                    owner.PostalCode = request.PostalCode;
                    owner.TelWork = request.TelWork;
                    owner.TelMobile = request.TelMobile;
                    owner.Fax = request.Fax;
                    owner.Email = request.Email;
                    owner.Website = request.Website;
                    owner.Title = request.Title;
                    owner.FirstName = request.FirstName;
                    owner.SecondName = request.SecondName;
                    owner.ThirdName = request.ThirdName;
                    owner.LastName = request.LastName;
                    owner.IDNumber = request.IDNumber;

                    db.SaveChanges();
                }

            }

            return Json(owner);
        }

        [Route("api/owner")]
        public JsonResult List()
        {
            return Json(db.Owners.ToList().Select(x => new OwnerResponse()
            {
                OwnerID = x.OwnerID,
                Type = x.Type,
                Name = x.Name,
                UnitNr = x.UnitNr,
                ComplexName = x.ComplexName,
                StreetNumber = x.StreetNumber,
                StreeName = x.StreetName,
                Suburb = x.Suburb,
                City = x.City,
                PostalCode = x.PostalCode,
                TelWork = x.TelWork,
                TelMobile = x.TelMobile,
                Fax = x.Fax,
                Email = x.Email,
                Website = x.Website,
                Title = x.Title,
                FirstName = x.FirstName,
                SecondName = x.SecondName,
                ThirdName = x.ThirdName,
                LastName = x.LastName,
                IDNumber = x.IDNumber
            }).ToList(), JsonRequestBehavior.AllowGet);
        }

        [Route("api/owner/search/{search}")]
        public JsonResult Search(string search = "")
        {
            var data = db.Owners.AsQueryable();
            search = search.ToLower();
            foreach (var word in search.Trim().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries))
            {
                data = data.Where(x =>
                 x.Type.ToLower().Contains(word) ||
                 x.Name.ToLower().Contains(word) ||
                 x.UnitNr.ToLower().Contains(word) ||
                 x.ComplexName.ToLower().Contains(word) ||
                 x.StreetNumber.ToLower().Contains(word) ||
                 x.StreetName.ToLower().Contains(word) ||
                 x.Suburb.ToLower().Contains(word) ||
                 x.City.ToLower().Contains(word) ||
                 x.PostalCode.ToString().Contains(word) ||
                 x.TelWork.Contains(word) ||
                 x.TelMobile.Contains(word) ||
                 x.Fax.Contains(word) ||
                 x.Email.ToLower().Contains(word) ||
                 x.Website.ToLower().Contains(word) ||
                 x.Title.ToLower().Contains(word) ||
                 x.FirstName.ToLower().Contains(word) ||
                 x.SecondName.ToLower().Contains(word) ||
                 x.ThirdName.ToLower().Contains(word) ||
                 x.LastName.ToLower().Contains(word) ||
                 x.IDNumber.ToLower().Contains(word)
                );
            }

            return Json(data.Take(20).ToList().Select(x => new OwnerResponse()
            {
                OwnerID = x.OwnerID,
                Type = x.Type,
                Name = x.Name,
                UnitNr = x.UnitNr,
                ComplexName = x.ComplexName,
                StreetNumber = x.StreetNumber,
                StreeName = x.StreetName,
                Suburb = x.Suburb,
                City = x.City,
                PostalCode = x.PostalCode,
                TelWork = x.TelWork,
                TelMobile = x.TelMobile,
                Fax = x.Fax,
                Email = x.Email,
                Website = x.Website,
                Title = x.Title,
                FirstName = x.FirstName,
                SecondName = x.SecondName,
                ThirdName = x.ThirdName,
                LastName = x.LastName,
                IDNumber = x.IDNumber
            }).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}