using CQRSLib;
using EventBus;
using ShortBreakView.Application.Commands;
using ShortBreakView.Application.Events;

namespace ShortBreakView.Application.CommandHandlers
{
    public class InterruptShortBreakCommandHandler: ICommandHandler<InterruptShortBreakCommand>
    {
        private readonly IEventBus _eventBus;

        public InterruptShortBreakCommandHandler(
            IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        
        public void Handle(InterruptShortBreakCommand command)
        {
            _eventBus.PushEvent(new ShortBreakInterrupted(
              command.WorkTime, 
              command.StopTime));
        }
    }
}