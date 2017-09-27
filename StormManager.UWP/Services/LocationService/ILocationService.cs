using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace StormManager.UWP.Services.LocationService
{
    internal interface ILocationService
    {
        BasicGeoposition Position { get; }
    }
}
