using StormManager.UWP.Common.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Template10.Mvvm;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.UI.Xaml.Controls.Maps;

namespace StormManager.UWP.ViewModels
{
    public class MapPartViewModel : ViewModelBase
    {
        private Geopoint _mapCentre;
        public Geopoint MapCentre
        {
            get { return _mapCentre; }
            set
            {
                _mapCentre = value;
                base.RaisePropertyChanged();
            }
        }

        private IList<MapElement> _mapElements;

        public IList<MapElement> MapElements
        {
            get { return _mapElements; }
            set
            {
                _mapElements = value;
                base.RaisePropertyChanged();
            }
        }



        private MapScene _mapScene;
        public MapScene MapScene
        {
            get { return _mapScene; }
            set
            {
                _mapScene = value;
                base.RaisePropertyChanged();
            }
        }

        public string MapServiceToken { get; } = "";

        private MapStyle _mapStyle;
        public MapStyle MapStyle
        {
            get { return _mapStyle; }
            set
            {
                _mapStyle = value;
                base.RaisePropertyChanged();
            }
        }

        private double _zoomLevel;
        public double ZoomLevel
        {
            get { return _zoomLevel; }
            set
            {
                _zoomLevel = value;
                base.RaisePropertyChanged();
            }
        }

        public MapPartViewModel()
        {
            var myPoint = new Geopoint(new BasicGeoposition() { Latitude = -37.57702, Longitude = 144.75402 });
            this.MapElements = new List<MapElement>
            {
                new MapIcon()
                {
                    Location = myPoint,
                    NormalizedAnchorPoint = new Point(0.5, 1.0),
                    Title = "My House",
                    ZIndex = 0
                }
            };
        }

        public void Map_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
//            try
//            {
//                var locationService = await new LocationService().StartAsync();
//                this.MapCentre = locationService.Position.ToGeopoint();
//            }
//            catch (Exception ex)
//            {
//#if DEBUG
//                Debug.WriteLine(ex.Message);
//#endif
//                this.MapCentre = new Geopoint(new BasicGeoposition()
//                {
//                    // Melbourne GPO
//                    Latitude = -37.813840,
//                    Longitude = 144.963000
//                });
//            }

//            this.ZoomLevel = 14;
            //this.MapScene = MapScene.CreateFromLocationAndRadius(this.MapCentre, 3000);
        }
    }
}