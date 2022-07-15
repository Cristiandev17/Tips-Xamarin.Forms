using Evertec.Tips.Mobile.Domain.Enumerations;
using Evertec.Tips.Mobile.Domain.Helpers;
using Evertec.Tips.Mobile.Domain.Models;
using Evertec.Tips.Mobile.Helpers;
using Evertec.Tips.Mobile.ViewModels.Base;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Evertec.Tips.Mobile.Providers.Toast;

namespace Evertec.Tips.Mobile.ViewModels
{
    public partial class TipsPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<TipModel> _tips = new ObservableCollection<TipModel>();

        [ObservableProperty]
        private bool _isRefreshing;

        [ObservableProperty]
        private bool _isThereTips;

        private IToastProvider _toastProvider;

        public TipsPageViewModel(INavigationService navigationService, IToastProvider toastProvider) : base(navigationService)
        {
            _toastProvider = toastProvider;
        }

        [ICommand]
        public async Task RefreshTips()
        {
            Tips = await TipService.GetAll();
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            await ShowProgress();
            await CreateAuthors();
            await RefreshView();
            ProgressProvider.HideProgress();
        }

        private async Task RefreshView()
        {
            await RefreshTips();
            if (Tips != null) IsThereTips = Tips.Any() ? true : false;
        }

        [ICommand]
        public async Task DeleteTip(TipModel item)
        {
            await ShowProgress();
            var response = await DialogProvider.DisplayAlertAsync(TextFieldHelper.Get("strWarning"), TextFieldHelper.Get("strMessageDeleteTip"),
                TextFieldHelper.Get("strDelete"), TextFieldHelper.Get("strCancel"));
            if (response)
            {
                var tip = Tips.FirstOrDefault(t => t.Id == item.Id);
                if (tip != null)
                {
                    var result = await TipService.DeleteTip(tip.Id);
                    if (result)
                    {
                        Tips.Remove(tip);
                        await _toastProvider.LongTime(TextFieldHelper.Get("strSuccessDeleteTip"));
                    }
                    else
                        await _toastProvider.LongTime(TextFieldHelper.Get("strError"));
                }
            }
            await RefreshView();
            ProgressProvider.HideProgress();
        }

        [ICommand]
        public async Task DetailTip(TipModel item)
        {
            await ShowProgress();
            await NavigationService.NavigateAsync(UriNavigationHelper.DetailTip, new NavigationParameters { { NavigationParametersHelper.DetailTip, item } });
            ProgressProvider.HideProgress();
        }

        [ICommand]
        public async Task CreateTip()
        {
            await ShowProgress();
            await NavigationService.NavigateAsync(UriNavigationHelper.AddTip, new NavigationParameters { { NavigationParametersHelper.Action, Actions.New } });
            ProgressProvider.HideProgress();
        }
    }
}
