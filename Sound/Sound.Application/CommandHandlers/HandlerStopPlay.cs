using CQRSLib;
using Sound.Application.Commands;

namespace Sound.Application.CommandHandlers
{
    public class HandlerStopPlay: ICommandHandler<StopPlay>
    {
        public void Handle(StopPlay command)
        {
            
        }
    }
}