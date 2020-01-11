using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
