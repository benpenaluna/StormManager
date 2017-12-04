using System;
using Template10.Common;
using Template10.Utils;
using Windows.UI.Xaml;
using Template10.Services.SettingsService;

namespace StormManager.UWP.Services.SettingsServices
{
    public class SettingsService
    {
        public static SettingsService Create { get; } = new SettingsService();

        //public static SettingsService Create(ISettingsHelper settings = null)
        //{
        //    return new SettingsService(settings);
        //}

        readonly ISettingsHelper _helper;

        //private SettingsService(ISettingsHelper settings = null)
        private SettingsService()
        {
            //_helper = settings ?? new SettingsHelper();
            _helper = new SettingsHelper();
        }

        public bool UseShellBackButton
        {
            get => _helper.Read(nameof(UseShellBackButton), true);
            set
            {
                _helper.Write(nameof(UseShellBackButton), value);
                BootStrapper.Current.NavigationService.GetDispatcherWrapper().Dispatch(() =>
                {
                    BootStrapper.Current.ShowShellBackButton = value;
                    BootStrapper.Current.UpdateShellBackButton();
                });
            }
        }

        public ApplicationTheme AppTheme
        {
            get
            {
                var theme = ApplicationTheme.Light;
                var value = _helper.Read(nameof(AppTheme), theme.ToString());
                return Enum.TryParse(value, out theme) ? theme : ApplicationTheme.Dark;
            }
            set
            {
                _helper.Write(nameof(AppTheme), value.ToString());
                ((FrameworkElement) Window.Current.Content).RequestedTheme = value.ToElementTheme();
                Views.Shell.HamburgerMenu.RefreshStyles(value, true);
            }
        }

        public TimeSpan CacheMaxDuration
        {
            get => _helper.Read(nameof(CacheMaxDuration), TimeSpan.FromDays(2));
            set
            {
                _helper.Write(nameof(CacheMaxDuration), value);
                BootStrapper.Current.CacheMaxDuration = value;
            }
        }

        public bool ShowHamburgerButton
        {
            get => _helper.Read(nameof(ShowHamburgerButton), true);
            set
            {
                _helper.Write(nameof(ShowHamburgerButton), value);
                Views.Shell.HamburgerMenu.HamburgerButtonVisibility = value ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public bool IsFullScreen
        {
            get => _helper.Read(nameof(IsFullScreen), false);
            set
            {
                _helper.Write(nameof(IsFullScreen), value);
                Views.Shell.HamburgerMenu.IsFullScreen = value;
            }
        }
    }
}

