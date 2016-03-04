using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropSpect.Web.Controllers.Helpers.CustomWebViewPageEngine
{
    public class ListOptions : Attribute
    {
        public ListOptions()
        {

        }

        public bool Hide { get; set; }
    }
}