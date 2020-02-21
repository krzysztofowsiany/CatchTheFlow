namespace EventBus
{
    public class Event
    {
        public string Data { get; }

        public string Type { get; }

        public Event(string data, string type)
        {
            Data = data;
            Type = type;
        }
    }
}