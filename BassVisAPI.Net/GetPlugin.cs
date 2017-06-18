using System;

using JetBrains.Annotations;

namespace BassVisAPI
{
    [Flags]
    [PublicAPI]
    public enum BASSVISGetPlugin
    {
        BASSVIS_FIND_DEFAULT = 0,
        BASSVIS_FIND_RECURSIVE = 5
    }
}

