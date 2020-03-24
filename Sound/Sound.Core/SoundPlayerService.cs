
namespace Sound.Core
{
    public class SoundPlayerService
    {
        private readonly ISoundPlayer _soundPlayer;

        public SoundPlayerService(ISoundPlayer soundPlayer)
        {
            _soundPlayer = soundPlayer;
        }
        public void StopPlay()
        {
            _soundPlayer.Stop();
        }

        public void StartPlay(string sound)
        {
            _soundPlayer.Play(sound);
        }
    }
}