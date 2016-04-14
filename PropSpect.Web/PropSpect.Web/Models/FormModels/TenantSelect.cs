using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropSpect.Web.Models.FormModels
{
    public class TenantSelect
    {
        public List<Tenant> Tenants { get; set; }
        public string ReturnUrl { get; set; }
    }
}