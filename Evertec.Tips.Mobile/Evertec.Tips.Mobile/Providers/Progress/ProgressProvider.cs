using Acr.UserDialogs;

namespace Evertec.Tips.Mobile.Providers.Progress
{
    public class ProgressProvider : IProgressProvider
    {
        public void ShowProgress(string message)
        {
            UserDialogs.Instance.ShowLoading(message);
        }

        public void HideProgress()
        {
            UserDialogs.Instance.HideLoading();
        }
    }
}
