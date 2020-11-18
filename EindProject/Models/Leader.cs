using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EindProject.Models
{
    public class RunningTotal
    {
        [JsonProperty(PropertyName = "total_seconds")]
        public float TotalSeconds { get; set; }
        [JsonProperty(PropertyName = "human_readable_total")]
        public string HumanReadableTotal { get; set; }
        [JsonProperty(PropertyName = "daily_average")]
        public float DailyAverage { get; set; }
        [JsonProperty(PropertyName = "human_readable_daily_average")]
        public string HumanReadableAverageDaily { get; set; }
        [JsonProperty(PropertyName = "languages")]
        public List<Language> Languages { get; set; }
    }

    public class Leader
    {
        [JsonProperty(PropertyName = "rank")]
        public int Rank { get; set; }
        [JsonProperty(PropertyName = "running_total")]
        public RunningTotal RunningTotal { get; set; }
        [JsonProperty(PropertyName = "user")]
        public User User { get; set; }
    }
}
