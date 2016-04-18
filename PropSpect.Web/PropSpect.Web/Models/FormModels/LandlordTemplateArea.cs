using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropSpect.Web.Models.FormModels
{
    public class LandlordTemplateArea
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public List<LandlordTemplateAreaItem> Items { get; set; }
    }
}