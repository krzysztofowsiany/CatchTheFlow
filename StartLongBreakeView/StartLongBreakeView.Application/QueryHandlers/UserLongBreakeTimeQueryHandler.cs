using CQRSLib;
using EventBus;
using StartLongBreakeView.Application.Query;
using StartLongBreakeView.Application.Views;

namespace StartLongBreakeView.Application.QueryHandlers
{
    public class UserLongBreakeTimeQueryHandler : IQueryHandler<UserLongBreakeTimeQuery, LongBreakeTimeView>
    {
        private readonly IEventRepository _eventRepository;

        public UserLongBreakeTimeQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public LongBreakeTimeView Handle(UserLongBreakeTimeQuery query)
            => new LongBreakeTimeView(_eventRepository);
    }
}