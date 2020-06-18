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
        public static int NewJobId = int.MinValue;

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

        protected static CompletionState EditCompletionState { get; set; }

        private JobType _selectedJobType = new JobType();

        private Frame _selectedFrame = new Frame()
        {
            Background = (SolidColorBrush)Application.Current.Resources["UnusedPageBackgroundThemeBrush"]
        };

        public Frame SelectedFrame
        {
            get => _selectedFrame;
            set { _selectedFrame = value; RaisePropertyChanged(); }
        }

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

        public JobType SelectedJobType
        {
            get => _selectedJobType;
            set { _selectedJobType = value; RaisePropertyChanged(); }
        }

        public static IEnumerable<JobType> PersistedJobTypes;

        public ObservableCollection<JobType> JobTypes { get; set; }

        public JobTypesPartViewModel()
        {
            InitialiseCollections();
            AttachEventHandlers();
        }

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
            foreach (var jobType in JobTypes)
            {
                jobType.PropertyChanged += JobTypes_PropertyChanged;
            }

            JobTypes.CollectionChanged += JobTypes_CollectionChanged;
            ((INotifyPropertyChanged)JobTypes).PropertyChanged += JobTypes_PropertyChanged;

            if (OnEditModeCompleted is null)
                OnEditModeCompleted += new WeakEventHandler<EventArgs>(JobTypesPartViewModel_EditModeCompleted).Handler;

            if (NavigateToEditModeOnChange is null)
                NavigateToEditModeOnChange += new WeakEventHandler<EventArgs>(NavigateToEditMode_OnChanged).Handler;
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
            JobTypes.Add(EditedJobType);
            SelectedJobType = EditedJobType;
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
            foreach (var addedItem in e.NewItems)
            {
                if (!(addedItem is JobType jobType))
                    continue;

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
            return !PersistedJobTypes.Contains(jobType);
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> pageState, bool suspending)
        {
            await base.OnNavigatedFromAsync(pageState, suspending);
            
            UnloadStaticEventHandlers();

            await App.UnitOfWork.CompleteAsync();
        }

        private static void UnloadStaticEventHandlers()
        {
            foreach (var d in OnEditModeCompleted.GetInvocationList())
            {
                OnEditModeCompleted -= (d as EventHandler);
            }

            foreach (var d in NavigateToEditModeOnChange.GetInvocationList())
            {
                NavigateToEditModeOnChange -= (d as EventHandler);
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
            throw new NotImplementedException();
        }
    }
}
