﻿using System;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace StormManager.UWP.Controls
{
    public sealed class MenuMapControl : Control
    {
        private MapControl _myMapControl;
        private Button _styleButton;
        private AutoSuggestBox _directionsSuggestBox;

        private MapRadioButton _roadStyleRadioButton;
        private MapRadioButton _aerialStyleRadioButton;
        private MapRadioButton _aerialWithRoadsStyleRadioButton;
        private MapRadioButton _terrainStyleRadioButton;
        private ToggleSwitch _toggleSwitch3D;
        private static readonly Geopoint DefaultCenter = new Geopoint(new BasicGeoposition() { Latitude = -36.151527, Longitude = 144.765963 });
        private static readonly MapScene DefaultMapScene = Windows.UI.Xaml.Controls.Maps.MapScene.CreateFromLocationAndRadius(DefaultCenter, 40000);

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

        public MapInteractionMode RotateInteractionMode
        {
            get => (MapInteractionMode)GetValue(RotateInteractionModeProperty);
            set => SetValue(RotateInteractionModeProperty, value);
        }
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

        private void AttachEvents()
        {
            _myMapControl.Loaded += (s, e) => MapLoaded?.Invoke(s, e);
            
            AttachSuggestBoxEvents();
            AttachStyleEvents();
        }

        private void AttachSuggestBoxEvents()
        {
            _directionsSuggestBox.TextChanged += DirectionsSuggestBox_TextChanged;
            _directionsSuggestBox.SuggestionChosen += DirectionsSuggestBox_SuggestionChosen;
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

        private T GetTemplateChild<T>(string name) where T : DependencyObject
        {
            if (!(GetTemplateChild(name) is T child))
                throw new NullReferenceException(name);

            return child;
        }

        private void DirectionsSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            // Only get results when it was a user typing, 
            // otherwise assume the value got filled in by TextMemberPath 
            // or the handler for SuggestionChosen.
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                //Set the ItemsSource to be your filtered dataset
                //sender.ItemsSource = dataset;
            }
        }


        private void DirectionsSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            // Set sender.Text. You can use args.SelectedItem to build your text string.
        }


        private void DirectionsSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {
                // User selected an item from the suggestion list, take an action on it here.
            }
            else
            {
                // Use args.QueryText to determine what to do.
            }
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
