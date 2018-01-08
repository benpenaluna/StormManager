using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using StormManager.UWP.Common.ExtensionMethods;

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

        //private DispatcherTimer _headingForegroundChangeTimer;

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
                var contrastChangeFactor = Converters.ColorToConstrastColorConverter.ContrastColorChangeFactor(FromColor, ToColor);
                if (contrastChangeFactor != null)
                {
                    var interval = (int) (20000 * contrastChangeFactor - 500); // TODO: 'Bind' '20000' to the Duration property when created 
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
    }
}
