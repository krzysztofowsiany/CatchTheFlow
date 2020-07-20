using System;
using System.Windows;
using Autofac;
using CQRSLib;
using CQRSLib.DateTime;
using EventBus;
using StartWorkView.UI;
using Suggestion.Application.Events;

namespace CatchTheFlow
{
    public class CatchTheFlowEventListener
    {
        private readonly IEventBus _eventBus;
        private readonly ICommandBus _commandBus;
        private readonly IEventRepository _eventRepository;
        private readonly IDateTime _dateTime;

        public CatchTheFlowEventListener(
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
            _eventBus.Subscribe<SuggestedWork>(@event =>
            {
                Application.Current.Dispatcher.Invoke(delegate{
                    var dialog = IoT.Container.Resolve<StartWorkDialog>();
                    dialog.Show();
                });
            });
        }
    }
}