using CQRSLib;
using EventBus;
using Configuration.Application.Query;
using Configuration.Application.Views;

namespace Configuration.Application.QueryHandlers
{
    public class ConfiguraitonSoundsQueryHandler : IQueryHandler<ConfiguraitonSoundsQuery, SoundConfigurationView>
    {
        private readonly IEventRepository _eventRepository;

        public ConfiguraitonSoundsQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public SoundConfigurationView Handle(ConfiguraitonSoundsQuery query)
            => new SoundConfigurationView(_eventRepository);
    }
}