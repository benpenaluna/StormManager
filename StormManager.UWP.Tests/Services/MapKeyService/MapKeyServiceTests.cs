using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StormManager.UWP.Common.ExtensionMethods;
using StormManager.UWP.Services.MapKeyService;
using StormManager.UWP.Tests.Common.ExtensionMethods;
using StormManager.UWP.Tests.Services.LocationService;
using Xunit;

namespace StormManager.UWP.Tests.Services.MapKeyService
{
    public class MapKeyServiceTests
    {
        private const int ArbitrarySeed = 6373822;

        [Fact]
        public async Task MapKeyService_CanCreateAsyncronously()
        {
            var randomKey = MapKeyGenerator.GenerateValidKey(MapKeyExtensions.MapKeyLength, ArbitrarySeed);
            var service = MapKeyHelperMockFactory.CreateMockMapKeyHelper(randomKey);
            var result = await UWP.Services.MapKeyService.MapKeyService.CreateAsync(service.Object);
            Assert.NotNull(result);
        }

        [Fact]
        public async void MayKeyService_CanDetermineKeyFollowingConstruction()
        {
            var randomKey = MapKeyGenerator.GenerateValidKey(MapKeyExtensions.MapKeyLength, ArbitrarySeed);

            var service = MapKeyHelperMockFactory.CreateMockMapKeyHelper(randomKey);
            IMapKeyService sut = await UWP.Services.MapKeyService.MapKeyService.CreateAsync(service.Object);
            var result = sut.Key;

            Assert.Equal(randomKey, result);
        }
    }
}
