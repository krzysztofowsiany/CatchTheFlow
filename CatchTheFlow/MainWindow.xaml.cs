using System.Windows;
using Autofac;
using EventBus;
using Sound.Application.Events;
using StartShortBreakeView.Application.Events;
using StartShortBreakeView.UI;
using StartWorkView.Application.Events;
using StartWorkView.UI;

namespace CatchTheFlow
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var eventBus = IoT.Container.Resolve<IEventBus>();
            eventBus.PushEvent(new WorkSoundUpdated("work_2.mp3"));
            eventBus.PushEvent(new ShortBreakeSoundUpdated("short_breake_1.mp3"));
            eventBus.PushEvent(new WorkTimeUpdated(20));
            eventBus.PushEvent(new ShortBreakeTimeUpdated(1));
        }
            
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var dialog = IoT.Container.Resolve<StartWorkDialog>();
            dialog.Show();
        }
        private void ButtonStartShortBreake_OnClick(object sender, RoutedEventArgs e)
        {
            var dialog = IoT.Container.Resolve<StartShortBreakeDialog>();
            dialog.Show();
        }
        
        
    }
}