using System;
using System.Collections.Generic;
using System.Text;
using PlatformSpecificPCL;
using Xamarin.Forms;
using System.IO;
using Foundation;
using AVFoundation;

[assembly: Dependency(typeof(PlatformSpecificPCL.iOS.PlatformSoundPlayer))]
namespace PlatformSpecificPCL.iOS
{
    class PlatformSoundPlayer : IPlatformSoundPlayer
    {
        const int numChannels = 1;
        const int bitsPerSample = 16;

        public void PlaySound(int samplingRate, byte[] pcmData)
        {
            int numSamples = pcmData.Length / (bitsPerSample / 8);

            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter binaryWriter = new BinaryWriter(memoryStream, Encoding.ASCII);

            binaryWriter.Write(new char[] { 'R', 'I', 'F', 'F' });
            binaryWriter.Write(36 + sizeof(short) * numSamples);
            binaryWriter.Write(new char[] { 'W', 'A', 'V', 'E' });
            binaryWriter.Write(new char[] { 'f', 'm', 't', ' '});
            binaryWriter.Write(16);
            binaryWriter.Write((short)1);
            binaryWriter.Write((short)numChannels);
            binaryWriter.Write(samplingRate);
            binaryWriter.Write(samplingRate * numChannels * bitsPerSample / 8);
            binaryWriter.Write((short)(numChannels * bitsPerSample / 8));
            binaryWriter.Write((short)bitsPerSample);
            binaryWriter.Write(new char[] { 'd', 'a', 't', 'a' });
            binaryWriter.Write(numSamples * numChannels * bitsPerSample / 8);

            binaryWriter.Write(pcmData, 0, pcmData.Length);

            memoryStream.Seek(0, SeekOrigin.Begin);
            NSData data = NSData.FromStream(memoryStream);
            AVAudioPlayer audioPlayer = AVAudioPlayer.FromData(data);
            audioPlayer.Play();
        }
    }
}
