using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using StormManager.UWP.Properties;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace StormManager.UWP.Controls
{
    public sealed class MapRadioButton : RadioButton, IMapStylePresenter, INotifyPropertyChanged
    {
        private static readonly ImageSource DefaultImageSource = new BitmapImage(new Uri("ms-appx:///Assets/StoreLogo.png", UriKind.Absolute));

        public ImageSource MapImageSource
        {
            get => (ImageSource)GetValue(MapImageSourceProperty);
            set
            {
                SetValue(MapImageSourceProperty, value);
                OnPropertyChanged(nameof(MapImageSource));
            }
        }
        public static readonly DependencyProperty MapImageSourceProperty =
            DependencyProperty.Register(nameof(MapImageSource), typeof(ImageSource), typeof(MapRadioButton), new PropertyMetadata(DefaultImageSource));

        public List<MapStylePresenter> MapStylePresenters { get; set; }


        public MapStyle MapStyle
        {
            get => (MapStyle)GetValue(MapStyleProperty);
            set
            {
                SetValue(MapStyleProperty, value);
                OnPropertyChanged(nameof(MapStyle));
            }
        }

        public static readonly DependencyProperty MapStyleProperty =
            DependencyProperty.Register(nameof(MapStyle), typeof(MapStyle), typeof(MapRadioButton), new PropertyMetadata(MapStyle.Road));

        public Stretch Stretch
        {
            get => (Stretch)GetValue(StretchProperty);
            set
            {
                SetValue(StretchProperty, value);
                OnPropertyChanged(nameof(Stretch));
            }
        }
        public static readonly DependencyProperty StretchProperty =
            DependencyProperty.Register(nameof(Stretch), typeof(Stretch), typeof(MapRadioButton), new PropertyMetadata(Stretch.None));

        public string Text => Content == null ? string.Empty : Content.ToString();

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
