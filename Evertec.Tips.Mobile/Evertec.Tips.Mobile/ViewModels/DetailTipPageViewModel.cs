using Evertec.Tips.Mobile.Domain.Enumerations;
using Evertec.Tips.Mobile.Domain.Helpers;
using Evertec.Tips.Mobile.Domain.Models;
using Evertec.Tips.Mobile.ViewModels.Base;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Prism.Navigation;
using System.Linq;
using System.Threading.Tasks;

namespace Evertec.Tips.Mobile.ViewModels
{
    public partial class DetailTipPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private TipModel _tip;

        [ObservableProperty]
        private AuthorModel _author;

        public DetailTipPageViewModel(INavigationService navigationService) : base(navigationService) { }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            Authors = await AuthorService.GetAll();
            if (parameters.Any())
            {
                Tip = parameters.GetValue<TipModel>(NavigationParametersHelper.DetailTip);
                Author = Authors.FirstOrDefault(a => a.Id == Tip.AuthorId);
            }
        }

        [ICommand]
        public async Task EditTip()
        {
            await ShowProgress();
            await NavigationService.NavigateAsync(UriNavigationHelper.EditTip, new NavigationParameters { { NavigationParametersHelper.EditTip, Tip }, { NavigationParametersHelper.Action, Actions.Edit } });
            ProgressProvider.HideProgress();
        }
    }
}
