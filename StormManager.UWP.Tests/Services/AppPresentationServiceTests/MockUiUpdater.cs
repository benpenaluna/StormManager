using System;
using Windows.UI.Xaml;
using StormManager.UWP.Services.AppPresentationService;

namespace StormManager.UWP.Tests.Services.AppPresentationServiceTests
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
