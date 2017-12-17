using System;
using Windows.UI.Xaml;
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
        public void SettingsService_DefaultUseShellBackButton()
        {
            var expected = UWP.Services.SettingsServices.SettingsService.UseShellBackButtonDefault;
            var sut = SettingsServiceWithTestableHelperAndUiUpdater();
            var result = sut.UseShellBackButton;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SettingsService_UseShellBackButtonSetsAndReturnsValue()
        {
            var expected = !UWP.Services.SettingsServices.SettingsService.UseShellBackButtonDefault;

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
            var expected = UWP.Services.SettingsServices.SettingsService.AppThemeDefault == ApplicationTheme.Light
                ? ApplicationTheme.Dark
                : ApplicationTheme.Light;

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

        [Fact]
        public void SettingsService_DefaultShowHamburgerButton()
        {
            var expected = UWP.Services.SettingsServices.SettingsService.ShowHamburgerButtonDefault;
            var sut = SettingsServiceWithTestableHelperAndUiUpdater();
            var result = sut.ShowHamburgerButton;

            Assert.Equal(expected, result);
        }

        [Fact]
        private void SettingsService_ShowHamburgerButtonSetAndReturnsValue()
        {
            var expected = !UWP.Services.SettingsServices.SettingsService.ShowHamburgerButtonDefault;

            var sut = SettingsServiceWithTestableHelperAndUiUpdater();
            sut.ShowHamburgerButton = expected;
            var result = sut.ShowHamburgerButton;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SettingsService_DefaultIsFullScreen()
        {
            var expected = UWP.Services.SettingsServices.SettingsService.IsFullScreenDefault;
            var sut = SettingsServiceWithTestableHelperAndUiUpdater();
            var result = sut.IsFullScreen;

            Assert.Equal(expected, result);
        }

        [Fact]
        private void SettingsService_IsFullScreenSetAndReturnsValue()
        {
            var expected = !UWP.Services.SettingsServices.SettingsService.IsFullScreenDefault;

            var sut = SettingsServiceWithTestableHelperAndUiUpdater();
            sut.IsFullScreen = expected;
            var result = sut.IsFullScreen;

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
