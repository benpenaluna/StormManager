using System.Collections.Generic;
using System.Threading.Tasks;
using StormManager.UWP.Mvvm;

namespace StormManager.UWP.ViewModels.SettingPageViewModel
{
    public class SettingsPageViewModel : ViewModelBase, ISettingsPageViewModel
    {
        public SettingsPartViewModel SettingsPartViewModel { get; } = new SettingsPartViewModel();
        public JobTypesPartViewModel JobTypesPartViewModel { get; } = new JobTypesPartViewModel();
        public AboutPartViewModel AboutPartViewModel { get; } = new AboutPartViewModel();

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> pageState, bool suspending)
        {
            await base.OnNavigatedFromAsync(pageState, suspending);

            await JobTypesPartViewModel.OnNavigatedFromAsync(pageState, suspending);
        }
    }
}

