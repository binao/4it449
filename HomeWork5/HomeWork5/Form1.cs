using HomeWork5.DataObjects;
using HomeWork5.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void buttonListOrders_Click(object sender, EventArgs e)
        {
            setOrders();
        }

        private async void setOrders()
        {
            labelInfo.Visible = true;
            labelInfo.Text = "Loading data...";
            List<OrderDataObject> orders = await OrderDataObject.ListOrdersAsync(customerTextBox.Text);

            if (orders.Any()) labelInfo.Visible = false;
            else
            {
                labelInfo.Text = "No data available";
                labelInfo.Visible = true;
            }

            orderDataObjectBindingSource.DataSource = orders;
        }

        private void customerTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) setOrders();
        }
    }
}
