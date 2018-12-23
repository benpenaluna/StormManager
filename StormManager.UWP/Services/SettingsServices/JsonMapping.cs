using System;

namespace StormManager.UWP.Services.SettingsServices
{
    public class JsonMapping : IPropertyMapping
    {
        protected IStoreConverter jsonConverter = new JsonConverter();
        public IStoreConverter GetConverter(Type type) => this.jsonConverter;
    }
}
