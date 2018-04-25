using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using JC_HomeWork11_client.ServiceHomeWork;

namespace JC_HomeWork11_client
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void clickMeButton_Click(object sender, RoutedEventArgs e)
        {
            loadingLabel.Content = "Loading, please wait...";
            loadingLabel.Visibility = Visibility.Visible;
            orderDataGrid.Visibility = Visibility.Hidden;

            ServiceHomeWorkClient client = new ServiceHomeWorkClient();

            if (textCustomerBox.Text != null)
            {
                OrderDO[] data = await client.GetOrdersAsync(textCustomerBox.Text);


                //Check if exist any data from db
                if (data.Any())
                {
                    orderDataGrid.ItemsSource = data;

                    orderDataGrid.Visibility = Visibility.Visible;
                    loadingLabel.Visibility = Visibility.Hidden;
                }
                else
                {
                    loadingLabel.Content = "No data";
                }
            }
        }
    }
}
