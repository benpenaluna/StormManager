using System.Diagnostics;
using Windows.UI.Xaml;

namespace StormManager.UWP.ViewModels.SettingPageViewModel.JobTypesManipulationViewModels
{
    public class JobTypesViewModePartViewModel : JobTypesPartViewModel
    {
        public void DeleteJobTypeAppBarButton_OnClick(object sender, RoutedEventArgs e)
        {
            DeletionRequested = true;
        }

        public void EditHyperlinkButton_OnClick(object sender, RoutedEventArgs e)
        {
            NavigateToEditMode = true;
        }
    }
}
