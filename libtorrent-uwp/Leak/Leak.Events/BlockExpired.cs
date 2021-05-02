﻿using Leak.Common;

namespace Leak.Events
{
    public class BlockExpired
    {
        public FileHash Hash;

        public PeerHash Peer;

        public BlockIndex Block;
    }
}