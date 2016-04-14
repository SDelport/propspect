using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropSpect.Web.Models.FormModels
{
    public class TenantPropertyManage
    {
        public List<Property> Properties { get; set; }
        public string TenantName { get; set; }
        public int TenantID { get; set; }
    }
}