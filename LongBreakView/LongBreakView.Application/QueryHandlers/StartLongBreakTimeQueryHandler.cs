using CQRSLib;
using EventBus;
using LongBreakView.Application.Query;
using LongBreakView.Application.Views;

namespace LongBreakView.Application.QueryHandlers
{
    public class StartLongBreakTimeQueryHandler : IQueryHandler<StartLongBreakTimeQuery, StartLongBreakTimeView>
    {
        private readonly IEventRepository _eventRepository;

        public StartLongBreakTimeQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public StartLongBreakTimeView Handle(StartLongBreakTimeQuery query)
            => new StartLongBreakTimeView(_eventRepository);
    }
}