using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EindProject.Models
{
    public class AllTimeStats
    {
        [JsonProperty(PropertyName = "is_up_to_date")]
        public bool UpToDate { get; set; }
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
        [JsonProperty(PropertyName = "total_seconds")]
        public double TotalSeconds { get; set; }
    }
}
