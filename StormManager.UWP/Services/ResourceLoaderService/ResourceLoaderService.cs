using System;

namespace StormManager.UWP.Services.ResourceLoaderService
{
    public sealed class ResourceLoaderService
    {
        private static readonly Lazy<ResourceLoaderService> UniqueInstance = new Lazy<ResourceLoaderService>(() => new ResourceLoaderService());

        private IResourceLoaderHelper Helper { get; set; }

        private ResourceLoaderService() { }

        public static string GetResourceValue(string name, IResourceLoaderHelper helper = null)
        {
            var resourceLoaderService = UniqueInstance.Value;
            resourceLoaderService.Helper = helper ?? ResourceLoaderHelper.Create(name);
            return resourceLoaderService.Helper.ResourceName;
        }
    }
}