using Evertec.Tips.Mobile.Common.Hubs;
using Evertec.Tips.Mobile.Domain.Entities;
using Evertec.Tips.Mobile.Infrastructure.Repositories;
using Evertec.Tips.Mobile.Interfaces;
using Evertec.Tips.Mobile.Providers.Cache;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;
using Evertec.Tips.Mobile.Domain.Dtos;
using Evertec.Tips.Mobile.Infrastructure.Interfaces;

namespace Evertec.Tips.Mobile.Services
{
    public class RealTimeTipService : IRealTimeTipService
    {
        public bool IsConnected => HubConnectionTip.IsConnected;

        public RealTimeTipService()
        {
            try
            {
                var cache = App.Resolve<ICacheProvider>();
                var userName = cache.Get<int>("username");
                HubConnectionTip.Initialize($"https://localhost:7252/TipHub?username={userName}");
            }
            catch (Exception e)
            {
            }
        }

        public Task Connect()
        {
            HubConnectionTip.HubConnection.On<TipDto>("NewTip", AddTip);
            HubConnectionTip.HubConnection.On<int>("DeleteTip", RemoveTip);
            HubConnectionTip.HubConnection.On<TipDto>("UpdateTip", UpdateTip);
            return Task.CompletedTask;
        }

        private async Task UpdateTip(TipDto arg)
        {
            var tipService = App.Resolve<ITipService>();
            await tipService.UpdateTip(arg);
        }

        private async Task RemoveTip(int arg)
        {
            var tipService = App.Resolve<ITipService>();
            await tipService.DeleteTip(arg);
        }

        private async Task AddTip(TipDto arg)
        {
            var tipService = App.Resolve<ITipService>();
            await tipService.AddTip(arg);
        }

        public async Task DisConnect()
        {
            await HubConnectionTip.DisConnect();
        }

        public async Task Register()
        {
            await HubConnectionTip.Register();
        }

        public async Task UnRegister(string userName)
        {
            await HubConnectionTip.UnRegister(userName);
        }
    }
}
