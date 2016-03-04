using PropSpect.Web.Controllers.Helpers.CustomWebViewPageEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace PropSpect.Web.Models.FormModels
{
    public class ListAsyncFormModel
    {
        public ListAsyncControl Control;
        public MvcHtmlString EncodedItems;


        public static ListAsyncFormModel Create<T>(List<T> items)
        {
            return HtmlExtensions.GetListAsyncModel(items);
        }
    }
}