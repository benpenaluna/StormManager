using Windows.UI.Xaml;

namespace StormManager.UWP.ViewModels.SettingPageViewModel.JobTypesManipulationViewModels
{
    public class JobTypesViewModePartViewModel : JobTypesPartViewModel
    {


        public void EditHyperlinkButton_OnClick(object sender, RoutedEventArgs e)
        {
            NavigateToEditMode = true;
        }
    }
}
