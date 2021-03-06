﻿using System;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;

namespace StormManager.UWP.Services.NetworkAvailableService
{
    // Source: https://github.com/Windows-XAML/Template10/blob/version_1.1.12/Template10%20(Library)/Services/NetworkAvailableService/NetworkAvailableHelper.cs

    public class NetworkAvailableHelper
    {
        public NetworkAvailableHelper()
        {
            NetworkInformation.NetworkStatusChanged += (s) =>
            {
                ConnectionProfile internetConnectionProfile = NetworkInformation.GetInternetConnectionProfile();
                ConnectionTypes conn = ConnectionTypes.None;
                if (internetConnectionProfile != null)
                {
                    NetworkConnectivityLevel connectionLevel = internetConnectionProfile.GetNetworkConnectivityLevel();
                    conn = (connectionLevel == NetworkConnectivityLevel.InternetAccess) ? ConnectionTypes.Internet : ConnectionTypes.LocalNetwork;
                }
                if (AvailabilityChanged != null)
                {
                    try { AvailabilityChanged(conn); }
                    catch { }
                }
            };
        }

        public Action<ConnectionTypes> AvailabilityChanged { get; set; }

        public Task<bool> IsInternetAvailable()
        {
            var _Profile = NetworkInformation.GetInternetConnectionProfile();
            if (_Profile == null)
                return Task.FromResult<bool>(false);
            var net = NetworkConnectivityLevel.InternetAccess;
            return Task.FromResult<bool>(_Profile.GetNetworkConnectivityLevel().Equals(net));
        }

        public Task<bool> IsNetworkAvailable()
        {
            var _Profile = NetworkInformation.GetInternetConnectionProfile();
            if (_Profile == null)
                return Task.FromResult<bool>(false);

            var local = NetworkConnectivityLevel.LocalAccess;
            return Task.FromResult<bool>(_Profile.GetNetworkConnectivityLevel().Equals(local));
        }
    }
}
