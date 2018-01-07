using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using StormManager.UWP.Annotations;
using StormManager.UWP.Common.ExtensionMethods;

namespace StormManager.UWP.Controls
{
    public sealed partial class MapIconControl : Control, INotifyPropertyChanged
    {
        private Storyboard _myStoryboard;
        private ColorAnimation _descriptionBorderBackgroundAnimation;
        private ColorAnimation _descriptionBorderAnimation;
        private ColorAnimation _mapIconFillPathAnimation;
        private ColorAnimation _headingForegroundAniation;
        private SolidColorBrush _headingForeground;

        private DispatcherTimer _headingForegroundChangeTimer;

        public AnimateColor AllowAnimateColor { get; set; }

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

        public Color FromColor
        {
            get => (Color)GetValue(FromColorProperty);
            set => SetValue(FromColorProperty, value);
        }
        public static readonly DependencyProperty FromColorProperty =
            DependencyProperty.Register(nameof(FromColor), typeof(Color), typeof(MapIconControl), new PropertyMetadata(Colors.LightBlue));

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
        
        public Color ToColor
        {
            get => (Color)GetValue(ToColorProperty);
            set => SetValue(ToColorProperty, value);
        }
        public static readonly DependencyProperty ToColorProperty =
            DependencyProperty.Register(nameof(ToColor), typeof(Color), typeof(MapIconControl), new PropertyMetadata(Colors.Blue));

        public MapIconControl()
        {
            Initialise(DateTime.UtcNow);
        }

        public MapIconControl(DateTime notificationTimeUtc)
        {
            Initialise(notificationTimeUtc);
        }

        private void Initialise(DateTime notificationTimeUtc)
        {
            DefaultStyleKey = typeof(MapIconControl);
            NotificationTimeUtc = notificationTimeUtc;
            AllowAnimateColor = AnimateColor.Aminate;
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
            if (AllowAnimateColor == AnimateColor.Aminate)
            {
                SetColorAnimationProperties(_descriptionBorderBackgroundAnimation);
                SetColorAnimationProperties(_descriptionBorderAnimation);
                SetColorAnimationProperties(_mapIconFillPathAnimation);

                // TODO: REFACTOR THIS AND MAKE IT READABLE!

                _headingForeground.Color = Converters.ColorToConstrastColorConverter.ConvertToConstractColor(FromColor);
                _headingForegroundAniation.From = _headingForeground.Color;
                var contrastChangeFactor = ContrastColorChangeFactor(FromColor, ToColor);
                if (contrastChangeFactor != null)
                {
                    var interval = (int) (20000 * contrastChangeFactor); // TODO: 'Bind' '20000' to the Duration property when created 
                    _headingForegroundAniation.To = _headingForeground.Color == Colors.White ? Colors.Black : Colors.White;
                    _headingForegroundAniation.BeginTime = new TimeSpan(0, 0, 0, 0, interval);
                }
                else
                {
                    _headingForegroundAniation.To = _headingForeground.Color;
                }

                _myStoryboard.Begin();
            }
            // TODO: What about when AllowAnimateColor is 'Static'?
        }

        private void SetColorAnimationProperties(ColorAnimation colorAnimation)
        {
            colorAnimation.From = FromColor;
            colorAnimation.To = ToColor;
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

        // TODO: Move ContrastColorChangeFactor to a more suitable location (and test it) - It doesn't belong in this class
        private double? ContrastColorChangeFactor(Color fromColor, Color toColor) 
        {
            // TODO: Refactor this method and make it readable
            var fromColorContrastValue = Converters.ColorToConstrastColorConverter.ContrastValue(fromColor);
            var toColorContrastValue = Converters.ColorToConstrastColorConverter.ContrastValue(toColor);

            if ((fromColorContrastValue <= 128 && toColorContrastValue <= 128) ||
                (fromColorContrastValue > 128 && toColorContrastValue > 128))
            {
                return null;
            }
            
            var factor = 0.5;
            var lowColor = fromColorContrastValue < toColorContrastValue ? fromColor : toColor;
            var highColor = fromColorContrastValue < toColorContrastValue ? toColor : fromColor;

            var midColor = FindMidColor(fromColor, toColor);

            var factorAlteration = 0.25;
            var midColorContrastValue = Converters.ColorToConstrastColorConverter.ContrastValue(midColor);
            while (midColorContrastValue < 127.0 || midColorContrastValue > 128.0)
            {
                if (midColorContrastValue > 127.5)
                {
                    highColor = midColor;
                    factor -= factorAlteration; 
                }
                else
                {
                    lowColor = midColor;
                    factor += factorAlteration;
                }

                midColor = FindMidColor(lowColor, highColor);
                midColorContrastValue = Converters.ColorToConstrastColorConverter.ContrastValue(midColor);

                factorAlteration /= 2.0;
            }

            return factor;
        }

        // TODO: Move FindMidColor to a more suitable location (and test it) - It doesn't belong in this class
        private Color FindMidColor(Color color1, Color color2)
        {
            var a = Convert.ToByte(Math.Min(color1.A, color2.A) + Math.Abs(color1.A - color2.A) / 2);
            var r = Convert.ToByte(Math.Min(color1.R, color2.R) + Math.Abs(color1.R - color2.R) / 2);
            var g = Convert.ToByte(Math.Min(color1.G, color2.G) + Math.Abs(color1.G - color2.G) / 2);
            var b = Convert.ToByte(Math.Min(color1.B, color2.B) + Math.Abs(color1.B - color2.B) / 2);
            return Color.FromArgb(a, r, g, b);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
