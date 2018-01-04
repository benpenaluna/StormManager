using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using StormManager.UWP.Annotations;
using StormManager.UWP.Common.ExtensionMethods;
using StormManager.UWP.Services.ResourceLoaderService;

namespace StormManager.UWP.Controls
{
    public sealed class MapIconControl : Control, INotifyPropertyChanged
    {
        private static readonly Image DefaultImage = new Image
        {
            Source = new BitmapImage
            {
                UriSource = new Uri(ResourceLoaderService.GetResourceValue("PushPinImageRed100pcLocation"))
            }
        };


        // TODO: Abstarct this string so that anything that implements IEnumerable can be used, and decided upon at run-time
        private static readonly string[] MapIconImageUpdates = {
            "PushPinImageRed10pcLocation",
            "PushPinImageRed20pcLocation",
            "PushPinImageRed30pcLocation",
            "PushPinImageRed40pcLocation",
            "PushPinImageRed50pcLocation",
            "PushPinImageRed60pcLocation",
            "PushPinImageRed70pcLocation",
            "PushPinImageRed90pcLocation",
            "PushPinImageRed90pcLocation",
            "PushPinImageRed100pcLocation"
        };

        private int _mapIconImageUpdatesIndexPointer;

        private readonly DispatcherTimer _timer = new DispatcherTimer(); 

        public Brush DescriptionBackgroundColor
        {
            get => (Brush)GetValue(DescriptionBackgroundColorProperty);
            set => SetValue(DescriptionBackgroundColorProperty, value);
        }
        public static readonly DependencyProperty DescriptionBackgroundColorProperty =
            DependencyProperty.Register(nameof(DescriptionBackgroundColor), typeof(Brush), typeof(MapIconControl), new PropertyMetadata(new SolidColorBrush(Colors.White)));

        public Brush DescriptionBorderColor
        {
            get => (Brush)GetValue(DescriptionBorderColorProperty);
            set => SetValue(DescriptionBorderColorProperty, value);
        }
        public static readonly DependencyProperty DescriptionBorderColorProperty =
            DependencyProperty.Register(nameof(DescriptionBorderColor), typeof(Brush), typeof(MapIconControl), new PropertyMetadata(new SolidColorBrush(Colors.Red)));

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

        public ImageSource MapIconImage
        {
            get => (ImageSource)GetValue(MapIconImageProperty);
            set
            {
                SetValue(MapIconImageProperty, value);
                OnPropertyChanged(nameof(MapIconImage));
            }
        }
        public static readonly DependencyProperty MapIconImageProperty =
            DependencyProperty.Register(nameof(MapIconImage), typeof(ImageSource), typeof(MapIconControl), new PropertyMetadata(DefaultImage.Source));

        public string NotificationTimeDisplayedToUser
        {
            get => (string)GetValue(NotificationTimeDisplayedToUserProperty);
            set => SetValue(NotificationTimeDisplayedToUserProperty, value);
        }
        public static readonly DependencyProperty NotificationTimeDisplayedToUserProperty =
            DependencyProperty.Register(nameof(NotificationTimeDisplayedToUser), typeof(string), typeof(MapIconControl), new PropertyMetadata("0 seconds ago"));

        public DateTime NotificationTimeUtc { get; set; }

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
        }

        protected override void OnApplyTemplate()
        {
            AttachEvents();
            StartMapIconImageUpdates();
        }

        private void AttachEvents()
        {
            Tapped += MapIconControl_Tapped;
            _timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, object e)
        {
            if (_mapIconImageUpdatesIndexPointer >= MapIconImageUpdates.Length)
            {
                _timer.Stop();
                _timer.Tick -= Timer_Tick;
                return;
            }

            UpdateMapIconImage();
        }

        private void UpdateMapIconImage()
        {
            var newImage = new Image
            {
                Source = new BitmapImage
                {
                    UriSource = new Uri(ResourceLoaderService.GetResourceValue(MapIconImageUpdates[_mapIconImageUpdatesIndexPointer++]))
                }
            };
            MapIconImage = newImage.Source;
        }

        private void StartMapIconImageUpdates()
        {
            _timer.Interval = new TimeSpan(0, 0, 2); // TODO: Structure this so that it is configurable at runtime, and takes into account the difference in time between notification time and creation of the pin  
            _timer.Start();
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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
