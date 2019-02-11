using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Store;
using Windows.UI;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace StormManager.UWP.Controls
{
    public class ColorPickerButton : Control
    {
        private ColorPicker _myColorPicker;
        private Button _baseButton;
        private Button _cancelButton;

        private Color _originalColor;

        public Color Color
        {
            get => (Color) GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register(nameof(Color), typeof(Color), typeof(ColorPickerButton), new PropertyMetadata(Colors.White));

        public object Content
        {
            get => (object)GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register(nameof(Content), typeof(object), typeof(ColorPickerButton), new PropertyMetadata(string.Empty));

        public ColorPickerButton()
        {
            DefaultStyleKey = typeof(ColorPickerButton);
        }

        protected override void OnApplyTemplate()
        {
            InitialiseControlReferences();
            AttachEvents();

            _originalColor = Color;
        }

        private void InitialiseControlReferences()
        {
            _myColorPicker = GetTemplateChild<ColorPicker>("MyColorPicker");
            _baseButton = GetTemplateChild<Button>("BaseButton");
            _cancelButton = GetTemplateChild<Button>("CancelButton");
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
            _myColorPicker.ColorChanged += MyColorPicker_ColorChanged;
            _baseButton.Tapped += BaseButton_Tapped;
            _cancelButton.Tapped += CancelButton_Tapped;
        }

        private void MyColorPicker_ColorChanged(ColorPicker sender, ColorChangedEventArgs args)
        {
            Color = args.NewColor;
        }

        private void BaseButton_Tapped(object sender, TappedRoutedEventArgs args)
        {
            _originalColor = Color;
        }

        private void CancelButton_Tapped(object sender, TappedRoutedEventArgs args)
        {
            Color = _originalColor;
        }
    }
}
