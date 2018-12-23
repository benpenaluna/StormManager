using System;

namespace StormManager.UWP.Services.SettingsServices
{
    // Source: https://github.com/Windows-XAML/Template10/blob/version_1.1.12/Template10%20(Library)/Services/SettingsService/IPropertyMapping.cs

    public interface IPropertyMapping
    {
        IStoreConverter GetConverter(Type type);
    }
}
