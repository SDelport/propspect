using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropSpect.Web.Controllers.Helpers
{
    public class NavLinkControl
    {
        public MvcHtmlString Label { get; set; }
        public MvcHtmlString Link { get; set; }
        public MvcHtmlString LinkClass { get; set; }
    }
}