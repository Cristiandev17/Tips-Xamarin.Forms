using System.Threading.Tasks;

namespace Evertec.Tips.Mobile.Providers.Toast
{
    public interface IToastProvider
    {
        Task LongTime(string message);
    }
}
