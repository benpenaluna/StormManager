using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using StormManager.UWP.Services.ResourceLoaderService;

namespace StormManager.UWP.Controls
{
    public sealed class MapIconControl : Control
    {
        private static readonly Image DefaultImage = new Image
        {
            Source = new BitmapImage
            {
                UriSource = new Uri(ResourceLoaderService.GetResourceValue("PushPinImageRedLocation"))
            }
        };

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
            set => SetValue(MapIconImageProperty, value);
        }
        public static readonly DependencyProperty MapIconImageProperty =
            DependencyProperty.Register(nameof(MapIconImage), typeof(ImageSource), typeof(MapIconControl), new PropertyMetadata(DefaultImage.Source));

        public MapIconControl()
        {
            DefaultStyleKey = typeof(MapIconControl);
        }

        protected override void OnApplyTemplate()
        {
            Tapped += (s, e) => DescriptionVisible = DescriptionVisible == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }
    }
}
