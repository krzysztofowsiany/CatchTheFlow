
using System.Collections.Generic;
using System.Windows;
using CQRSLib;
using Configuration.Application.Commands;
using Configuration.Application.Query;
using Configuration.Application.Views;

namespace Configuration.UI
{
    public partial class ConfigurePomodoroSoundsDialog
    {
        private readonly ICommandBus _commandBus;
        private readonly SoundConfigurationView _result;

        public ConfigurePomodoroSoundsDialog(ICommandBus commandBus, IQueryBus queryBus)
        {
            InitializeComponent();
            
            _commandBus = commandBus;
            _result = queryBus.Process<ConfiguraitonSoundsQuery, SoundConfigurationView>(new ConfiguraitonSoundsQuery());

            var workSoundFiles = new List<string>();
            workSoundFiles.Add("work_1.mp3");
            workSoundFiles.Add("work_2.mp3");
            workSounds.ItemsSource = workSoundFiles;
            workSounds.SelectedValue = _result.WorkSound;
            
            var shortBreakSoundFiles = new List<string>();
            shortBreakSoundFiles.Add("short_breake_1.mp3");
            shortBreakSoundFiles.Add("short_breake_2.mp3");
            shortBreakSounds.ItemsSource = shortBreakSoundFiles;
            shortBreakSounds.SelectedValue = _result.ShortBreakeSound;
            
            var longBreakSoundFiles = new List<string>();
            longBreakSoundFiles.Add("long_breake_1.mp3");
            longBreakSoundFiles.Add("long_breake_2.mp3");
            longBreakSounds.ItemsSource = longBreakSoundFiles;
            longBreakSounds.SelectedValue = _result.LongBreakeSound;
        }
        
        private void SaveSettings(object sender, RoutedEventArgs e)
        {
            _commandBus.Send(new SaveSoundSettingsCommand(
                workSounds.SelectedValue.ToString(), 
                shortBreakSounds.SelectedValue.ToString(), 
                longBreakSounds.SelectedValue.ToString())
            );
            
            Close();
        }
    }
}