using StormManager.UWP.Common.ExtensionMethods;
using StormManager.UWP.Services.MapKeyService;
using StormManager.UWP.Tests.Common.ExtensionMethods;
using System.Threading.Tasks;
using Xunit;

namespace StormManager.UWP.Tests.Services.MapKeyService
{
    public class MapKeyHelperTests
    {
        private const int ArbitrarySeed = -8837746;

        [Fact]
        public async Task MapKeynHelper_CanCreateAsyncronously()
        {
            var randomKey = KeyGenerator.GenerateValidKey(KeyExtensions.MapKeyLength, ArbitrarySeed);
            var result = await MapKeyHelper.CreateAsync(randomKey);

            Assert.NotNull(result);
        }

        [Fact]
        public async void MayKeyHelper_CanDetermineKeyFollowingConstruction()
        {
            var randomKey = KeyGenerator.GenerateValidKey(KeyExtensions.MapKeyLength, ArbitrarySeed);
            var sut = await MapKeyHelper.CreateAsync(randomKey);
            var result = sut.Key;

            Assert.Equal(randomKey, result);
        }

        [Fact]
        public async void MayKeyHelper_KeyPropertyEmptyWhenProvidedInvalidKey()
        {
            var expected = string.Empty;

            var randomKey = KeyGenerator.GenerateValidKey(KeyExtensions.MapKeyLength - 1, ArbitrarySeed);
            var service = MapKeyHelperMockFactory.CreateMockMapKeyHelper(randomKey);

            var sut = await MapKeyHelper.CreateAsync(service.Object.Key);
            var result = sut.Key;

            Assert.Equal(expected, result);
        }
    }
}
