﻿using Moq;
using StormManager.UWP.Services.LocationService;
using Windows.Devices.Geolocation;

namespace StormManager.UWP.Tests.Services.LocationService
{
    internal static class LocationHelperMockFactory
    {
        public static Mock<ILocationHelper> CreateMockLocationHelper(double latitude = 0.0, double longitude = 0.0)
        {
            var service = new Mock<ILocationHelper>();
            service.Setup(x => x.AccessStatus).Returns(GeolocationAccessStatus.Allowed);
            service.Setup(x => x.Position).Returns(new BasicGeoposition()
            {
                Latitude = latitude,
                Longitude = longitude
            });
            return service;
        }
    }
}
