using Windows.Services.Maps;

namespace StormManager.UWP.Common.ExtensionMethods
{
    public static class MapLocationExtensions
    {
        public static string StreetAddressOrCommonPlaceName(this MapLocation location)
        {
            var formattedAddress = location.Address.FormattedAddress;

            if (location.Address.Country != "")
            {
                formattedAddress = formattedAddress.Replace(location.Address.Country, "");
            }

            if (location.Address.PostCode != "")
            {
                formattedAddress = formattedAddress.Replace(location.Address.PostCode, "");
            }

            if (location.Address.Region != "")
            {
                formattedAddress = formattedAddress.Replace(location.Address.Region, "");
            }

            return formattedAddress.TrimEnd(' ', ',');
        }
    }
}
