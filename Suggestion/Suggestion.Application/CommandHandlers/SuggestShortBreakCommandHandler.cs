using CQRSLib;
using EventBus;
using Suggestion.Application.Commands;

namespace Suggestion.Application.CommandHandlers
{
    public class SuggestShortBreakCommandHandler: ICommandHandler<SuggestShortBreakCommand>
    {
        private readonly IEventBus _eventBus;

        public SuggestShortBreakCommandHandler(
            IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        
        public void Handle(SuggestShortBreakCommand command)
        {
          /*eventBus.PushEvent(new WorkStarted(
              command.WorkTime, 
              command.StopTime,
              command.Timestamp));*/
        }
    }
}