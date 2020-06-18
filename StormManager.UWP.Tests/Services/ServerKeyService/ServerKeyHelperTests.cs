using StormManager.UWP.Services.ServerKeyService;
using StormManager.UWP.Tests.Common.ExtensionMethods;
using System.Threading.Tasks;
using Xunit;

namespace StormManager.UWP.Tests.Services.ServerKeyService
{
    public class ServerKeyHelperTests
    {
        private const int ArbitraryUserIdSeed = 65223115;
        private const int ArbitraryPasswordSeed = 9467291;

        [Fact]
        public async Task ServerKeyHelper_CanCreateAsynchronously()
        {
            var secret = CreateSecret();
            var result = await ServerKeyHelper.CreateAsync(secret);

            Assert.NotNull(result);
        }

        [Fact]
        public async void ServerKeyHelper_CanDetermineUserIdFollowingConstruction()
        {
            var expected = CreateArbitraryUserId();

            var secret = CreateSecret();
            var sut = await ServerKeyHelper.CreateAsync(secret);
            var result = sut.UserId;

            Assert.Equal(expected, result);
        }

        [Fact]
        public async void ServerKeyHelper_CanDeterminePasswordFollowingConstruction()
        {
            var expected = CreateArbitraryPassword();
            var secret = CreateSecret();
            var sut = await ServerKeyHelper.CreateAsync(secret);
            var result = sut.Password;

            Assert.Equal(expected, result);
        }

        private static string CreateSecret()
        {
            var randomUserId = CreateArbitraryUserId();
            var randomPassword = CreateArbitraryPassword();
            return string.Concat(randomUserId, ",", randomPassword);
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
