using JC_HomeWork5.DataObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JC_HomeWork5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Async method for load client date. Mouse event for click on the buton

        private async void button1_MouseClickAsync(object sender, MouseEventArgs e)
        {
            loadingLabel.Text = "Loading, please wait...";
            loadingLabel.Visible = true;
            orderDataGridView.Visible = false;

            if (textCustomerBox.Text != null)
            {
                List<OrderDO> data = await OrderDO.GetOrdersAsync(textCustomerBox.Text);

                //Check if exist any data from db
                if (data.Any())
                {
                    orderDOBindingSource.DataSource = data;
                    orderDataGridView.Visible = true;
                    loadingLabel.Visible = false;
                }
                else {
                    loadingLabel.Text = "No data";
                }
            }
            
        }

        //Async method for load client date. The same method as in mouse button click (in addition to the assignment).
        private async void textCustomerBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_MouseClickAsync( sender, null);
            }
        }

    }
}
