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

        [JsonProperty(PropertyName = "percent")]
        public float Percent { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }
}
