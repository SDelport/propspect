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
        public MvcHtmlString EncodedTemplate;
        public Dictionary<string,List<SelectListItem>> ItemLists { get; set; }
        public MvcHtmlString ListOptions { get; set; }
        public MvcHtmlString EditOptions { get; set; }
        public ListAsyncFormModel()
        {
            ItemLists = new Dictionary<string, List<SelectListItem>>();
        }


        public static ListAsyncFormModel Create<T>(List<T> items) where T :new()
        {
            return HtmlExtensions.GetListAsyncModel(items);
        }
    }
}