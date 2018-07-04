using System.Collections.Generic;
using Windows.Services.Maps;
using StormManager.UWP.Models.Mapping;

namespace StormManager.UWP.Common.ExtensionMethods
{
    public static class MapLocationExtensions
    {
        public static string StreetAddressOrCommonPlaceName(this IClonedMapLocation location)
        {
            return StreetAddressOrCommonPlaceName(new MapLocationSuggestion(location));
        }

        public static string StreetAddressOrCommonPlaceName(this IMapLocationSuggestion location)
        {
            var formattedAddress = location.MapLocation.Address.FormattedAddress;

            var itemsToRemove = new List<string>
            {
                location.MapLocation.Address.Country,
                location.MapLocation.Address.PostCode,
                location.MapLocation.Address.Region
            };

            foreach (var item in itemsToRemove)
            {
                if (item != "")
                {
                    formattedAddress = formattedAddress.Replace(item, "");
                }
            }

            return formattedAddress.TrimEnd(' ', ',');
        }
    }
}
