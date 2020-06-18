using StormManager.UWP.Services.ResourceLoaderService;
using Xunit;

namespace StormManager.UWP.Tests.Services.ResourceLoader
{
    public class ResourceLoaderServiceTests
    {
        [Fact]
        public void ResourceLoaderService_CanGetResourceValue()
        {
            const string expected = "Test";
            const string arbitraryInputString = "Arbitrary String";

            var helper = ResourceLoaderHelperMockFactory.CreateMockResourceLoader(expected);
            var result = ResourceLoaderService.GetResourceValue(arbitraryInputString, helper.Object);

            Assert.Equal(expected, result);
        }
    }
}
