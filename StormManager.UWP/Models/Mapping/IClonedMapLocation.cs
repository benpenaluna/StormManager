using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace StormManager.UWP.Models.Mapping
{
    public interface IClonedMapLocation
    {
        IClonedMapAddress Address { get; }
        string Description { get; }
        string DisplayName { get; }
        Geopoint Point { get; }
    }
}
