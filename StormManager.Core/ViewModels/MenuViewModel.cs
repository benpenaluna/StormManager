using MvvmCross.Core.ViewModels;
using StormManager.Core.Models;
using System.Collections.Generic;

namespace StormManager.Core.ViewModels
{
    public class MenuViewModel : MvxViewModel
    {
        public List<MenuModel> MenuItems { get; }

        public MenuViewModel()
        {
            MenuItems = new List<MenuModel>
            {
                new MenuModel() {Title = "Home", ImageName = "ic_build_white", Navigate = NavigateHome},
                new MenuModel() {Title = "About", ImageName = "ic_description_white", Navigate = NavigateOtherViewModel}
            };
        }

        private MvxCommand _resetCommand;
        public MvxCommand NavigateHome
        {
            get
            {
                _resetCommand = _resetCommand ?? new MvxCommand(() => ShowViewModel<ContentViewModel>());
                return _resetCommand;
            }
        }

        private MvxCommand _navigateOtherViewModel;
        public MvxCommand NavigateOtherViewModel
        {
            get
            {
                _navigateOtherViewModel = _navigateOtherViewModel ?? new MvxCommand(() => ShowViewModel<OtherViewModel>());
                return _navigateOtherViewModel;
            }
        }
    }
}