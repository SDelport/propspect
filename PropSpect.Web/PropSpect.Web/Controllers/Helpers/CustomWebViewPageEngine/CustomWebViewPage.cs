using PropSpect.Web.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropSpect.Web.Controllers.Helpers.CustomWebViewPageEngine
{
    public abstract class CustomWebViewPage : WebViewPage
    {
        public Form Form { get; set; }



        public override void InitHelpers()
        {
            base.InitHelpers();
        }
    }

}