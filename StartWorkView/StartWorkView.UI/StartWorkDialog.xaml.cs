
using System;
using System.Windows;
using CQRSLib;
using StartWorkView.Application.Commands;
using StartWorkView.Application.Query;
using StartWorkView.Application.Views;

namespace StartWorkView.UI
{
    public partial class StartWorkDialog
    {
        private readonly ICommandBus _commandBus;
        private readonly UserWorkTime _result;

        public StartWorkDialog(ICommandBus commandBus, IQueryBus queryBus)
        {
            InitializeComponent();
            
            _commandBus = commandBus;
            _result = queryBus.Process<UserWorkTimeQuery, UserWorkTime>(new UserWorkTimeQuery());

            WorkTime.Text = $"{_result.WorkTime} min";
        }
        
        private void StartWork(object sender, RoutedEventArgs e)
        {
            var dateTime = DateTime.UtcNow;
            _commandBus.Send(new StartWorkCommand(_result.WorkTime, dateTime));
            Close();
        }
    }
}