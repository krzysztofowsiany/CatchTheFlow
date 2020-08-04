using CQRSLib;
using EventBus;
using Sound.Application.Commands;
using Sound.Application.Views;
using Sound.Application.Events;

namespace Sound.Infrastructure
{
    public class SoundEventListener
    {
        private readonly IEventBus _eventBus;
        private readonly ICommandBus _commandBus;
        private readonly IEventRepository _eventRepository;

        public SoundEventListener(
            IEventBus eventBus, 
            ICommandBus commandBus,
            IEventRepository eventRepository)
        {
            _eventBus = eventBus;
            _commandBus = commandBus;
            _eventRepository = eventRepository;
            
            SubscribeToWorkStopped();
            SubscribeToWorkStarted();
            SubscribeToShortBreakeStarted();
            SubscribeToShortBreakeStopped();
            SubscribeToLongBreakeStarted();
            SubscribeToLongBreakeStopped();
        }

        private void SubscribeToShortBreakeStarted()
        {
            _eventBus.Subscribe<ShortBreakeStarted>(@event =>
            {
                var view = new SoundShortBreakeInformationView(_eventRepository);

                _commandBus.Send(new StartPlayCommand(view.Sound));
            });
        }
        
        private void SubscribeToLongBreakeStarted()
        {
            _eventBus.Subscribe<LongBreakeStarted>(@event =>
            {
                var view = new SoundLongBreakeInformationView(_eventRepository);

                _commandBus.Send(new StartPlayCommand(view.Sound));
            });
        }
        
        private void SubscribeToWorkStarted()
        {
            _eventBus.Subscribe<WorkStarted>(@event =>
            {
                var view = new SoundWorkInformationView(_eventRepository);

                _commandBus.Send(new StartPlayCommand(view.Sound));
            });
        }

        private void SubscribeToWorkStopped()
        {
            _eventBus.Subscribe<WorkStopped>(@event =>
            {
                var view = new WorkStopTimeView(_eventRepository);

                _commandBus.Send(new StopPlayCommand (view.StopTime));
            });
        }
        
        private void SubscribeToShortBreakeStopped()
        {
            _eventBus.Subscribe<ShortBreakeStopped>(@event =>
            {
                var view = new ShortBreakeStopTimeView(_eventRepository);

                _commandBus.Send(new StopPlayCommand (view.StopTime));
            });
        }
        
        private void SubscribeToLongBreakeStopped()
        {
            _eventBus.Subscribe<LongBreakeStopped>(@event =>
            {
                var view = new LongBreakeStopTimeView(_eventRepository);

                _commandBus.Send(new StopPlayCommand (view.StopTime));
            });
        }
    }
}