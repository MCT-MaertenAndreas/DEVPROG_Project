using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EindProject.Models
{
    public class Leaders
    {
        [JsonProperty(PropertyName = "data")]
        public List<Leader> users = new List<Leader>();
        [JsonProperty(PropertyName = "page")]
        public int page { get; set; }
        [JsonProperty(PropertyName = "total_pages")]
        public int totalPages { get; set; }
    }
}
