using System;
using System.IO;
using NAudio.Wave;
using Sound.Core;

namespace Sound.Sound
{
    public class SoundPlayer : ISoundPlayer
    {
        private readonly WaveOutEvent _waveOutputEvent;
        private AudioFileReader _audioFileReader;

        public SoundPlayer()
        {
            _waveOutputEvent = new WaveOutEvent();
        }

        public void Stop()
        {
            if (_waveOutputEvent.PlaybackState == PlaybackState.Playing)
                _waveOutputEvent.Stop();
            
            _audioFileReader?.Dispose();
        }

        public void Play(string sound)
        {
            Stop();
            
            var audioFile = GetSoundPath(sound);
            _audioFileReader = new AudioFileReader(audioFile);
            _waveOutputEvent.Init(_audioFileReader);
            _waveOutputEvent.Play();
        }
        
        private string GetSoundPath(string sound)
        {
            return Path.Combine(Environment.CurrentDirectory, "sounds", sound);
        }
    }
}