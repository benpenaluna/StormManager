using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using Autofac;
using StormManager.UWP.Cache;
using StormManager.UWP.Common;
using StormManager.UWP.Models;
using StormManager.UWP.Mvvm;
using StormManager.UWP.Services.WebApiService;

namespace StormManager.UWP.ViewModels.SettingPageViewModel
{
    public class JobTypesPartViewModel : ViewModelBase
    {
        public ObservableCollection<JobType> JobTypes { get; set; }

        public JobTypesPartViewModel()
        {
            JobTypes = new ObservableCollectionEx<JobType>();
            foreach (var jobType in AppCache.JobTypes)
            {
                JobTypes.Add(new JobType(jobType));
            }

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

        private static async void JobTypes_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender == null || sender.GetType() != typeof(JobType))
                return;

            if (!AppCache.JobTypes.Contains((JobType)sender))
            {
                //Debugger.Break();

                try
                {
                    //TODO: Create a procedure in the webApiService that handles this, in order to de-couple the view model from the service
                    IWebApiService webApiService = App.Container.Resolve<IWebApiService>();
                    await webApiService.PutAsync("Update_JobTypes", (JobType)sender);
                }
                catch (Exception exception)
                {
                    // TODO: Handle the exceptions
                    Console.WriteLine(exception);
                    throw;
                }
                 

                //TODO: Update AppCache.JobTypes
            }
        }
    }
}
