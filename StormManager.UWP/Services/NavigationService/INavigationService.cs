﻿using StormManager.UWP.Common;
using StormManager.UWP.Services.ViewService;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace StormManager.UWP.Services.NavigationService
{
    // Source: https://github.com/Windows-XAML/Template10/blob/version_1.1.12/Template10%20(Library)/Services/NavigationService/INavigationService.cs

    public interface INavigationService
    {
        void GoBack(NavigationTransitionInfo infoOverride = null);
        void GoForward();

        object Content { get; }

        void Navigate(Type page, object parameter = null, NavigationTransitionInfo infoOverride = null);
        void Navigate<T>(T key, object parameter = null, NavigationTransitionInfo infoOverride = null) where T : struct, IConvertible;

        Task<bool> NavigateAsync(Type page, object parameter = null, NavigationTransitionInfo infoOverride = null);
        Task<bool> NavigateAsync<T>(T key, object parameter = null, NavigationTransitionInfo infoOverride = null) where T : struct, IConvertible;

        bool CanGoBack { get; }
        bool CanGoForward { get; }

        string NavigationState { get; set; }

        void Refresh();

        void Refresh(object param);



        Task<ViewLifetimeControl> OpenAsync(Type page, object parameter = null, string title = null, ViewSizePreference size = ViewSizePreference.UseHalf);

        object CurrentPageParam { get; }
        Type CurrentPageType { get; }

        DispatcherWrapper Dispatcher { get; }

        [Obsolete]
        Task SaveNavigationAsync();

        [Obsolete]
        Task<bool> RestoreSavedNavigationAsync();

        Task SaveAsync();

        Task<bool> LoadAsync();

        event TypedEventHandler<Type> AfterRestoreSavedNavigation;

        void ClearHistory();
        void ClearCache(bool removeCachedPagesInBackStack = false);

        Task SuspendingAsync();
        void Resuming();

        Frame Frame { get; }
        FrameFacade FrameFacade { get; }

        /// <summary>
        /// Specifies if this instance of INavigationService associated with <see cref="CoreApplication.MainView"/> or any other secondary view.
        /// </summary>
        /// <returns><value>true</value> if associated with MainView, <value>false</value> otherwise</returns>
        bool IsInMainView { get; }
    }
}
