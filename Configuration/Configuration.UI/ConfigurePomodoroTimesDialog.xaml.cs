
using System.Windows;
using CQRSLib;
using Configuration.Application.Commands;
using Configuration.Application.Query;
using Configuration.Application.Views;

namespace Configuration.UI
{
    public partial class ConfigurePomodoroTimesDialog
    {
        private readonly ICommandBus _commandBus;
        private readonly TimeConfigurationView _result;

        public ConfigurePomodoroTimesDialog(ICommandBus commandBus, IQueryBus queryBus)
        {
            InitializeComponent();
            
            _commandBus = commandBus;
            _result = queryBus.Process<ConfiguraitonTimesQuery, TimeConfigurationView>(new ConfiguraitonTimesQuery());

            WorkTime.Value = _result.WorkTime;
            ShortBreakeTime.Value = _result.ShortBreakeTime;
            LongBreakeTime.Value = _result.LongBreakeTime;
        }
        
        private void SaveSettings(object sender, RoutedEventArgs e)
        {
            var workTime = (ushort)WorkTime.Value;
            var shortBreakeTime = (ushort)ShortBreakeTime.Value;
            var longBreakeTime = (ushort)LongBreakeTime.Value;
            
            _commandBus.Send(new SaveSettingsCommand(
                workTime, 
                shortBreakeTime, 
                longBreakeTime));
            
            Close();
        }
    }
}