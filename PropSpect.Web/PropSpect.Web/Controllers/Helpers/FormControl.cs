using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropSpect.Web.Controllers.Helpers.CustomWebViewPageEngine
{
    public class FormControl
    {
        public MvcHtmlString ID { get; set; }
        public MvcHtmlString Label { get; set; }
        public MvcHtmlString CssClass { get; set; }
        public MvcHtmlString Validation { get; set; }
        public MvcHtmlString ValidationAttributes { get; set; }
        public MvcHtmlString Value { get; set; }
        public MvcHtmlString PropertyName { get; set; }
        public bool IsAsync { get; set; }
        public Dictionary<string,object> Extras { get; set; }

        public MvcHtmlString HtmlID
        {
            get
            {
                return new MvcHtmlString(PropertyName.ToString().Replace(" ", "").ToLower());
            }
        }

        public MvcHtmlString VariableName
        {
            get
            {
                return new MvcHtmlString(PropertyName.ToString().Replace(" ", "").Replace("/", ""));
            }
        }
    }
}