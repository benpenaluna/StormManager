using Windows.UI.Xaml;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Template10.Controls;
using Windows.UI.Xaml.Data;
using Autofac;
using StormManager.UWP.Converters.ConversionHelpers;
using StormManager.UWP.Services.LocationService;
using StormManager.UWP.Services.MapKeyService;
using StormManager.UWP.Services.ResourceLoaderService;
using StormManager.UWP.Services.SettingsServices;
using Template10.Services.SettingsService;
using SettingsService = StormManager.UWP.Services.SettingsServices.SettingsService;

namespace StormManager.UWP
{
    /// Documentation on APIs used in this page:
    /// https://github.com/Windows-XAML/Template10/wiki

    [Bindable]
    sealed partial class App
    {
        public static IContainer Container { get; private set; }

        public App()
        {
            InitializeComponent();
            SplashFactory = (e) => new Views.Splash(e);

            #region app settings

            // some settings must be set in app.constructor
            var settings = new SettingsService(new SettingsHelper(), new UiUpdater());
            RequestedTheme = settings.AppTheme;
            CacheMaxDuration = settings.CacheMaxDuration;
            ShowShellBackButton = settings.UseShellBackButton;
            AutoSuspendAllFrames = true;
            AutoRestoreAfterTerminated = true;
            AutoExtendExecutionSession = true;

            #endregion
        }

        public override Task OnInitializeAsync(IActivatedEventArgs args)
        {
            var builder = new ContainerBuilder();

            RegisterServices(builder);

            Container = builder.Build();

            //var test = Container.Resolve<Services.SettingsServices.ISettingsService>();

            return Task.FromResult<object>(null);
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            //builder.RegisterType<LocationService>().As<ILocationService>();
            //builder.RegisterType<LocationHelper>().As<ILocationHelper>();
            //builder.RegisterType<MapKeyHelper>().As<IMapKeyHelper>();
            //builder.RegisterType<MapKeyService>().As<IMapKeyService>();
            //builder.RegisterType<ResourceLoaderHelper>().As<IResourceLoaderHelper>();
            //builder.RegisterType<ResourceLoaderService>().AsSelf();
            builder.RegisterType<SettingsHelper>().As<ISettingsHelper>();
            builder.RegisterType<UiUpdater>().As<IUiUpdater>();
            builder.RegisterType<SettingsService>().As<Services.SettingsServices.ISettingsService>();

            builder.RegisterType<ContrastFactorApproximationHelper>().As<IContrastFactorApproximationHelper>();
        }

        public override UIElement CreateRootElement(IActivatedEventArgs e)
        {
            var service = NavigationServiceFactory(BackButton.Attach, ExistingContent.Exclude);
            return new ModalDialog
            {
                DisableBackButtonWhenModal = true,
                Content = new Views.Shell(service),
                ModalContent = new Views.Busy(),
            };
        }

        public override async Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            // TODO: add your long-running task here
            await NavigationService.NavigateAsync(typeof(Views.MainPage));
        }
    }
}

