using StormManager.UWP.Services.ResourceLoaderService;
using Xunit;

namespace StormManager.UWP.Tests.Services.ResourceLoader
{
    public class ResourceLoaderHelperTests
    {
        [Fact]
        public void ResourceLoaderHelper_CanCreate()
        {
            const string expected = "Test";
            const string arbitaryInputString = "Arbitary String";

            var helper = ResourceLoaderHelperMockFactory.CreateMockResourceLoader(expected);
            var result = ResourceLoaderHelper.Create(arbitaryInputString, helper.Object);

            Assert.NotNull(result);
        }

        [Fact]
        public void ResourceLoaderHelper_CanRetrieveResourceNameAfterCreation()
        {
            const string expected = "Test";
            const string arbitaryInputString = "Arbitary String";

            var helper = ResourceLoaderHelperMockFactory.CreateMockResourceLoader(expected);
            var sut = ResourceLoaderHelper.Create(arbitaryInputString, helper.Object);
            var result = sut.ResourceName;

            Assert.Equal(expected, result);
        }
    }
}
