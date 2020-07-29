
using System;
using System.Windows;
using CQRSLib;
using StartLongBreakeView.Application.Commands;
using StartLongBreakeView.Application.Query;
using StartLongBreakeView.Application.Views;

namespace StartLongBreakeView.UI
{
    public partial class StartLongBreakeDialog
    {
        private readonly ICommandBus _commandBus;
        private readonly LongBreakeTimeView _result;

        public StartLongBreakeDialog(ICommandBus commandBus, IQueryBus queryBus)
        {
            InitializeComponent();
            
            _commandBus = commandBus;
            _result = queryBus.Process<UserLongBreakeTimeQuery, LongBreakeTimeView>(new UserLongBreakeTimeQuery());

            LongBreakeTime.Text = $"{_result.BreakeTime} min";
        }
        
        private void StartShortBreake(object sender, RoutedEventArgs e)
        {
            var dateTime = DateTime.UtcNow;
            _commandBus.Send(new StartLongBreakeCommand(_result.BreakeTime, dateTime));
            Close();
        }
    }
}