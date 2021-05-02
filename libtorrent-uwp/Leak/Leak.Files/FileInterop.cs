using InteropWrapper;
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Leak.Files
{
    internal static class FileInterop
    {
        public static IntPtr CreateFile2(
            [In] string fileName,
            [In] uint dwDesiredAccess,
            [In] uint dwShareMode,
            [In] IntPtr lpSecurityAttributes,
            [In] uint dwCreationDisposition,
            [In] uint dwFlags,
            [In] uint dwAttributes,
            [In] IntPtr hTemplateFile)
        {
            long res = Kernel32Wrapper.CreateFile2_wrapper(fileName, dwDesiredAccess, dwShareMode, lpSecurityAttributes.ToInt64(), dwCreationDisposition, dwFlags, dwAttributes, hTemplateFile.ToInt64());
            return IntPtr.Size == 4 ? new IntPtr((int)res) : new IntPtr(res);
        }

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        public static extern int CloseHandle(
            [In] IntPtr handle);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        public static extern bool SetFilePointerEx(
            [In] IntPtr handle,
            [In] long distance,
            [Out] IntPtr pointer,
            [In] uint method);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        public static extern bool SetEndOfFile(
            [In] IntPtr handle);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        public static extern unsafe uint ReadFile(
            [In] IntPtr hFile,
            [Out] IntPtr lpBuffer,
            [In] int maxBytesToRead,
            [Out] out int bytesActuallyRead,
            [In] NativeOverlapped* lpOverlapped);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        public static extern unsafe int WriteFile(
            [In] IntPtr hFile,
            [Out] IntPtr lpBuffer,
            [In] int numberOfBytesToWrite,
            [Out] out int umberOfBytesWritten,
            [In] NativeOverlapped* lpOverlapped);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        public static extern bool FlushFileBuffers(
            [In] IntPtr handle);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        public static extern unsafe uint GetOverlappedResult(
            [In] IntPtr handle,
            [In] NativeOverlapped* lpOverlapped,
            [Out] out uint ptrBytesTransferred,
            [In] bool wait);

        public static uint GetLastError()
        {
            //return (uint)Marshal.GetLastWin32Error();
            return Kernel32Wrapper.GetLastError_wrapper();
        }
    }
}