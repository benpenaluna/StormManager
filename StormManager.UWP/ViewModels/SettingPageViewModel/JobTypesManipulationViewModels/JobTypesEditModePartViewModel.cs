using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using StormManager.UWP.Common.Editing;
using StormManager.UWP.Models;
using StormManager.UWP.Services.ResourceLoaderService;

namespace StormManager.UWP.ViewModels.SettingPageViewModel.JobTypesManipulationViewModels
{
    public class JobTypesEditModePartViewModel : JobTypesPartViewModel
    {
        private bool _pageLoaded;

        private CompletionState  _completionState;

        public CompletionState CompletionState
        {
            get => _completionState;
            set
            {
                _completionState = value;
                UpdateTitleText();
            }
        }

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

        private string _titleText;

        public string TitleText
        {
            get => _titleText;
            set { _titleText = value; RaisePropertyChanged(); }
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

        private void UpdateTitleText()
        {
            TitleText = ResourceLoaderService.GetResourceValue(CompletionState == CompletionState.Updated ? "EditJobTypeTitleText" : "NewJobTypeTitleText");
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
            JobType.DateUpdated = DateTime.UtcNow;
            JobType.UpdatedBy = "sqladmin"; // TODO: Update 'sqladmin' to the logged on user when user is created
            
            EditedJobType = JobType;

            NavigateBackToViewMode();
        }

        public void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            NavigateBackToViewMode();
        }

        private static void NavigateBackToViewMode()
        {
            EditCompletionState = CompletionState.Cancelled;
            EditModeCompletion = EditCompletion.Complete;

            NavigateToEditMode = false;
        }
    }
}
