using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SuperQuick
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        protected readonly SuperQuickContext context;

        public MainWindowViewModel()
        {
            ViewOrdersCommand = new RelayCommand(ViewOrders);
            context = new SuperQuickContext();
            Task.Run(() =>
            {
                Customers = new ObservableCollection<Customer>(context.Customers);
            });
            
        }
        private void ViewOrders(object sender)
        {

        }
        public ICommand ViewOrdersCommand { get; private set; }
        private  ObservableCollection<Customer> customers { get; set; }

        public ObservableCollection<Customer> Customers
        {
            get { return customers; }

            set
            {
                customers = value;
                OnPropertyChanged();
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(
            [System.Runtime.CompilerServices.CallerMemberName]
            string propertyName = "")
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
