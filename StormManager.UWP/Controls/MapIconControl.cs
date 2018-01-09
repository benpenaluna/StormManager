using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Autofac;
using StormManager.UWP.Common.ExtensionMethods;
using StormManager.UWP.Controls.ControlHelpers;

namespace StormManager.UWP.Controls
{
    public sealed partial class MapIconControl : Control
    {
        private Storyboard _myStoryboard;
        private ColorAnimation _descriptionBorderBackgroundAnimation;
        private ColorAnimation _descriptionBorderAnimation;
        private ColorAnimation _mapIconFillPathAnimation;
        private ColorAnimation _headingForegroundAniation;
        private SolidColorBrush _headingForeground;

        private List<ColorAnimation> ColorAnimations;

        public AnimateColor AllowAnimateColor { get; set; }

        public IColorAnimationHelper ColorAnimationHelper { get; set; }

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

        //public Color FromColor
        //{
        //    get => (Color)GetValue(FromColorProperty);
        //    set => SetValue(FromColorProperty, value);
        //}
        //public static readonly DependencyProperty FromColorProperty =
        //    DependencyProperty.Register(nameof(FromColor), typeof(Color), typeof(MapIconControl), new PropertyMetadata(Colors.LightBlue));

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
            DependencyProperty.Register(nameof(NotificationTimeDisplayedToUser), typeof(string), typeof(MapIconControl), new PropertyMetadata("0 seconds ago"));

        public DateTime NotificationTimeUtc { get; set; }
        
        //public Color ToColor
        //{
        //    get => (Color)GetValue(ToColorProperty);
        //    set => SetValue(ToColorProperty, value);
        //}
        //public static readonly DependencyProperty ToColorProperty =
        //    DependencyProperty.Register(nameof(ToColor), typeof(Color), typeof(MapIconControl), new PropertyMetadata(Colors.Blue));

        public MapIconControl(IColorAnimationHelper colorAnimationHelper = null)
        {
            Initialise(DateTime.UtcNow, colorAnimationHelper);
        }

        public MapIconControl(DateTime notificationTimeUtc, IColorAnimationHelper colorAnimationHelper = null)
        {
            Initialise(notificationTimeUtc, colorAnimationHelper);
        }

        private void Initialise(DateTime notificationTimeUtc, IColorAnimationHelper colorAnimationHelper)
        {
            DefaultStyleKey = typeof(MapIconControl);
            NotificationTimeUtc = notificationTimeUtc;
            AllowAnimateColor = AnimateColor.Aminate;
            ColorAnimationHelper = colorAnimationHelper ?? App.Container.Resolve<IColorAnimationHelper>();
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
            _headingForegroundAniation = GetTemplateChild<ColorAnimation>("HeadingForegroundAniation");
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
        }

        private void TriggerStartUpEvents()
        {
            ColorAnimations = new List<ColorAnimation> { _descriptionBorderBackgroundAnimation, _descriptionBorderAnimation, _mapIconFillPathAnimation };

            if (AllowAnimateColor == AnimateColor.Aminate)
            {
                AnimatePinAndDescriptionColor();
            }
            // TODO: What about when AllowAnimateColor is 'Static'?
        }

        private void AnimatePinAndDescriptionColor()
        {
            SetColorAnimationProperties();
            SetHeadingForegroundProperties();

            _myStoryboard.Begin();
        }

        private void SetColorAnimationProperties()
        {
            foreach (var colorAnimation in ColorAnimations)
            {
                colorAnimation.From = ColorAnimationHelper.FromColor;
                colorAnimation.To = ColorAnimationHelper.ToColor;
                colorAnimation.Duration = ColorAnimationHelper.Duration;
            }
        }

        private void SetHeadingForegroundProperties()
        {
            SetHeadingForegroundAnimationFromColor();

            var contrastChangeFactor = Converters.ColorToConstrastColorConverter.ContrastColorChangeFactor(ColorAnimationHelper.FromColor, ColorAnimationHelper.ToColor);
            var contrastColorChangeRequired = contrastChangeFactor != null;
            if (contrastColorChangeRequired)
            {
                SetBeginTimeForContrastChange(contrastChangeFactor);
            }

            SetHeadingForegroundAnimationToColor(contrastColorChangeRequired);
        }

        private void SetHeadingForegroundAnimationFromColor()
        {
            _headingForeground.Color = Converters.ColorToConstrastColorConverter.ConvertToConstractColor(ColorAnimationHelper.FromColor);
            _headingForegroundAniation.From = _headingForeground.Color;
        }

        private void SetBeginTimeForContrastChange(double? contrastChangeFactor)
        {
            if (contrastChangeFactor == null) return;

            var intervalInMilliseconds = (int)(ColorAnimationHelper.Duration.TotalMilliseconds * contrastChangeFactor -
                                               _headingForegroundAniation.Duration.TimeSpan.TotalMilliseconds / 2);
            _headingForegroundAniation.BeginTime = new TimeSpan(0, 0, 0, 0, intervalInMilliseconds);
        }

        private void SetHeadingForegroundAnimationToColor(bool changeRequired)
        {
            if (changeRequired)
            {
                _headingForegroundAniation.To = _headingForeground.Color == Colors.White ? Colors.Black : Colors.White;
            }
            else
            {
                _headingForegroundAniation.To = _headingForegroundAniation.From;
            }
        }

        private void MapIconControl_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (DescriptionVisible == Visibility.Collapsed)
            {
                NotificationTimeDisplayedToUser = DetermineNotificationTimeDisplay();
            }

            DescriptionVisible = DescriptionVisible == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
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
