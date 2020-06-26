
using System;
using System.Windows;
using CQRSLib;
using StartShortBreakeView.Application.Commands;
using StartShortBreakeView.Application.Query;
using StartShortBreakeView.Application.Views;

namespace StartShortBreakeView.UI
{
    public partial class StartShortBreakeDialog
    {
        private readonly ICommandBus _commandBus;
        private readonly ShortBreakeTimeView _result;

        public StartShortBreakeDialog(ICommandBus commandBus, IQueryBus queryBus)
        {
            InitializeComponent();
            
            _commandBus = commandBus;
            _result = queryBus.Process<UserShortBreakeTimeQuery, ShortBreakeTimeView>(new UserShortBreakeTimeQuery());

            ShortBreakeTime.Text = $"{_result.BreakeTime} min";
        }
        
        private void StartShortBreake(object sender, RoutedEventArgs e)
        {
            var dateTime = DateTime.UtcNow;
            _commandBus.Send(new StartShortBreakeCommand(_result.BreakeTime, dateTime));
            Close();
        }
    }
}