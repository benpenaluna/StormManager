using System;
using System.Threading.Tasks;

namespace StormManager.UWP.Services.NetworkAvailableService
{
    public interface INetworkAvailableService
    {
        Task<bool> IsInternetAvailable();
        Task<bool> IsNetworkAvailable();
        Action<ConnectionTypes> AvailabilityChanged { get; set; }
    }
}
