using JetBrains.Annotations;

namespace BassVisAPI
{
    [PublicAPI]
    public enum BASSVIS_PLAYSTATE
    {
        Error = -1,
        Stop = 0,
        Play = 1,
        IsPlaying = 2,
        Pause = 3,
        PrevTitle = 4,
        NextTitle = 5,
        SetPlaylistTitle = 6,
        GetPlaylistTitlePos = 7,
        SetPlaylistPos = 8,
        GetSelectedTitlePos = 9,
        PlaylistClear = 10,
        AddPlaylistTitle = 11,
    }
}

