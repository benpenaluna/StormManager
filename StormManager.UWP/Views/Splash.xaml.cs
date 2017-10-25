using System;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace StormManager.UWP.Views
{
    public sealed partial class Splash
    {
        public Splash(SplashScreen splashScreen)
        {
            InitializeComponent();
            Window.Current.SizeChanged += (s, e) => Resize(splashScreen);
            Resize(splashScreen);
            Opacity = 0;
        }

        private void Resize(SplashScreen splashScreen)
        {
            if (Math.Abs(splashScreen.ImageLocation.Top) <= 0.1)
            {
                SplashImage.Visibility = Visibility.Collapsed;
                return;
            }
            else
            {
                RootCanvas.Background = null;
                SplashImage.Visibility = Visibility.Visible;
            }
            SplashImage.Height = splashScreen.ImageLocation.Height;
            SplashImage.Width = splashScreen.ImageLocation.Width;
            SplashImage.SetValue(Canvas.TopProperty, splashScreen.ImageLocation.Top);
            SplashImage.SetValue(Canvas.LeftProperty, splashScreen.ImageLocation.Left);
            ProgressTransform.TranslateY = SplashImage.Height / 2;
        }

        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            Opacity = 1;
        }
    }
}

