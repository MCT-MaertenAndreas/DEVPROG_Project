using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EindProject.Models
{
    public class Leaders
    {
        [JsonProperty(PropertyName = "current_user")]
        public Leader CurrentUser { get; set; }

        [JsonProperty(PropertyName = "data")]
        public List<Leader> Users = new List<Leader>();
        [JsonProperty(PropertyName = "page")]
        public int Page { get; set; }
        [JsonProperty(PropertyName = "total_pages")]
        public int TotalPages { get; set; }
    }
}
