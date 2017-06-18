﻿using JetBrains.Annotations;

namespace BassVisAPI
{
    [PublicAPI]
    public enum BASSVIS_CONFIGFLAGS
    {
        BASSVIS_SONIQUEVIS_CONFIG_DEFAULT,
        BASSVIS_CONFIG_FFTAMP,
        BASSVIS_SONIQUEVIS_CONFIG_FFT_SKIPCOUNT,
        BASSVIS_SONIQUEVIS_CONFIG_WAVE_SKIPCOUNT,
        BASSVIS_SONIQUEVIS_CONFIG_SLOWFADE,
        BASSVIS_SONIQUEVIS_CONFIG_RENDERTIMING,
        BASSVIS_SONIQUEVIS_CONFIG_USESLOWFADE
    }
}

