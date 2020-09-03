using CQRSLib;
using EventBus;
using Configuration.Application.Query;
using Configuration.Application.Views;

namespace Configuration.Application.QueryHandlers
{
    public class ConfiguraitonTimesQueryHandler : IQueryHandler<ConfiguraitonTimesQuery, TimeConfigurationView>
    {
        private readonly IEventRepository _eventRepository;

        public ConfiguraitonTimesQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public TimeConfigurationView Handle(ConfiguraitonTimesQuery query)
            => new TimeConfigurationView(_eventRepository);
    }
}