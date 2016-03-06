using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropSpect.Api.Models.Request
{
    public class CreateAreaItemRequest
    {
        public int AreaItemID { get; set; }
        public string RoomItem { get; set; }
        public string RoomDescription { get; set; }
    }
}
