using CQRSLib;
using EventBus;
using StartShortBreakeView.Application.Query;
using StartShortBreakeView.Application.Views;

namespace StartShortBreakeView.Application.QueryHandlers
{
    public class UserShortBreakeTimeQueryHandler : IQueryHandler<UserShortBreakeTimeQuery, ShortBreakeTimeView>
    {
        private readonly IEventRepository _eventRepository;

        public UserShortBreakeTimeQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public ShortBreakeTimeView Handle(UserShortBreakeTimeQuery query)
            => new ShortBreakeTimeView(_eventRepository);
    }
}