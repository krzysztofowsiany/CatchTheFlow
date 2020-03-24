using System;
using System.IO;
using NAudio.Wave;
using Sound.Core;

namespace Sound.Sound
{
    public class SoundPlayer : ISoundPlayer
    {
        private readonly WaveOutEvent _waveOutputEvent;

        public SoundPlayer()
        {
            _waveOutputEvent = new WaveOutEvent();
        }

        public void Stop()
        {
            if (_waveOutputEvent.PlaybackState == PlaybackState.Playing)
                _waveOutputEvent.Stop();
        }

        public void Play(string sound)
        {
            var audioFile = GetSoundPath(sound);
            using (var audioFileReader = new AudioFileReader(audioFile))
            {
                _waveOutputEvent.Init(audioFileReader);
                _waveOutputEvent.Play();
            }
        }
        
        private string GetSoundPath(string sound)
        {
            return Path.Combine(Environment.CurrentDirectory, "sounds", sound);
        }
    }
}