﻿using StormManager.UWP.Common;
using StormManager.UWP.Utils;
using System;
using Windows.UI.Xaml;

namespace StormManager.UWP.Services.SettingsServices
{
    public class UiUpdater : IUiUpdater
    {
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

        public void UpdateHamburgerButtonDisplay(bool value)
        {
            Views.Shell.HamburgerMenu.HamburgerButtonVisibility = value ? Visibility.Visible : Visibility.Collapsed;
        }

        public void UpdateFullScreen(bool value)
        {
            Views.Shell.HamburgerMenu.IsFullScreen = value;
        }
    }
}
