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
    public class PropertyController : Controller
    {

        [Route("property/edit/{propertyID?}")]
        public ActionResult AddProperty(int propertyID = 0)
        {
            PropertyResponse formModel = new PropertyResponse();

            if (propertyID != 0)
            {
                PropertyResponse property = ApiWrapper.Get<PropertyResponse>("api/property/" + propertyID);
                formModel.PropertyID = property.PropertyID;
                formModel.StreetName = property.StreetName;
                formModel.StreetNumber = property.StreetNumber;
                formModel.City = property.City;
                formModel.ComplexName = property.ComplexName;
                formModel.PostalCode = property.PostalCode;
                formModel.PropertyID = property.PropertyID;
                formModel.PropertyType = property.PropertyType;
                formModel.UnitNumber = property.UnitNumber;
                formModel.Suburb = property.Suburb;
            }


            return View("Add", formModel);
        }

        [Route("property/add")]
        public JsonResult AddedProperty(PropertyResponse model)
        {
            CreatePropertyRequest request = new CreatePropertyRequest();
            request.PropertyID = model.PropertyID;
            request.StreetName = model.StreetName;
            request.StreetNumber = model.StreetNumber;
            request.City = model.City;
            request.ComplexName = model.ComplexName;
            request.PostalCode = model.PostalCode;
            request.PropertyID = model.PropertyID;
            request.PropertyType = model.PropertyType;
            request.UnitNumber = model.UnitNumber;
            request.Suburb = model.Suburb;

            var result = ApiWrapper.Post<PropertyResponse>("api/property/add", request);

            return Json(result);
        }



        [Route("property/list")]
        public ActionResult List()
        {
            List<Property> propertys = new List<Property>();

            propertys = Property.CreateList(ApiWrapper.Get<List<PropertyResponse>>("api/property/list"));

            ListAsyncFormModel formModel = ListAsyncFormModel.Create(propertys);


            formModel.ItemLists.Add("CityItems", EnvironmentCache.GetDisplayValues("CITY").Select(x => new SelectListItem()
            {
                Text = x.Display,
                Value = x.ID
            }).ToList());

            return View("List", formModel);
        }

        [Route("property/select/{searchMethod?}/{searchString?}")]
        public ActionResult SelectProperty(string searchMethod = "", string searchString = "")
        {
            var response = Property.CreateList(ApiWrapper.Get<List<PropertyResponse>>(("api/property/search/" + searchMethod + "/" + searchString).Trim('/')));

            PropertySelect model = new PropertySelect();
            model.Properties = response;
            model.ReturnUrl = Request.QueryString["returnurl"];

            return View("Select", model);
        }

        [Route("property/selectowner/{searchMethod?}/{searchString?}")]
        public ActionResult SelectOwner(string searchMethod = "", string searchString = "")
        {
            var response = Owner.CreateList(ApiWrapper.Get<List<OwnerResponse>>(("api/property/searchowner/" + searchMethod + "/" + searchString).Trim('/')));

            OwnerSelect model = new OwnerSelect();
            model.Owners = response;
            model.ReturnUrl = Request.QueryString["returnurl"];

            return View("OwnerSelect", model);
        }

        [Route("property/selecttenant/{searchMethod?}/{searchString?}")]
        public ActionResult SelectTenant(string searchMethod = "", string searchString = "")
        {
            var response = Tenant.CreateList(ApiWrapper.Get<List<TenantResponse>>(("api/property/searchtenant/" + searchMethod + "/" + searchString).Trim('/')));

            TenantSelect model = new TenantSelect();
            model.Tenants = response;
            model.ReturnUrl = Request.QueryString["returnurl"];

            return View("TenantSelect", model);
        }



        [Route("property/manage/owner/{ownerID}")]
        public ActionResult OwnerProperty(int ownerID)
        {
            var propertyResponse = Property.CreateList(ApiWrapper.Get<List<PropertyResponse>>("api/property/owner/" + ownerID));
            var ownerResponse = ApiWrapper.Get<OwnerResponse>("api/owner/get/" + ownerID);

            OwnerPropertyManage model = new OwnerPropertyManage();
            model.OwnerName = ownerResponse.Name + " " + ownerResponse.LastName;
            model.OwnerID = ownerID;
            model.Properties = propertyResponse;

            return View("OwnerPropertyManage", model);
        }

        [Route("property/manage/tenant/{tenantID}")]
        public ActionResult TenantProperty(int tenantID)
        {
            var propertyResponse = Property.CreateList(ApiWrapper.Get<List<PropertyResponse>>("api/property/tenant/" + tenantID));
            var tenantResponse = ApiWrapper.Get<TenantResponse>("api/tenant/get/" + tenantID);

            TenantPropertyManage model = new TenantPropertyManage();
            model.TenantName = tenantResponse.FirstName + " " + tenantResponse.LastName;
            model.TenantID = tenantID;
            model.Properties = propertyResponse;

            return View("TenantPropertyManage", model);
        }

        [Route("property/manage/propertyowner/{propertyID}")]
        public ActionResult PropertyOwner(int propertyID)
        {
            var propertyResponse = ApiWrapper.Get<PropertyResponse>("api/property/" + propertyID);
            var ownerResponse = Owner.CreateList(ApiWrapper.Get<List<OwnerResponse>>("api/property/propertyowner/" + propertyID));

            PropertyOwnerTenantManage model = new PropertyOwnerTenantManage();
            model.Owners = ownerResponse;
            model.PropertyID = propertyResponse.PropertyID;
            model.StreetName = propertyResponse.StreetName;
            model.StreetNumber = propertyResponse.StreetNumber;
            model.UnitNumber = propertyResponse.UnitNumber;
            model.ComplexName = propertyResponse.ComplexName;

            return View("PropertyOwnerManage", model);
        }

        [Route("property/manage/propertytenant/{propertyID}")]
        public ActionResult PropertyTenant(int propertyID)
        {
            var propertyResponse = ApiWrapper.Get<PropertyResponse>("api/property/" + propertyID);
            var tenantResponse = Tenant.CreateList(ApiWrapper.Get<List<TenantResponse>>("api/property/propertytenant/" + propertyID));

            PropertyOwnerTenantManage model = new PropertyOwnerTenantManage();
            model.Tenants = tenantResponse;
            model.PropertyID = propertyResponse.PropertyID;
            model.StreetName = propertyResponse.StreetName;
            model.StreetNumber = propertyResponse.StreetNumber;
            model.UnitNumber = propertyResponse.UnitNumber;
            model.ComplexName = propertyResponse.ComplexName;

            return View("PropertyTenantManage", model);
        }


        [HttpPost]
        [Route("property/manage/owner/add/{ownerID}")]
        public ActionResult AssignPropertyOwner(int ownerID, int propertyID)
        {
            var response = ApiWrapper.Get<bool>("api/property/assign-owner/" + propertyID + "/" + ownerID);

            return Redirect("/property/manage/owner/" + ownerID);
        }


        [Route("property/unassign-owner/{propertyID}/{ownerID}")]
        public ActionResult UnassignPropertyOwner(int ownerID, int propertyID)
        {
            var response = ApiWrapper.Get<bool>("api/property/unassign-owner/" + propertyID + "/" + ownerID);

            return Redirect("/property/manage/owner/" + ownerID);
        }
        

        [HttpPost]
        [Route("property/manage/tenant/add/{tenantID}")]
        public ActionResult AssignPropertyTenant(int tenantID, int propertyID)
        {
            var response = ApiWrapper.Get<bool>("api/property/assign-tenant/" + propertyID + "/" + tenantID);

            return Redirect("/property/manage/tenant/" + tenantID);
        }


        [Route("property/unassign-tenant/{propertyID}/{tenantID}")]
        public ActionResult UnassignPropertyTenant(int tenantID, int propertyID)
        {
            var response = ApiWrapper.Get<bool>("api/property/unassign-tenant/" + propertyID + "/" + tenantID);

            return Redirect("/property/manage/tenant/" + tenantID);
        }

        [HttpPost]
        [Route("property/manage/propertyowner/add/{propertyID}")]
        public ActionResult AssignOwnerProperty(int ownerID, int propertyID)
        {
            var response = ApiWrapper.Get<bool>("api/property/assign-owner/" + propertyID + "/" + ownerID);

            return Redirect("/property/manage/propertyowner/" + propertyID);
        }

        [Route("property/unassign-propertyowner/{propertyID}/{ownerID}")]
        public ActionResult UnassignOwnerProperty(int ownerID, int propertyID)
        {
            var response = ApiWrapper.Get<bool>("api/property/unassign-owner/" + propertyID + "/" + ownerID);

            return Redirect("/property/manage/propertyowner/" + propertyID);
        }

        [HttpPost]
        [Route("property/manage/propertytenant/add/{propertyID}")]
        public ActionResult AssignTenantProperty(int tenantID, int propertyID)
        {
            var response = ApiWrapper.Get<bool>("api/property/assign-tenant/" + propertyID + "/" + tenantID);

            return Redirect("/property/manage/propertytenant/" + propertyID);
        }

        [Route("property/unassign-propertytenant/{propertyID}/{tenantID}")]
        public ActionResult UnassignTenantProperty(int tenantID, int propertyID)
        {
            var response = ApiWrapper.Get<bool>("api/property/unassign-tenant/" + propertyID + "/" + tenantID);

            return Redirect("/property/manage/propertytenant/" + propertyID);
        }

        [Route("property/search/{search}")]
        public JsonResult Search(string search)
        {
            List<Property> propertys = new List<Property>();

            propertys = Property.CreateList(ApiWrapper.Get<List<PropertyResponse>>("api/property/list/" + search));

            return Json(propertys, JsonRequestBehavior.AllowGet);

        }

    }
}