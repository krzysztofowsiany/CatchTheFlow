
using System;
using System.Windows;
using System.Windows.Threading;
using CQRSLib;
using ShortBreakView.Application.Commands;
using ShortBreakView.Application.Query;
using ShortBreakView.Application.Views;

namespace ShortBreakView.UI
{
    public partial class ShortBreakDialog
    {
        private readonly ICommandBus _commandBus;
        private DispatcherTimer _timer;
        private DateTime _targetTime;
        private readonly StartShortBreakTimeView _result;

        public ShortBreakDialog(ICommandBus commandBus, IQueryBus queryBus)
        {
            InitializeComponent();
            
            _commandBus = commandBus;
            _result = queryBus.Process<StartShortBreakTimeQuery, StartShortBreakTimeView>(new StartShortBreakTimeQuery());
            _targetTime = _result.StartTime.AddMinutes(_result.BreakTime);
            
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
            
            ShortBreakTime.Text = $"{Math.Abs(timeToEnd.Minutes)} min {Math.Abs(timeToEnd.Seconds)} sec";
        }

        private void InterruptShortBrake(object sender, RoutedEventArgs e)
        {
            var dateTime = DateTime.UtcNow;
            _commandBus.Send(new InterruptShortBreakCommand(_result.BreakTime, dateTime));
            Close();
        }
    }
}