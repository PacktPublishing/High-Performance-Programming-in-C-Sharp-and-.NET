using CH12_ResponsiveMAUI.Api;
using System.Collections.ObjectModel;

namespace CH12_ResponsiveMAUI.ViewModels
{
    public class ViewModelBase<T> : PropertyChangeNotifier
    {
        bool _isRefreshing;

        public ObservableCollection<T> Entities { get; private set; } = new ObservableCollection<T>();

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }
    }
}
