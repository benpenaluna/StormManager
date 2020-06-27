using StormManager.UWP.Common;
using StormManager.UWP.Common.Editing;
using StormManager.UWP.Models;
using StormManager.UWP.Mvvm;
using StormManager.UWP.Views.JobTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace StormManager.UWP.ViewModels.SettingPageViewModel
{
    public class JobTypesPartViewModel : ViewModelBase
    {
        private static bool _deletionRequested;
        protected static bool DeletionRequested
        {
            get { return _deletionRequested; }
            set 
            { 
                _deletionRequested = value;
                
                if (value)
                    DeletionRequestedOnChange?.Invoke(new object(), new EventArgs());
            }
        }

        protected static CompletionState EditCompletionState { get; set; }

        public static JobType EditedJobType { get; set; }

        private static EditCompletion _editModeCompletion;
        protected static EditCompletion EditModeCompletion
        {
            get => _editModeCompletion;
            set
            {
                _editModeCompletion = value;

                if (value == EditCompletion.Complete)
                    OnEditModeCompleted?.Invoke(new object(), new EventArgs());
            }
        }
        
        public ObservableCollection<JobType> JobTypes { get; set; }

        private static bool _navigateToEditMode;
        protected static bool NavigateToEditMode
        {
            get => _navigateToEditMode;
            set
            {
                _navigateToEditMode = value;

                if (value)
                    NavigateToEditModeOnChange?.Invoke(new object(), new EventArgs());
            }
        }

        public static int NewJobId = int.MinValue;

        public static IEnumerable<JobType> PersistedJobTypes;

        private Frame _selectedFrame = new Frame()
        {
            Background = (SolidColorBrush)Application.Current.Resources["UnusedPageBackgroundThemeBrush"]
        };
        public Frame SelectedFrame
        {
            get => _selectedFrame;
            set { _selectedFrame = value; RaisePropertyChanged(); }
        }
        
        private JobType _selectedJobType = new JobType();
        public JobType SelectedJobType
        {
            get => _selectedJobType;
            set { _selectedJobType = value; RaisePropertyChanged(); }
        }

        public JobTypesPartViewModel()
        {
            InitialiseCollections();
            AttachEventHandlers();
        }

        protected static event EventHandler DeletionRequestedOnChange;

        public static event EventHandler OnEditModeCompleted;
        
        protected static event EventHandler NavigateToEditModeOnChange;

        private void InitialiseCollections()
        {
            InitialiseJobTypesCollection();
            InitialiseEditCompletionProperties();
        }

        private void InitialiseJobTypesCollection()
        {
            JobTypes = new ObservableCollectionEx<JobType>();

            PersistedJobTypes = App.UnitOfWork.JobTypes.GetAllJobTypes();
            foreach (var jobType in PersistedJobTypes)
            {
                JobTypes.Add(new JobType(jobType));
            }

            if (JobTypes.Count > 0)
                SelectedJobType = JobTypes.FirstOrDefault();
        }

        private static void InitialiseEditCompletionProperties()
        {
            EditedJobType = new JobType();
            EditCompletionState = CompletionState.Undetermined;
            EditModeCompletion = EditCompletion.Incomplete;
        }

        private void AttachEventHandlers()
        {
            AttachJobTypeCollectionEventHandlers();

            AttachNavigationEventHanders();
        }

        private void AttachJobTypeCollectionEventHandlers()
        {
            foreach (var jobType in JobTypes)
            {
                jobType.PropertyChanged += JobTypes_PropertyChanged;
            }

            JobTypes.CollectionChanged += JobTypes_CollectionChanged;
            ((INotifyPropertyChanged)JobTypes).PropertyChanged += JobTypes_PropertyChanged;
        }

        private void AttachNavigationEventHanders()
        {
            if (DeletionRequestedOnChange is null)
                DeletionRequestedOnChange += new WeakEventHandler<EventArgs>(DeletionRequested_OnChanged).Handler;

            if (OnEditModeCompleted is null)
                OnEditModeCompleted += new WeakEventHandler<EventArgs>(JobTypesPartViewModel_EditModeCompleted).Handler;

            if (NavigateToEditModeOnChange is null)
                NavigateToEditModeOnChange += new WeakEventHandler<EventArgs>(NavigateToEditMode_OnChanged).Handler;
        }

        private void DeletionRequested_OnChanged(object sender, EventArgs e)
        {
            var jobForDeletion = new JobType(SelectedJobType);

            var index = JobTypes.IndexOf(SelectedJobType);

            SelectedJobType = index + 1 <= JobTypes.Count - 2 ? JobTypes[index + 1] : JobTypes[JobTypes.Count - 2];

            JobTypes.Remove(jobForDeletion);
        }

        private void JobTypesPartViewModel_EditModeCompleted(object sender, EventArgs e)
        {
            switch (EditCompletionState)
            {
                case CompletionState.Addition:
                    AddNewJobToCollection();
                    break;

                case CompletionState.Updated:
                    break;
            }

            ResetFrameToViewMode();
            ResetEditCompletionProperties();
        }

        private void NavigateToEditMode_OnChanged(object sender, EventArgs e)
        {
            if (NavigateToEditMode)
            {
                SelectedFrame.Navigate(typeof(JobTypesEditMode), new JobEdit(SelectedJobType, CompletionState.Updated));
            }
        }

        private void AddNewJobToCollection()
        {
            var editedJobType = new JobType(EditedJobType);

            JobTypes.Add(EditedJobType);
            ReOrderJobTypes();
            AttachJobTypeCollectionEventHandlers();
            
            UpdateSelectedJobType(editedJobType);
        }

        private void ReOrderJobTypes()
        {
            var reOrderedJobTypes = JobTypes.OrderBy(x => x.Category).ThenBy(x => x.SubCategory).ToList();
            JobTypes.Clear();
            foreach(var jobType in reOrderedJobTypes)
            {
                JobTypes.Add(jobType);
            }
        }

        private void UpdateSelectedJobType(JobType editedJobType)
        {
            if (JobTypes != null)
            {
                var newEditedJobType = JobTypes.Where(x => x.Id == editedJobType.Id);

                SelectedJobType = newEditedJobType != null ? newEditedJobType.FirstOrDefault() : JobTypes.FirstOrDefault();

                return;
            }

            SelectedJobType = JobTypes.FirstOrDefault();
        }

        private void ResetFrameToViewMode()
        {
            SelectedFrame.Navigate(typeof(JobTypesViewMode), SelectedJobType);
        }

        private static void ResetEditCompletionProperties()
        {
            InitialiseEditCompletionProperties();
        }

        private static void JobTypes_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                ProcessAdditions(e);

            if (e.OldItems != null)
                ProcessDeletions(e);
        }

        private static void ProcessAdditions(NotifyCollectionChangedEventArgs e)
        {
            foreach (var addedItem in e.NewItems)
            {
                if (!(addedItem is JobType jobType))
                    continue;

                App.UnitOfWork.JobTypes.Add(jobType);
            }
        }

        private static void ProcessDeletions(NotifyCollectionChangedEventArgs e)
        {
            foreach (var deletedItem in e.OldItems)
            {
                if (!(deletedItem is JobType jobType))
                    continue;

                App.UnitOfWork.JobTypes.Remove(jobType);
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
            return !PersistedJobTypes.Contains(jobType);
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> pageState, bool suspending)
        {
            await base.OnNavigatedFromAsync(pageState, suspending);
            
            DetachNavigationEventHandlers();

            await App.UnitOfWork.CompleteAsync();
        }

        private static void DetachNavigationEventHandlers()
        {
            DetachSubscribersFrom(DeletionRequestedOnChange);

            DetachSubscribersFrom(OnEditModeCompleted);

            DetachSubscribersFrom(NavigateToEditModeOnChange);
        }

        private static void DetachSubscribersFrom(EventHandler evnt)
        {
            foreach (var subscriber in evnt.GetInvocationList())
            {
                evnt -= (subscriber as EventHandler);
            }
        }

        public void JobTypesListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender == null || sender.GetType() != typeof(ListView))
                return;

            if ((sender as ListView)?.SelectedItem is JobType selection)
            {
                SelectedJobType = selection;
            }

            SelectedFrame.Navigate(typeof(JobTypesViewMode), SelectedJobType);
        }

        public void AddAppBarButton_OnClick(object sender, RoutedEventArgs e)
        {
            SelectedFrame.Navigate(typeof(JobTypesEditMode), new JobEdit(new JobType() { Id = NewJobId++ }, CompletionState.Addition));
        }

        public void FilterAppBarButton_OnClick(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}
