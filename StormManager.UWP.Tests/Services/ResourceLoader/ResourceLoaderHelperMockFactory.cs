using Moq;
using StormManager.UWP.Services.ResourceLoaderService;

namespace StormManager.UWP.Tests.Services.ResourceLoader
{
    internal static class ResourceLoaderHelperMockFactory
    {
        public static Mock<IResourceLoaderHelper> CreateMockResourceLoader(string returnString)
        {
            var helper = new Mock<IResourceLoaderHelper>();
            helper.Setup(x => x.ResourceName).Returns(returnString);
            return helper;
        }
    }
}
