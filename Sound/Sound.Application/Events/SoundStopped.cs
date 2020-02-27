namespace Sound.Application.Events
{
    public class SoundStopped
    {
        public string Value { get; }
        public SoundStopped(string value)
        {
            Value = value;
        }
    }
}