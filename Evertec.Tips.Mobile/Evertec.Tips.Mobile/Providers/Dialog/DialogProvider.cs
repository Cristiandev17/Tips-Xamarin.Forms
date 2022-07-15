using System.Threading.Tasks;
using Prism.Services;

namespace Evertec.Tips.Mobile.Providers.Dialog
{
    public class DialogProvider : IDialogProvider
    {
        IPageDialogService pageDialogService;

        public DialogProvider(IPageDialogService pageDialogService)
        {
            this.pageDialogService = pageDialogService;
        }

        public async Task<string> DisplayActionSheetAsync(string title, string cancelButton, string destroyButton, params string[] otherButtons)
        {
            return await pageDialogService.DisplayActionSheetAsync(title, cancelButton, destroyButton, otherButtons);
        }

        public async Task DisplayActionSheetAsync(string title, params IActionSheetButton[] buttons)
        {
            await pageDialogService.DisplayActionSheetAsync(title, buttons);
        }

        public async Task DisplayAlertAsync(string title, string message)
        {
            await pageDialogService.DisplayAlertAsync(title, message, "Ok");
        }

        public async Task<bool> DisplayAlertAsync(string title, string message, string acceptButton, string cancelButton)
        {
            return await pageDialogService.DisplayAlertAsync(title, message, acceptButton, cancelButton);
        }
    }
}
