using System;
using System.Runtime.InteropServices;

using JetBrains.Annotations;

namespace BassVisAPI
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    [PublicAPI]
    public sealed class BASSVIS_PARAM
    {
        public int VisHandle;
        public IntPtr VisGenWinHandle;
        public BASSVISKind Kind;

        public BASSVIS_PARAM(BASSVISKind kind, int handle = 0)
        {
            Kind = kind;
            VisHandle = handle;
            VisGenWinHandle = IntPtr.Zero;
        }
    }
}

