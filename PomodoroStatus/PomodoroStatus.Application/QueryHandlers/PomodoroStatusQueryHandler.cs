using CQRSLib;
using EventBus;
using PomodoroStatus.Application.Query;
using PomodoroStatus.Application.Views;

namespace PomodoroStatus.Application.QueryHandlers
{
    public class PomodoroStatusQueryHandler : IQueryHandler<PomodoroStatusQuery, PomodoroStatusView>
    {
        private readonly IEventRepository _eventRepository;

        public PomodoroStatusQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public PomodoroStatusView Handle(PomodoroStatusQuery query)
            => new PomodoroStatusView(_eventRepository);
    }
}