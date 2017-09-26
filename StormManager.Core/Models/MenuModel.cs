using MvvmCross.Core.ViewModels;
using System;

namespace StormManager.Core.Models
{
    public class MenuModel
    {
        public String Title { get; set; }

        public String ImageName { get; set; }

        public IMvxCommand Navigate { get; set; }

        public MenuModel()
        {

        }
    }
}