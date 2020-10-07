
using System;
using System.Windows;
using System.Windows.Threading;
using CQRSLib;
using LongBreakView.Application.Commands;
using LongBreakView.Application.Query;
using LongBreakView.Application.Views;

namespace LongBreakView.UI
{
    public partial class LongBreakDialog
    {
        private readonly ICommandBus _commandBus;
        private DispatcherTimer _timer;
        private DateTime _targetTime;
        private readonly StartLongBreakTimeView _result;

        public LongBreakDialog(ICommandBus commandBus, IQueryBus queryBus)
        {
            InitializeComponent();
            
            _commandBus = commandBus;
            _result = queryBus.Process<StartLongBreakTimeQuery, StartLongBreakTimeView>(new StartLongBreakTimeQuery());
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
            
            LongBreakTime.Text = $"{Math.Abs(timeToEnd.Minutes)} min {Math.Abs(timeToEnd.Seconds)} sec";
        }
      
        private void InterruptLongBreak(object sender, RoutedEventArgs e)
        {
            var dateTime = DateTime.UtcNow;
            _commandBus.Send(new InterruptLongBreakCommand(_result.BreakTime, dateTime));
            Close();
        }
    }
}