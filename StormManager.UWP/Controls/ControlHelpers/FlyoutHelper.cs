using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;

namespace StormManager.UWP.Controls.ControlHelpers
{
    public static class FlyoutHelper
    {
        public static readonly DependencyProperty IsVisibleProperty =
            DependencyProperty.RegisterAttached(
                "IsOpen", typeof(bool), typeof(FlyoutHelper),
                new PropertyMetadata(true, IsOpenChangedCallback));

        public static readonly DependencyProperty ParentProperty =
            DependencyProperty.RegisterAttached(
                "Parent", typeof(FrameworkElement), typeof(FlyoutHelper), null);

        public static void SetIsOpen(DependencyObject element, bool value)
        {
            element.SetValue(IsVisibleProperty, value);
        }

        public static bool GetIsOpen(DependencyObject element)
        {
            return (bool)element.GetValue(IsVisibleProperty);
        }

        private static void IsOpenChangedCallback(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            if (!(d is FlyoutBase fb))
                return;

            if ((bool)e.NewValue)
            {
                fb.Closed += Flyout_Closed;
                fb.ShowAt(GetParent(d));
            }
            else
            {
                fb.Closed -= Flyout_Closed;
                fb.Hide();
            }
        }

        private static void Flyout_Closed(object sender, object e)
        {
            // When the flyout is closed, sets its IsOpen attached property to false.
            SetIsOpen(sender as DependencyObject, false);
        }

        public static void SetParent(DependencyObject element, FrameworkElement value)
        {
            element.SetValue(ParentProperty, value);
        }

        public static FrameworkElement GetParent(DependencyObject element)
        {
            return (FrameworkElement)element.GetValue(ParentProperty);
        }
    }
}
