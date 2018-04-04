using System.ComponentModel;

namespace EGuard.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _startTime;
        private string _endTime;
        private string _test;

        public string StartTime
        {
            get
            {
               return _startTime; ;
            }
            set
            {
                _startTime = value;
                OnPropertyChanged("StartTime");
            }
        }

        public string EndTime
        {
            get
            {
                return _endTime;
            }
            set
            {
                _endTime = value;
                OnPropertyChanged("EndTime");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
