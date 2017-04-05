using EGuard.Data.Repositories;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace EGuard.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _startTime;
        private string _endTime;
        private ObservableCollection<string> _pendingUrls = new ObservableCollection<string>();

        private readonly ISiteCategoryRepository _siteCategoryRepository;

        public MainViewModel(ISiteCategoryRepository siteCategoryRepository)
        {
            _siteCategoryRepository = siteCategoryRepository;
            _startTime = "09:00";
            _endTime = "17:00";
            _pendingUrls = new ObservableCollection<string>(_siteCategoryRepository.GetPendingUrls());
        }

        public string StartTime
        {
            get
            {
               return _startTime;
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

        public ObservableCollection<string> PendingSites
        {
            get
            {
                return _pendingUrls;
            }
            set
            {
                _pendingUrls = value;
                OnPropertyChanged("PendingSites");
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
