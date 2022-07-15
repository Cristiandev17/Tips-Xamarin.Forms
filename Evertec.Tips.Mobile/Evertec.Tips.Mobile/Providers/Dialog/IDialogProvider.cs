using Prism.Services;
using System.Threading.Tasks;

namespace Evertec.Tips.Mobile.Providers.Dialog
{
    public interface IDialogProvider
    {
        Task DisplayAlertAsync(string title, string message);

        Task<bool> DisplayAlertAsync(string title, string message, string acceptButton, string cancelButton);

        Task<string> DisplayActionSheetAsync(string title, string cancelButton, string destroyButton, params string[] otherButtons);

        Task DisplayActionSheetAsync(string title, params IActionSheetButton[] buttons);
    }
}
