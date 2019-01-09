using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel.Store;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Services.Maps;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Autofac;
using StormManager.UWP.Common.ExtensionMethods;
using StormManager.UWP.Controls.ControlHelpers;
using StormManager.UWP.Models.Mapping;

namespace StormManager.UWP.Controls
{
    public sealed class MenuMapControl : Control
    {
        private MapControl _myMapControl;
        private Button _styleButton;
        private AutoSuggestBox _directionsSuggestBox;
        private readonly IFoundMapLocations _lastFoundMapLocations = FoundMapLocations.Create();

        private MapRadioButton _roadStyleRadioButton;
        private MapRadioButton _aerialStyleRadioButton;
        private MapRadioButton _aerialWithRoadsStyleRadioButton;
        private MapRadioButton _terrainStyleRadioButton;
        private ToggleSwitch _toggleSwitch3D;
        private static readonly Geopoint DefaultCenter = new Geopoint(new BasicGeoposition() { Latitude = -36.151527, Longitude = 144.765963 });
        private static readonly MapScene DefaultMapScene = MapScene.CreateFromLocationAndRadius(DefaultCenter, 40000);

        public Geopoint MapCenter
        {
            get => (Geopoint)GetValue(MapCenterProperty);
            set => SetValue(MapCenterProperty, value);
        }
        public static readonly DependencyProperty MapCenterProperty =
            DependencyProperty.Register(nameof(MapCenter), typeof(Geopoint), typeof(MenuMapControl), new PropertyMetadata(DefaultCenter));

        public MapScene MapScene
        {
            get => (MapScene)GetValue(MapSceneProperty);
            set => SetValue(MapSceneProperty, value);
        }
        public static readonly DependencyProperty MapSceneProperty =
            DependencyProperty.Register(nameof(MapScene), typeof(MapScene), typeof(MenuMapControl), new PropertyMetadata(DefaultMapScene));

        public string MapServiceToken
        {
            get => (string)GetValue(MapServiceTokenProperty);
            set => SetValue(MapServiceTokenProperty, value);
        }
        public static readonly DependencyProperty MapServiceTokenProperty =
            DependencyProperty.Register(nameof(MapServiceToken), typeof(string), typeof(MenuMapControl), new PropertyMetadata(string.Empty));

        public double MapZoomLevel
        {
            get => (double)GetValue(MapZoomLevelProperty);
            set => SetValue(MapZoomLevelProperty, value);
        }
        public static readonly DependencyProperty MapZoomLevelProperty =
            DependencyProperty.Register(nameof(MapZoomLevel), typeof(double), typeof(MenuMapControl), new PropertyMetadata(6.8));


        public double RadiusAroundNewPushPin
        {
            get => (double)GetValue(RadiusAroundNewPushPinProperty);
            set
            {
                if (value < 1.0)
                    throw new ArgumentException(nameof(RadiusAroundNewPushPin) + " must be greater than or equal to 1 meters.");

                SetValue(RadiusAroundNewPushPinProperty, value);    
            }
        }
        public static readonly DependencyProperty RadiusAroundNewPushPinProperty =
            DependencyProperty.Register(nameof(RadiusAroundNewPushPin), typeof(double), typeof(MenuMapControl), new PropertyMetadata(1000.0));

        public MapInteractionMode RotateInteractionMode
        {
            get => (MapInteractionMode)GetValue(RotateInteractionModeProperty);
            set => SetValue(RotateInteractionModeProperty, value);
        }

        public uint SearchResultsDisplayed
        {
            get => (uint)GetValue(SearchResultsDisplayedProperty);
            set => SetValue(SearchResultsDisplayedProperty, value);
        }
        public static readonly DependencyProperty SearchResultsDisplayedProperty =
            DependencyProperty.Register(nameof(SearchResultsDisplayed), typeof(uint), typeof(MenuMapControl), new PropertyMetadata((uint)3));

        public static readonly DependencyProperty RotateInteractionModeProperty =
            DependencyProperty.Register(nameof(RotateInteractionMode), typeof(MapInteractionMode), typeof(MenuMapControl), new PropertyMetadata(MapInteractionMode.Auto));

        public MapInteractionMode TiltInteractionMode
        {
            get => (MapInteractionMode)GetValue(TiltInteractionModeProperty);
            set => SetValue(TiltInteractionModeProperty, value);
        }
        public static readonly DependencyProperty TiltInteractionModeProperty =
            DependencyProperty.Register(nameof(TiltInteractionMode), typeof(MapInteractionMode), typeof(MenuMapControl), new PropertyMetadata(MapInteractionMode.Auto));

        public bool ToggleSwitch3DEnabled
        {
            get => (bool)GetValue(ToggleSwitch3DEnabledProperty);
            set => SetValue(ToggleSwitch3DEnabledProperty, value);
        }
        public static readonly DependencyProperty ToggleSwitch3DEnabledProperty =
            DependencyProperty.Register(nameof(ToggleSwitch3DEnabled), typeof(bool), typeof(MenuMapControl), new PropertyMetadata(false));

        public MapInteractionMode ZoomInteractionMode
        {
            get => (MapInteractionMode)GetValue(ZoomInteractionModeProperty);
            set => SetValue(ZoomInteractionModeProperty, value);
        }
        public static readonly DependencyProperty ZoomInteractionModeProperty =
            DependencyProperty.Register(nameof(ZoomInteractionMode), typeof(MapInteractionMode), typeof(MenuMapControl), new PropertyMetadata(MapInteractionMode.Auto));

        public MenuMapControl()
        {
            DefaultStyleKey = typeof(MenuMapControl);
        }
        
        public event EventHandler<object> MapLoading;

        public event EventHandler<RoutedEventArgs> MapLoaded;
        
        protected override void OnApplyTemplate()
        {
            InitialiseControlReferences();
            AttachEvents();
        }

        private void InitialiseControlReferences()
        {
            _myMapControl = GetTemplateChild<MapControl>("MyMapControl");
            _styleButton = GetTemplateChild<Button>("StyleButton");
            _directionsSuggestBox = GetTemplateChild<AutoSuggestBox>("DirectionsSuggestBox");
            _roadStyleRadioButton = GetTemplateChild<MapRadioButton>("RoadStyleRadioButton");
            _aerialStyleRadioButton = GetTemplateChild<MapRadioButton>("AerialStyleRadioButton");
            _aerialWithRoadsStyleRadioButton = GetTemplateChild<MapRadioButton>("AerialWithRoadsStyleRadioButton");
            _terrainStyleRadioButton = GetTemplateChild<MapRadioButton>("TerrainStyleRadioButton");
            _toggleSwitch3D = GetTemplateChild<ToggleSwitch>("ToggleSwitch3D");
        }
        
        private T GetTemplateChild<T>(string name) where T : DependencyObject
        {
            if (!(GetTemplateChild(name) is T child))
            {
                throw new NullReferenceException(name);
            }

            return child;
        }

        private void AttachEvents()
        {
            _myMapControl.Loading += (s, e) => MapLoading?.Invoke(s, e);
            _myMapControl.Loaded += (s, e) => MapLoaded?.Invoke(s, e);
            
            AttachSuggestBoxEvents();
            AttachStyleEvents();
        }

        private void AttachSuggestBoxEvents()
        {
            _directionsSuggestBox.TextChanged += DirectionsSuggestBox_TextChanged;
            _directionsSuggestBox.QuerySubmitted += DirectionsSuggestBox_QuerySubmitted;
        }

        private void AttachStyleEvents()
        {
            _roadStyleRadioButton.Checked += MapStylePresenter_Changed;
            _aerialStyleRadioButton.Checked += MapStylePresenter_Changed;
            _aerialWithRoadsStyleRadioButton.Checked += MapStylePresenter_Changed;
            _terrainStyleRadioButton.Checked += MapStylePresenter_Changed;
            _toggleSwitch3D.Toggled += ToggleSwitch3D_Toggled;
        }

        private async void DirectionsSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason != AutoSuggestionBoxTextChangeReason.UserInput)
            {
                return;
            }

             var finderResult = await FindLocationsAsync(sender.Text);
            DisplayAndCacheLocationSuggestions(finderResult);
        }

        private async Task<MapLocationFinderResult> FindLocationsAsync(string queryText)
        {
            return await MapLocationFinder.FindLocationsAsync(queryText, MapCenter, SearchResultsDisplayed);
        }

        private void DisplayAndCacheLocationSuggestions(MapLocationFinderResult result)
        {
            _lastFoundMapLocations.UpdateLocations(result);

            if (_directionsSuggestBox.ItemsSource == null)
            {
                _directionsSuggestBox.ItemsSource = _lastFoundMapLocations.Locations;
            }
        }

        private void DirectionsSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion == null)
            {
                TryPinLastFoundLocationToMap(sender.Text);
            }
            else
            {
                TryPinLocationToMap(args.ChosenSuggestion as MapLocationSuggestion);
            }
        }

        private void TryPinLastFoundLocationToMap(string userEnteredLocationName)
        {
            if (_lastFoundMapLocations.IsLocationsListEmpty)
            {
                return;
            }

            AddMapIconAndSetScene(_lastFoundMapLocations.LastLocation(userEnteredLocationName));
        }

        private void AddMapIconAndSetScene(IClonedMapLocation location)
        {
            if (location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }

            var defaultMapIcon = CreateDefaultMapIcon(location);
            AddAndPositionMapIcon(defaultMapIcon, location);
            AttachMapIconEvents(defaultMapIcon);

            SetMapSceneForMapIconAddition(location);
        }

        private static MapIconControl CreateDefaultMapIcon(IClonedMapLocation location)
        {
            var colorAnimationHelper = JobTypeColorAnimationFactory.Create(ColorAnimationType.BuildingDamage);
            //var iconWithCollapsableDescription = new MapIconControl(colorAnimationHelper)
            //{
            //    HeadingVisible = Visibility.Collapsed,
            //    StatusVisible = Visibility.Collapsed,
            //    NotificationTimeVisbible = Visibility.Collapsed,
            //    SubHeadingText = location.StreetAddressOrCommonPlaceName()
            //};
            var iconWithCollapsableDescription = new MapIconControl(colorAnimationHelper)
            {
                HeadingVisible = Visibility.Visible,
                StatusVisible = Visibility.Visible,
                NotificationTimeVisbible = Visibility.Visible,
                SubHeadingText = location.StreetAddressOrCommonPlaceName()
            };

            return iconWithCollapsableDescription;
        }

        private void AddAndPositionMapIcon(MapIconControl icon, IClonedMapLocation location)
        {
            _myMapControl.Children.Add(icon);

            var position = new Geopoint(location.Point.Position, AltitudeReferenceSystem.Terrain);
            MapControl.SetLocation(icon, position);
            MapControl.SetNormalizedAnchorPoint(icon, new Point(0.5, 1.0));
        }

        private void AttachMapIconEvents(MapIconControl icon)
        {
            icon.RemoveClicked += MapIconControlRemoveClicked;
        }

        private void MapIconControlRemoveClicked(object sender, RoutedEventArgs args)
        {
            _myMapControl.Children.Remove(sender as UIElement);
        }
        
        private void SetMapSceneForMapIconAddition(IClonedMapLocation location)
        {
            _myMapControl.Scene = MapScene.CreateFromLocationAndRadius(location.Point, RadiusAroundNewPushPin, _myMapControl.Heading, _myMapControl.Pitch);
        }

        private void TryPinLocationToMap(MapLocationSuggestion suggestion)
        {
            var location = suggestion.MapLocation;
            
            AddMapIconAndSetScene(location);
        }

        private void MapStylePresenter_Changed(object sender, RoutedEventArgs e)
        {
            IMapStylePresenter mapStylePresenter;
            try { mapStylePresenter = ParseObjectToIMapStylePresenter(sender); }
            catch { return; }

            UpdateStyleButton(mapStylePresenter);

            UpdateMapStyleChange(mapStylePresenter);
        }

        private static IMapStylePresenter ParseObjectToIMapStylePresenter(object sender)
        {
            if (sender.GetType() != typeof(MapRadioButton))
                throw new ArgumentException();

            IMapStylePresenter mapStylePresenter = sender as MapRadioButton;
            if (mapStylePresenter == null)
                throw new NullReferenceException();

            return mapStylePresenter;
        }

        private void UpdateStyleButton(IMapStylePresenter mapStylePresenter)
        {
            _styleButton.Content = mapStylePresenter.Text;
        }

        private void UpdateMapStyleChange(IMapStylePresenter mapStylePresenter)
        {
            ToggleSwitch3DEnabled = mapStylePresenter.MapStyle.ToString().StartsWith(MapStyle.Aerial.ToString());

            if (!ToggleSwitch3DEnabled)
            {
                _myMapControl.Style = mapStylePresenter.MapStyle;
                return;
            }

            if (mapStylePresenter.MapStyle == MapStyle.Aerial)
                _myMapControl.Style = _toggleSwitch3D.IsOn ? MapStyle.Aerial3D : MapStyle.Aerial;
            else if (mapStylePresenter.MapStyle == MapStyle.AerialWithRoads)
                _myMapControl.Style = _toggleSwitch3D.IsOn ? MapStyle.Aerial3DWithRoads : MapStyle.AerialWithRoads;
        }

        private void ToggleSwitch3D_Toggled(object sender, RoutedEventArgs e)
        {
            if (_myMapControl.Style == MapStyle.Aerial) _myMapControl.Style = MapStyle.Aerial3D;
            else if (_myMapControl.Style == MapStyle.Aerial3D) _myMapControl.Style = MapStyle.Aerial;
            else if (_myMapControl.Style == MapStyle.AerialWithRoads) _myMapControl.Style = MapStyle.Aerial3DWithRoads;
            else if (_myMapControl.Style == MapStyle.Aerial3DWithRoads) _myMapControl.Style = MapStyle.AerialWithRoads;
        }
    }
}
