using CQRSLib;
using EventBus;
using Suggestion.Application.Commands;
using Suggestion.Application.Events;

namespace Suggestion.Application.CommandHandlers
{
    public class SuggestWorkCommandHandler: ICommandHandler<SuggestWorkCommand>
    {
        private readonly IEventBus _eventBus;

        public SuggestWorkCommandHandler(
            IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        
        public void Handle(SuggestWorkCommand command)
        {
            _eventBus.PushEvent(new SuggestedWork(
              command.WorkTime, 
              command.StopTime));
        }
    }
}