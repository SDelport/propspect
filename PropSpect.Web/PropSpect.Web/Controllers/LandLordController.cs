using Newtonsoft.Json;
using PropSpect.Api.Models.Request;
using PropSpect.Api.Models.Response;
using PropSpect.Web.Controllers.Helpers;
using PropSpect.Web.Controllers.Helpers.CustomWebViewPageEngine;
using PropSpect.Web.Models.FormModels;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PropSpect.Web.Controllers
{
    public class LandLordController : Controller
    {
        [Route("landlord/add")]
        [Route("landlord/edit/{landlordID?}")]
        public ActionResult AddLandLord(int landlordID = 0)
        {
            LandLordResponse formModel = new LandLordResponse();

            if (landlordID != 0)
            {
                LandLordResponse landlord = ApiWrapper.Get<LandLordResponse>("api/landlord/" + landlordID);
                formModel.LandlordID = landlord.LandlordID;
                formModel.Title = landlord.Title;
                formModel.Name = landlord.Name;
                formModel.FirstName = landlord.FirstName;
                formModel.LastName = landlord.LastName;
                formModel.SecondName = landlord.SecondName;
                formModel.ThirdName = landlord.ThirdName;
                formModel.Type = landlord.Type;
                formModel.IDNumber = landlord.IDNumber;
                formModel.AddressUnitNr = landlord.AddressUnitNr;
                formModel.ComplexName = landlord.ComplexName;
                formModel.StreetNumber = landlord.StreetNumber;
                formModel.StreetName = landlord.StreetName;
                formModel.CityName = landlord.CityName;
                formModel.PostalCode = landlord.PostalCode;
                formModel.TelWork = landlord.TelWork;
                formModel.TelMobile = landlord.TelMobile;
                formModel.Fax = landlord.Fax;
                formModel.Email = landlord.Email;
                formModel.Website = landlord.Website;
            }


            return View("Add", formModel);
        }

        [Route("landlord/added")]
        public ActionResult AddedLandLord(LandLordResponse model)
        {
            CreateLandLordRequest request = new CreateLandLordRequest();
            request.LandlordID = model.LandlordID;
            request.Title = model.Title;
            request.Name = model.Name;
            request.FirstName = model.FirstName;
            request.LastName = model.LastName;
            request.SecondName = model.SecondName;
            request.ThirdName = model.ThirdName;
            request.Type = model.Type;
            request.IDNumber = model.IDNumber;
            request.AddressUnitNr = model.AddressUnitNr;
            request.ComplexName = model.ComplexName;
            request.StreetNumber = model.StreetNumber;
            request.StreetName = model.StreetName;
            request.CityName = model.CityName;
            request.PostalCode = model.PostalCode;
            request.TelWork = model.TelWork;
            request.TelMobile = model.TelMobile;
            request.Fax = model.Fax;
            request.Email = model.Email;
            request.Website = model.Website;

            ApiWrapper.Post<bool>("api/landlord/add", request);

            return Redirect("/landlord");
        }

        [Route("landlord")]
        public ActionResult List()
        {
            List<LandLord> landlords = new List<LandLord>();

            landlords = LandLord.CreateList(ApiWrapper.Get<List<LandLordResponse>>("api/landlord"));

            ListAsyncFormModel formModel = ListAsyncFormModel.Create(landlords);
            

            return View("List", formModel);
        }
    }
}