using EGuard.Data.Repositories;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;

namespace EGuard.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _startTime;
        private string _endTime;

        private ObservableCollection<string> _pendingUrls = new ObservableCollection<string>();
        private readonly object _collectionLock = new object();

        private readonly ISiteCategoryRepository _siteCategoryRepository;

        public MainViewModel(ISiteCategoryRepository siteCategoryRepository)
        {
            _siteCategoryRepository = siteCategoryRepository;
            _startTime = "09:00";
            _endTime = "17:00";

            _pendingUrls = new ObservableCollection<string>(_siteCategoryRepository.GetPendingUrls());
            _pendingUrls.CollectionChanged += OnPendingUrlsChanged;
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

        public ObservableCollection<string> PendingUrls
        {
            get
            {
                return _pendingUrls;
            }
        }

        public void AddPendingUrl(string url)
        {
            lock (_collectionLock)
            {
                Action action = () =>
                {
                    _pendingUrls.Add(url);
                };

                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, action);
            }
        }

        private void OnPendingUrlsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if(e.Action == NotifyCollectionChangedAction.Add)
            {
                _siteCategoryRepository.Add((string)e.NewItems[0]);
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
