﻿namespace StormManager.UWP.Services.SettingsServices
{
    // Source: https://github.com/Windows-XAML/Template10/blob/version_1.1.12/Template10%20(Library)/Services/SettingsService/ISettingsService.cs

    using Windows.Foundation.Collections;

    public interface ISettingsService
    {
        IPropertyMapping Converters { get; set; }
        IPropertySet Values { get; }
        bool Exists(string key);
        T Read<T>(string key, T fallback = default(T));
        void Remove(string key);
        void Write<T>(string key, T value);
        ISettingsService Open(string folderName, bool createFolderIsNotExists = true);
        void Clear(bool deleteSubContainers = true);
    }
}
