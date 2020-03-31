using CQRSLib;
using EventBus;
using Sound.Application.Commands;
using Sound.Application.Views;
using Sound.Application.Events;

namespace Sound.Infrastructure
{
    public class EventListener
    {
        private readonly IEventBus _eventBus;
        private readonly ICommandBus _commandBus;
        private readonly IEventRepository _eventRepository;

        public EventListener(
            IEventBus eventBus, 
            ICommandBus commandBus,
            IEventRepository eventRepository)
        {
            _eventBus = eventBus;
            _commandBus = commandBus;
            _eventRepository = eventRepository;
            
            SubscribeToWorkStopped();
            SubscribeToWorkStarted();
        }

        private void SubscribeToWorkStarted()
        {
            _eventBus.Subscribe<WorkStarted>(@event =>
            {
                var view = new SoundWorkInformation(@event, _eventRepository.Events);

                _commandBus.Send(new StartPlay
                {
                    Timestamp = view.Timestamp,
                    Sound = view.Sound
                });
            });
        }

        private void SubscribeToWorkStopped()
        {
            _eventBus.Subscribe<WorkStopped>(@event =>
            {
                var view = new WorkStopTime(@event.StopTime);

                _commandBus.Send(new StopPlay
                {
                    Timestamp = @event.Timestamp
                });
            });
        }
    }
}