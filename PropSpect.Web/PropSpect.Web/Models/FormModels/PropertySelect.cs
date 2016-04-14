using PropSpect.Api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PropSpect.Web.Controllers.Helpers.CustomWebViewPageEngine;
using System.Web.Mvc;

namespace PropSpect.Web.Models.FormModels
{
    public class PropertySelect
    {
        public List<Property> Properties { get; set; }
        public string ReturnUrl { get; set; }


    }
}