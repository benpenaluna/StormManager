using System;
using Template10.Common;
using Template10.Utils;
using Windows.UI.Xaml;
using Autofac;
using Template10.Services.SettingsService;

namespace StormManager.UWP.Services.SettingsServices
{
    public class SettingsService : ISettingsService
    {
        public static bool UseShellBackButtonDefault => true;

        public static ApplicationTheme AppThemeDefault => ApplicationTheme.Light;

        public static TimeSpan CacheMaxDurationDefault => TimeSpan.FromDays(2);

        public static bool ShowHamburgerButtonDefault => true;

        public static bool IsFullScreenDefault => false;

        //public static ISettingsService Create(ISettingsHelper helper = null, IUiUpdater updater = null)
        //{
        //    return new SettingsService(helper, updater);
        //}

        private readonly ISettingsHelper _helper;

        private readonly IUiUpdater _updater;

        //public SettingsService(ISettingsHelper helper = null, IUiUpdater updater = null)
        //{
        //    _helper = helper ?? new SettingsHelper();
        //    _updater = updater ?? UiUpdater.Create();
        //}

        public SettingsService(ISettingsHelper helper = null, IUiUpdater updater = null)
        {
            _helper = helper ?? App.Container.Resolve<ISettingsHelper>();
            _updater = updater ?? App.Container.Resolve<IUiUpdater>();
            //_helper = helper ?? new SettingsHelper();
            //_updater = updater ?? UiUpdater.Create();
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

