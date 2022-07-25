using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MonkeyCache;
using MonkeyCache.FileStore;

namespace Evertec.Tips.Mobile.Providers.Cache
{
    public class CacheProvider : ICacheProvider
    {
        public CacheProvider()
        {
            Barrel.ApplicationId = "Control de Entregas";
        }

        public void AddItem<T>(string key, T data)
        {
            string result = JsonConvert.SerializeObject(data);
            Barrel.Current.Add(key, result, TimeSpan.FromDays(2));
        }

        public void RemoveAll()
        {
            Barrel.Current.EmptyAll();
        }

        public bool Exists(string key)
        {
            if (Barrel.Current.Exists(key) && Barrel.Current.IsExpired(key))
            {
                Barrel.Current.Empty(key);
            }

            return Barrel.Current.Exists(key);
        }

        public T Get<T>(string key)
        {
            return Barrel.Current.Get<T>(key);
        }

        public void Remove(string key)
        {
            Barrel.Current.Empty(key);
        }
    }
}
