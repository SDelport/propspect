using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropSpect.Api.Models.Response
{
    public class InspectionDetailsResponse
    {
        public List<InspectionAreaItemResponse> Items { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string PageName { get; set; }
    }
}
