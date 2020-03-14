
using System.Media;

namespace Sound.Core
{
    public class SoundPlayerFacade
    {
        private readonly SoundPlayer _playerPlayer;

        public SoundPlayerFacade()
        {
            _playerPlayer = new SoundPlayer();
        }
        public void StopPlay()
        {
            _playerPlayer.Stop();
        }
    }
}