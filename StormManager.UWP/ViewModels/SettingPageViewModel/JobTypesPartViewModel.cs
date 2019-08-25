﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using StormManager.UWP.Common;
using StormManager.UWP.Models;
using StormManager.UWP.Mvvm;

namespace StormManager.UWP.ViewModels.SettingPageViewModel
{
    public class JobTypesPartViewModel : ViewModelBase
    {
        private const int AddButtonId = -1;

        private static int newJobTypeId = int.MaxValue; 

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
            AddDummyJobTypeForAddButton();

            PersistedJobTypes = App.UnitOfWork.JobTypes.GetAllJobTypes();
            foreach (var jobType in PersistedJobTypes)
            {
                JobTypes.Add(new JobType(jobType));
            }
        }

        private void AddDummyJobTypeForAddButton()
        {
            JobTypes.Add(new JobType {Id = AddButtonId});
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
            foreach (var addedItem in e.NewItems)
            {
                if (!(addedItem is JobType jobType))
                    continue;

                //App.UnitOfWork.JobTypes.AddJobType(jobType);
                App.UnitOfWork.JobTypes.Add(jobType);
            }
        }

        private static void JobTypes_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender == null || sender.GetType() != typeof(JobType))
                return;

            var jobType = sender as JobType;
            if (JobWasUpdated(jobType))
                App.UnitOfWork.JobTypes.UpdateJobType(jobType);
        }

        private static bool JobWasUpdated(JobType jobType)
        {
            return jobType?.Id != AddButtonId && !PersistedJobTypes.Contains(jobType);
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> pageState, bool suspending)
        {
            await base.OnNavigatedFromAsync(pageState, suspending);

            await App.UnitOfWork.CompleteAsync();
        }

        public void JobTypesGridView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is JobType selection && selection.Id != AddButtonId)
                return;

            // TODO: Add logic to add a new Job Type
            // TODO: Default color should be configurable at runtime
            JobTypes.Add(new JobType
            {
                Id = newJobTypeId--,
                Category = "New Category", // TODO: Add this to resources
                SubCategory = "New Sub Category", // TODO: Add this to resources
                IsUsed = true,
                NewJobColorWindowUi = Color.FromArgb(255,105,105,105),
                AgingJobColorWindowUi = Color.FromArgb(255, 0, 0, 0),
                DateUpdated = DateTime.UtcNow,
                UpdatedBy = "sqladmin" // TODO: This needs to be updated
            });

        }
    }
}
