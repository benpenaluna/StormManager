using Moq;
using StormManager.UWP.Services.ServerKeyService;

namespace StormManager.UWP.Tests.Services.ServerKeyService
{
    internal class ServerKeyHelperMockFactory
    {
        public static Mock<IServerKeyHelper> CreateMockServerKeyHelper(string userId, string password)
        {
            var service = new Mock<IServerKeyHelper>();
            service.Setup(x => x.UserId).Returns(userId);
            service.Setup(x => x.Password).Returns(password);
            return service;
        }
    }
}
