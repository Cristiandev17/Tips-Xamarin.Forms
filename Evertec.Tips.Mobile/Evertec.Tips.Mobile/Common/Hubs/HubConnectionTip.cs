using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evertec.Tips.Mobile.Providers.Cache;
using Microsoft.AspNetCore.SignalR.Client;

namespace Evertec.Tips.Mobile.Common.Hubs
{
    public class HubConnectionTip
    {
        public static HubConnection HubConnection { get; set; }

        public static bool IsConnected => HubConnection.State != HubConnectionState.Disconnected;

        public static void Initialize(string realTimeHub)
        {
            HubConnection = new HubConnectionBuilder()
                  .WithUrl(realTimeHub, options =>
                  {
                      options.SkipNegotiation = true;
                      options.Transports = Microsoft.AspNetCore.Http.Connections.HttpTransportType.WebSockets;
                  })
                  .WithAutomaticReconnect()
                  .Build();

            HubConnection.Closed += async (error) =>
            {
                await Register();
            };

            HubConnection.Reconnecting += async (dd) =>
            {
                await Register();
            };
        }

        public static async Task Connect()
        {
            await HubConnection.StartAsync();
        }

        public static async Task DisConnect()
        {
            await HubConnection.StopAsync();
        }

        public static async Task Register()
        {
            var cache = App.Resolve<ICacheProvider>();
            var userName = cache.Get<int>("username");
            int retries = 0;
            while (retries < 5 && retries != -1)
            {
                if (!IsConnected)
                    await Connect();

                if (IsConnected)
                {
                    await HubConnection.InvokeAsync("RegisterToHub", userName);
                    retries = -1;
                }
                else
                {
                    retries++;
                    await Task.Delay(1000);
                }
            }
        }

        public static async Task UnRegister(string userName)
        {
            int retries = 0;
            while (retries < 5 && retries != -1)
            {
                if (!IsConnected)
                    await Connect();

                if (IsConnected)
                {
                    await HubConnection.InvokeAsync("UnRegisterToHub", userName);
                    await DisConnect();
                    retries = -1;
                }
                else
                {
                    retries++;
                    await Task.Delay(1000);
                }
            }
        }
    }
}
