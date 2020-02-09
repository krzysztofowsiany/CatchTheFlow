namespace EventBus
{
    public struct Event
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