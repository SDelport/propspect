using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropSpect.Web.Models.FormModels
{
    public class ManageAreaItems
    {
        public List<AreaItem> items { get; set; }
        public Area area { get; set; }
        public ManageAreaItems()
        {

        }
        public ManageAreaItems(List<AreaItem> items, Area area)
        {
            this.items = items;
            this.area = area;
        }
    }
}