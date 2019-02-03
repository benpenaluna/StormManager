using Autofac;
using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Resources;
using Windows.ApplicationModel.Store;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using StormManager.UWP.Common.ExtensionMethods;
using StormManager.UWP.Controls.ControlHelpers;

namespace StormManager.UWP.Controls
{
    public sealed class MapIconControl : Control
    {
        private static readonly ResourceLoader ResLoader = ResourceLoader.GetForCurrentView();

        private Storyboard _myStoryboard;
        private ColorAnimation _descriptionBorderBackgroundAnimation;
        private ColorAnimation _descriptionBorderAnimation;
        private ColorAnimation _mapIconFillPathAnimation;
        private ColorAnimation _headingForegroundAnimation;
        private SolidColorBrush _headingForeground;

        private List<ColorAnimation> _colorAnimations;

        private readonly MenuFlyoutItem _removeMenuFlyoutItem = new MenuFlyoutItem();

        public AnimateColor AllowAnimateColor => MapIconControlHelper.ColorAnimationSettings.AnimateColor;

        public IMapIconControlHelper MapIconControlHelper { get; set; }

        public event EventHandler<RoutedEventArgs> RemoveClicked; 

        public Brush DescriptionBackgroundColor
        {
            get => (Brush)GetValue(DescriptionBackgroundColorProperty);
            set => SetValue(DescriptionBackgroundColorProperty, value);
        }
        public static readonly DependencyProperty DescriptionBackgroundColorProperty =
            DependencyProperty.Register(nameof(DescriptionBackgroundColor), typeof(Brush), typeof(MapIconControl), new PropertyMetadata(new SolidColorBrush(Colors.White)));

        public CornerRadius DescriptionBorderCornerRadius
        {
            get => (CornerRadius)GetValue(DescriptionBorderCornerRadiusProperty);
            set => SetValue(DescriptionBorderCornerRadiusProperty, value);
        }
        public static readonly DependencyProperty DescriptionBorderCornerRadiusProperty =
            DependencyProperty.Register(nameof(DescriptionBorderCornerRadius), typeof(CornerRadius), typeof(MapIconControl), new PropertyMetadata(new CornerRadius(3)));

        public Thickness DescriptionBorderPadding
        {
            get => (Thickness)GetValue(DescriptionBorderPaddingProperty);
            set => SetValue(DescriptionBorderPaddingProperty, value);
        }
        public static readonly DependencyProperty DescriptionBorderPaddingProperty =
            DependencyProperty.Register(nameof(DescriptionBorderPadding), typeof(Thickness), typeof(MapIconControl), new PropertyMetadata(new Thickness(0)));

        public Thickness DescriptionBorderThickness
        {
            get => (Thickness)GetValue(DescriptionBorderThicknessProperty);
            set => SetValue(DescriptionBorderThicknessProperty, value);
        }
        public static readonly DependencyProperty DescriptionBorderThicknessProperty =
            DependencyProperty.Register(nameof(DescriptionBorderThickness), typeof(Thickness), typeof(MapIconControl), new PropertyMetadata(new Thickness(2)));

        public Visibility DescriptionVisible
        {
            get => (Visibility)GetValue(DescriptionVisibleProperty);
            set => SetValue(DescriptionVisibleProperty, value);
        }
        public static readonly DependencyProperty DescriptionVisibleProperty =
            DependencyProperty.Register(nameof(DescriptionVisible), typeof(Visibility), typeof(MapIconControl), new PropertyMetadata(Visibility.Collapsed));

        public string HeadingText
        {
            get => (string)GetValue(HeadingTextProperty);
            set => SetValue(HeadingTextProperty, value);
        }
        public static readonly DependencyProperty HeadingTextProperty =
            DependencyProperty.Register(nameof(HeadingText), typeof(string), typeof(MapIconControl), new PropertyMetadata(ResLoader.GetString("MapIconContol/DefaultHeadingText")));

        public Visibility HeadingVisible
        {
            get => (Visibility)GetValue(HeadingVisibleProperty);
            set => SetValue(HeadingVisibleProperty, value);
        }
        public static readonly DependencyProperty HeadingVisibleProperty =
            DependencyProperty.Register(nameof(HeadingVisible), typeof(Visibility), typeof(MapIconControl), new PropertyMetadata(Visibility.Visible));

        public Brush MapIconBorderBrush
        {
            get => (Brush)GetValue(MapIconBorderBrushProperty);
            set => SetValue(MapIconBorderBrushProperty, value);
        }
        public static readonly DependencyProperty MapIconBorderBrushProperty =
            DependencyProperty.Register(nameof(MapIconBorderBrush), typeof(Brush), typeof(MapIconControl), new PropertyMetadata(new SolidColorBrush(Colors.Black)));

        public double MapIconBorderThickness
        {
            get => (double)GetValue(MapIconBorderThicknessProperty);
            set => SetValue(MapIconBorderThicknessProperty, value);
        }
        public static readonly DependencyProperty MapIconBorderThicknessProperty =
            DependencyProperty.Register(nameof(MapIconBorderThickness), typeof(double), typeof(MapIconControl), new PropertyMetadata(1.0));

        public string NotificationTimeDisplayedToUser
        {
            get => (string)GetValue(NotificationTimeDisplayedToUserProperty);
            set => SetValue(NotificationTimeDisplayedToUserProperty, value);
        }
        public static readonly DependencyProperty NotificationTimeDisplayedToUserProperty =
            DependencyProperty.Register(nameof(NotificationTimeDisplayedToUser), typeof(string), typeof(MapIconControl), new PropertyMetadata(ResLoader.GetString("MapIconContol/DefaultNotificationTime")));

        public Visibility NotificationTimeVisbible
        {
            get => (Visibility)GetValue(NotificationTimeVisbibleProperty);
            set => SetValue(NotificationTimeVisbibleProperty, value);
        }
        public static readonly DependencyProperty NotificationTimeVisbibleProperty =
            DependencyProperty.Register(nameof(NotificationTimeVisbible), typeof(Visibility), typeof(MapIconControl), new PropertyMetadata(Visibility.Visible));

        public DateTime NotificationTimeUtc => MapIconControlHelper.NotificationTimeUtc;

        public Visibility StatusVisible
        {
            get => (Visibility )GetValue(StatusVisibleProperty);
            set => SetValue(StatusVisibleProperty, value);
        }
        public static readonly DependencyProperty StatusVisibleProperty =
            DependencyProperty.Register(nameof(StatusVisible), typeof(Visibility), typeof(MapIconControl), new PropertyMetadata(Visibility.Visible));

        public string SubHeadingText
        {
            get => (string)GetValue(SubHeadingTextProperty);
            set => SetValue(SubHeadingTextProperty, value);
        }
        public static readonly DependencyProperty SubHeadingTextProperty =
            DependencyProperty.Register(nameof(SubHeadingText), typeof(string), typeof(MapIconControl), new PropertyMetadata(ResLoader.GetString("MapIconContol/DefaultSubHeadingText")));


        public Visibility SubHeadingVisible
        {
            get => (Visibility)GetValue(SubHeadingVisibleProperty);
            set => SetValue(SubHeadingVisibleProperty, value);
        }
        public static readonly DependencyProperty SubHeadingVisibleProperty =
            DependencyProperty.Register(nameof(SubHeadingVisible), typeof(Visibility), typeof(MapIconControl), new PropertyMetadata(Visibility.Visible));

        public MapIconControl(IMapIconControlHelper mapIconControlHelper = null)
        {
            Initialise(mapIconControlHelper);
        }

        private void Initialise(IMapIconControlHelper mapIconControlHelper = null)
        {
            DefaultStyleKey = typeof(MapIconControl);

            MapIconControlHelper = mapIconControlHelper ?? App.Container.Resolve<IMapIconControlHelper>();

            _removeMenuFlyoutItem.Text = ResLoader.GetString("RemoveMenuFlyoutItem/Text");
        }

        protected override void OnApplyTemplate()
        {
            InitialiseControlReferences();
            AttachEvents();
            TriggerStartUpEvents();
        }

        private void InitialiseControlReferences()
        {
            _myStoryboard = GetTemplateChild<Storyboard>("MyStoryboard");
            _descriptionBorderBackgroundAnimation = GetTemplateChild<ColorAnimation>("DescriptionBorderBackgroundAnimation");
            _descriptionBorderAnimation = GetTemplateChild<ColorAnimation>("DescriptionBorderAnimation");
            _mapIconFillPathAnimation = GetTemplateChild<ColorAnimation>("MapIconFillPathAnimation");
            _headingForegroundAnimation = GetTemplateChild<ColorAnimation>("HeadingForegroundAnimation");
            _headingForeground = GetTemplateChild<SolidColorBrush>("HeadingForeground");
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
            Tapped += MapIconControl_Tapped;
            ContextRequested += MapIconControl_ContextRequested;
        }

        private void MapIconControl_Tapped(object sender, TappedRoutedEventArgs args)
        {
            if (DescriptionVisible == Visibility.Collapsed)
            {
                NotificationTimeDisplayedToUser = DetermineNotificationTimeDisplay();
            }

            DescriptionVisible = DescriptionVisible == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        private void MapIconControl_ContextRequested(UIElement sender, ContextRequestedEventArgs args)
        {
            var menuFlyout = new MenuFlyout();
            menuFlyout.Items?.Add(_removeMenuFlyoutItem);

            args.TryGetPosition(sender, out var pointerPosition);
            menuFlyout.ShowAt(sender, pointerPosition);

            if (RemoveClicked != null)
            {
                _removeMenuFlyoutItem.Click += (s, e) => RemoveClicked(sender, e);
            }
        }

        private void TriggerStartUpEvents()
        {
            _colorAnimations = new List<ColorAnimation> { _descriptionBorderBackgroundAnimation, _descriptionBorderAnimation, _mapIconFillPathAnimation };

            if (AllowAnimateColor == AnimateColor.Aminate)
            {
                AnimatePinAndDescriptionColor();
            }
            // TODO: What about when AnimateColor is 'Static'?
        }

        private void AnimatePinAndDescriptionColor()
        {
            SetColorAnimationProperties();
            SetHeadingForegroundProperties();

            _myStoryboard.Begin();
        }

        private void SetColorAnimationProperties()
        {
            foreach (var colorAnimation in _colorAnimations)
            {
                colorAnimation.From = MapIconControlHelper.ColorAnimationSettings.FromColor;
                colorAnimation.To = MapIconControlHelper.ColorAnimationSettings.ToColor;
                colorAnimation.Duration = MapIconControlHelper.ColorAnimationSettings.Duration;
            }
        }

        private void SetHeadingForegroundProperties()
        {
            SetHeadingForegroundAnimationFromColor();

            var contrastChangeFactor = Converters.ColorToConstrastColorConverter.
                ContrastColorChangeFactor(MapIconControlHelper.ColorAnimationSettings.FromColor, MapIconControlHelper.ColorAnimationSettings.ToColor);
            var contrastColorChangeRequired = contrastChangeFactor != null;
            if (contrastColorChangeRequired)
            {
                SetBeginTimeForContrastChange(contrastChangeFactor);
            }

            SetHeadingForegroundAnimationToColor(contrastColorChangeRequired);
        }

        private void SetHeadingForegroundAnimationFromColor()
        {
            _headingForeground.Color = Converters.ColorToConstrastColorConverter.ConvertToConstractColor(MapIconControlHelper.ColorAnimationSettings.FromColor);
            _headingForegroundAnimation.From = _headingForeground.Color;
        }

        private void SetBeginTimeForContrastChange(double? contrastChangeFactor)
        {
            if (contrastChangeFactor == null) return;

            var intervalInMilliseconds = (int)(MapIconControlHelper.ColorAnimationSettings.Duration.TotalMilliseconds * contrastChangeFactor -
                                               _headingForegroundAnimation.Duration.TimeSpan.TotalMilliseconds / 2);
            _headingForegroundAnimation.BeginTime = new TimeSpan(0, 0, 0, 0, intervalInMilliseconds);
        }

        private void SetHeadingForegroundAnimationToColor(bool changeRequired)
        {
            if (changeRequired)
            {
                _headingForegroundAnimation.To = _headingForeground.Color == Colors.White ? Colors.Black : Colors.White;
            }
            else
            {
                _headingForegroundAnimation.To = _headingForegroundAnimation.From;
            }
        }

        private string DetermineNotificationTimeDisplay()
        {
            var timeSinceNotification = DateTime.UtcNow - NotificationTimeUtc;

            if (timeSinceNotification < TimeSpan.FromSeconds(60))
            {
                return timeSinceNotification.SecondsOnlyFormat();
            }

            if (timeSinceNotification < TimeSpan.FromMinutes(60))
            {
                return timeSinceNotification.MinutesOnlyFormat();
            }

            return timeSinceNotification < TimeSpan.FromHours(24) ? timeSinceNotification.HoursMinutesFormat() : timeSinceNotification.DaysHoursFormat();
        }
    }
}
