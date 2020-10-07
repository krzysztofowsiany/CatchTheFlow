using CQRSLib;
using EventBus;
using LongBreakView.Application.Commands;
using LongBreakView.Application.Events;

namespace LongBreakView.Application.CommandHandlers
{
    public class InterruptLongBreakCommandHandler: ICommandHandler<InterruptLongBreakCommand>
    {
        private readonly IEventBus _eventBus;

        public InterruptLongBreakCommandHandler(
            IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        
        public void Handle(InterruptLongBreakCommand command)
        {
            _eventBus.PushEvent(new LongBreakInterrupted(
              command.WorkTime, 
              command.StopTime));
        }
    }
}