using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StormManager.UWP.Services.ResourceLoaderService
{
    public static class ResourceLoaderService
    {
        public static string GetResourceValue(string name)
        {
            var loader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView();
            return loader.GetString(name);
        }
    }
}
