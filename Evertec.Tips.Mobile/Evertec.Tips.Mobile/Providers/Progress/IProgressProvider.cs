namespace Evertec.Tips.Mobile.Providers.Progress
{
    public interface IProgressProvider
    {
        void ShowProgress(string message);

        void HideProgress();
    }
}
