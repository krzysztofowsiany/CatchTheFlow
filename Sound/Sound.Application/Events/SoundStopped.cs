using System;

namespace Sound.Application.Events
{
    public class SoundStopped
    {
        public DateTime Timestamp { get; }
        public SoundStopped(DateTime timestamp)
        {
            Timestamp = timestamp;
        }
    }
}