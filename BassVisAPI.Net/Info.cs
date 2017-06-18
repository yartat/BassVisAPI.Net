using System;
using System.Runtime.InteropServices;

using JetBrains.Annotations;

namespace BassVisAPI
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    [PublicAPI]
    public sealed class BASSVIS_INFO
    {
        [MarshalAs(UnmanagedType.LPStr)] private string SongTitle;
        [MarshalAs(UnmanagedType.LPStr)] private string SongFile;
        public int Position;
        public int PlaylistPos = 1;
        public int PlaylistLen = 1;
        public int SampleRate = 44100;
        public int BitRate = 256;
        public int Duration;
        public int Channels = 2;

        public BASSVIS_INFO(string songtitle, string filename)
        {
            SongTitle = songtitle;
            SongFile = filename;
        }
    }
}

