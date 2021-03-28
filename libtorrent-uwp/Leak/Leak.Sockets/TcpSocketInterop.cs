using InteropWrapper;
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Leak.Sockets
{
    internal class TcpSocketInterop
    {
        public unsafe delegate int ConnectExDelegate(
            IntPtr socket,
            IntPtr socketAddress,
            int socketAddressSize,
            IntPtr data,
            int dataLength,
            out int bytesSent,
            NativeOverlapped* overlapped);

        public unsafe delegate int AcceptExDelegate(
            IntPtr sListenSocket,
            IntPtr sAcceptSocket,
            IntPtr lpOutputBuffer,
            uint dwReceiveDataLength,
            uint dwLocalAddressLength,
            uint dwRemoteAddressLength,
            out int lpdwBytesReceived,
            NativeOverlapped* lpOverlapped);

        public delegate void GetAcceptExSockaddrsDelegate(
                IntPtr buffer,
                int receiveDataLength,
                int localAddressLength,
                int remoteAddressLength,
                out IntPtr localSocketAddress,
                out int localSocketAddressLength,
                out IntPtr remoteSocketAddress,
                out int remoteSocketAddressLength);

        public unsafe delegate int DisconnectExDelegate(
            IntPtr socket,
            NativeOverlapped* overlapped,
            int dwFlags,
            int reserved);

        [StructLayout(LayoutKind.Sequential)]
        public struct WSABuffer
        {
            public int length;
            public IntPtr buffer;
        }

        public static IntPtr WSASocket(int addressFamily, int socketType, int protocolType, IntPtr protocolInfo, uint group, uint flags)
        {
            return (IntPtr)SocketWrapper.WSASocket_wrapper(addressFamily, socketType, protocolType, protocolInfo.ToInt64(), group, flags);
        }

        public static int closesocket(IntPtr socket)
        {
            return SocketWrapper.closesocket_wrapper(socket.ToInt64());
        }

        public static int bind(IntPtr socket, IntPtr socketAddress, int socketAddressSize)
        {
            return SocketWrapper.bind_wrapper(socket.ToInt64(), socketAddress.ToInt64(), socketAddressSize);
        }

        public static int listen(IntPtr socket, int backlog)
        {
            return SocketWrapper.listen_wrapper(socket.ToInt64(), backlog);
        }

        public static int getsockname(IntPtr socket, IntPtr socketAddress, ref int socketAddressSizeIn)
        {
            int res = SocketWrapper.getsocketname_wrapper(socket.ToInt64(), socketAddress.ToInt64(), socketAddressSizeIn, out int socketAddressSizeOut);
            socketAddressSizeIn = socketAddressSizeOut;
            return res;
        }

        public static int WSAIoctl(IntPtr socket, int ioControlCode, ref Guid guidIn, int guidSize, out IntPtr funcPtr, int funcPtrSize, out int bytesTransferred, IntPtr shouldBeNull, IntPtr shouldBeNull2)
        {
            int res = SocketWrapper.WSAIoctl_wrapper(socket.ToInt64(),
                                                        ioControlCode,
                                                        guidIn,
                                                        out Guid guidOut,
                                                        guidSize,
                                                        out long funcPtrOut,
                                                        funcPtrSize,
                                                        out int bytesTransferedOut,
                                                        shouldBeNull.ToInt64(),
                                                        shouldBeNull2.ToInt64());
            guidIn = guidOut;
            bytesTransferred = bytesTransferedOut;
            if (funcPtrSize == 8) funcPtr = new IntPtr(funcPtrOut);
            else funcPtr = new IntPtr((int)funcPtrOut);
            return res;
        }

        public static unsafe uint WSASend(
            IntPtr socket,
            WSABuffer* lpBuffers,
            int buffersCount,
            out int numberOfBytesSent,
            int dwFlags,
            NativeOverlapped* lpOverlapped,
            IntPtr lpCompletionRoutine)
        {
            int res = SocketWrapper.WSASend_wrapper(socket.ToInt64(), (long)lpBuffers, buffersCount, out int numberOfBytesSentOut, dwFlags, (long)lpOverlapped, lpCompletionRoutine.ToInt64());
            numberOfBytesSent = numberOfBytesSentOut;
            return (uint)res;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern unsafe uint ReadFile(
            [In] IntPtr hFile,
            [Out] IntPtr lpBuffer,
            [In] uint maxBytesToRead,
            [Out] out uint bytesActuallyRead,
            [In] NativeOverlapped* lpOverlapped);

        public static unsafe uint WSAGetOverlappedResult(
            IntPtr handle,
            NativeOverlapped* lpOverlapped,
            out uint ptrBytesTransferred,
            bool wait,
            out uint flags)
        {
            bool res = SocketWrapper.WSAGetOverlappedResult_wrapper(handle.ToInt64(), (long)lpOverlapped, out uint ignore, wait, out uint outFlags);
            ptrBytesTransferred = ignore;
            flags = outFlags;
            return (uint)(res ? 1 : 0);
        }

        public static uint WSAGetLastError()
        {
            return (uint)SocketWrapper.WSAGetLastError_wrapper();
        }

        public static uint GetLastError()
        {
            return Kernel32Wrapper.GetLastError_wrapper();
        }
    }
}