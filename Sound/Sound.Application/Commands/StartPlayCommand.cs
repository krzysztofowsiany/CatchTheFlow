using CQRSLib;

namespace Sound.Application.Commands
{
    public class StartPlayCommand: ICommand
    {
        public StartPlayCommand(string sound)
        {
            Sound = sound;
        }

        public string Sound { get;  }
    }
}