using System;

namespace Sound.Infrastructure.Events
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