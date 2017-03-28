using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace RedOverUI
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal static class Win32Delegates
    {
        internal enum GWL
        {
            ExStyle = -20
        }

        internal enum WS_EX
        {
            Transparent = 0x20,
            Layered = 0x80000
        }

        internal enum LWA
        {
            ColorKey = 0x1,
            Alpha = 0x2
        }

        [DllImport("user32", EntryPoint = "GetWindowLong")]
        internal static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32", EntryPoint = "SetWindowLong")]
        internal static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dsNewLong);

        [DllImport("user32.dll", EntryPoint = "SetLayeredWindowAttributes")]
        internal static extern bool SetLayeredWindowAttributes(IntPtr hWnd, int crKey, byte alpha, LWA dwFlags);
    }
}
