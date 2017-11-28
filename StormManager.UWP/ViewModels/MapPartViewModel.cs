using System.Collections.Generic;
using System.Windows.Input;
using Template10.Mvvm;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls.Maps;
using StormManager.UWP.Common.ExtensionMethods;
using StormManager.UWP.Services.LocationService;
using StormManager.UWP.Services.MapKeyService;

namespace StormManager.UWP.ViewModels
{
    public class MapPartViewModel : ViewModelBase
    {
        private Geopoint _mapCentre;
        public Geopoint MapCentre
        {
            get => _mapCentre;
            set
            {
                _mapCentre = value;
                RaisePropertyChanged();
            }
        }

        private IList<MapElement> _mapElements;

        public IList<MapElement> MapElements
        {
            get => _mapElements;
            set
            {
                _mapElements = value;
                RaisePropertyChanged();
            }
        }
        
        private MapScene _mapScene;
        public MapScene MapScene
        {
            get => _mapScene;
            set
            {
                _mapScene = value;
                RaisePropertyChanged();
            }
        }

        public string MapServiceToken { get; private set; }

        private MapStyle _mapStyle;
        public MapStyle MapStyle
        {
            get => _mapStyle;
            set
            {
                _mapStyle = value;
                RaisePropertyChanged();
            }
        }

        private double _zoomLevel;
        public double ZoomLevel
        {
            get => _zoomLevel;
            set
            {
                _zoomLevel = value;
                RaisePropertyChanged();
            }
        }

        private ICommand _mapLoadeedCommand; 
        public ICommand MapLoadedCommand => _mapLoadeedCommand ?? (_mapLoadeedCommand = new DelegateCommand(Map_Loaded));

        public MapPartViewModel()
        {
            RetrieveMapServiceToken();
        }

        private async void RetrieveMapServiceToken()
        {
            IMapKeyService mapKeyService = await MapKeyService.CreateAsync();
            MapServiceToken = mapKeyService.Key;
        }

        private async void Map_Loaded()
        {
            var location = await LocationService.TryGetCurrentLocationAsync();
            if (location.Success) SetCurrentLocation(location.Result, 3000);
        }

        private void SetCurrentLocation(BasicGeoposition location, double radiusInMeters = 10000)
        {
            MapCentre = location.ToGeopoint();
            MapScene = MapScene.CreateFromLocationAndRadius(MapCentre, radiusInMeters);
        }
    }
}