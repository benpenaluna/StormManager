using MvvmCross.Core.ViewModels;

namespace StormManager.Core.ViewModels
{
    public class OtherViewModel : MvxViewModel
    {
        public OtherViewModel()
        {
        }

        public void ShowMenu()
        {
            ShowViewModel<MenuViewModel>();
        }
    }
}