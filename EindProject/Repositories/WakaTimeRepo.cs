using EindProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EindProject.Repositories
{
    public class WakaTimeRepo
    {
        private static string sBaseURL = "https://wakatime.com/";

        public static async Task<Leaders> GetLeaders()
        {
            const string sPath = "/api/v1/leaders";

            Leaders leaders;

            using (var client = WakaTimeRepo.GetHttpClient())
            {
                string data = await client.GetStringAsync(WakaTimeRepo.sBaseURL + sPath);

                if (data == null) return null;

                leaders = JsonConvert.DeserializeObject<Leaders>(data);
            }

            return leaders;
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
            //client.DefaultRequestHeaders.Add("Authorization", sToken);

            return client;
        }
    }
}
