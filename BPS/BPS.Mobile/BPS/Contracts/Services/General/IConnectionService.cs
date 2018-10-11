using Plugin.Connectivity.Abstractions;

namespace BPS.Core.Contracts.Services.General
{
    public interface IConnectionService
    {
        bool IsConnected { get; }
        event ConnectivityChangedEventHandler ConnectivityChanged;
    }
}
