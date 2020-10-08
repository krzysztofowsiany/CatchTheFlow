using System.Windows;
using Autofac;
using Configuration.UI;
using LongBreakView.UI;
using ShortBreakView.UI;
using StartLongBreakeView.UI;
using StartWorkView.UI;
using WorkView.UI;

namespace CatchTheFlow
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
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

        private void ButtonStartLongBreake_OnClick(object sendeButtonConfig_OnClick, RoutedEventArgs e)
        {
            var dialog =  IoT.Container.Resolve<StartLongBreakeDialog>();
            dialog.Show();
        }

        private void ButtonConfig_OnClick(object sender, RoutedEventArgs e)
        {
            var dialog = IoT.Container.Resolve<ConfigurePomodoroTimesDialog>();
            dialog.Show();
        }

        private void ButtonConfig2_OnClick(object sender, RoutedEventArgs e)
        {
             var dialog = IoT.Container.Resolve<ConfigurePomodoroSoundsDialog>();
                dialog.Show();
        }

        private void ButtonInterruptWork_OnClick(object sender, RoutedEventArgs e)
        {
            var dialog = IoT.Container.Resolve<WorkDialog>();
            dialog.Show();
        }
        
        private void ButtonInterruptShortBreak_OnClick(object sender, RoutedEventArgs e)
        {
            var dialog = IoT.Container.Resolve<ShortBreakDialog>();
            dialog.Show();
        }
        
        private void ButtonInterruptLongBreak_OnClick(object sender, RoutedEventArgs e)
        {
            var dialog = IoT.Container.Resolve<LongBreakDialog>();
            dialog.Show();
        }
        
    }
}