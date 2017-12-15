using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Moq;
using StormManager.UWP.Services.SettingsServices;
using Xunit;

namespace StormManager.UWP.Tests.Services.SettingsService
{
    public class SettingsServiceTests
    {
        [Fact]
        public void SettingsService_CanCreate()
        {
            var result = UWP.Services.SettingsServices.SettingsService.Create();
            Assert.NotNull(result);
        }

        [Fact]
        public void SettingsService_DefaultUseShellBackButtonReturnsTrue()
        {
            var expected = UWP.Services.SettingsServices.SettingsService.UseShellBackButtonDefault;
            var sut = SettingsServiceWithTestableHelperAndUiUpdater();
            var result = sut.UseShellBackButton;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SettingsService_UseShellBackButtonSetsAndReturnsValue()
        {
            const bool expected = false;

            var sut = SettingsServiceWithTestableHelperAndUiUpdater();
            sut.UseShellBackButton = expected;
            var result = sut.UseShellBackButton;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SettingsService_DefaultAppThemeLight()
        {
            var expected = UWP.Services.SettingsServices.SettingsService.AppThemeDefault;
            var sut = SettingsServiceWithTestableHelperAndUiUpdater();
            var result = sut.AppTheme;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SettingsService_AppThemeSetsAndReturnsValue()
        {
            const ApplicationTheme expected = ApplicationTheme.Dark;

            var sut = SettingsServiceWithTestableHelperAndUiUpdater();
            sut.AppTheme = expected;
            var result = sut.AppTheme;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SettingsService_DefaultCacheMaxDuration()
        {
            var expected = UWP.Services.SettingsServices.SettingsService.CacheMaxDurationDefault;
            var sut = SettingsServiceWithTestableHelperAndUiUpdater();
            var result = sut.CacheMaxDuration;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SettingsService_CacheMaxDurationSetsAndReturnsValue()
        {
            var defaultMaxCacheDuration = UWP.Services.SettingsServices.SettingsService.CacheMaxDurationDefault.Days;
            var days = defaultMaxCacheDuration == int.MaxValue ? defaultMaxCacheDuration - 1 : defaultMaxCacheDuration + 1;
            var expected = TimeSpan.FromDays(days);

            var sut = SettingsServiceWithTestableHelperAndUiUpdater();
            sut.CacheMaxDuration = expected;
            var result = sut.CacheMaxDuration;

            Assert.Equal(expected, result);
        }

        private static ISettingsService SettingsServiceWithTestableHelperAndUiUpdater()
        {
            var settingsHelper = MockSettingsHelper.Create();
            var uiUpdater = MockUiUpdater.Create();
            return UWP.Services.SettingsServices.SettingsService.Create(settingsHelper, uiUpdater);
        }
    }
}
