using PropSpect.Api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropSpect.Web.Models.FormModels
{
    public class Inspection
    {
        public List<InspectionItem> Items { get; set; }
        public Inspection()
        {

        }
        public Inspection(List<InspectionResponse> responseList)
        {
            Items = new List<InspectionItem>();
            foreach (InspectionResponse response in responseList)
            {
                Items.Add(new InspectionItem(response));
            }
        }
    }
}