using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropSpect.Api.Models.Request
{
    public class CreateLandlordTemplateAreaItemRequest
    {
        public int LandlordTemplateAreaItemID { get; set; }
        public string ItemName { get; set; }
        public int ItemOrder { get; set; }
    }
}
