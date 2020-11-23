using System.Windows;
using Autofac;
using EventBus;
using StartLongBreakView.UI;
using StartWorkView.UI;
using Suggestion.Application.Events;

namespace CatchTheFlow
{
    public class CatchTheFlowEventListener
    {
        private readonly IEventBus _eventBus;

        public CatchTheFlowEventListener(
            IEventBus eventBus)
        {
            _eventBus = eventBus;

            SubscribeToWorkStarted();         
            SubscribeToShortBreakStarted();
            SubscribeToLongBreakStarted();
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
        
        private void SubscribeToShortBreakStarted()
        {
            _eventBus.Subscribe<SuggestedShortBreak>(@event =>
            {
                Application.Current.Dispatcher.Invoke(delegate{
                    var dialog = IoT.Container.Resolve<StartShortBreakDialog>();
                    dialog.Show();
                });
            });
        }
        
        private void SubscribeToLongBreakStarted()
        {
            _eventBus.Subscribe<SuggestedLongBreak>(@event =>
            {
                Application.Current.Dispatcher.Invoke(delegate{
                    var dialog = IoT.Container.Resolve<StartLongBreakDialog>();
                    dialog.Show();
                });
            });
        }
    }
}