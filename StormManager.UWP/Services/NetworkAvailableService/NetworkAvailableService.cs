using System;
using System.Threading.Tasks;

namespace StormManager.UWP.Services.NetworkAvailableService
{
    // Source: https://github.com/Windows-XAML/Template10/blob/version_1.1.12/Template10%20(Library)/Services/NetworkAvailableService/NetworkAvailableService.cs

    public class NetworkAvailableService : INetworkAvailableService
    {
        NetworkAvailableHelper _helper = new NetworkAvailableHelper();

        public async Task<bool> IsInternetAvailable() => await _helper.IsInternetAvailable();

        public async Task<bool> IsNetworkAvailable() => await _helper.IsNetworkAvailable();

        public Action<ConnectionTypes> AvailabilityChanged
        {
            get
            {
                return _helper.AvailabilityChanged;
            }
            set
            {
                _helper.AvailabilityChanged = value;
            }
        }
    }
}
