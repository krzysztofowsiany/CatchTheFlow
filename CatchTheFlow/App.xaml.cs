using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;
using Autofac;
using Configuration.UI;
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

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow = new MainWindow();
            MainWindow.Closing += MainWindowClosing;

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
           // _result = queryBus.Process<StartWorkTimeQuery, StartWorkTime>(new StartWorkTimeQuery());
        }

        private void ShowMainWindow()
        {
           /* switch (_result.PomodoroStatus)
            {
                IoT.Container.Resolve<StartWorkDialog>().Show();    
            }*/
            
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