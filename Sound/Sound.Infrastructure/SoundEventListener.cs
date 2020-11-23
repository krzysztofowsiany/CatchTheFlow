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
            SubscribeToWorkInterrupted();
            
            SubscribeToShortBreakStarted();
            SubscribeToShortBreakStopped();
            SubscribeToShortBreakInterrupted();
            
            SubscribeToLongBreakStarted();
            SubscribeToLongBreakStopped();
            SubscribeToLongBreakInterrupted();
        }

        private void SubscribeToShortBreakStarted()
        {
            _eventBus.Subscribe<ShortBreakStarted>(@event =>
            {
                var view = new SoundShortBreakInformationView(_eventRepository);

                _commandBus.Send(new StartPlayCommand(view.Sound));
            });
        }
        
        private void SubscribeToLongBreakStarted()
        {
            _eventBus.Subscribe<LongBreakStarted>(@event =>
            {
                var view = new SoundLongBreakInformationView(_eventRepository);

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
        
        private void SubscribeToWorkInterrupted()
        {
            _eventBus.Subscribe<WorkInterrupted>(@event =>
            {
                _commandBus.Send(new StopPlayCommand (@event.StartTime));
            });
        }
        
        private void SubscribeToShortBreakInterrupted()
        {
            _eventBus.Subscribe<ShortBreakInterrupted>(@event =>
            {
                _commandBus.Send(new StopPlayCommand (@event.StartTime));
            });
        }
        
        private void SubscribeToLongBreakInterrupted()
        {
            _eventBus.Subscribe<LongBreakInterrupted>(@event =>
            {
                _commandBus.Send(new StopPlayCommand (@event.StartTime));
            });
        }
        
        private void SubscribeToShortBreakStopped()
        {
            _eventBus.Subscribe<ShortBreakStopped>(@event =>
            {
                var view = new ShortBreakStopTimeView(_eventRepository);

                _commandBus.Send(new StopPlayCommand (view.StopTime));
            });
        }
        
        private void SubscribeToLongBreakStopped()
        {
            _eventBus.Subscribe<LongBreakStopped>(@event =>
            {
                var view = new LongBreakStopTimeView(_eventRepository);

                _commandBus.Send(new StopPlayCommand (view.StopTime));
            });
        }
    }
}