using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Template10.Common;
using Template10.Utils;

namespace StormManager.UWP.Services.SettingsServices
{
    public class UiUpdater : IUiUpdater
    {
        public static IUiUpdater Create()
        {
            return new UiUpdater();
        }

        private UiUpdater() { }

        public void UpdateUseShellBackButton(bool value)
        {
            BootStrapper.Current.NavigationService.GetDispatcherWrapper().Dispatch(() =>
            {
                BootStrapper.Current.ShowShellBackButton = value;
                BootStrapper.Current.UpdateShellBackButton();
            });
        }

        public void UpdateAppTheme(ApplicationTheme appTheme)
        {
            ((FrameworkElement)Window.Current.Content).RequestedTheme = appTheme.ToElementTheme();
            Views.Shell.HamburgerMenu.RefreshStyles(appTheme, true);
        }

        public void UpdateCacheMaxDuration(TimeSpan value)
        {
            BootStrapper.Current.CacheMaxDuration = value;
        }
    }
}
