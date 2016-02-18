using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropSpect.Web.Controllers.Helpers.CustomWebViewPageEngine
{
    public static class Form
    {
        public static MvcHtmlString EndForm(this HtmlHelper html)
        {
            return new MvcHtmlString("</form>");
        }
    }
}