using Windows.Services.Maps;

namespace StormManager.UWP.Models.Mapping
{
    public class ClonedMapAddress : IClonedMapAddress
    {
        private readonly MapAddress _mapAddress;

        private readonly IClonedMapAddress _helper;

        private readonly bool _helperProvided;

        public string BuildingFloor => _helperProvided ? _helper.BuildingFloor : _mapAddress.BuildingFloor;

        public string BuildingName => _helperProvided ? _helper.BuildingName : _mapAddress.BuildingName;

        public string BuildingRoom => _helperProvided ? _helper.BuildingRoom : _mapAddress.BuildingRoom;

        public string BuildingWing => _helperProvided ? _helper.BuildingWing : _mapAddress.BuildingWing;

        public string Continent => _helperProvided ? _helper.Continent : _mapAddress.Continent;

        public string Country => _helperProvided ? _helper.Country : _mapAddress.Country;

        public string CountryCode => _helperProvided ? _helper.CountryCode : _mapAddress.CountryCode;

        public string District => _helperProvided ? _helper.District : _mapAddress.District;

        public string FormattedAddress => _helperProvided ? _helper.FormattedAddress : _mapAddress.FormattedAddress;

        public string Neighborhood => _helperProvided ? _helper.Neighborhood : _mapAddress.Neighborhood;

        public string PostCode => _helperProvided ? _helper.PostCode : _mapAddress.PostCode;

        public string Region => _helperProvided ? _helper.Region : _mapAddress.Region;

        public string RegionCode => _helperProvided ? _helper.RegionCode : _mapAddress.RegionCode;

        public string Street => _helperProvided ? _helper.Street : _mapAddress.Street;

        public string StreetNumber => _helperProvided ? _helper.StreetNumber : _mapAddress.StreetNumber;

        public string Town => _helperProvided ? _helper.Town : _mapAddress.Town;

        private ClonedMapAddress(MapAddress address)
        {
            _mapAddress = address;
        }

        private ClonedMapAddress(IClonedMapAddress clonedAddress)
        {
            _helper = clonedAddress;
            _helperProvided = true;
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
