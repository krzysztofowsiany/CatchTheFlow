using CQRSLib;
using EventBus;
using StartLongBreakeView.Application.Query;
using StartLongBreakeView.Application.Views;

namespace StartLongBreakeView.Application.QueryHandlers
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