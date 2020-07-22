using CQRSLib;
using EventBus;
using Suggestion.Application.Commands;
using Suggestion.Application.Events;
using Suggestion.Application.Views;

namespace Suggestion.Infrastructure
{
    public class SuggestionEventListener
    {
        private const int PomodoroMaxWorkCycle = 4;

        private readonly IEventBus _eventBus;
        private readonly ICommandBus _commandBus;
        private readonly IEventRepository _eventRepository;

        public SuggestionEventListener(
            IEventBus eventBus,
            ICommandBus commandBus,
            IEventRepository eventRepository)
        {
            _eventBus = eventBus;
            _commandBus = commandBus;
            _eventRepository = eventRepository;

            SubscribeToWorkStarted();
            SubscribeToShortBreakeStopped();
        }

        private void  SubscribeToShortBreakeStopped()
        {
            _eventBus.Subscribe<ShortBreakeStopped>(@event =>
            {
                var view = new ShortBreakeStoppedInformation(_eventRepository);
                    _commandBus.Send(
                        new SuggestWorkCommand(view.WorkTime, view.StopTime)
                    );
            });
        }
        
        private void SubscribeToWorkStarted()
        {
            _eventBus.Subscribe<WorkStopped>(@event =>
            {
                var view = new TimeOfEndWorkView(_eventRepository);
                if (view.Count < PomodoroMaxWorkCycle)
                {
                    _commandBus.Send(
                        new SuggestShortBreakCommand(view.WorkTime, view.StopTime)
                        );
                }
                else
                {
                    _commandBus.Send(
                        new SuggestLongBreakeCommand(view.WorkTime, view.StopTime)
                    );
                }
            });
        }
    }
}