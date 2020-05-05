using CQRSLib;
using EventBus;
using StartWorkView.Application.Commands;
using StartWorkView.Application.Events;

namespace StartWorkView.Application.CommandHandlers
{
    public class StartWorkCommandHandler: ICommandHandler<StartWorkCommand>
    {
        private readonly IEventBus _eventBus;

        public StartWorkCommandHandler(
            IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        
        public void Handle(StartWorkCommand command)
        {
          _eventBus.PushEvent(new WorkStarted(
              command.WorkTime, 
              command.StopTime,
              command.Timestamp));
        }
    }
}