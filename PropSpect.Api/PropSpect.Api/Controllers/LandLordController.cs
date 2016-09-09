using PropSpect.Api.Authorize;
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

    public class LandlordController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        [Route("api/landlord/{id}")]
        public JsonResult Get(int id)
        {
            LandlordResponse response = null;

            Landlord landlord = db.LandLords.Where(x => x.LandlordID == id).FirstOrDefault();

            if (landlord != null)
            {
                response = new LandlordResponse();
                response.LandlordID = landlord.LandlordID;
                response.Title = landlord.Title;
                response.Name = landlord.Name;
                response.FirstName = landlord.FirstName;
                response.LastName = landlord.LastName;
                response.SecondName = landlord.SecondName;
                response.ThirdName = landlord.ThirdName;
                response.Type = landlord.Type;
                response.IDNumber = landlord.IDNumber;
                response.AddressUnitNr = landlord.AddressUnitNr;
                response.ComplexName = landlord.ComplexName;
                response.StreetNumber = landlord.StreetNumber;
                response.StreetName = landlord.StreetName;
                response.CityName = landlord.CityName;
                response.PostalCode = landlord.PostalCode;
                response.TelWork = landlord.TelWork;
                response.TelMobile = landlord.TelMobile;
                response.Fax = landlord.Fax;
                response.Email = landlord.Email;
                response.Website = landlord.Website;
                response.VatNumber = landlord.VatNumber;
                response.RegNumber = landlord.RegNumber;
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [Route("api/landlord/delete/{id}")]
        public JsonResult Delete(int id)
        {
            Landlord landlord = db.LandLords.Where(x => x.LandlordID == id).FirstOrDefault();

            if (landlord != null)
            {
                db.LandLords.Remove(landlord);
                db.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("api/landlord/add")]
        public JsonResult Add(CreateLandLordRequest request)
        {
            Landlord landlord = null;
            if (request.LandlordID <= 0)
            {
                landlord = new Landlord();
                landlord.Title = request.Title;
                landlord.Name = request.Name;
                landlord.FirstName = request.FirstName;
                landlord.LastName = request.LastName;
                landlord.SecondName = request.SecondName;
                landlord.ThirdName = request.ThirdName;
                landlord.Type = request.Type;
                landlord.IDNumber = request.IDNumber;
                landlord.AddressUnitNr = request.AddressUnitNr;
                landlord.ComplexName = request.ComplexName;
                landlord.StreetNumber = request.StreetNumber;
                landlord.StreetName = request.StreetName;
                landlord.CityName = request.CityName;
                landlord.PostalCode = request.PostalCode;
                landlord.TelWork = request.TelWork;
                landlord.TelMobile = request.TelMobile;
                landlord.Fax = request.Fax;
                landlord.Email = request.Email;
                landlord.Website = request.Website;
                landlord.RegNumber = request.RegNumber;
                landlord.VatNumber = request.VatNumber;

                db.LandLords.Add(landlord);
                db.SaveChanges();
            }
            else
            {
                landlord = db.LandLords.Where(x => x.LandlordID == request.LandlordID).FirstOrDefault();
                if (landlord != null)
                {
                    landlord.Title = request.Title;
                    landlord.Name = request.Name;
                    landlord.FirstName = request.FirstName;
                    landlord.LastName = request.LastName;
                    landlord.SecondName = request.SecondName;
                    landlord.ThirdName = request.ThirdName;
                    landlord.Type = request.Type;
                    landlord.IDNumber = request.IDNumber;
                    landlord.AddressUnitNr = request.AddressUnitNr;
                    landlord.ComplexName = request.ComplexName;
                    landlord.StreetNumber = request.StreetNumber;
                    landlord.StreetName = request.StreetName;
                    landlord.CityName = request.CityName;
                    landlord.PostalCode = request.PostalCode;
                    landlord.TelWork = request.TelWork;
                    landlord.TelMobile = request.TelMobile;
                    landlord.Fax = request.Fax;
                    landlord.Email = request.Email;
                    landlord.Website = request.Website;
                    landlord.RegNumber = request.RegNumber;
                    landlord.VatNumber = request.VatNumber;

                    db.SaveChanges();
                }

            }

            return Json(landlord);
        }


        [Route("api/landlord/list/{search?}")]
        public JsonResult List(string search = "")
        {


            //Company Name    Contact Name    Contact Surname Email Website Work Number Cell Number
            return Json(db.LandLords.Where(x =>
            search == "" ||
            x.Name.ToLower().Contains(search.ToLower()) ||
            x.FirstName.ToLower().Contains(search.ToLower()) ||
            x.LastName.ToLower().Contains(search.ToLower()) ||
            x.Email.ToLower().Contains(search.ToLower()) ||
            x.Website.ToLower().Contains(search.ToLower()) ||
            x.TelWork.ToLower().Contains(search.ToLower()) ||
            x.TelMobile.ToLower().Contains(search.ToLower())
            ).ToList().Select(x => new LandlordResponse()
            {
                AddressUnitNr = x.AddressUnitNr,
                CityName = x.CityName,
                ComplexName = x.ComplexName,
                Email = x.Email,
                Fax = x.Fax,
                FirstName = x.FirstName,
                IDNumber = x.IDNumber,
                LandlordID = x.LandlordID,
                LastName = x.LastName,
                Name = x.Name,
                PostalCode = x.PostalCode,
                SecondName = x.SecondName,
                StreetName = x.StreetName,
                StreetNumber = x.StreetNumber,
                Suburb = x.Suburb,
                TelMobile = x.TelMobile,
                TelWork = x.TelWork,
                ThirdName = x.ThirdName,
                Title = x.Title,
                Type = x.Type,
                Website = x.Website,
                VatNumber = x.VatNumber,
                RegNumber = x.RegNumber
            }).ToList(), JsonRequestBehavior.AllowGet);
        }


    }
}