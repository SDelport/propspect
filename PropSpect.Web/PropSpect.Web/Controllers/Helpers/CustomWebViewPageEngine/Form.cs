using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropSpect.Web.Controllers.Helpers.CustomWebViewPageEngine
{
    public class Form<TModel> 
    {
        public HtmlHelper<TModel> Html { get; set; }

        public Form(ViewContext viewContext, IViewDataContainer viewDataContainer)
        {
            Html = new HtmlHelper<TModel>(viewContext, viewDataContainer);
        }
    }

 
}