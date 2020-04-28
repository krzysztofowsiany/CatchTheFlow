using CQRSLib;
using CQRSLib.DateTime;
using EventBus;
using Sound.Application.Commands;
using Sound.Application.Views;
using Sound.Application.Events;
using DateTime = System.DateTime;

namespace Sound.Infrastructure
{
    public class SoundEventListener
    {
        private readonly IEventBus _eventBus;
        private readonly ICommandBus _commandBus;
        private readonly IEventRepository _eventRepository;
        private readonly IDateTime _dateTime;

        public SoundEventListener(
            IEventBus eventBus, 
            IDateTime dateTime,
            ICommandBus commandBus,
            IEventRepository eventRepository)
        {
            _eventBus = eventBus;
            _dateTime = dateTime;
            _commandBus = commandBus;
            _eventRepository = eventRepository;
            
            SubscribeToWorkStopped();
            SubscribeToWorkStarted();
        }

        private void SubscribeToWorkStarted()
        {
            _eventBus.Subscribe<WorkStarted>(@event =>
            {
                var view = new SoundWorkInformationView(_eventRepository);

                _commandBus.Send(new StartPlayCommand
                {
                    Timestamp = @event.Timestamp,
                    Sound = view.Sound
                });
            });
        }

        private void SubscribeToWorkStopped()
        {
            _eventBus.Subscribe<WorkStopped>(@event =>
            {
                var view = new WorkStopTimeView(_eventRepository);

                _commandBus.Send(new StopPlayCommand
                {
                    Timestamp = DateTime.UtcNow,
                    StopTime = view.StopTime
                });
            });
        }
    }
}