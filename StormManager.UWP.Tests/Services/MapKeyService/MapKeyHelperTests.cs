using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StormManager.UWP.Common.ExtensionMethods;
using StormManager.UWP.Services.MapKeyService;
using StormManager.UWP.Tests.Common.ExtensionMethods;
using Xunit;

namespace StormManager.UWP.Tests.Services.MapKeyService
{
    public class MapKeyHelperTests
    {
        private const int ArbitrarySeed = -8837746;
        
        [Fact]
        public async Task MapKeynHelper_CanCreateAsyncronously()
        {
            var randomKey = MapKeyGenerator.GenerateValidKey(MapKeyExtensions.MapKeyLength, ArbitrarySeed);
            var service = MapKeyHelperMockFactory.CreateMockMapKeyHelper(randomKey);
            var result = await MapKeyHelper.CreateAsync(service.Object.Key);

            Assert.NotNull(result);
        }

        [Fact]
        public async void MayKeyHelper_CanDetermineKeyFollowingConstruction()
        {
            var randomKey = MapKeyGenerator.GenerateValidKey(MapKeyExtensions.MapKeyLength, ArbitrarySeed);
            var sut = await MapKeyHelper.CreateAsync(randomKey);
            var result = sut.Key;

            Assert.Equal(randomKey, result);
        }

        [Fact]
        public async void MayKeyHelper_InvalidKeyThrowsException()
        {
            var randomKey = MapKeyGenerator.GenerateValidKey(MapKeyExtensions.MapKeyLength -1, ArbitrarySeed);
            var service = MapKeyHelperMockFactory.CreateMockMapKeyHelper(randomKey);
            
            await Assert.ThrowsAsync<ArgumentException>(async () => await MapKeyHelper.CreateAsync(service.Object.Key));
        }
    }
}
