using StormManager.UWP.Models;
using StormManager.UWP.ViewModels.SettingPageViewModel;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace StormManager.UWP.Views
{
    public sealed partial class SettingsPage
    {
        readonly Services.SerializationService.ISerializationService _serializationService;

        private const double JobTypeContentFrameWidth = 500.0D;

        public SettingsPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Required;
            _serializationService = Services.SerializationService.SerializationService.Json;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var index = int.Parse(_serializationService.Deserialize(e.Parameter?.ToString()).ToString());
            MyPivot.SelectedIndex = index;
        }

        private void JobTypesSplitView_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            JobTypesSplitView.OpenPaneLength = JobTypesSplitView.ActualWidth > JobTypeContentFrameWidth
                ? JobTypesSplitView.ActualWidth - JobTypeContentFrameWidth
                : 0.0D;
        }

        public void JobTypesListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((SettingsPageViewModel)DataContext).JobTypesPartViewModel.JobTypesListView_OnSelectionChanged(sender, e);

            JobTypesListView.ScrollIntoView(JobTypesListView.SelectedItem, ScrollIntoViewAlignment.Leading);
        }

        public void AutoSuggestBoxSearch_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason != AutoSuggestionBoxTextChangeReason.UserInput || JobTypesListView.Items == null)
                return;

            sender.ItemsSource = DetermineEligibleSuggestions(sender.Text, JobTypesListView.Items);
        }

        private static ObservableCollection<JobType> DetermineEligibleSuggestions(string userSearchText,
            ItemCollection items)
        {
            var options = new ObservableCollection<JobType>();
            foreach (var item in items)
            {
                var jobType = GetJobType(item);
                if (jobType == null)
                    continue;

                if (jobType.Category.Contains(userSearchText) || jobType.SubCategory.Contains(userSearchText))
                    options.Add(jobType);
            }

            return options;
        }

        private static JobType GetJobType(object item)
        {
            return item.GetType() == typeof(JobType) ? item as JobType : null;
        }

        public void AutoSuggestBoxSearch_SuggestionChosen(AutoSuggestBox sender,
            AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            if (JobTypesListView.Items == null || !JobTypesListView.Items.Contains(args.SelectedItem))
                return;

            JobTypesListView.SelectedItem = args.SelectedItem;
        }
    }
}
