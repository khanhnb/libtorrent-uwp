using InteropWrapper;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace Leak.Sockets
{
    internal static class UdpSocketInterop
    {
        public static IntPtr WSASocket(int addressFamily, int socketType, int protocolType, IntPtr protocolInfo, uint group, uint flags)
        {
            return (IntPtr)SocketWrapper.WSASocket_wrapper(addressFamily, socketType, protocolType, protocolInfo.ToInt64(), group, flags);
        }

        public static unsafe uint WSASendTo(
            [In] IntPtr socket,
            [In] TcpSocketInterop.WSABuffer* buffers,
            [In] int buffersCount,
            [Out] out int numberOfBytesSent,
            [In] int dwFlags,
            [In] IntPtr socketAddress,
            [In] int socketAddressSize,
            [In] NativeOverlapped* lpOverlapped,
            [In] IntPtr lpCompletionRoutine)
        {
            int res = SocketWrapper.WSASendTo_wrapper(socket.ToInt64(), (long)buffers, buffersCount, out int numberOfBytesSentOut, dwFlags, socketAddress.ToInt64(), socketAddressSize, (long)lpOverlapped, lpCompletionRoutine.ToInt64());
            numberOfBytesSent = numberOfBytesSentOut;
            return (uint)res;
        }

        public static unsafe int WSARecvFrom(
            [In] IntPtr socket,
            [In] TcpSocketInterop.WSABuffer* buffers,
            [In] int buffersCount,
            [Out] out int numberOfBytesReceived,
            [In, Out] ref int dwFlags,
            [In] IntPtr socketAddress,
            [In, Out] ref int socketAddressSize,
            [In] NativeOverlapped* lpOverlapped,
            [In] IntPtr lpCompletionRoutine)
        {
            int res = SocketWrapper.WSARecvFrom_wrapper(socket.ToInt64(), (long)buffers, buffersCount, out int numberOfBytesReceivedOut, dwFlags, out int dwFlagsOut, socketAddress.ToInt64(), socketAddressSize, out int socketAddressSizeOut, (long)lpOverlapped, lpCompletionRoutine.ToInt64());
            dwFlags = dwFlagsOut;
            socketAddressSize = socketAddressSizeOut;
            numberOfBytesReceived = numberOfBytesReceivedOut;
            return res;
        }

        public static uint setsockopt(
            IntPtr socket,
            int optionLevel,
            int optionName,
            ref int optionValue,
            int optionLength)
        {
            return (uint)SocketWrapper.setsockopt_wrapper(socket.ToInt64(), optionLevel, optionName, optionValue, optionLength);
        }

        public static int closesocket(IntPtr socket)
        {
            return SocketWrapper.closesocket_wrapper(socket.ToInt64());
        }
    }
}