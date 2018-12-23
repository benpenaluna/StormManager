using System;
using System.Threading.Tasks;

namespace StormManager.UWP.Services.NetworkAvailableService
{
    // Source: https://github.com/Windows-XAML/Template10/blob/version_1.1.12/Template10%20(Library)/Services/NetworkAvailableService/INetworkAvailableService.cs

    public interface INetworkAvailableService
    {
        Task<bool> IsInternetAvailable();
        Task<bool> IsNetworkAvailable();
        Action<ConnectionTypes> AvailabilityChanged { get; set; }
    }
}
