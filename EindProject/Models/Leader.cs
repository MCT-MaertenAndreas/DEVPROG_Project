using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EindProject.Models
{
    public class RunningTotal
    {
        [JsonProperty(PropertyName = "total_seconds")]
        public float totalSeconds { get; set; }
        [JsonProperty(PropertyName = "human_readable_total")]
        public string humanReadableTotal { get; set; }
        [JsonProperty(PropertyName = "daily_average")]
        public float dailAverage { get; set; }
        [JsonProperty(PropertyName = "human_readable_daily_average")]
        public string humanReadableDailyAverage { get; set; }
        [JsonProperty(PropertyName = "languages")]
        public List<Language> languages { get; set; }
    }

    public class Leader
    {
        [JsonProperty(PropertyName = "rank")]
        public int rank { get; set; }
        [JsonProperty(PropertyName = "running_total")]
        public RunningTotal runningTotal { get; set; }
        [JsonProperty(PropertyName = "user")]
        public User user { get; set; }
    }
}
