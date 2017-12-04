using Moq;
using StormManager.UWP.Services.MapKeyService;

namespace StormManager.UWP.Tests.Services.MapKeyService
{
    internal class MapKeyHelperMockFactory
    {
        public static Mock<IMapKeyHelper> CreateMockMapKeyHelper(string key)
        {
            var service = new Mock<IMapKeyHelper>();
            service.Setup(x => x.Key).Returns(key);
            return service;
        }
    }
}
