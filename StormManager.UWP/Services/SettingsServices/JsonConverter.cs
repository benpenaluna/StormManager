using System;

namespace StormManager.UWP.Services.SettingsServices
{
    // Source: https://github.com/Windows-XAML/Template10/blob/version_1.1.12/Template10%20(Library)/Services/SettingsService/JsonConverter.cs

    using Newtonsoft.Json;

    public class JsonConverter : IStoreConverter
    {
        public object FromStore(string value, Type type) => JsonConvert.DeserializeObject(value, type);
        public string ToStore(object value, Type type) => JsonConvert.SerializeObject(value, Formatting.None);
    }
}
