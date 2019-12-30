using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using StormManager.UWP.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace StormManager.UWP.Views.JobTypes
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class JobTypesEditMode : Page
    {
        private double ColorRectangleGridLength => 100.0D; 
        
        public JobType JobType
        {
            get => (JobType)GetValue(MyPropertyProperty);
            set => SetValue(MyPropertyProperty, value);
        }
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register(nameof(JobType), typeof(int), typeof(JobTypesEditMode), new PropertyMetadata(new JobType()));

        public JobTypesEditMode()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null && e.Parameter.GetType() == typeof(JobType))
                JobType = (JobType)e.Parameter;

            base.OnNavigatedTo(e);
        }

        //private void CategoryTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        //{
        //    JobType.Category = CategoryTextBox.Text;
        //}
    }
}
