using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropSpect.Web.Models.FormModels
{
    public class OwnerPropertyManage
    {
        public List<Property> Properties { get; set; }
        public string OwnerName { get; set; }
        public int OwnerID { get; set; }
    }
}