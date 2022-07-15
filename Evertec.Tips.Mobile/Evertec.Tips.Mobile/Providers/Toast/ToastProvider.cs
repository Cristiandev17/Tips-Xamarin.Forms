using System;
using System.Threading.Tasks;
using Acr.UserDialogs;

namespace Evertec.Tips.Mobile.Providers.Toast
{
    public class ToastProvider : IToastProvider
    {
        public Task LongTime(string message)
        {
            return Task.FromResult(UserDialogs.Instance.Toast(message, TimeSpan.FromSeconds(5)));
        }
    }
}
