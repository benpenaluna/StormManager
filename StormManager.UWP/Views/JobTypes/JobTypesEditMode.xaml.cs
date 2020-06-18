using StormManager.UWP.Common.Editing;
using StormManager.UWP.ViewModels.SettingPageViewModel.JobTypesManipulationViewModels;
using Windows.UI.Xaml.Navigation;

namespace StormManager.UWP.Views.JobTypes
{
    public sealed partial class JobTypesEditMode
    {
        private double ColorRectangleGridLength => 100.0D;

        public JobTypesEditMode()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null && e.Parameter.GetType() == typeof(JobEdit))
            {
                ((JobTypesEditModePartViewModel)DataContext).JobType = ((JobEdit)e.Parameter).JobType;
                ((JobTypesEditModePartViewModel)DataContext).CompletionState = ((JobEdit)e.Parameter).CompletionState;
            }

            base.OnNavigatedTo(e);
        }
    }
}
