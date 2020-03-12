
using System;
using System.Media;

namespace Sound.Core
{
    public class SoundPlayerFacade
    {
        private SoundPlayer _playerPlayer;

        public SoundPlayerFacade()
        {
            _playerPlayer = new SoundPlayer();
        }
        public void StopPlay()
        {
            Console.WriteLine("stop play");
           // _playerPlayer.Stop();
        }
    }
}