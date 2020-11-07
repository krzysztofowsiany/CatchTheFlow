namespace PomodoroStatus.Tests.Events
{
    public class ShortBreakeSoundUpdated
    {
        public string Sound { get; }

        public ShortBreakeSoundUpdated(string sound)
        {
            Sound = sound;
        }
    }
}