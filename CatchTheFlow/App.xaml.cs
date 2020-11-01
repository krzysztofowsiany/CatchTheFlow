using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;
using Autofac;
using Configuration.UI;
using CQRSLib;
using LongBreakView.UI;
using PomodoroStatus.Application.Query;
using PomodoroStatus.Application.Views;
using ShortBreakView.UI;
using StartWorkView.UI;
using WorkView.UI;

namespace CatchTheFlow
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// https://www.thomasclaudiushuber.com/2015/08/22/creating-a-background-application-with-wpf/
    /// </summary>
    public partial class App
    {
        private NotifyIcon _notifyIcon;
        private bool _isExit;
        private IQueryBus _queryBus;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow = new MainWindow();
            MainWindow.Closing += MainWindowClosing;
            _queryBus = IoT.Container.Resolve<IQueryBus>();
            CreateNotifyIcon();
        }

        private void CreateContextMenu()
        {
            _notifyIcon.ContextMenuStrip = new ContextMenuStrip();
            _notifyIcon.ContextMenuStrip.Items.Add("Sounds").Click += (sender, args) =>
                IoT.Container.Resolve<ConfigurePomodoroSoundsDialog>().Show();
            
            _notifyIcon.ContextMenuStrip.Items.Add("Pomodoro Times").Click+= (sender, args) =>
                IoT.Container.Resolve<ConfigurePomodoroTimesDialog>().Show();
        }

        private void CreateNotifyIcon()
        {
            _notifyIcon = new NotifyIcon();
            _notifyIcon.Icon = CatchTheFlow.Properties.Resources.CatchTheFlowLogo;
            _notifyIcon.DoubleClick += (s, args) => ShowMainWindow();
            _notifyIcon.Visible = true;

            CreateContextMenu();
        }

        private void ShowMainWindow()
        {
            
            var status = _queryBus.Process<PomodoroStatusQuery, PomodoroStatusView>(new PomodoroStatusQuery());
        
            switch (status.PomodoroStatus)
            {
                case PomodoroStatus.Application.Views.PomodoroStatus.WorkToStart:
                    IoT.Container.Resolve<StartWorkDialog>().Show();
                break;
                
                case PomodoroStatus.Application.Views.PomodoroStatus.LongBreak:
                    IoT.Container.Resolve<LongBreakDialog>().Show();
                    break;
                
                case PomodoroStatus.Application.Views.PomodoroStatus.ShortBreak:
                    IoT.Container.Resolve<ShortBreakDialog>().Show();
                    break;
                
                case PomodoroStatus.Application.Views.PomodoroStatus.Work:
                    IoT.Container.Resolve<WorkDialog>().Show();
                    break;
            }
            
        }

        private void ShowMainWindow2()
        {
            if (MainWindow.IsVisible)
            {
                if (MainWindow.WindowState == WindowState.Minimized)
                {
                    MainWindow.WindowState = WindowState.Normal;
                }
                MainWindow.Activate();
            }
            else
            {
                MainWindow.Show();
            }
        }

        private void MainWindowClosing(object sender, CancelEventArgs e)
        {
            if (!_isExit)
            {
                e.Cancel = true;
                MainWindow.Hide();
            }
        }
    }
}