using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropSpect.Web.Models.FormModels
{
    public class PropertyOwnerTenantManage
    {
        public List<Owner> Owners { get; set; }
        public List<Tenant> Tenants { get; set; }
        public string UnitNumber { get; set; }
        public string ComplexName { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public int PropertyID { get; set; }
    }
}