using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PropSpect.Api.Models
{
    [Table("api_consumer_log")]
    public class ResetPasswordKey
    {
        [Column("key_id")]
        public int ResetPasswordKeyID { get; set; }
        [Column("api_log_request_url")]
        public string Key { get; set; }
        [Column("api_log_status_code")]
        public int UserID { get; set; }

    }
}