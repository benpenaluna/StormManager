using StormManager.UWP.Tests.Common.ExtensionMethods;
using System.Threading.Tasks;
using Xunit;

namespace StormManager.UWP.Tests.Services.ServerKeyService
{
    public class ServerKeyServiceTests
    {
        private const int ArbitraryUserIdSeed = 65223115;
        private const int ArbitraryPasswordSeed = 9467291;

        [Fact]
        public async Task ServerKeyService_CanCreateAsynchronously()
        {
            var randomUserId = CreateArbitraryUserId();
            var randomPassword = CreateArbitraryPassword();
            var service = ServerKeyHelperMockFactory.CreateMockServerKeyHelper(randomUserId, randomPassword);
            var result = await UWP.Services.ServerKeyService.ServerKeyService.CreateAsync(service.Object);

            Assert.NotNull(result);
        }

        [Fact]
        public async void MayKeyService_CanDetermineUserIdFollowingConstruction()
        {
            var randomUserId = CreateArbitraryUserId();
            var randomPassword = CreateArbitraryPassword();
            var service = ServerKeyHelperMockFactory.CreateMockServerKeyHelper(randomUserId, randomPassword);
            var sut = await UWP.Services.ServerKeyService.ServerKeyService.CreateAsync(service.Object);

            var expected = randomUserId;
            var result = sut.UserId;

            Assert.Equal(expected, result);
        }

        [Fact]
        public async void MayKeyService_CanDeterminePasswordFollowingConstruction()
        {
            var randomUserId = CreateArbitraryUserId();
            var randomPassword = CreateArbitraryPassword();
            var service = ServerKeyHelperMockFactory.CreateMockServerKeyHelper(randomUserId, randomPassword);
            var sut = await UWP.Services.ServerKeyService.ServerKeyService.CreateAsync(service.Object);

            var expected = randomPassword;
            var result = sut.Password;

            Assert.Equal(expected, result);
        }

        private static string CreateArbitraryUserId()
        {
            return KeyGenerator.GenerateValidKey(12, ArbitraryUserIdSeed);
        }

        private static string CreateArbitraryPassword()
        {
            return KeyGenerator.GenerateValidKey(14, ArbitraryPasswordSeed);
        }
    }
}
