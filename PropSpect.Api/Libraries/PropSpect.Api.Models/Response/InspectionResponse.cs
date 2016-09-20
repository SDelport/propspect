using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropSpect.Api.Models.Response
{
    public class InspectionResponse
    {
        public int    InspectionID { get; set; }
        public int PropertyID { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }
        public string EntityType { get; set; }
        public int?    EntityID { get; set; }
        public string HouseClean { get; set; }  
        public string HouseComments { get; set; }
        public string CarpetsClean { get; set; }
        public string CarpetsComments { get; set; }
        public string GardenClean { get; set; }
        public string GardenComments { get; set; }
        public string PoolClean { get; set; }
        public string PoolComments { get; set; }
        public string OverallComments { get; set; }
    }
}
