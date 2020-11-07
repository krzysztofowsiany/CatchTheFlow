namespace PomodoroStatus.Tests.Events
{
    public class LongBreakeSoundUpdated
    {
        public string Sound { get; }

        public LongBreakeSoundUpdated(string sound)
        {
            Sound = sound;
        }
    }
}