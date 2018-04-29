using HomeWork7.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HomeWork6.OrdersServiceReference;

namespace HomeWork7.ViewModels
{
    class OrderViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<OrderDataModel> _Orders;
        private String _SearchText;
        private bool _Loading = false;

        public event PropertyChangedEventHandler PropertyChanged;


        public ICommand LoadCommand { get; private set; }

        public ObservableCollection<OrderDataModel> Orders
        {
            get { return _Orders; }
            set
            {
                _Orders = value;
                OnPropertyChanged("Orders");
            }
        }

        public bool Loading
        {
            get { return _Loading; }
            set
            {
                _Loading = value;
                OnPropertyChanged("Loading");
            }
        }

        public String SearchText
        {
            get { return _SearchText; }
            set
            {
                _SearchText = value;
                OnPropertyChanged("SearchText");
            }
        }

        public OrderViewModel()
        {
            //Create command for orders loading
            LoadCommand = new Command(obj => true, async obj => await LoadOrdersAsync());
        }

        public async Task<ObservableCollection<OrderDataModel>> LoadOrdersAsync()
        {
            OrdersServiceClient client = new OrdersServiceClient();

            Loading = true;
            await Task.Delay(1000);

            Orders = new ObservableCollection<OrderDataModel>(client.GetOrders(SearchText));
            Loading = false;
            return await Task.FromResult(Orders);
        }

        //Notify about property change
        private void OnPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
