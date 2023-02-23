using System.Runtime.InteropServices;

namespace Attributes;

internal static partial class InteropAttributes
{
    [LibraryImport("User32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static partial bool IsWindowVisible(IntPtr hWnd);

    [LibraryImport("advapi32.dll", EntryPoint = "LookupPrivilegeValueW",
        SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static partial bool LookupPrivilegeValue(
        [MarshalAs(UnmanagedType.LPWStr)] string? lpSystemName,
        [MarshalAs(UnmanagedType.LPWStr)] string lpName,
        out LUID lpLuid);

    [StructLayout(LayoutKind.Sequential)]
    public struct LUID
    {
        public uint LowPart;
        public int HighPart;
    }
}