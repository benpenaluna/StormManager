namespace StormManager.UWP.Models.Mapping
{
    public interface IClonedMapAddress
    {
        string BuildingFloor { get; }
        string BuildingName { get; }
        string BuildingRoom { get; }
        string BuildingWing { get; }
        string Continent { get; }
        string Country { get; }
        string CountryCode { get; }
        string District { get; }
        string FormattedAddress { get; }
        string Neighborhood { get; }
        string PostCode { get; }
        string Region { get; }
        string RegionCode { get; }
        string Street { get; }
        string StreetNumber { get; }
        string Town { get; }
    }
}
