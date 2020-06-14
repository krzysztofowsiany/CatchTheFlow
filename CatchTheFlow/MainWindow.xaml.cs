using System;
using System.Windows;
using Autofac;
using EventBus;
using Sound.Application.Events;
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
            eventBus.PushEvent(new WorkTimeUpdated(25));
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var dialog = IoT.Container.Resolve<StartWorkDialog>();
            dialog.Show();
        }
    }
}