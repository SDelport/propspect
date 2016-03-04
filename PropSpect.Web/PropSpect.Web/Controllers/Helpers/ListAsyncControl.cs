using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropSpect.Web.Controllers.Helpers.CustomWebViewPageEngine
{
    public class ListAsyncControl : FormControl
    {
        public List<HeaderControl> Headers { get; set; }

        public ListAsyncControl()
        {
            Headers = new List<HeaderControl>();
        }
    }
}