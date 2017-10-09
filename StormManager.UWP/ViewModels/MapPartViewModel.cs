using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
                base.RaisePropertyChanged();
            }
        }

        private IList<MapElement> _mapElements;

        public IList<MapElement> MapElements
        {
            get => _mapElements;
            set
            {
                _mapElements = value;
                base.RaisePropertyChanged();
            }
        }
        
        private MapScene _mapScene;
        public MapScene MapScene
        {
            get => _mapScene;
            set
            {
                _mapScene = value;
                base.RaisePropertyChanged();
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
                base.RaisePropertyChanged();
            }
        }

        private double _zoomLevel;
        public double ZoomLevel
        {
            get => _zoomLevel;
            set
            {
                _zoomLevel = value;
                base.RaisePropertyChanged();
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
            await TrySetCurrentLocationAsync(3000);
        }

        private async Task<bool> TrySetCurrentLocationAsync(double radiusInMeters = 10000)
        {
            ILocationService locationService;

            try { locationService = await LocationService.CreateAsync(); }
            catch { return false; }

            if (locationService == null) return false;

            this.MapCentre = locationService.Position.ToGeopoint();
            this.MapScene = MapScene.CreateFromLocationAndRadius(this.MapCentre, radiusInMeters);
            return true;
        }
    }
}