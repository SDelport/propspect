using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropSpect.Web.Models.FormModels
{
    public class ManagePropertyAreas
    {
        public List<Area> Areas { get; set; }
        public Property Property { get; set; }
        public ManagePropertyAreas(List<Area> areas,Property property)
        {
            this.Areas = areas;
            this.Property = property;
        }
        public ManagePropertyAreas()
        {

        }
    }
}