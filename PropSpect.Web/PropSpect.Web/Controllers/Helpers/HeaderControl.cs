﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropSpect.Web.Controllers.Helpers.CustomWebViewPageEngine
{
    public class HeaderControl : FormControl
    {
        public MvcHtmlString Source { get; set; }
        public bool UseSource { get;  set; }
    }
}