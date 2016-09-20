using PropSpect.Api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropSpect.Web.Models.FormModels
{
    public class PreInspection
    {
        public List<PropertyResponse> Properties { get; set; }
        public List<TenantResponse> Tenants { get; set; }
        public List<OwnerResponse> Owners { get; set; }
    }
}