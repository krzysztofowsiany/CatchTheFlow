using System;
using System.Reactive.Linq;
using CQRSLib;
using CQRSLib.DateTime;
using EventBus;
using PomodoroLongBreak.Application.Commands;
using PomodoroLongBreak.Application.Events;
using PomodoroLongBreak.Application.Views;
using DateTime = System.DateTime;

namespace PomodoroLongBreak.Infrastructure
{
    public class PomodoroLongBreakEventListener
    {
        private readonly IEventBus _eventBus;
        private readonly ICommandBus _commandBus;
        private readonly IEventRepository _eventRepository;
        private readonly IDateTime _dateTime;

        public PomodoroLongBreakEventListener(
            IEventBus eventBus,
            IDateTime dateTime,
            ICommandBus commandBus,
            IEventRepository eventRepository)
        {
            _eventBus = eventBus;
            _commandBus = commandBus;
            _eventRepository = eventRepository;
            _dateTime = dateTime;

            SubscribeToLongBreakStarted();
            SubscribeToLongBreakInterrupted();
        }

        private void SubscribeToLongBreakInterrupted()
        {
            _eventBus.Subscribe<LongBreakInterrupted>(@event =>
            {
                _commandBus.Send(new StopLongBreakCommand(
                    @event.WorkTime,
                    DateTime.UtcNow));
            });
        }

        private void SubscribeToLongBreakStarted()
        {
            _eventBus.Subscribe<LongBreakStarted>(@event =>
            {
                var view = new LongBreakStartedInformationView(_eventRepository);

                Observable
                    .Timer(_dateTime.DueTime(view.BreakTime))
                    .Subscribe(
                        onNext =>
                        {
                            _commandBus.Send(new StopLongBreakCommand(
                                view.BreakTime,
                                view.StartTime.AddMinutes(view.BreakTime)));
                        }
                    );
            });
        }
    }
}