using System;

namespace StormManager.UWP.Services.SettingsServices
{
    public interface IPropertyMapping
    {
        IStoreConverter GetConverter(Type type);
    }
}
