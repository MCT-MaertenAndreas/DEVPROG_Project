using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EindProject.Models
{
    public class User
    {
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string email { get; set; }
        [JsonProperty(PropertyName = "username")]
        public string username { get; set; }
        [JsonProperty(PropertyName = "full_name")]
        public string fullName { get; set; }
        [JsonProperty(PropertyName = "display_name")]
        public string displayName { get; set; }
        [JsonProperty(PropertyName = "website")]
        public string website { get; set; }
        [JsonProperty(PropertyName = "human_readable_website")]
        public string humanReadableWebsite;
        [JsonProperty(PropertyName = "location")]
        public string location { get; set; }
        [JsonProperty(PropertyName = "is_hireable")]
        public bool isHireable { get; set; }
        [JsonProperty(PropertyName = "photo")]
        public string photo { get; set; }
        [JsonProperty(PropertyName = "photo_public")]
        public bool isPhotoPublic { get; set; }
    }
}
