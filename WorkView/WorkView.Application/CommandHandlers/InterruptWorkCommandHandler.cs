using CQRSLib;
using EventBus;
using WorkView.Application.Commands;
using WorkView.Application.Events;

namespace WorkView.Application.CommandHandlers
{
    public class InterruptWorkCommandHandler: ICommandHandler<InterruptWorkCommand>
    {
        private readonly IEventBus _eventBus;

        public InterruptWorkCommandHandler(
            IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        
        public void Handle(InterruptWorkCommand command)
        {
            _eventBus.PushEvent(new WorkInterrupted(
              command.WorkTime, 
              command.StopTime));
        }
    }
}