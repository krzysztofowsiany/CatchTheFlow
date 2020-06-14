namespace Sound.Application.Events
{
    public class WorkSoundUpdated
    {
        public string Sound { get; }

        public WorkSoundUpdated(string sound)
        {
            Sound = sound;
        }
    }
}