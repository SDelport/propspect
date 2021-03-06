﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropSpect.Web.Controllers.Helpers.CustomWebViewPageEngine
{
  
    public abstract class CustomWebViewPage<TModel> : WebViewPage<TModel>
    {
        public Form<TModel> Form { get; set; }
        public UI<TModel> UI { get; set; }

        public string Title { get; set; }


        public override void InitHelpers()
        {
            base.InitHelpers();
            Form = new Form<TModel>(this.ViewContext, this);
            UI = new UI<TModel>(this.ViewContext, this);

        }
    }

}