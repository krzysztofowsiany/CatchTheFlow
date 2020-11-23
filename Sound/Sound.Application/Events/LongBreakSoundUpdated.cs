namespace Sound.Application.Events
{
    public class LongBreakSoundUpdated
    {
        public string Sound { get; }

        public LongBreakSoundUpdated(string sound)
        {
            Sound = sound;
        }
    }
}