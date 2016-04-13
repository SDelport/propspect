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
    [LoggedIn]
    public class LandLordController : Controller
    {

        [Route("landlord/edit/{landlordID?}")]
        public ActionResult AddLandLord(int landlordID = 0)
        {
            LandlordResponse formModel = new LandlordResponse();

            if (landlordID != 0)
            {
                LandlordResponse landlord = ApiWrapper.Get<LandlordResponse>("api/landlord/" + landlordID);
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
                formModel.VatNumber = landlord.VatNumber;
                formModel.RegNumber = landlord.RegNumber;
                formModel.TelWork = landlord.TelWork;
                formModel.TelMobile = landlord.TelMobile;
                formModel.Fax = landlord.Fax;
                formModel.Email = landlord.Email;
                formModel.Website = landlord.Website;
            }


            return View("Add", formModel);
        }

        [Route("landlord/add")]
        public JsonResult AddedLandLord(LandlordResponse model)
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
            request.VatNumber = model.VatNumber;
            request.RegNumber = model.RegNumber;

            var result = ApiWrapper.Post<Landlord>("api/landlord/add", request);

            return Json(result);
        }

        [Route("landlord/list")]
        public ActionResult List()
        {
            List<Landlord> landlords = new List<Landlord>();

            landlords = Landlord.CreateList(ApiWrapper.Get<List<LandlordResponse>>("api/landlord/list"));

            ListAsyncFormModel formModel = ListAsyncFormModel.Create(landlords);


            formModel.ItemLists.Add("CityItems", EnvironmentCache.GetDisplayValues("CITY").Select(x => new SelectListItem()
            {
                Text = x.Display,
                Value = x.ID
            }).ToList());

            return View("List", formModel);
        }

        [Route("landlord/search/{search?}")]
        public JsonResult Search(string search = "")
        {
            List<Landlord> landlords = new List<Landlord>();

            landlords = Landlord.CreateList(ApiWrapper.Get<List<LandlordResponse>>("api/landlord/list/" + search));

            return Json(landlords, JsonRequestBehavior.AllowGet);

        }

        [Route("landlord/delete/{landlordID}")]
        public JsonResult Delete(int landlordID)
        {
            var response = ApiWrapper.Get<bool>("api/landlord/delete/" + landlordID);

            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}