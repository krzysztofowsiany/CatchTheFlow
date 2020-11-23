namespace Sound.Application.Events
{
    public class ShortBreakSoundUpdated
    {
        public string Sound { get; }

        public ShortBreakSoundUpdated(string sound)
        {
            Sound = sound;
        }
    }
}