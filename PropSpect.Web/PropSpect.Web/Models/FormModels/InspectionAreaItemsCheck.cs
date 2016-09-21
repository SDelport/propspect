using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropSpect.Web.Models.FormModels
{
    public class InspectionAreaItemsCheck
    {
        public bool firstPage { get; set; }
        public bool lastPage { get; set; }
        public List<InspectionAreaItem> items { get; set; }
        public string AreaName { get; set; }
        public string backLink { get; set; }
        public string nextLink { get; set; }
        public InspectionAreaItemsCheck(bool firstPage,bool lastPage,List<InspectionAreaItem> items,string AreaName,string nextLink,string backLink="#")
        {
            this.firstPage = firstPage;
            this.lastPage = lastPage;
            this.items = items;
            this.AreaName = AreaName;
            this.nextLink = nextLink;
            this.backLink = backLink;
        }
    }
}