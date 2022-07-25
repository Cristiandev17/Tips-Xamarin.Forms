using System.Threading.Tasks;

namespace Evertec.Tips.Mobile.Interfaces
{
    public interface IRealTimeTipService
    {
        bool IsConnected { get; }

        Task Connect();

        Task DisConnect();

        Task Register();

        Task UnRegister(string userName);
    }
}
