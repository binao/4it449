using JC_HomeWork6.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JC_HomeWork6
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

            if (textCustomerBox.Text != null)
            {
                List<OrderDO> data = await OrderDO.GetOrdersAsync(textCustomerBox.Text);

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
