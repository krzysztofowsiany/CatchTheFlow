using CQRSLib;
using EventBus;
using Suggestion.Application.Commands;
using Suggestion.Application.Events;

namespace Suggestion.Application.CommandHandlers
{
    public class SuggestLongBreakCommandHandler: ICommandHandler<SuggestLongBreakCommand>
    {
        private readonly IEventBus _eventBus;

        public SuggestLongBreakCommandHandler(
            IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        
        public void Handle(SuggestLongBreakCommand command)
        {
            _eventBus.PushEvent(new SuggestedLongBreak(
              command.BreakTime, 
              command.StopTime));
        }
    }
}