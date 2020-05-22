using CQRSLib;
using EventBus;
using StartWorkView.Application.Query;
using StartWorkView.Application.Views;

namespace StartWorkView.Application.QueryHandlers
{
    public class UserWorkTimeQueryHandler : IQueryHandler<UserWorkTimeQuery, UserWorkTime>
    {
        private readonly IEventRepository _eventRepository;

        public UserWorkTimeQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public UserWorkTime Handle(UserWorkTimeQuery query)
            => new UserWorkTime(_eventRepository);
    }
}