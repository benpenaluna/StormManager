using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using StormManager.UWP.Services.SettingsServices;

namespace StormManager.UWP.Tests.Services.SettingsService
{
    internal class MockUiUpdater : IUiUpdater
    {
        public static IUiUpdater Create()
        {
            return new MockUiUpdater();
        }

        private MockUiUpdater() { }

        public void UpdateUseShellBackButton(bool value) { }

        public void UpdateAppTheme(ApplicationTheme appTheme) { }

        public void UpdateCacheMaxDuration(TimeSpan value) { }
    }
}
