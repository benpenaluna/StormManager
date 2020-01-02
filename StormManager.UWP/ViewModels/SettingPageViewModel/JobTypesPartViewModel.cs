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
using StormManager.UWP.Common;
using StormManager.UWP.Common.Editing;
using StormManager.UWP.Models;
using StormManager.UWP.Mvvm;
using StormManager.UWP.Views.JobTypes;

namespace StormManager.UWP.ViewModels.SettingPageViewModel
{
    public class JobTypesPartViewModel : ViewModelBase
    {
        private const int AddButtonId = -1;

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

        protected static CompletionState  EditCompletionState { get; set; }

        private JobType _selectedJobType = new JobType();
        
        private Frame _selectedFrame = new Frame()
        {
            Background=(SolidColorBrush)Application.Current.Resources["UnusedPageBackgroundThemeBrush"]
        };
        
        public Frame SelectedFrame
        {
            get => _selectedFrame;
            set { _selectedFrame = value; RaisePropertyChanged(); }
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

        private void InitialiseCollections()
        {
            JobTypes = new ObservableCollectionEx<JobType>();

            PersistedJobTypes = App.UnitOfWork.JobTypes.GetAllJobTypes();
            foreach (var jobType in PersistedJobTypes)
            {
                JobTypes.Add(new JobType(jobType));
            }

            if (JobTypes.Count > 0)
                SelectedJobType = JobTypes.FirstOrDefault();

            SetEditCompletionProperties();
        }

        private static void SetEditCompletionProperties()
        {
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
            ((INotifyPropertyChanged) JobTypes).PropertyChanged += JobTypes_PropertyChanged;

            OnEditModeCompleted += JobTypesPartViewModel_EditModeCompleted;
        }

        private void JobTypesPartViewModel_EditModeCompleted(object sender, EventArgs e)
        {
            switch (EditCompletionState)
            {
                case CompletionState.Undetermined:
                
                case CompletionState.Cancelled:
                    ResetFrameToViewMode();
                    break;
                
                case CompletionState.Completed:
                    break;
                
                case CompletionState.Deleted:
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            SetEditCompletionProperties();
        }

        private void ResetFrameToViewMode()
        {
            SelectedFrame.Navigate(typeof(JobTypesViewMode), SelectedJobType);
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
            return jobType?.Id != AddButtonId && !PersistedJobTypes.Contains(jobType);
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> pageState, bool suspending)
        {
            await base.OnNavigatedFromAsync(pageState, suspending);

            await App.UnitOfWork.CompleteAsync();
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
            SelectedFrame.Navigate(typeof(JobTypesEditMode), new JobType());
        }
    }
}
