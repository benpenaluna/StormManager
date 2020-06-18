using Autofac;
using System;
using Windows.UI.Xaml;

namespace StormManager.UWP.Services.SettingsServices
{
    public class AppSettingsService : IAppSettingsService
    {
        public static bool UseShellBackButtonDefault => true;

        public static ApplicationTheme AppThemeDefault => ApplicationTheme.Light;

        public static TimeSpan CacheMaxDurationDefault => TimeSpan.FromDays(2);

        public static bool ShowHamburgerButtonDefault => true;

        public static bool IsFullScreenDefault => false;

        private readonly ISettingsHelper _helper;

        private readonly IUiUpdater _updater;

        public AppSettingsService(ISettingsHelper helper = null, IUiUpdater updater = null)
        {
            _helper = helper ?? App.Container.Resolve<ISettingsHelper>();
            _updater = updater ?? App.Container.Resolve<IUiUpdater>();
        }

        public bool UseShellBackButton
        {
            get => _helper.Read(nameof(UseShellBackButton), UseShellBackButtonDefault);
            set
            {
                _helper.Write(nameof(UseShellBackButton), value);
                _updater.UpdateUseShellBackButton(value);
            }
        }

        public ApplicationTheme AppTheme
        {
            get
            {
                var theme = AppThemeDefault;
                var value = _helper.Read(nameof(AppTheme), theme.ToString());
                return Enum.TryParse(value, out theme) ? theme : ApplicationTheme.Dark;
            }
            set
            {
                _helper.Write(nameof(AppTheme), value.ToString());
                _updater.UpdateAppTheme(value);
            }
        }

        public TimeSpan CacheMaxDuration
        {
            get => _helper.Read(nameof(CacheMaxDuration), CacheMaxDurationDefault);
            set
            {
                _helper.Write(nameof(CacheMaxDuration), value);
                _updater.UpdateCacheMaxDuration(value);
            }
        }

        public bool ShowHamburgerButton
        {
            get => _helper.Read(nameof(ShowHamburgerButton), ShowHamburgerButtonDefault);
            set
            {
                _helper.Write(nameof(ShowHamburgerButton), value);
                _updater.UpdateHamburgerButtonDisplay(value);
            }
        }

        public bool IsFullScreen
        {
            get => _helper.Read(nameof(IsFullScreen), IsFullScreenDefault);
            set
            {
                _helper.Write(nameof(IsFullScreen), value);
                _updater.UpdateFullScreen(value);
            }
        }
    }
}

