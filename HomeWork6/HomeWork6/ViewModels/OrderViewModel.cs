using HomeWork6.Commands;
using HomeWork6.DataModels;
using HomeWork6.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HomeWork6.ViewModels
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
            set {
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
            using (MyCSharpDotNetEntities context =
                new MyCSharpDotNetEntities())
            {
                Loading = true;
                await Task.Delay(1000);

                Orders = new ObservableCollection<OrderDataModel>( context.Orders
                    .Where(order => order.CustomerID == SearchText)
                    .Select(order => new OrderDataModel
                    {
                        OrderID = order.OrderID,
                        OrderDate = order.OrderDate,
                        EmployeeLastName = order.Employee.LastName,
                        CustomerID = order.CustomerID
                    })) ;
                Loading = false;
                return await Task.FromResult(Orders);
            }
        }

        //Notify about property change
        private void OnPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
