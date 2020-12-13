using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace EindProject.Models
{
    public class CacheProvider
    {
        List<string> keys = new List<string>();
        private IMemoryCache cache;

        public CacheProvider()
        {
            this.cache = new MemoryCache(new MemoryCacheOptions { });
        }

        internal T Get<T>(string key)
        {
            if (this.cache.TryGetValue(key, out T value))
                return value;
            else
                return default(T);
        }

        internal void Remove(string key)
        {
            this.keys.Remove(key);
            this.cache.Remove(key);
        }

        internal void RemoveAll()
        {
            foreach (string item in this.keys)
            {
                this.cache.Remove(item);
            }
            this.keys.Clear();
        }

        internal void Set<T>(string key, T value)
        {
            DateTimeOffset expiry = DateTimeOffset.Now.AddMinutes(30);

            this.keys.Add(key);
            this.cache.Set(key, value, expiry);
        }
    }
}
