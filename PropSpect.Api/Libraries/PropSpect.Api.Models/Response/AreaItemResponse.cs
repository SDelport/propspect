using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropSpect.Api.Models.Response
{
    public class AreaItemResponse
    {
        public int AreaItemID { get; set; }
        public int AreaID { get; set; }
        public string RoomItem { get; set; }        
        public string RoomDescription { get; set; }
    }
}
