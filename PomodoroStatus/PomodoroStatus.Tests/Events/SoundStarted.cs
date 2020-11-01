namespace PomodoroStatus.Tests.Events
{
    public class SoundStarted
    {
        public string Sound { get; }

        public SoundStarted(string sound)
        {
            Sound = sound;
        }
    }
}