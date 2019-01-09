using System;
using Windows.UI.Xaml;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml.Data;
using Autofac;
using StormManager.UWP.Controls;
using StormManager.UWP.Controls.ControlHelpers;
using StormManager.UWP.Converters.ConversionHelpers;
using StormManager.UWP.Models.Mapping;
using StormManager.UWP.Services.MapKeyService;
using StormManager.UWP.Services.SettingsServices;
using StormManager.UWP.Services.WebApiService;

namespace StormManager.UWP
{
    /// Documentation on APIs used in this page:
    /// https://github.com/Windows-XAML/Template10/wiki

    [Bindable]
    sealed partial class App
    {
        public static IContainer Container { get; private set; }

        private static IMapKeyService _mapKeyService;
        public static string MapKey => _mapKeyService.Key;

        private static string _connectionSting = "Server=tcp:stormmanagerserver.database.windows.net,1433;Initial Catalog=StormManager;Persist Security Info=False;User ID=sqladmin;Password=PythoN98*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;App=EntityFramework";

        public static string ConnectionString
        {
            get => _connectionSting;
            set => _connectionSting = value;
        }


        public App()
        {
            InitializeComponent();
            SplashFactory = (e) => new Views.Splash(e);

            #region app settings

            // some settings must be set in app.constructor
            var settings = new AppSettingsService(new SettingsHelper(), new UiUpdater());
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

            //var test = Container.Resolve<Services.SettingsServices.IAppSettingsService>();

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
            builder.RegisterType<AppSettingsService>().As<Services.SettingsServices.IAppSettingsService>();

            builder.RegisterType<ContrastFactorApproximationHelper>().As<IContrastFactorApproximationHelper>();
            builder.RegisterType<MapIconControlHelper>().As<IMapIconControlHelper>();
            builder.RegisterType<ColorAnimationHelper>().As<IColorAnimationHelper>();
            builder.RegisterType<FoundMapLocations>().As<IFoundMapLocations>();

            //builder.RegisterType<WebApiService>().As<IWebApiService>();
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
            _mapKeyService = await MapKeyService.CreateAsync();
            await NavigationService.NavigateAsync(typeof(Views.MainPage));

            await Cache.AppCache.GetMembersAsync();
        }
    }
}

