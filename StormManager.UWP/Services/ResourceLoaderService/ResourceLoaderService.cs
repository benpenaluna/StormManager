using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StormManager.UWP.Services.ResourceLoaderService
{
    public sealed class ResourceLoaderService : IResourceLoaderService
    {
        private static readonly Lazy<ResourceLoaderService> uniqueInstance = new Lazy<ResourceLoaderService>(() => new ResourceLoaderService());

        private ResourceLoaderService() { }

        public static ResourceLoaderService Instance => uniqueInstance.Value;

        public string Value(string name)
        {
            var loader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView();
            return loader.GetString(name);
        }
    }
}