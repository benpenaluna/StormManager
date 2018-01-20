using Template10.Controls;
using Template10.Services.NavigationService;
using Windows.UI.Xaml;
using Autofac;
using StormManager.UWP.Services.SettingsServices;

namespace StormManager.UWP.Views
{
    public sealed partial class Shell
    {
        public static Shell Instance { get; set; }
        public static HamburgerMenu HamburgerMenu => Instance.MyHamburgerMenu;
        readonly ISettingsService _settings;

        public Shell()
        {
            Instance = this;
            InitializeComponent();
            _settings = App.Container.Resolve<ISettingsService>();
        }

        public Shell(INavigationService navigationService) : this()
        {
            SetNavigationService(navigationService);
        }

        public void SetNavigationService(INavigationService navigationService)
        {
            MyHamburgerMenu.NavigationService = navigationService;
            HamburgerMenu.RefreshStyles(_settings.AppTheme, true);
            HamburgerMenu.IsFullScreen = _settings.IsFullScreen;
            HamburgerMenu.HamburgerButtonVisibility = _settings.ShowHamburgerButton ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}

