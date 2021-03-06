﻿using System;
using System.Threading.Tasks;

namespace StormManager.UWP.Common
{
    // Source: https://github.com/Windows-XAML/Template10/blob/version_1.1.12/Template10%20(Library)/Common/IDispatcherWrapper.cs

    using Windows.UI.Core;

    public interface IDispatcherWrapper
    {
        void Dispatch(Action action, int delayms = 0, CoreDispatcherPriority priority = CoreDispatcherPriority.Normal);
        Task DispatchAsync(Func<Task> func, int delayms = 0, CoreDispatcherPriority priority = CoreDispatcherPriority.Normal);
        Task DispatchAsync(Action action, int delayms = 0, CoreDispatcherPriority priority = CoreDispatcherPriority.Normal);
        Task<T> DispatchAsync<T>(Func<T> func, int delayms = 0, CoreDispatcherPriority priority = CoreDispatcherPriority.Normal);

        void DispatchIdle(Action action, int delayms = 0);
        Task DispatchIdleAsync(Func<Task> func, int delayms = 0);
        Task DispatchIdleAsync(Action action, int delayms = 0);
        Task<T> DispatchIdleAsync<T>(Func<T> func, int delayms = 0);

        bool HasThreadAccess();
    }
}
