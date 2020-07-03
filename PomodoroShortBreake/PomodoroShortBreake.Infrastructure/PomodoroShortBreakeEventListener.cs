using System;
using System.Reactive.Linq;
using CQRSLib;
using CQRSLib.DateTime;
using EventBus;
using PomodoroShortBreake.Application.Commands;
using PomodoroShortBreake.Application.Events;
using PomodoroShortBreake.Application.Views;
using DateTime = System.DateTime;

namespace PomodoroShortBreake.Infrastructure
{
    public class PomodoroShortBreakeEventListener
    {
        private readonly IEventBus _eventBus;
        private readonly ICommandBus _commandBus;
        private readonly IEventRepository _eventRepository;
        private readonly IDateTime _dateTime;

        public PomodoroShortBreakeEventListener(
            IEventBus eventBus,
            IDateTime dateTime,
            ICommandBus commandBus,
            IEventRepository eventRepository)
        {
            _eventBus = eventBus;
            _commandBus = commandBus;
            _eventRepository = eventRepository;
            _dateTime = dateTime;

            SubscribeToWorkStarted();
        }

        private void SubscribeToWorkStarted()
        {
            _eventBus.Subscribe<ShortBreakeStarted>(@event =>
            {
                var view = new ShortBreakeStartedInformationView(_eventRepository);

                Observable
                    .Timer(_dateTime.DueTime(view.BreakeTime))
                    .Subscribe(
                        onNext =>
                        {
                            _commandBus.Send(new StopShortBreakeCommand(
                                view.BreakeTime,
                                view.StartTime.AddMinutes(view.BreakeTime)));
                        }
                    );
            });
        }
    }
}