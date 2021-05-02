#include "pch.h"
#include "Kernel32Wrapper.h"

uint32 InteropWrapper::Kernel32Wrapper::GetLastError_wrapper()
{
	return GetLastError();
}

int64 InteropWrapper::Kernel32Wrapper::CreateFile2_wrapper(String^ fileName, uint32 dwDesiredAccess, uint32 dwShareMode, int64 lpSecurityAttributes, uint32 dwCreationDisposition, uint32 dwFlags, uint32 dwAttributes, int64 hTemplateFile)
{
	CREATEFILE2_EXTENDED_PARAMETERS CreateExParams = {0};
	CreateExParams.dwSize = sizeof(CREATEFILE2_EXTENDED_PARAMETERS);
	CreateExParams.dwFileAttributes = dwAttributes;
	CreateExParams.dwFileFlags = dwFlags;
	CreateExParams.lpSecurityAttributes = (LPSECURITY_ATTRIBUTES)lpSecurityAttributes;
	CreateExParams.hTemplateFile = (HANDLE)hTemplateFile;
	return (int64)CreateFile2(fileName->Data(), dwDesiredAccess, dwShareMode, dwCreationDisposition, &CreateExParams);
}
