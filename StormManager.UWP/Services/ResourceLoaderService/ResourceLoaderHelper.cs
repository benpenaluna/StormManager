namespace StormManager.UWP.Services.ResourceLoaderService
{
    public class ResourceLoaderHelper : IResourceLoaderHelper
    {
        public string ResourceName { get; }

        private ResourceLoaderHelper(string name)
        {
            ResourceName = RetrieveResource(name);
        }

        public static IResourceLoaderHelper Create(string name, IResourceLoaderHelper helper = null)
        {
            return helper ?? new ResourceLoaderHelper(name);
        }

        private static string RetrieveResource(string name)
        {
            var loader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView();
            return loader.GetString(name);
        }
    }
}
