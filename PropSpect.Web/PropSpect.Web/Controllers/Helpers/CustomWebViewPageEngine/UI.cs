using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace PropSpect.Web.Controllers.Helpers.CustomWebViewPageEngine
{
    public class UI<TModel>
    {
        public HtmlHelper<TModel> Html { get; set; }

        public UI(ViewContext viewContext, IViewDataContainer viewDataContainer)
        {
            Html = new HtmlHelper<TModel>(viewContext, viewDataContainer);
        }

        public MvcHtmlString NavLink(string label, string link = "", string linkClass = "")
        {
            if (string.Compare(HttpContext.Current.Request.RawUrl, link, true) == 0)
                linkClass += "active ";

            if (string.IsNullOrEmpty(link))
                link = "/" + label.ToLower().Replace(" ", "");


            linkClass = linkClass.Trim();

            NavLinkControl control = new NavLinkControl();
            control.Label = new MvcHtmlString(label);
            control.Link = new MvcHtmlString(link);
            control.LinkClass = new MvcHtmlString(linkClass);

            return this.Html.Partial("Templates/Default/Navlink", control);
        }
    }


}