using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evertec.Tips.Mobile.Providers.Cache
{
    public interface ICacheProvider
    {
        void AddItem<T>(string key, T data);

        void RemoveAll();

        bool Exists(string key);

        T Get<T>(string key);

        void Remove(string key);
    }
}
