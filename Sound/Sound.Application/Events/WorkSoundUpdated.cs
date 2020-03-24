using System;

namespace Sound.Application.Events
{
    public class WorkSoundUpdated
    {
        public string Sound { get; }
        public DateTime Timestamp { get; }

        public WorkSoundUpdated(string sound, DateTime timestamp)
        {
            Sound = sound;
            Timestamp = timestamp;
        }
    }
}