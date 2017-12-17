using System;
using Windows.UI.Xaml;

namespace StormManager.UWP.Services.SettingsServices
{
    public interface IUiUpdater
    {
        void UpdateUseShellBackButton(bool value);

        void UpdateAppTheme(ApplicationTheme appTheme);

        void UpdateCacheMaxDuration(TimeSpan value);

        void UpdateHamburgerButtonDisplay(bool value);

        void UpdateFullScreen(bool value);
    }
}
