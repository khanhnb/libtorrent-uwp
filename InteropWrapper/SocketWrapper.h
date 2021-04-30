#pragma once

namespace InteropWrapper
{
    public ref class SocketWrapper sealed
    {
	private:
		SocketWrapper();
    public:
		static int closesocket_wrapper(int64 socket);
		static int WSAGetLastError_wrapper();
		static int listen_wrapper(int64 socket, int backlog);
		static int bind_wrapper(int64 socket, int64 socketAddress, int socketAddressSize);
		static int getsocketname_wrapper(int64 socket, int64 socketAddress, int socketAddressSizeIn, int* socketAddressSizeOut);
		static int64 WSASocket_wrapper(int addressFamily, int socketType, int protocolType, int64 protocolInfo, uint32 group, uint32 flags);
		static int WSAIoctl_wrapper(int64 socket, int ioControlCode, Guid guidIn, Guid* guidOut, int guidSize, int64* funcPtr, int funcPtrSize, int* bytesTransferred, int64 shouldBeNull, int64 shouldBeNull2);
		static bool WSAGetOverlappedResult_wrapper(int64 socket, int64 ptrNativeOverlapped, uint32* ptrBytesTransferred, bool wait, uint32* ptrFlags);
		static int WSASend_wrapper(int64 socket, int64 lpBuffers, int buffersCount, int* numberOfBytesSent, int dwFlags, int64 lpOverlapped, int64 lpCompletionRoutine);
		static int setsockopt_wrapper(int64 socket, int optionLevel, int optionName, int optionValue, int optionLength);
		static int WSASendTo_wrapper(int64 socket, int64 lpBuffers, int buffersCount, int* numberOfBytesSent, int dwFlags, int64 socketAddress, int socketAddressSize, int64 lpOverlapped, int64 lpCompletionRoutine);
		static int WSARecvFrom_wrapper(int64 socket, int64 lpBuffers, int buffersCount, int* numberOfBytesReceived, int dwFlagsIn, int* dwFlagsOut, int64 socketAddress, int socketAddressSizeIn, int* socketAddressSizeOut, int64 lpOverlapped, int64 lpCompletionRoutine);
	};
}
