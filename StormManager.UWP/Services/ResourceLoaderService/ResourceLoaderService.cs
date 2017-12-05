using System;

namespace StormManager.UWP.Services.ResourceLoaderService
{
    public sealed class ResourceLoaderService : IResourceLoaderService
    {
        private static readonly Lazy<ResourceLoaderService> UniqueInstance = new Lazy<ResourceLoaderService>(() => new ResourceLoaderService());

        private ResourceLoaderService() { }

        public static string GetResourceValue(string name)
        {
            IResourceLoaderService resource = UniqueInstance.Value;
            return resource.RetrieveResource(name);
        }

        public string RetrieveResource(string name)
        {
            var loader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView();
            return loader.GetString(name);
        }
    }
}