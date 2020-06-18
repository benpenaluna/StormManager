using StormManager.UWP.Mvvm;
using System.Collections.Generic;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls.Maps;

namespace StormManager.UWP.ViewModels.OperationsPageViewModel
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

        public string MapServiceToken => App.MapKey;

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
    }
}