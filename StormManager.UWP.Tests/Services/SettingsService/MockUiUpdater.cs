using StormManager.UWP.Services.SettingsServices;
using System;
using Windows.UI.Xaml;

namespace StormManager.UWP.Tests.Services.SettingsService
{
    internal class MockUiUpdater : IUiUpdater
    {
        public static IUiUpdater Create() { return new MockUiUpdater(); }

        private MockUiUpdater() { }

        public void UpdateUseShellBackButton(bool value) { }

        public void UpdateAppTheme(ApplicationTheme appTheme) { }

        public void UpdateCacheMaxDuration(TimeSpan value) { }

        public void UpdateHamburgerButtonDisplay(bool value) { }

        public void UpdateFullScreen(bool value) { }
    }
}
