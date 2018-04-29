using HomeWork7.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HomeWork7.Services;
using HomeWork12Library.DataModels;

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
            Loading = true;
            await Task.Delay(1000);

            //Call api only if searched text is not null or empty
            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                Orders = await ApiClient.CallAsync<
                            ObservableCollection<OrderDataModel>>(
                            "Orders",
                            SearchText);
            }
            else Orders = new ObservableCollection<OrderDataModel>();

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
