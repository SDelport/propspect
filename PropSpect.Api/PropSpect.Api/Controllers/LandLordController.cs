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
    [AuthorizationLevel(RoleType.Tenant, RoleType.Landlord)]
    public class LandLordController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        [Route("api/landlord/{id}")]
        public JsonResult Get(int id)
        {
            LandLordResponse response = null;

            Landlord landlord = db.LandLords.Where(x => x.LandlordID == id).FirstOrDefault();

            if (landlord != null)
            {
                response = new LandLordResponse();
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
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("api/landlord/add")]
        public JsonResult Add(CreateLandLordRequest request)
        {
            if(request.LandlordID<=0)
            { 
            Landlord landlord = new Landlord();
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



            db.LandLords.Add(landlord);
            db.SaveChanges();
            }
            else
            {
                Landlord landlord = db.LandLords.Where(x => x.LandlordID == request.LandlordID).FirstOrDefault();
                if(landlord!= null)
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

                    db.SaveChanges();
                }

            }

            return Json("true");
        }


        [Route("api/landlord")]
        public JsonResult List()
        {


            return Json(db.LandLords.ToList().Select(x => new LandLordResponse()
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
                TelMobile = x.Suburb,
                TelWork = x.TelWork,
                ThirdName = x.ThirdName,
                Title = x.Title,
                Type = x.Type,
                Website = x.Website
            }).ToList(), JsonRequestBehavior.AllowGet);
        }


    }
}