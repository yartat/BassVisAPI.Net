using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

using JetBrains.Annotations;

namespace BassVisAPI
{
    [PublicAPI]
    public sealed class BassVis
    {
        private const string BassVisFileName = "bass_vis.dll";

        static BassVis()
        {
            if (!File.Exists(BassVisFileName))
            {
                NativeMethods.LoadLibraryEx(
                    Path.Combine(Environment.Is64BitProcess ? @".\x64" : @".\x86", BassVisFileName),
                    IntPtr.Zero,
                    NativeMethods.LoadLibraryFlags.DEFAULT);
            }
        }

        public delegate void BassVisState(BASSVIS_PLAYSTATE state);

        [DllImport(BassVisFileName, CharSet=CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BASSVIS_AIMP2VIS_RenderDeviceToDC(
            BASSVISKind kind, 
            IntPtr handle, 
            int channel, 
            IntPtr hDc);

        [DllImport(BassVisFileName, CharSet=CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BASSVIS_AIMP2VIS_RenderStreamToDC(
            BASSVISKind kind, 
            IntPtr handle, 
            int channel, 
            IntPtr hDc);

        [DllImport(BassVisFileName, CharSet=CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BASSVIS_Clicked(BASSVIS_PARAM param, int x, int y);

        [DllImport(BassVisFileName, CharSet=CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BASSVIS_Config(BASSVIS_PARAM param, int module);

        [DllImport(BassVisFileName, CharSet=CharSet.Auto)]
        public static extern void BASSVIS_ExecutePlugin(BASSVIS_EXEC exec, BASSVIS_PARAM param);

        [DllImport(BassVisFileName, CharSet=CharSet.Auto)]
        private static extern IntPtr BASSVIS_FindPlugins(
            BASSVISKind kind, 
            [In, MarshalAs(UnmanagedType.LPStr)] string pluginPath, 
            BASSVISGetPlugin findType, 
            byte param);

        [DllImport(BassVisFileName, CharSet=CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern void BASSVIS_Free(BASSVIS_PARAM param);

        [DllImport(BassVisFileName, CharSet=CharSet.Auto)]
        public static extern int BASSVIS_GetModuleHandle(
            BASSVISKind kind, 
            [In, MarshalAs(UnmanagedType.LPStr)] string pluginPath);

        [DllImport(BassVisFileName, CharSet=CharSet.Auto)]
        public static extern int BASSVIS_GetModulePresetCount(
            BASSVIS_PARAM param, 
            [In, MarshalAs(UnmanagedType.LPStr)] string pluginPath);

        [DllImport(BassVisFileName, EntryPoint="BASSVIS_GetModulePresetNameList", CharSet=CharSet.Auto)]
        private static extern IntPtr BASSVIS_GetModulePresetNameListPtr(
            BASSVIS_PARAM param, 
            [In, MarshalAs(UnmanagedType.LPStr)] string pluginPath);

        [DllImport(BassVisFileName, EntryPoint="BASSVIS_GetModulePresetName", CharSet=CharSet.Auto)]
        private static extern IntPtr BASSVIS_GetModulePresetNamePtr(
            BASSVIS_PARAM param, 
            int module, 
            [In, MarshalAs(UnmanagedType.LPStr)] string pluginPath);

        [DllImport(BassVisFileName, CharSet=CharSet.Auto)]
        public static extern int BASSVIS_GetOption(BASSVIS_PARAM param, BASSVIS_CONFIGFLAGS option);

        [DllImport(BassVisFileName, EntryPoint="BASSVIS_GetPluginName", CharSet=CharSet.Auto)]
        private static extern IntPtr BASSVIS_GetPluginNamePtr(BASSVIS_PARAM param);

        [DllImport(BassVisFileName, EntryPoint="BASSVIS_GetVersion", CharSet=CharSet.Auto)]
        private static extern IntPtr BASSVIS_GetVersionPtr();

        [DllImport(BassVisFileName, CharSet=CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BASSVIS_Init(BASSVISKind kind, IntPtr handle);

        [DllImport(BassVisFileName, CharSet=CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BASSVIS_IsFree(BASSVIS_PARAM param);

        [DllImport(BassVisFileName, CharSet=CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern void BASSVIS_Quit(BASSVIS_PARAM param);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport(BassVisFileName, CharSet=CharSet.Auto)]
        public static extern bool BASSVIS_RenderChannel(BASSVIS_PARAM param, int channel, bool usewasapi);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport(BassVisFileName, CharSet=CharSet.Auto)]
        public static extern bool BASSVIS_Resize(BASSVIS_PARAM param, int left, int top, int width, int height);

        [DllImport(BassVisFileName, CharSet=CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BASSVIS_SetFullscreen(
            BASSVIS_PARAM param, 
            IntPtr sourceHandle, 
            IntPtr destinHandle, 
            int sourceLeft, 
            int sourceTop, 
            int sourceWidth, 
            int sourceHeight, 
            [MarshalAs(UnmanagedType.Bool)] bool fullScreen, 
            int screenWidth, 
            int screenHeight);

        [DllImport(BassVisFileName, CharSet=CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BASSVIS_SetInfo(BASSVIS_PARAM param, BASSVIS_INFO info);

        [DllImport(BassVisFileName, CharSet=CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BASSVIS_SetModulePreset(BASSVIS_PARAM param, int index);

        [DllImport(BassVisFileName, CharSet=CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BASSVIS_SetOption(BASSVIS_PARAM param, BASSVIS_CONFIGFLAGS option, int value);

        [DllImport(BassVisFileName, CharSet=CharSet.Auto)]
        public static extern int BASSVIS_SetPlayState(
            BASSVIS_PARAM param, 
            BASSVIS_PLAYSTATE state, 
            int value, 
            [MarshalAs(UnmanagedType.LPStr)] string title);

        [DllImport(BassVisFileName, CharSet=CharSet.Auto)]
        public static extern void BASSVIS_SetVisPort(
            BASSVIS_PARAM param, 
            IntPtr windowHandle, 
            IntPtr containerHandle, 
            int x, 
            int y, 
            int width, 
            int height);

        [DllImport(BassVisFileName, CharSet=CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BASSVIS_StartRecord(BASSVIS_PARAM param, int samplerate, int channels);

        [DllImport(BassVisFileName, CharSet=CharSet.Auto)]
        public static extern void BASSVIS_WINAMP_VisButtonClicked(BASSVIS_PARAM param, BASSVIS_BUTTONFLAGS button);

        [DllImport(BassVisFileName, EntryPoint="BASSVIS_WINAMP_RemoveCallback", CharSet=CharSet.Auto)]
        public static extern void BASSVIS_WINAMPRemoveCallback();

        [DllImport(BassVisFileName, EntryPoint="BASSVIS_WINAMP_SetStateCallback", CharSet=CharSet.Auto)]
        public static extern void BASSVIS_WINAMPSetStateCallback(BassVisState proc);

        public static bool StartRecord(BASSVIS_PARAM param, int samplerate = 44100, int channels = 2) =>
            BASSVIS_StartRecord(param, samplerate, channels);

        public static int SetPlayState(BASSVIS_PARAM param, BASSVIS_PLAYSTATE state, int value = -1) =>
            BASSVIS_SetPlayState(param, state, value, string.Empty);

        public static string GetVersion() => 
            PtrToAnsiString(BASSVIS_GetVersionPtr());

        public static BASSVIS_PARAM GetPluginParam(BASSVISKind kind, string pluginPath)
        {
            var handle = BASSVIS_GetModuleHandle(kind, pluginPath);
            return handle != 0 ? new BASSVIS_PARAM(kind, handle) : null;
        }

        public static string GetPluginName(BASSVIS_PARAM param) => 
            PtrToAnsiString(BASSVIS_GetPluginNamePtr(param));

        public static IEnumerable<string> GetModulePresetNames(
            BASSVIS_PARAM param,
            string pluginPath)
        {
            var value = PtrToAnsiString(BASSVIS_GetModulePresetNameListPtr(param, pluginPath));
            return !string.IsNullOrEmpty(value) ? value.Split(',') : null;
        }

        public static string GetModulePresetName(BASSVIS_PARAM param, int module, string pluginPath) =>
            PtrToAnsiString(BASSVIS_GetModulePresetNamePtr(param, module, pluginPath));

        public static IEnumerable<string> FindPlugins(BASSVISKind kind, string pluginPath, bool recursive)
        {
            var value = PtrToAnsiString(BASSVIS_FindPlugins(
                kind,
                pluginPath,
                recursive ? BASSVISGetPlugin.BASSVIS_FIND_RECURSIVE : BASSVISGetPlugin.BASSVIS_FIND_DEFAULT,
                44));
            return !string.IsNullOrEmpty(value) ? value.Split(',') : null;
        }

        private static string PtrToAnsiString(IntPtr handle)
        {
            return handle != IntPtr.Zero ? Marshal.PtrToStringAnsi(handle) : null;
        }
    }
}
