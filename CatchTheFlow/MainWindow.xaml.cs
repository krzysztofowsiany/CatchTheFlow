using System.Windows;
using Autofac;
using StartLongBreakeView.UI;
using StartWorkView.UI;

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

        private void ButtonStartLongBreake_OnClick(object sender, RoutedEventArgs e)
        {
            var dialog = IoT.Container.Resolve<StartLongBreakeDialog>();
            dialog.Show();
        }
    }
}