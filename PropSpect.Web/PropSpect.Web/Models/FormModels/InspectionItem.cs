using PropSpect.Api.Models.Response;
using PropSpect.Web.Controllers.Helpers.CustomWebViewPageEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PropSpect.Web.Models.FormModels
{
    public class InspectionItem
    {
        public int InspectionID { get; set; }
        public int PropertyID { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }
        [ListOptions(Hide = true)]
        public string EntityType { get; set; }
        [ListOptions(Hide = true)]
        public int? EntityID { get; set; }
        [DisplayName("House Clean")]
        public string HouseClean { get; set; }
        [ListOptions(Hide = true)]
        public string HouseComments { get; set; }
        [DisplayName("Carpets Clean")]
        public string CarpetsClean { get; set; }
        [ListOptions(Hide = true)]
        public string CarpetsComments { get; set; }
        [DisplayName("Garden Clean")]
        public string GardenClean { get; set; }
        [ListOptions(Hide = true)]
        public string GardenComments { get; set; }
        [DisplayName("Pool Clean")]
        public string PoolClean { get; set; }
        [ListOptions(Hide = true)]
        public string PoolComments { get; set; }
        [DisplayName("Overall Comments")]
        public string OverallComments { get; set; }
        public InspectionItem()
        {

        }
        public InspectionItem(InspectionResponse response)
        {
            this.CarpetsClean = response.CarpetsClean;
            this.CarpetsComments = response.CarpetsComments;
            this.Date = response.Date;
            this.EntityID = response.EntityID;
            this.EntityType = response.EntityType;
            this.GardenClean = response.GardenClean;
            this.GardenComments = response.GardenComments;
            this.HouseClean = response.HouseClean;
            this.HouseComments = response.HouseComments;
            this.InspectionID = response.InspectionID;
            this.OverallComments = response.OverallComments;
            this.PoolClean = response.PoolClean;
            this.PoolComments = response.PoolComments;
            this.PropertyID = response.PropertyID;
            this.Type = response.Type;
        }
        public static List<InspectionItem> ToList(List<InspectionResponse> responses)
        {
            List<InspectionItem> items = new List<InspectionItem>();
            foreach (var response in responses)
            {
                items.Add(new InspectionItem(response));
            }
            return items;
        }
    }
}