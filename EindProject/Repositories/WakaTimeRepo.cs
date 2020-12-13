using EindProject.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace EindProject.Repositories
{
    public class WakaTimeRepo
    {
        private static string BaseURL = "https://wakatime.com/";

        public static bool IsTokenValid(string token)
        {
            return token.Length == 84 && token.StartsWith("sec_");
        }

        public static async Task<Leaders> GetLeaders(uint page = 1)
        {
            const string sPath = "/api/v1/leaders";

            string data = await WakaTimeRepo.Get(sPath + "?page="+ page);

            if (data == null) return null;

            return JsonConvert.DeserializeObject<Leaders>(data);
        }

        public static async Task<User> GetCurrentUser()
        {
            string token = Preferences.Get("token", "");
            if (!IsTokenValid(token)) return null;

            const string sPath = "/api/v1/users/current";

            string data = await WakaTimeRepo.Get(sPath);

            if (data == null) return null;

            JObject obj = JsonConvert.DeserializeObject<JObject>(data);

            if (obj["data"] == null) return null;

            return obj["data"].ToObject<User>();
        }

        public static async Task<AllTimeStats> GetCurrentUserAllTimeStats()
        {
            string token = Preferences.Get("token", "");
            if (!IsTokenValid(token)) return null;

            const string sPath = "/api/v1/users/current/all_time_since_today";

            string data = await WakaTimeRepo.Get(sPath);

            if (data == null) return null;

            JObject obj = JsonConvert.DeserializeObject<JObject>(data);

            if (obj["data"] == null) return null;

            return obj["data"].ToObject<AllTimeStats>();
        }

        public static async Task<Stats> GetUserStats(string guid)
        {
            string sPath = $"/api/v1/users/{guid}/stats/last_7_days";
            
            string data = await WakaTimeRepo.Get(sPath);

            if (data == null) return null;

            JObject obj = JsonConvert.DeserializeObject<JObject>(data);

            if (obj["data"] == null) return null;

            return obj["data"].ToObject<Stats>();
        }

        private async static Task<string> Get(string path)
        {
            using (var client = WakaTimeRepo.GetHttpClient())
            {
                try
                {
                    return await client.GetStringAsync(WakaTimeRepo.BaseURL + path);
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        private static HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();

            string token = Preferences.Get("token", "");
            if (IsTokenValid(token))
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            return client;
        }
    }
}
