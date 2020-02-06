using System.Reactive.Linq;
using EventBus;

namespace Sound.Application
{
    public class Consumer
    {
        private IEventBus _eventBus;

        public Consumer(IEventBus eventBus)
        {
            _eventBus = eventBus;
            _eventBus
                .OfType<IEvent>()
                .Where(e => e.)
                .Subscribe();
        }
    }
}