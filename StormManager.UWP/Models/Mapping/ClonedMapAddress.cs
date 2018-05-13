using Windows.Services.Maps;

namespace StormManager.UWP.Models.Mapping
{
    public class ClonedMapAddress : IClonedMapAddress
    {
        private readonly MapAddress _mapAddress;

        private readonly IClonedMapAddress _helper;

        public string BuildingFloor => _helper.BuildingFloor ?? _mapAddress.BuildingFloor;

        public string BuildingName => _helper.BuildingName ?? _mapAddress.BuildingName;

        public string BuildingRoom => _helper.BuildingRoom ?? _mapAddress.BuildingRoom;

        public string BuildingWing => _helper.BuildingWing ?? _mapAddress.BuildingWing;

        public string Continent => _helper.Continent ?? _mapAddress.Continent;

        public string Country => _helper.Country ?? _mapAddress.Country;

        public string CountryCode => _helper.CountryCode ?? _mapAddress.CountryCode;

        public string District => _helper.District ?? _mapAddress.District;

        public string FormattedAddress => _helper.FormattedAddress ?? _mapAddress.FormattedAddress;

        public string Neighborhood => _helper.Neighborhood ?? _mapAddress.Neighborhood;

        public string PostCode => _helper.PostCode ?? _mapAddress.PostCode;

        public string Region => _helper.Region ?? _mapAddress.Region;

        public string RegionCode => _helper.RegionCode ?? _mapAddress.RegionCode;

        public string Street => _helper.Street ?? _mapAddress.Street;

        public string StreetNumber => _helper.StreetNumber ?? _mapAddress.StreetNumber;

        public string Town => _helper.Town ?? _mapAddress.Town;

        private ClonedMapAddress(MapAddress address)
        {
            _mapAddress = address;
        }

        private ClonedMapAddress(IClonedMapAddress clonedAddress)
        {
            _helper = clonedAddress;
        }

        public static IClonedMapAddress Create(MapAddress address)
        {
            return new ClonedMapAddress(address);
        }

        public static IClonedMapAddress Create(IClonedMapAddress helper)
        {
            return new ClonedMapAddress(helper);
        }
    }
}
