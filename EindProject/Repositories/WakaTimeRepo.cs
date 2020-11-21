using EindProject.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace EindProject.Repositories
{
    public class WakaTimeRepo
    {
        private static string sBaseURL = "https://wakatime.com/";

        public static bool IsTokenValid(string token)
        {
            return token.Length == 84 && token.StartsWith("sec_");
        }

        public static async Task<Leaders> GetLeaders(uint page = 1)
        {
            const string sPath = "/api/v1/leaders";

            Leaders leaders;

            using (var client = WakaTimeRepo.GetHttpClient())
            {
                string data = await client.GetStringAsync(WakaTimeRepo.sBaseURL + sPath + "?page="+ page);

                if (data == null) return null;

                leaders = JsonConvert.DeserializeObject<Leaders>(data);
            }

            return leaders;
        }

        public static async Task<User> GetCurrentUser()
        {
            string token = Preferences.Get("token", "");
            if (!IsTokenValid(token)) return null;

            const string sPath = "/api/v1/users/current";

            User user;
            using (var client = WakaTimeRepo.GetHttpClient())
            {
                string data;
                try
                {
                    data = await client.GetStringAsync(WakaTimeRepo.sBaseURL + sPath);
                }
                catch (Exception)
                {
                    return null;
                }

                if (data == null) return null;

                JObject obj = JsonConvert.DeserializeObject<JObject>(data);

                if (obj["data"] == null) return null;

                user = obj["data"].ToObject<User>();
            }

            return user;
        }

        public static async Task<Stats> GetUserStats(string guid)
        {
            string sPath = $"/api/v1/users/{guid}/stats";

            Stats stats;

            using (var client = WakaTimeRepo.GetHttpClient())
            {
                string data = await client.GetStringAsync(WakaTimeRepo.sBaseURL + sPath);

                if (data == null) return null;

                stats = JsonConvert.DeserializeObject<Stats>(data);
            }

            return stats;
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
