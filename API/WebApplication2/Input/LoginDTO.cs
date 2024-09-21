using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Input
{
    public class LoginDTO
    {
        [JsonProperty("EmailAddress")]
        [JsonRequired]
        [Required]
        public string EmailAddress { get; set; }

        [JsonProperty("Password")]
        [JsonRequired]
        [Required]
        public string Password { get; set; }
    }
}
