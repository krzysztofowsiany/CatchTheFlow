using System;
using System.Reactive.Linq;
using CQRSLib;
using CQRSLib.DateTime;
using EventBus;
using PomodoroLongBreake.Application.Commands;
using PomodoroLongBreake.Application.Events;
using PomodoroLongBreake.Application.Views;

namespace PomodoroLongBreake.Infrastructure
{
    public class PomodoroLongBreakeEventListener
    {
        private readonly IEventBus _eventBus;
        private readonly ICommandBus _commandBus;
        private readonly IEventRepository _eventRepository;
        private readonly IDateTime _dateTime;

        public PomodoroLongBreakeEventListener(
            IEventBus eventBus,
            IDateTime dateTime,
            ICommandBus commandBus,
            IEventRepository eventRepository)
        {
            _eventBus = eventBus;
            _commandBus = commandBus;
            _eventRepository = eventRepository;
            _dateTime = dateTime;

            SubscribeToLongBreakeStarted();
        }

        private void SubscribeToLongBreakeStarted()
        {
            _eventBus.Subscribe<LongBreakeStarted>(@event =>
            {
                var view = new LongBreakeStartedInformationView(_eventRepository);

                Observable
                    .Timer(_dateTime.DueTime(view.BreakeTime))
                    .Subscribe(
                        onNext =>
                        {
                            _commandBus.Send(new StopLongBreakeCommand(
                                view.BreakeTime,
                                view.StartTime.AddMinutes(view.BreakeTime)));
                        }
                    );
            });
        }
    }
}