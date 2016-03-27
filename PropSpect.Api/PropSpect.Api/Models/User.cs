using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PropSpect.Api.Models
{
    [Table("user_login")]
    public class User
    {
        [Column("key_id")]
        public int UserID { get; set; }

        [Column("user_name")]
        public string Username { get; set; }

        [Column("user_type")]
        public string Type { get; set; }

        [Column("user_password")]
        public string Password { get; set; }

        [Column("user_password_changed")]
        public char IsPasswordChanged { get; set; }

        [Column("user_salt")]
        public string Salt { get; set; }

        [Column("user_language")]
        public string Language { get; set; }


    }
}