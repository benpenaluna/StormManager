using System.Collections.ObjectModel;
using System.Linq;
using Windows.Services.Maps;
using StormManager.UWP.Utils;

namespace StormManager.UWP.Models.Mapping
{
    public class FoundMapLocations : IFoundMapLocations
    {
        public ObservableCollection<IMapLocationSuggestion> Locations { get; }

        public bool IsLocationsListEmpty => Locations == null || Locations.Count == 0;

        private FoundMapLocations()
        {
            Locations = new ObservableCollection<IMapLocationSuggestion>();
        }

        public static IFoundMapLocations Create()
        {
            return new FoundMapLocations();
        }

        public void UpdateLocations(MapLocationFinderResult result)
        {
            UpdateLocations(ClonedMapLocationFinderResult.Create(result));
        }

        public void UpdateLocations(IClonedMapLocationFinderResult result)
        {
            Locations.Clear();

            if (result.Locations != null)
            {
                Locations.AddRange(result.Locations.Select(location => new MapLocationSuggestion(location)).ToList());
            }
        }

        public IClonedMapLocation LastLocation(string userEnteredLocationName)  // TODO: Unit Test this
        {
            var locations = from loc in Locations
                            where loc.MapLocation.DisplayName.StartsWith(userEnteredLocationName)
                            select loc.MapLocation;

            return locations.FirstOrDefault();
        }
    }
}
