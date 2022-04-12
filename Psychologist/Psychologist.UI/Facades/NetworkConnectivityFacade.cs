using Psychologist.Core.Abstractions;
using Xamarin.Essentials;

namespace Psychologist.UI.Facades
{
    public class NetworkConnectivityFacade:INetworkConnectivity
    {
        public bool IsConnected => Connectivity.NetworkAccess==NetworkAccess.Internet;
    }
}