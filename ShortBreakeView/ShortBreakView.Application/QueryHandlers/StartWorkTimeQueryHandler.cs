using CQRSLib;
using EventBus;
using ShortBreakView.Application.Query;
using ShortBreakView.Application.Views;

namespace ShortBreakView.Application.QueryHandlers
{
    public class StartShortBreakTimeQueryHandler : IQueryHandler<StartShortBreakTimeQuery, StartShortBreakTimeView>
    {
        private readonly IEventRepository _eventRepository;

        public StartShortBreakTimeQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public StartShortBreakTimeView Handle(StartShortBreakTimeQuery query)
            => new StartShortBreakTimeView(_eventRepository);
    }
}