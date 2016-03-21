using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PropSpect.Api.Models
{
    [Table("all_environment_record")]
    public class EnvironmentValue
    {
        [Column("env_id")]
        public string ID { get; set; }
        [Column("env_code")]
        public string Code { get; set; }
        [Column("env_desc")]
        public string Display { get; set; }
        [Column("env_type")]
        public string Type{ get; set; }

    }
}