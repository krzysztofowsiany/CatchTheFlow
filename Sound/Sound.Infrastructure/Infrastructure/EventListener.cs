using EventBus;
using Sound.Application.Views;
using Sound.Infrastructure.Events;

namespace Sound.Infrastructure
{
    public class EventListener
    {
        private IEventBus _eventBus;

        public EventListener(IEventBus eventBus)
        {
            _eventBus = eventBus;
            var events = _eventBus.Subscribe<WorkStopped>(@event =>
            {
                var view = new WorkStopTime(@event.StopTime);
                
                
                //_eventBus.PushEvent(new SoundStopped(@event.Timestamp));
              //  Console.WriteLine($"Event in sound {onNext.Value}");
              
            });
                
        }
    }
}