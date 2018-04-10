using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using PlatformSpecificPCL;
using Android.Media;

[assembly: Dependency(typeof(PlatformSpecificPCL.Droid.PlatformSoundPlayer))]
namespace PlatformSpecificPCL.Droid
{
    class PlatformSoundPlayer : IPlatformSoundPlayer
    {
        AudioTrack previousAudioTrack;
        public void PlaySound(int samplingRate, byte[] pcmData)
        {
            if(previousAudioTrack != null)
            {
                previousAudioTrack.Stop();
                previousAudioTrack.Release();
            }

            AudioTrack audioTrack = new AudioTrack(Stream.Music, samplingRate, ChannelOut.Mono, Android.Media.Encoding.Pcm16bit, pcmData.Length * sizeof(char), AudioTrackMode.Static);
            audioTrack.Write(pcmData, 0, pcmData.Length);
            audioTrack.Play();

            previousAudioTrack = audioTrack;
        }
    }
}