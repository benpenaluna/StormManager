using System;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace StormManager.UWP.Controls
{
    public class MapStylePresenter : IMapStylePresenter
    {
        private static readonly ImageSource DefaultImageSource = new BitmapImage(new Uri("ms-appx:///Assets/StoreLogo.png", UriKind.Absolute));

        public ImageSource MapImageSource { get; set; }

        public MapStyle MapStyle { get; set; }

        public Stretch Stretch { get; set; }

        public string Text { get; set; }

        public MapStylePresenter()
        {
            MapImageSource = DefaultImageSource;
            MapStyle = MapStyle.Road;
            Stretch = Stretch.None;
            Text = string.Empty;
        }
    }
}
