using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropSpect.Web.Controllers.Helpers.CustomWebViewPageEngine
{
    public class ListOptions : Attribute
    {
        public bool Hide { get; set; }
    }

    

    public class EditOptions : Attribute
    {
        public ControlType Type { get; set; }
        public string SourceName { get; set; }
        public string DependancyName { get; set; }
    }

   
}