using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using StormManager.UWP.Common;
using StormManager.UWP.Models;
using StormManager.UWP.Mvvm;
using StormManager.UWP.Services.NavigationService;

namespace StormManager.UWP.ViewModels.SettingPageViewModel
{
    public class JobTypesPartViewModel : ViewModelBase
    {
        public static IEnumerable<JobType> PersistedJobTypes;

        public ObservableCollection<JobType> JobTypes { get; set; }

        public JobTypesPartViewModel()
        {
            InitialiseCollections();
            AttachEventHandlers();
        }

        private void InitialiseCollections()
        {
            JobTypes = new ObservableCollectionEx<JobType>();
            PersistedJobTypes = App.UnitOfWork.JobTypes.GetAllJobTypes();
            foreach (var jobType in PersistedJobTypes)
            {
                JobTypes.Add(new JobType(jobType));
            }
        }

        private void AttachEventHandlers()
        {
            foreach (var jobType in JobTypes)
            {
                jobType.PropertyChanged += JobTypes_PropertyChanged;
            }

            JobTypes.CollectionChanged += JobTypes_CollectionChanged;
            ((INotifyPropertyChanged) JobTypes).PropertyChanged += JobTypes_PropertyChanged;
        }

        private static void JobTypes_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Debugger.Break();
        }

        private static void JobTypes_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender == null || sender.GetType() != typeof(JobType))
                return;

            if (!PersistedJobTypes.Contains((JobType)sender))
            {
                //Debugger.Break();

                App.UnitOfWork.JobTypes.UpdateJobType((JobType) sender);

                //try
                //{
                //    TODO: Create a procedure in the webApiService that handles this, in order to de-couple the view model from the service
                //    IWebApiService webApiService = App.Container.Resolve<IWebApiService>();
                //    await webApiService.PutAsync("Update_JobTypes", (JobType)sender);  // TODO: Remove literal string
                //}
                //catch (Exception exception)
                //{
                //     TODO: Handle the exceptions
                //    Console.WriteLine(exception);
                //    throw;
                //}


                //TODO: Update AppCache.JobTypes
            }
        }

        public override Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            App.UnitOfWork.Complete();

            return base.OnNavigatingFromAsync(args);
        }

        public override Task OnNavigatedFromAsync(IDictionary<string, object> pageState, bool suspending)
        {
            App.UnitOfWork.Complete();

            return base.OnNavigatedFromAsync(pageState, suspending);
        }
    }
}
