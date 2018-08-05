using System;
using Windows.UI.Xaml;
using StormManager.UWP.Services.AppPresentationService;
using StormManager.UWP.Services.SettingsServices;
using Xunit;

namespace StormManager.UWP.Tests.Services.AppPresentationServiceTests
{
    public class AppPresentationServiceTests
    {
        [Fact]
        public void SettingsService_CanInstantiate()
        {
            var result = new AppPresentationService(new SettingsHelper(), new UiUpdater());
            Assert.NotNull(result);
        }

        //[Fact]
        //public void SettingsService_CanCreate()
        //{
        //    var result = UWP.Services.SettingsServices.AppPresentationService.Create();
        //    Assert.NotNull(result);
        //}

        [Fact]
        public void SettingsService_DefaultUseShellBackButton()
        {
            var expected = AppPresentationService.UseShellBackButtonDefault;
            var sut = SettingsServiceWithTestableHelperAndUiUpdater();
            var result = sut.UseShellBackButton;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SettingsService_UseShellBackButtonSetsAndReturnsValue()
        {
            var expected = !AppPresentationService.UseShellBackButtonDefault;

            var sut = SettingsServiceWithTestableHelperAndUiUpdater();
            sut.UseShellBackButton = expected;
            var result = sut.UseShellBackButton;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SettingsService_DefaultAppThemeLight()
        {
            var expected = AppPresentationService.AppThemeDefault;
            var sut = SettingsServiceWithTestableHelperAndUiUpdater();
            var result = sut.AppTheme;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SettingsService_AppThemeSetsAndReturnsValue()
        {
            var expected = AppPresentationService.AppThemeDefault == ApplicationTheme.Light
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
            var expected = AppPresentationService.CacheMaxDurationDefault;
            var sut = SettingsServiceWithTestableHelperAndUiUpdater();
            var result = sut.CacheMaxDuration;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SettingsService_CacheMaxDurationSetsAndReturnsValue()
        {
            var defaultMaxCacheDuration = AppPresentationService.CacheMaxDurationDefault.Days;
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
            var expected = AppPresentationService.ShowHamburgerButtonDefault;
            var sut = SettingsServiceWithTestableHelperAndUiUpdater();
            var result = sut.ShowHamburgerButton;

            Assert.Equal(expected, result);
        }

        [Fact]
        private void SettingsService_ShowHamburgerButtonSetAndReturnsValue()
        {
            var expected = !AppPresentationService.ShowHamburgerButtonDefault;

            var sut = SettingsServiceWithTestableHelperAndUiUpdater();
            sut.ShowHamburgerButton = expected;
            var result = sut.ShowHamburgerButton;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SettingsService_DefaultIsFullScreen()
        {
            var expected = AppPresentationService.IsFullScreenDefault;
            var sut = SettingsServiceWithTestableHelperAndUiUpdater();
            var result = sut.IsFullScreen;

            Assert.Equal(expected, result);
        }

        [Fact]
        private void SettingsService_IsFullScreenSetAndReturnsValue()
        {
            var expected = !AppPresentationService.IsFullScreenDefault;

            var sut = SettingsServiceWithTestableHelperAndUiUpdater();
            sut.IsFullScreen = expected;
            var result = sut.IsFullScreen;

            Assert.Equal(expected, result);
        }

        private static IAppPresentationService SettingsServiceWithTestableHelperAndUiUpdater()
        {
            var settingsHelper = MockAppPresentationHelper.Create();
            var uiUpdater = MockUiUpdater.Create();
            return new AppPresentationService(settingsHelper, uiUpdater);
        }
    }
}
