using System.Collections.ObjectModel;
using StormManager.Standard.Models;
using StormManager.UWP.Cache;
using StormManager.UWP.Common;
using StormManager.UWP.Mvvm;

namespace StormManager.UWP.ViewModels.SettingPageViewModel
{
    public class JobTypesPartViewModel : ViewModelBase
    {
        public ObservableCollection<Models.JobType> JobTypes { get; set; }

        //public RelayCommand SendCommand { get; set; }

        private bool isFlyoutOpen;
        public bool IsFlyoutOpen
        {
            get => isFlyoutOpen;
            set { this.Set(() => isFlyoutOpen, ref isFlyoutOpen, value); }
        }
        
        public JobTypesPartViewModel()
        {
            JobTypes = new ObservableCollection<Models.JobType>(AppCache.JobTypes);

            //SendCommand = new RelayCommand(() => { IsFlyoutOpen = false; });
    }
    }
}
