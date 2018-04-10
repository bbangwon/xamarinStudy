using System;
using System.Collections.Generic;
using System.Text;

namespace PlatformSpecificPCL
{
    public interface IPlatformSoundPlayer
    {
        void PlaySound(int samplingRate, byte[] pcmData);
    }
}
