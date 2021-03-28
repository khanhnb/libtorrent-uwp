#pragma once
namespace InteropWrapper
{
	public ref class Kernel32Wrapper sealed
	{
	private:
		Kernel32Wrapper();
	public:
		static uint32 GetLastError_wrapper();
		static int64 CreateFile2_wrapper(String^ fileName, uint32 dwDesiredAccess, uint32 dwShareMode, int64 lpSecurityAttributes, uint32 dwCreationDisposition, uint32 dwFlags, uint32 dwAttributes, int64 hTemplateFile);
	};
}

