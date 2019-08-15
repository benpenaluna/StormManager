using System.Threading.Tasks;
using StormManager.UWP.Mvvm;
using StormManager.UWP.Services.NavigationService;

namespace StormManager.UWP.ViewModels.SettingPageViewModel
{
    public class SettingsPageViewModel : ViewModelBase, ISettingsPageViewModel
    {
        public SettingsPartViewModel SettingsPartViewModel { get; } = new SettingsPartViewModel();
        public JobTypesPartViewModel JobTypesPartViewModel { get; } = new JobTypesPartViewModel();
        public AboutPartViewModel AboutPartViewModel { get; } = new AboutPartViewModel();

        public override Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            JobTypesPartViewModel.OnNavigatingFromAsync(args);
            return base.OnNavigatingFromAsync(args);
        }
    }
}

