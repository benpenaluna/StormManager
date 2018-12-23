using System;

namespace StormManager.UWP.Services.SettingsServices
{
    using Newtonsoft.Json;
    
    public class JsonConverter : IStoreConverter
    {
        public object FromStore(string value, Type type) => JsonConvert.DeserializeObject(value, type);
        public string ToStore(object value, Type type) => JsonConvert.SerializeObject(value, Formatting.None);
    }
}
