using System;
using System.Linq;
using StormManager.UWP.Mvvm;

namespace StormManager.UWP.Services.ProfileService
{
    // Source: https://github.com/Windows-XAML/Template10/blob/version_1.1.12/Template10%20(Library)/Services/ProfileService/ProfileService.cs

    public class ProfileService : BindableBase
    {
        public ProfileService()
        {
            StartAsync();
        }

        async void StartAsync()
        {
            try
            {
                var users = await Windows.System.User.FindAllAsync();
                var current = users.FirstOrDefault();
                FirstName = await current.GetPropertyAsync(Windows.System.KnownUserProperties.FirstName) as string;
                LastName = await current.GetPropertyAsync(Windows.System.KnownUserProperties.LastName) as string;
                var display = await current.GetPropertyAsync(Windows.System.KnownUserProperties.DisplayName) as string;
                DisplayName = string.IsNullOrEmpty(display) ? $"{FirstName} {LastName}" : display;
            }
            catch (Exception)
            {
                throw;
            }
        }

        string _FirstName = "None";
        public string FirstName { get { return _FirstName; } private set { Set(ref _FirstName, value); } }

        string _LastName = "None";
        public string LastName { get { return _LastName; } private set { Set(ref _LastName, value); } }

        string _DisplayName = "None";
        public string DisplayName { get { return _DisplayName; } private set { Set(ref _DisplayName, value); } }
    }
}
