using CQRSLib;
using EventBus;
using Sound.Application.Commands;
using Sound.Application.Views;
using Sound.Application.Events;

namespace Sound.Infrastructure
{
    public class EventListener
    {
        public EventListener(
            IEventBus eventBus, 
            ICommandBus commandBus)
        {
            eventBus.Subscribe<WorkStopped>(@event =>
            {
                var view = new WorkStopTime(@event.StopTime);
                
                commandBus.Send(new StopPlay
                {
                    Timestamp = @event.Timestamp
                });
            });
            
            eventBus.Subscribe<WorkStarted>(@event =>
            {
                var view = new SoundWorkInformation(@event);
                
                commandBus.Send(new StartPlay
                {
                    Timestamp = view.Timestamp,
                    Sound = view.Sound
                });
            });
                
        }
    }
}