using System.Collections.ObjectModel;
using StormManager.Standard.Models;
using StormManager.UWP.Cache;
using StormManager.UWP.Mvvm;

namespace StormManager.UWP.ViewModels.SettingPageViewModel
{
    public class JobTypesPartViewModel : ViewModelBase
    {
        public ObservableCollection<Models.JobType> JobTypes { get; set; }

        public JobTypesPartViewModel()
        {
            JobTypes = new ObservableCollection<Models.JobType>(AppCache.JobTypes);
        }
    }
}
