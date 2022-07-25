using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evertec.Tips.Mobile.Domain.Enumerations;
using Evertec.Tips.Mobile.Domain.Helpers;
using Evertec.Tips.Mobile.Providers.Toast;
using Evertec.Tips.Mobile.ViewModels.Base;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Prism.Navigation;

namespace Evertec.Tips.Mobile.ViewModels
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _userName;

        private readonly IToastProvider _toastProvider;

        public LoginPageViewModel(INavigationService navigationService, IToastProvider toastProvider) : base(navigationService)
        {
            _toastProvider = toastProvider;
        }

        [ICommand]
        public async Task Login()
        {
            await ShowProgress();

            if (!string.IsNullOrEmpty(UserName) && UserName.Length >= 7)
            {
                CacheProvider.AddItem("username", UserName);
                await RealTimeTipService.Register().ConfigureAwait(false);
                await NavigationService.NavigateAsync(UriNavigationHelper.Tips);
            }
            else
            {
                await _toastProvider.LongTime("");
            }

            ProgressProvider.HideProgress();
        }

    }
}
