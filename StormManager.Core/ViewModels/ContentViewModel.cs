using MvvmCross.Core.ViewModels;

namespace StormManager.Core.ViewModels
{
    public class ContentViewModel : MvxViewModel
    {
        public ContentViewModel()
        {
        }

        public void ShowMenu()
        {
            ShowViewModel<MenuViewModel>();
        }
    }
}