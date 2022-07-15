using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evertec.Tips.Mobile.Domain.Models;
using Evertec.Tips.Mobile.Helpers;
using Evertec.Tips.Mobile.Interfaces;
using Evertec.Tips.Mobile.Providers.Dialog;
using Evertec.Tips.Mobile.Providers.Progress;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Prism.Navigation;

namespace Evertec.Tips.Mobile.ViewModels.Base
{
    public partial class BaseViewModel : ObservableObject, IInitialize, INavigationAware, IDestructible
    {
        [ObservableProperty]
        private string _title;

        [ObservableProperty]
        private List<AuthorModel> _authors;

        protected INavigationService NavigationService;
        protected ITipService TipService;
        protected IAuthorService AuthorService;

        protected readonly IDialogProvider DialogProvider;
        protected readonly IProgressProvider ProgressProvider;

        public BaseViewModel(INavigationService navigationService)
        {
            this.NavigationService = navigationService;
            this.TipService = App.Resolve<ITipService>();
            this.DialogProvider = App.Resolve<IDialogProvider>();
            this.ProgressProvider = App.Resolve<IProgressProvider>();
            this.AuthorService = App.Resolve<IAuthorService>();
        }

        protected async Task ShowProgress()
        {
            ProgressProvider.ShowProgress(TextFieldHelper.Get("strLoading"));
            await Task.Delay(1500);
        }

        protected async Task CreateAuthors()
        {
            Authors = await AuthorService.GetAll();
            if (!Authors.Any())
            {
                var one = AuthorService.AddAuthor(new AuthorModel
                {
                    Name = "Juan Ortega",
                });
                var two = AuthorService.AddAuthor(new AuthorModel
                {
                    Name = "Juan Alvarez",
                });
                var three = AuthorService.AddAuthor(new AuthorModel
                {
                    Name = "Juan Osorio",
                });
                var four = AuthorService.AddAuthor(new AuthorModel
                {
                    Name = "Juan Garcia",
                });
                await Task.WhenAll(one, two, three, four);
            }
        }

        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }
    }
}
