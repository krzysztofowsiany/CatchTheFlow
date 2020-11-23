using CQRSLib;
using EventBus;
using StartLongBreakView.Application.Query;
using StartLongBreakView.Application.Views;

namespace StartLongBreakView.Application.QueryHandlers
{
    public class UserShortBreakTimeQueryHandler : IQueryHandler<UserShortBreakTimeQuery, ShortBreakTimeView>
    {
        private readonly IEventRepository _eventRepository;

        public UserShortBreakTimeQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public ShortBreakTimeView Handle(UserShortBreakTimeQuery query)
            => new ShortBreakTimeView(_eventRepository);
    }
}