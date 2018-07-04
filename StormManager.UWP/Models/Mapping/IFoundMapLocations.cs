using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.Services.Maps;

namespace StormManager.UWP.Models.Mapping
{
    public interface IFoundMapLocations
    {
        ObservableCollection<IMapLocationSuggestion> Locations { get; }
        bool IsLocationsListEmpty { get; }
        void UpdateLocations(MapLocationFinderResult result);
        void UpdateLocations(IClonedMapLocationFinderResult result);
        IClonedMapLocation LastLocation(string userEnteredLocationName);
    }
}
