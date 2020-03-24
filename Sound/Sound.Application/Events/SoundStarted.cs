using System;

namespace Sound.Application.Events
{
    public class SoundStarted
    {
        public string Sound { get; }
        public DateTime Timestamp { get; }

        public SoundStarted(string sound, DateTime timestamp)
        {
            Sound = sound;
            Timestamp = timestamp;
        }
    }
}