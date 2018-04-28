using JC_HomeWork12_library.DataObjects;
using JC_HomeWork12_library.Parametrs;
using System.Collections.Generic;
using System.Linq;
using System.Windows;


namespace JC_HomeWork12_client
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

        // Click button call service with parametr from text box and show client's orders
        private async void clickMeButton_Click(object sender, RoutedEventArgs e)
        {
            loadingLabel.Content = "Loading, please wait...";
            loadingLabel.Visibility = Visibility.Visible;
            orderDataGrid.Visibility = Visibility.Hidden;



            if (textCustomerBox.Text != null)
            {
                List<OrderDO> data = await ClientHelper.CallAsync<
                        List<OrderDO>>(
                        "Orders",
                         textCustomerBox.Text);


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
