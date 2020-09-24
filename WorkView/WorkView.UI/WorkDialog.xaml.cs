
using System;
using System.Windows;
using System.Windows.Threading;
using CQRSLib;
using WorkView.Application.Commands;
using WorkView.Application.Query;
using WorkView.Application.Views;

namespace WorkView.UI
{
    public partial class WorkDialog
    {
        private readonly ICommandBus _commandBus;
        private DispatcherTimer _timer;
        private DateTime _targetTime;
        private readonly StartWorkTime _result;

        public WorkDialog(ICommandBus commandBus, IQueryBus queryBus)
        {
            InitializeComponent();
            
            _commandBus = commandBus;
            _result = queryBus.Process<StartWorkTimeQuery, StartWorkTime>(new StartWorkTimeQuery());
            _targetTime = _result.StartTime.AddMinutes(_result.WorkTime);
            
            AddUpdateTimer();
        }

        private void AddUpdateTimer()
        {
            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _timer.Tick += (sender, args) => UpdateCurrentWorkTime();
            _timer.Start();
        }

        private void UpdateCurrentWorkTime()
        {
            var timeToEnd = DateTime.Now.Subtract(_targetTime);
            if (timeToEnd > TimeSpan.Zero)
                Close();
            
            WorkTime.Text = $"{Math.Abs(timeToEnd.Minutes)} min {Math.Abs(timeToEnd.Seconds)} sec";
        }

        private void InterruptWork(object sender, RoutedEventArgs e)
        {
            var dateTime = DateTime.UtcNow;
            _commandBus.Send(new InterruptWorkCommand(_result.WorkTime, dateTime));
            Close();
        }
    }
}