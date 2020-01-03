using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using StormManager.UWP.Common.Editing;
using StormManager.UWP.Models;

namespace StormManager.UWP.ViewModels.SettingPageViewModel.JobTypesManipulationViewModels
{
    public class JobTypesEditModePartViewModel : JobTypesPartViewModel
    {
        private bool _pageLoaded;

        public CompletionState CompletionState { get; set; }

        private JobType _jobType;
        public JobType JobType
        {
            get => _jobType;
            set { _jobType = value; RaisePropertyChanged(); }
        }

        private bool _saveButtonEnabled;
        public bool SaveButtonEnabled
        {
            get => _saveButtonEnabled;
            set { _saveButtonEnabled = value; RaisePropertyChanged(); }
        }
        
        public JobTypesEditModePartViewModel()
        {
            InitialiseProperties();
        }

        private void InitialiseProperties()
        {
            JobType = new JobType();
            DisableSaveButton();
        }

        private void DisableSaveButton()
        {
            SaveButtonEnabled = false;
        }

        private void EnableSaveButton()
        {
            SaveButtonEnabled = true;
        }

        public void CategoryTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            EnableSaveButton();
        }

        public void SubCategoryTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            EnableSaveButton();
        }

        public void NewJobColorPicker_OnColorChanged(object sender, ColorChangedEventArgs args)
        {
            EnableSaveButton();
        }

        public void AgingJobColorPicker_OnColorChanged(object sender, ColorChangedEventArgs args)
        {
            EnableSaveButton();
        }

        public void ToggleSwitch_OnToggled(object sender, RoutedEventArgs e)
        {
            if (HandleToggleSwitchLoadBehaviour(e.OriginalSource)) 
                return;

            EnableSaveButton();
        }

        private bool HandleToggleSwitchLoadBehaviour(object toggleSwitch)
        {
            if (toggleSwitch == null || toggleSwitch.GetType() != typeof(ToggleSwitch))
                return true;

            if (_pageLoaded && (toggleSwitch as ToggleSwitch)?.IsOn != JobType.IsUsed) 
                return false;
            
            _pageLoaded = true;
            return true;
        }

        public void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            EditedJobType = JobType;
            EditCompletionState = CompletionState;
            EditModeCompletion = EditCompletion.Complete;
        }

        public void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            EditCompletionState = CompletionState.Cancelled;
            EditModeCompletion = EditCompletion.Complete;
        }
    }
}
