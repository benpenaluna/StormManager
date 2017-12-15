using System;
using Windows.UI.Xaml;

namespace StormManager.UWP.Services.SettingsServices
{
    public interface ISettingsService
    {
        bool UseShellBackButton { get; set; }
        ApplicationTheme AppTheme { get; set; }
        TimeSpan CacheMaxDuration { get; set; }
        bool ShowHamburgerButton { get; set; }
        bool IsFullScreen { get; set; }
    }
}
