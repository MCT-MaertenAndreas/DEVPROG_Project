using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EindProject.Models
{
    public class Language
    {
        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }
        [JsonProperty(PropertyName = "total_seconds")]
        public float totalSeconds { get; set; }
    }
}
