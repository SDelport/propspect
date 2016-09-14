using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropSpect.Web.Models.FormModels
{
    public class AddAreaItems
    {
        public int PropertyID { get; set; }
        public List<LandlordTemplateArea> TemplateAreas { get; set; }
        public AddAreaItems(int PropertyID, List<LandlordTemplateArea> TemplateAreas)
        {
            this.PropertyID = PropertyID;
            this.TemplateAreas = TemplateAreas;
        }
    }
}