
using System;
using System.Windows;
using CQRSLib;
using StartLongBreakView.Application.Commands;
using StartLongBreakView.Application.Query;
using StartLongBreakView.Application.Views;

namespace StartLongBreakView.UI
{
    public partial class StartLongBreakDialog
    {
        private readonly ICommandBus _commandBus;
        private readonly LongBreakTimeView _result;

        public StartLongBreakDialog(ICommandBus commandBus, IQueryBus queryBus)
        {
            InitializeComponent();
            
            _commandBus = commandBus;
            _result = queryBus.Process<UserLongBreakTimeQuery, LongBreakTimeView>(new UserLongBreakTimeQuery());

            LongBreakeTime.Text = $"{_result.BreakTime} min";
        }
        
        private void StartShortBreake(object sender, RoutedEventArgs e)
        {
            var dateTime = DateTime.UtcNow;
            _commandBus.Send(new StartLongBreakCommand(_result.BreakTime, dateTime));
            Close();
        }
    }
}