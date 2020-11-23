using System;
using System.Reactive.Linq;
using CQRSLib;
using CQRSLib.DateTime;
using EventBus;
using PomodoroShortBreak.Application.Commands;
using PomodoroShortBreak.Application.Events;
using PomodoroShortBreak.Application.Views;
using DateTime = System.DateTime;

namespace PomodoroShortBreak.Infrastructure
{
    public class PomodoroShortBreakEventListener
    {
        private readonly IEventBus _eventBus;
        private readonly ICommandBus _commandBus;
        private readonly IEventRepository _eventRepository;
        private readonly IDateTime _dateTime;

        public PomodoroShortBreakEventListener(
            IEventBus eventBus,
            IDateTime dateTime,
            ICommandBus commandBus,
            IEventRepository eventRepository)
        {
            _eventBus = eventBus;
            _commandBus = commandBus;
            _eventRepository = eventRepository;
            _dateTime = dateTime;

            SubscribeToShortBreakStarted();
            SubscribeToShortBreakInterrupted();
        }

        private void SubscribeToShortBreakInterrupted()
        {
            _eventBus.Subscribe<ShortBreakInterrupted>(@event =>
            {
                _commandBus.Send(new StopShortBreakCommand(
                    @event.WorkTime,
                    DateTime.UtcNow));
            });
        }

        private void SubscribeToShortBreakStarted()
        {
            _eventBus.Subscribe<ShortBreakStarted>(@event =>
            {
                var view = new ShortBreakStartedInformationView(_eventRepository);

                Observable
                    .Timer(_dateTime.DueTime(view.BreakTime))
                    .Subscribe(
                        onNext =>
                        {
                            _commandBus.Send(new StopShortBreakCommand(
                                view.BreakTime,
                                view.StartTime.AddMinutes(view.BreakTime)));
                        }
                    );
            });
        }
    }
}