using Autofac;
using StormManager.UWP.Controls;
using StormManager.UWP.Services.NavigationService;
using StormManager.UWP.Services.SettingsServices;
using Windows.UI.Xaml;

namespace StormManager.UWP.Views
{
    public sealed partial class Shell
    {
        public static Shell Instance { get; set; }
        public static HamburgerMenu HamburgerMenu => Instance.MyHamburgerMenu;
        readonly IAppSettingsService _appSettings;

        public Shell()
        {
            Instance = this;
            InitializeComponent();
            _appSettings = App.Container.Resolve<IAppSettingsService>();
        }

        public Shell(INavigationService navigationService) : this()
        {
            SetNavigationService(navigationService);
        }

        public void SetNavigationService(INavigationService navigationService)
        {
            MyHamburgerMenu.NavigationService = navigationService;
            HamburgerMenu.RefreshStyles(_appSettings.AppTheme, true);
            HamburgerMenu.IsFullScreen = _appSettings.IsFullScreen;
            HamburgerMenu.HamburgerButtonVisibility = _appSettings.ShowHamburgerButton ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}

