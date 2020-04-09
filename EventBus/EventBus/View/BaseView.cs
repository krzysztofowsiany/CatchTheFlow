namespace EventBus.View
{
    public abstract class BaseView
    {
        protected IEventRepository _eventRepository;

        protected BaseView(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public abstract void RestoreState();
    }
}