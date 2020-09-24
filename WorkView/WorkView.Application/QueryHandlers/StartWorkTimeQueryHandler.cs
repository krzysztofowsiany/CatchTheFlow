using CQRSLib;
using EventBus;
using WorkView.Application.Query;
using WorkView.Application.Views;

namespace WorkView.Application.QueryHandlers
{
    public class StartWorkTimeQueryHandler : IQueryHandler<StartWorkTimeQuery, StartWorkTime>
    {
        private readonly IEventRepository _eventRepository;

        public StartWorkTimeQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public StartWorkTime Handle(StartWorkTimeQuery query)
            => new StartWorkTime(_eventRepository);
    }
}