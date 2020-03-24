namespace Sound.Core
{
    public interface ISoundPlayer
    {
        void Stop();

        void Play(string sound);
    }
}