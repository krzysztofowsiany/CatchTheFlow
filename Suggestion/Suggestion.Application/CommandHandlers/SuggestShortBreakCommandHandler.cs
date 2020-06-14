using CQRSLib;
using EventBus;
using Suggestion.Application.Commands;
using Suggestion.Application.Events;

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
            _eventBus.PushEvent(new SuggestedShortBreake(
              command.BreakeTime, 
              command.StopTime));
        }
    }
}