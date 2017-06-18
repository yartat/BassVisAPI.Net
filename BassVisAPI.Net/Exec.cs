using System;
using System.Runtime.InteropServices;

using JetBrains.Annotations;

namespace BassVisAPI
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    [PublicAPI]
    public sealed class BASSVIS_EXEC
    {
        [MarshalAs(UnmanagedType.LPStr)] private string PluginFile;
        public int AMP_UseOwnW1;
        public int AMP_UseOwnW2;
        public int AMP_ModuleIndex;
        public bool AMP_UseFakeWindow;
        public IntPtr SON_ParentHandle = IntPtr.Zero;
        [MarshalAs(UnmanagedType.LPStr)] public string SON_ConfigFile;
        public bool SON_UseOpenGL;
        public int SON_ViewportWidth;
        public int SON_ViewportHeight;
        [MarshalAs(UnmanagedType.Bool)] public bool SON_ShowPrgBar;
        [MarshalAs(UnmanagedType.Bool)] public bool SON_ShowFPS;
        [MarshalAs(UnmanagedType.Bool)] public bool SON_UseCover;
        public int WMP_PluginIndex;
        public int WMP_PresetIndex;
        public IntPtr WMP_SrcVisHandle = IntPtr.Zero;
        public IntPtr BB_ParentHandle = IntPtr.Zero;
        [MarshalAs(UnmanagedType.Bool)] public bool BB_ShowFPS;
        [MarshalAs(UnmanagedType.Bool)] public bool BB_ShowPrgBar;
        public IntPtr AIMP_PaintHandle = IntPtr.Zero;
        public int Width;
        public int Height;
        public int Left;
        public int Top;

        public BASSVIS_EXEC(string filename)
        {
            PluginFile = filename;
            SON_ConfigFile = string.Empty;
        }
    }
}

