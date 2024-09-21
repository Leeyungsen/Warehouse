using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Input
{
    public class MsCategoryUpdateDTO
    {

        [JsonProperty("categoryId")]
        [JsonRequired]
        [Required]
        public string categoryID { get; set; }


        [JsonProperty("categoryName")]
        [JsonRequired]
        [Required]
        public string categoryName { get; set; }

    }
}
