using Microsoft.Xaml.Interactivity;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace StormManager.UWP.Behaviors
{
    // Source: https://github.com/Windows-XAML/Template10/blob/version_1.1.12/Template10%20(Library)/Behaviors/FocusAction.cs

    public class FocusAction : DependencyObject, IAction
    {
        public object Execute(object sender, object parameter)
        {
            Control ui;
            if (TargetObject != null)
                ui = TargetObject;
            else
                ui = sender as Control;
            if (ui != null)
                ui.Focus(FocusState.Programmatic);
            return null;
        }

        public Control TargetObject
        {
            get { return (Control)GetValue(TargetObjectProperty); }
            set { SetValue(TargetObjectProperty, value); }
        }
        public static readonly DependencyProperty TargetObjectProperty =
            DependencyProperty.Register(nameof(TargetObject), typeof(Control), typeof(FocusAction), new PropertyMetadata(null));
    }
}
