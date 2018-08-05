using System;

namespace StormManager.UWP.Services.SettingsServices
{
    public interface IStoreConverter
    {
        string ToStore(object value, Type type);
        object FromStore(string value, Type type);
    }
}
