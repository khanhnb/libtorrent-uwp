#include "pch.h"
#include "SocketWrapper.h"

using namespace InteropWrapper;

int InteropWrapper::SocketWrapper::closesocket_wrapper(int64 socket)
{
	return closesocket((SOCKET)socket);
}

int InteropWrapper::SocketWrapper::WSAGetLastError_wrapper()
{
	return WSAGetLastError();
}

int InteropWrapper::SocketWrapper::listen_wrapper(int64 socket, int backlog)
{
	return listen((SOCKET)socket, backlog);
}

int InteropWrapper::SocketWrapper::bind_wrapper(int64 socket, int64 socketAddress, int socketAddressSize)
{
	return bind((SOCKET)socket, (sockaddr*)socketAddress, socketAddressSize);
}

int InteropWrapper::SocketWrapper::getsocketname_wrapper(int64 socket, int64 socketAddress, int socketAddressSizeIn, int* socketAddressSizeOut)
{
	*socketAddressSizeOut = socketAddressSizeIn;
	return getsockname((SOCKET)socket, (sockaddr*)socketAddress, socketAddressSizeOut);
}

int64 InteropWrapper::SocketWrapper::WSASocket_wrapper(int addressFamily, int socketType, int protocolType, int64 protocolInfo, uint32 group, uint32 flags)
{
	return WSASocket(addressFamily, socketType, protocolType, (LPWSAPROTOCOL_INFOW)protocolInfo, group, flags);
}

int InteropWrapper::SocketWrapper::WSAIoctl_wrapper(int64 socket, int ioControlCode, Guid guidIn, Guid* guidOut, int guidSize, int64* funcPtr, int funcPtrSize, int* bytesTransferred, int64 shouldBeNull, int64 shouldBeNull2)
{
	*guidOut = guidIn;
	return WSAIoctl((SOCKET)socket, ioControlCode, guidOut, guidSize, funcPtr, funcPtrSize, (LPDWORD)bytesTransferred, (LPWSAOVERLAPPED)shouldBeNull, (LPWSAOVERLAPPED_COMPLETION_ROUTINE)shouldBeNull2);
}

bool InteropWrapper::SocketWrapper::WSAGetOverlappedResult_wrapper(int64 socket, int64 ptrNativeOverlapped, uint32* ptrBytesTransferred, bool wait, uint32* ptrFlags)
{
	return WSAGetOverlappedResult((SOCKET)socket, (LPWSAOVERLAPPED)ptrNativeOverlapped, (LPDWORD)ptrBytesTransferred, wait, (LPDWORD)ptrFlags);
}

int InteropWrapper::SocketWrapper::WSASend_wrapper(int64 socket, int64 lpBuffers, int buffersCount, int* numberOfBytesSent, int dwFlags, int64 lpOverlapped, int64 lpCompletionRoutine)
{
	return WSASend((SOCKET)socket, (LPWSABUF)lpBuffers, buffersCount, (LPDWORD)numberOfBytesSent, dwFlags, (LPWSAOVERLAPPED)lpOverlapped, (LPWSAOVERLAPPED_COMPLETION_ROUTINE)lpCompletionRoutine);
}

int InteropWrapper::SocketWrapper::setsockopt_wrapper(int64 socket, int optionLevel, int optionName, int optionValue, int optionLength)
{
	return setsockopt((SOCKET)socket, optionLevel, optionName, (char*) &optionValue, optionLength);
}

int InteropWrapper::SocketWrapper::WSASendTo_wrapper(int64 socket, int64 lpBuffers, int buffersCount, int* numberOfBytesSent, int dwFlags, int64 socketAddress, int socketAddressSize, int64 lpOverlapped, int64 lpCompletionRoutine)
{
	return WSASendTo((SOCKET)socket, (LPWSABUF)lpBuffers, buffersCount, (LPDWORD)numberOfBytesSent, dwFlags, (sockaddr*)socketAddress, socketAddressSize, (LPWSAOVERLAPPED)lpOverlapped, (LPWSAOVERLAPPED_COMPLETION_ROUTINE)lpCompletionRoutine);
}

int InteropWrapper::SocketWrapper::WSARecvFrom_wrapper(int64 socket, int64 lpBuffers, int buffersCount, int* numberOfBytesReceived, int dwFlagsIn, int* dwFlagsOut, int64 socketAddress, int socketAddressSizeIn, int* socketAddressSizeOut, int64 lpOverlapped, int64 lpCompletionRoutine)
{
	*dwFlagsOut = dwFlagsIn;
	*socketAddressSizeOut = socketAddressSizeIn;
	return WSARecvFrom((SOCKET)socket, (LPWSABUF)lpBuffers, buffersCount, (LPDWORD)numberOfBytesReceived, (LPDWORD)dwFlagsOut, (sockaddr*)socketAddress, socketAddressSizeOut, (LPWSAOVERLAPPED)lpOverlapped, (LPWSAOVERLAPPED_COMPLETION_ROUTINE)lpCompletionRoutine);
}
