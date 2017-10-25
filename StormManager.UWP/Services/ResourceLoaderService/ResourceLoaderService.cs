using System;

namespace StormManager.UWP.Services.ResourceLoaderService
{
    public sealed class ResourceLoaderService : IResourceLoaderService
    {
        private static readonly Lazy<ResourceLoaderService> UniqueInstance = new Lazy<ResourceLoaderService>(() => new ResourceLoaderService());

        private ResourceLoaderService() { }

        public static ResourceLoaderService Instance => UniqueInstance.Value;

        public string Value(string name)
        {
            var loader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView();
            return loader.GetString(name);
        }
    }
}