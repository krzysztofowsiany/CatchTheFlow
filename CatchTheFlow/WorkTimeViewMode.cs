using System.ComponentModel;
using System.Runtime.CompilerServices;
using CatchTheFlow.Annotations;

namespace CatchTheFlow
{
    public sealed class WorkTimeViewMode:INotifyPropertyChanged
    {
        private ushort _workTime;
        public ushort WorkTime
        {
            get => _workTime;
            set
            {
                _workTime = value;
                OnPropertyChanged();
            }
        }

        public string WorkTimeText => $"{_workTime} min";

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}