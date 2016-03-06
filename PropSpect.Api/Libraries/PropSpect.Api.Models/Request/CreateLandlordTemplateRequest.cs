using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropSpect.Api.Models.Request
{
    public class CreateLandlordTemplateRequest
    {
        public int LandlordTemplateID { get; set; }
        public string TemplateName { get; set; }
    }
}
