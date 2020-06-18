using StormManager.UWP.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace StormManager.UWP.Behaviors
{
    public class JobTypeTemplateSelector : DataTemplateSelector
    {
        public DataTemplate OriginalTemplate { get; set; }
        public DataTemplate AddTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            return item is JobType jobType && jobType.Id == -1 ? AddTemplate : OriginalTemplate;
        }
    }
}
