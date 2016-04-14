using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropSpect.Web.Models.FormModels
{
    public class OwnerSelect
    {
        public List<Owner> Owners { get; set; }
        public string ReturnUrl { get; set; }
    }
}