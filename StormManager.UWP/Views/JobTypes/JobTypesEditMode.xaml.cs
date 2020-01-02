using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using StormManager.UWP.Models;
using StormManager.UWP.ViewModels.SettingPageViewModel.JobTypesManipulationViewModels;

namespace StormManager.UWP.Views.JobTypes
{
    public sealed partial class JobTypesEditMode : Page
    {
        private double ColorRectangleGridLength => 100.0D; 
        
        public JobTypesEditMode()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null && e.Parameter.GetType() == typeof(JobType))
            {
                ((JobTypesEditModePartViewModel)DataContext).JobType = (JobType) e.Parameter;
            }

            base.OnNavigatedTo(e);
        }
    }
}
