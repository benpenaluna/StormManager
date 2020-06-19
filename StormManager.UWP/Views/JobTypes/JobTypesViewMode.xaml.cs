using StormManager.UWP.Models;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace StormManager.UWP.Views.JobTypes
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class JobTypesViewMode : Page
    {
        private double ColorRectangleGridLength => 100.0D;

        public JobType JobType
        {
            get => (JobType)GetValue(MyPropertyProperty);
            set => SetValue(MyPropertyProperty, value);
        }
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register(nameof(JobType), typeof(int), typeof(JobTypesViewMode), new PropertyMetadata(new JobType()));

        public JobTypesViewMode()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null && e.Parameter.GetType() == typeof(JobType))
                JobType = (JobType)e.Parameter;

            base.OnNavigatedTo(e);
        }

        private async void DeleteJobTypeAppBarButton_OnClick(object sender, RoutedEventArgs e)
        {
            var result = await Delete_ContentDialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                ViewModel.DeleteJobTypeAppBarButton_OnClick(sender, e);
            }
        }
    }
}
