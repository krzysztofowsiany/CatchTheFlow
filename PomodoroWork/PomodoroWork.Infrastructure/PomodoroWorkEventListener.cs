using System;
using System.Reactive.Linq;
using CQRSLib;
using CQRSLib.DateTime;
using EventBus;
using PomodoroWork.Application.Commands;
using PomodoroWork.Application.Events;
using PomodoroWork.Application.Views;
using DateTime = System.DateTime;

namespace PomodoroWork.Infrastructure
{
    public class PomodoroWorkEventListener
    {
        private readonly IEventBus _eventBus;
        private readonly ICommandBus _commandBus;
        private readonly IEventRepository _eventRepository;
        private readonly IDateTime _dateTime;

        public PomodoroWorkEventListener(
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
            _eventBus.Subscribe<WorkStarted>(@event =>
            {
                var view = new StartWorkTimeView(_eventRepository);

                Observable
                    .Timer(_dateTime.DueTime(view.WorkTime))
                    .Subscribe(
                        onNext =>
                        {
                            _commandBus.Send(new StopWorkCommand(
                                view.WorkTime,
                                view.StartTime.AddMinutes(view.WorkTime),
                                DateTime.UtcNow));
                        }
                    );
            });
        }
    }
}