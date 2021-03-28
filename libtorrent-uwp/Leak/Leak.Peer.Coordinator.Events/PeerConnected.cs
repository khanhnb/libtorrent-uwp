using Leak.Common;
using Leak.Networking.Core;

namespace Leak.Peer.Coordinator.Events
{
    public class PeerConnected
    {
        public PeerHash Peer;
        public NetworkConnection Connection;
    }
}