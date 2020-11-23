
using System;
using System.Windows;
using CQRSLib;
using StartLongBreakView.Application.Commands;
using StartLongBreakView.Application.Query;
using StartLongBreakView.Application.Views;

namespace StartLongBreakView.UI
{
    public partial class StartShortBreakDialog
    {
        private readonly ICommandBus _commandBus;
        private readonly ShortBreakTimeView _result;

        public StartShortBreakDialog(ICommandBus commandBus, IQueryBus queryBus)
        {
            InitializeComponent();
            
            _commandBus = commandBus;
            _result = queryBus.Process<UserShortBreakTimeQuery, ShortBreakTimeView>(new UserShortBreakTimeQuery());

            ShortBreakTime.Text = $"{_result.BreakTime} min";
        }
        
        private void StartShortBreak(object sender, RoutedEventArgs e)
        {
            var dateTime = DateTime.UtcNow;
            _commandBus.Send(new StartShortBreakCommand(_result.BreakTime, dateTime));
            Close();
        }
    }
}