using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PropSpect.Api.Models
{
    [Table("prop_property_area_item")]
    public class AreaItem
    {
        [Column("key_id")]
        public int AreaItemID { get; set; }

        [Column("parent_id")]
        public int AreaID { get; set; }

        [Column("prop_room_item")]
        public string RoomItem { get; set; }

        [Column("prop_room_decription")]
        public string RoomDescription { get; set; }

    }
}