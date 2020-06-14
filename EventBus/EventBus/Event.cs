using System;

namespace EventBus
{
    public class Event
    {
        public string Data { get; }

        public string Type { get; }
        
        public DateTime Timestamp { get; }

        public Event(string data, string type, DateTime timestamp)
        {
            Data = data;
            Type = type;
            Timestamp = timestamp;
        }
    }
}