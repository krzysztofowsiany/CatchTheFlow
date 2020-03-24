using System;
using Sound.Application.Events;

namespace Sound.Application.Views
{
    public class SoundWorkInformation
    {
        public SoundWorkInformation(WorkStarted @event)
        {
            Sound = "work_1.mp3";
            Timestamp = @event.Timestamp;
        }

        public DateTime Timestamp { get; set; }

        public string Sound { get; set; }
    }
}