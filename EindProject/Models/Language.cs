using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EindProject.Models
{
    public class Language
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "total_seconds")]
        public float TotalSeconds { get; set; }
        [JsonProperty(PropertyName = "percent")]
        public float Percent { get; set; }
    }
}
