using CQRSLib;
using CQRSLib.DateTime;
using EventBus;
using DateTime = System.DateTime;

namespace StartWorkView.Infrastructure
{
    public class StartWorkViewEventListener
    {
        private readonly IEventBus _eventBus;
        private readonly ICommandBus _commandBus;
        private readonly IEventRepository _eventRepository;
        private readonly IDateTime _dateTime;

        public StartWorkViewEventListener(
            IEventBus eventBus,
            IDateTime dateTime,
            ICommandBus commandBus,
            IEventRepository eventRepository)
        {
            _eventBus = eventBus;
            _commandBus = commandBus;
            _eventRepository = eventRepository;
            _dateTime = dateTime;
            
            SubscribeToWorkStarted();
        }

        private void SubscribeToWorkStarted()
        {
           /* _eventBus.Subscribe<WorkStarted>(@event =>
            {
                var view = new StartWorkTimeView(_eventRepository);
                
                Observable
                    .Timer(_dateTime.DueTime(view.WorkTime))
                    .Subscribe(
                        onNext =>
                        {
                            _commandBus.Send(new StopWorkCommand
                            {
                                Timestamp = DateTime.UtcNow,
                                WorkTime =  view.WorkTime,
                                StopTime = view.StartTime.AddMinutes(view.WorkTime)
                            });  
                        }
                    );
            });*/
        }
    }
}