using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Input
{
    public class SignUpDTO
    {
        [JsonProperty("UserName")]
        [JsonRequired]
        [Required]
        public string UserName { get; set; }

        [JsonProperty("EmailAddress")]
        [JsonRequired]
        [Required]
        public string EmailAddress { get; set; }

        [JsonProperty("Password")]
        [JsonRequired]
        [Required]
        public string Password { get; set; }

        [JsonProperty("UserID")]
        [JsonRequired]
        [Required]
        public Guid UserID { get; set; }
    }
}
