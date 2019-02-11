using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Windows.UI;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using StormManager.UWP.Utils;

namespace StormManager.UWP.Views
{
    public sealed partial class SettingsPage
    {
        private Color _myColor;

        readonly Services.SerializationService.ISerializationService _serializationService;

        public SettingsPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Required;
            _serializationService = Services.SerializationService.SerializationService.Json;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var index = int.Parse(_serializationService.Deserialize(e.Parameter?.ToString()).ToString());
            MyPivot.SelectedIndex = index;
        }

        private void confirmColor_Click(object sender, RoutedEventArgs e)
        {
            //_myColor = myColorPicker.Color;
            CloseColorPickerFlyOut();
        }

        private void cancelColor_Click(object sender, RoutedEventArgs e)
        {
            CloseColorPickerFlyOut();
        }

        private void CloseColorPickerFlyOut()
        {
            // TODO: Refactor this method!

            var dataTemplate = JobTypesGridView.ItemTemplate;
            var stackPanel = dataTemplate?.LoadContent() as StackPanel;
            var stackPanelChildren = stackPanel?.Children;

            var childStackPanels = new List<StackPanel>();
            foreach (var element in stackPanelChildren)
            {
                if (element.GetType() == typeof(StackPanel))
                {
                    childStackPanels.Add(element as StackPanel);
                }
            } 

            foreach (var panel in childStackPanels)
            {
                var children = panel.Children;
                foreach (var element in children)
                {
                    if (element.GetType() == typeof(Button))
                    {
                        var button = element as Button;
                        button?.Flyout?.Hide();
                        
                    }
                }



                
            }
            
            void ColorPickerButton_Tapped(object sender, TappedEventArgs e)
            {
                
            }


            //Debugger.Break();

            //var button = e.OriginalSource as Button;
            //var grid = button?.Parent as Grid;
            //var relativePanel = grid?.Parent as RelativePanel;
            //var flyOutPresenter = relativePanel.Parent as FlyoutPresenter;

            //var popup = flyOutPresenter.Parent as Popup;
            //Debugger.Break();

            //if (JobTypesGridView.Items == null)
            //{
            //    return;
            //}

            //foreach (var item in JobTypesGridView.Items)
            //{
            //    var container = JobTypesGridView.ItemContainerGenerator.ContainerFromItem(item);
            //}

            //var contentPresenter = FindVisualChild<ContentPresenter>(JobTypesGridView);
            //var scrollViewer = contentPresenter.FirstChild<ScrollViewer>();
            //var dataTemplate = contentPresenter.ContentTemplate;
            //var colorPickerButton = dataTemplate.AllChildren().OfType<Button>().First(x => x.Name.Equals("ColorPickerButton"));

            //colorPickerButton?.Flyout.Hide();

            //var gridView = JobTypesGridView;
            //var dataTemplate = JobTypesGridView.ItemTemplate;
            //var ctrls = dataTemplate.AllChildren();
            //Debugger.Break();
            //DependencyObject dataTemplate = JobTypesGridView.ItemTemplate;
            //var colorPickerButton = dataTemplate.AllChildren().OfType<Button>()
            //    .First(x => x.Name.Equals("ColorPickerButton"));
            //var colorPickerButton = AllChildren(dataTemplate).OfType<Button>()
            //    .First(x => x.Name.Equals("ColorPickerButton"));

            //colorPickerButton?.Flyout.Hide();
            //foreach (var gridViewItem in gridView.Items)
            //{
            //    try
            //    {
            //        //var container = gridView.ItemContainerGenerator.ContainerFromItem(gridViewItem);

            //        var container = gridView.Items.

            //        if (container == null)
            //        {
            //            break;
            //        }

            //        var children = AllChildren(container);
            //        const string name = "ColorPickerButton";
            //        var colorPickerButton = (Button) children.First(c => c.Name == name);

            //        colorPickerButton?.Flyout.Hide();
            //    }
            //    catch (Exception e)
            //    {
            //        Debug.WriteLine(e.Message);
            //    }


            //}
        }

        public List<Control> AllChildren(DependencyObject parent)
        {
            var list = new List<Control>();
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is Control item)
                {
                    list.Add(item);
                }
                list.AddRange(AllChildren(child));
            }

            return list;
        }

        //public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj)
        //    where T : DependencyObject
        //{
        //    if (depObj != null)
        //    {
        //        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
        //        {
        //            DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
        //            if (child != null && child is T)
        //            {
        //                yield return (T)child;
        //            }

        //            foreach (T childOfChild in FindVisualChildren<T>(child))
        //            {
        //                yield return childOfChild;
        //            }
        //        }
        //    }
        //}

        //public static childItem FindVisualChild<childItem>(DependencyObject obj)
        //    where childItem : DependencyObject
        //{
        //    foreach (childItem child in FindVisualChildren<childItem>(obj))
        //    {
        //        return child;
        //    }

        //    return null;
        //}
    }
}
