using EindProject.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace EindProject.Models
{
    public class Leaderboard
    {
        private Dictionary<uint, Leaders> leaders;

        public Leaderboard()
        {
            this.leaders = App.cache.Get<Dictionary<uint, Leaders>>("leaderboard");
            if (this.leaders == null) this.leaders = new Dictionary<uint, Leaders>();
        }

        private Task AddPageToCache(uint currentPage, Leaders leaders)
        {
            if (!this.leaders.ContainsKey(currentPage)) this.leaders.Add(currentPage, leaders);
            App.cache.Set<Dictionary<uint, Leaders>>("leaderboard", this.leaders);

            return Task.CompletedTask;
        }

        public async Task Cache(uint maxPage)
        {
            for (uint i = 1; i <= maxPage; i++)
            {
                if (this.leaders.ContainsKey(i)) continue;

                Leaders leaders = await WakaTimeRepo.GetLeaders(i);

                // Create thread to set the cache, prevent stuttering
                this.AddPageToCache(i, leaders);
            }
        }

        internal async Task<Leaders> GetPage(uint currentPage)
        {
            if (this.leaders.ContainsKey(currentPage))
            {
                this.leaders.TryGetValue(currentPage, out Leaders value);

                return value;
            }

            Leaders leaders = await WakaTimeRepo.GetLeaders(currentPage);

            // Create thread to set the cache, prevent stuttering
            this.AddPageToCache(currentPage, leaders);

            return leaders;
        }

        internal List<Leader> Search(string search)
        {
            List<Leader> leaders = new List<Leader>();

            foreach (var page in this.leaders.Values)
            {
                List<Leader> filteredUsers = page.Users.FindAll(l => l.User.DisplayName.Contains(search));

                leaders.AddRange(filteredUsers);
            }

            return leaders;
        }
    }
}
