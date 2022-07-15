using Evertec.Tips.Mobile.Domain.Helpers;
using Evertec.Tips.Mobile.Infrastructure.Interfaces;
using Evertec.Tips.Mobile.Infrastructure.Providers;
using Evertec.Tips.Mobile.Infrastructure.Repositories;
using Evertec.Tips.Mobile.Interfaces;
using Evertec.Tips.Mobile.Providers.Dialog;
using Evertec.Tips.Mobile.Providers.Progress;
using Evertec.Tips.Mobile.Providers.Toast;
using Evertec.Tips.Mobile.Services;
using Evertec.Tips.Mobile.ViewModels;
using Evertec.Tips.Mobile.Views;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace Evertec.Tips.Mobile
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync(UriNavigationHelper.Tips);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Core
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterForNavigation<NavigationPage>();

            //Services
            containerRegistry.Register<ITipService, TipService>();
            containerRegistry.Register<IAuthorService, AuthorService>();

            //Providers
            containerRegistry.Register<IDialogProvider, DialogProvider>();
            containerRegistry.Register<IProgressProvider, ProgressProvider>();
            containerRegistry.Register<IToastProvider, ToastProvider>();
            containerRegistry.Register<IDatabaseContextProvider, DatabaseContextProvider>();

            //Repositories
            containerRegistry.Register<ITipRepository, TipRepository>();
            containerRegistry.Register<IAuthorRepository, AuthorRepository>();

            //Views
            containerRegistry.RegisterForNavigation<TipsPage, TipsPageViewModel>();
            containerRegistry.RegisterForNavigation<AddTipPage, AddTipPageViewModel>();
            containerRegistry.RegisterForNavigation<DetailTipPage, DetailTipPageViewModel>();
        }

        public static T Resolve<T>()
        {
            return ((PrismApplication)App.Current).Container.Resolve<T>();
        }
    }
}
