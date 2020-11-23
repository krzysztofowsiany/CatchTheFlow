using CQRSLib;
using EventBus;
using StartLongBreakView.Application.Query;
using StartLongBreakView.Application.Views;

namespace StartLongBreakView.Application.QueryHandlers
{
    public class UserLongBreakTimeQueryHandler : IQueryHandler<UserLongBreakTimeQuery, LongBreakTimeView>
    {
        private readonly IEventRepository _eventRepository;

        public UserLongBreakTimeQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public LongBreakTimeView Handle(UserLongBreakTimeQuery query)
            => new LongBreakTimeView(_eventRepository);
    }
}