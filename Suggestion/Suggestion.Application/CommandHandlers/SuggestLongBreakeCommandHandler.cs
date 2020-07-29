using CQRSLib;
using EventBus;
using Suggestion.Application.Commands;
using Suggestion.Application.Events;

namespace Suggestion.Application.CommandHandlers
{
    public class SuggestLongBreakeCommandHandler: ICommandHandler<SuggestLongBreakeCommand>
    {
        private readonly IEventBus _eventBus;

        public SuggestLongBreakeCommandHandler(
            IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        
        public void Handle(SuggestLongBreakeCommand command)
        {
            _eventBus.PushEvent(new SuggestedLongBreake(
              command.BreakeTime, 
              command.StopTime));
        }
    }
}