using HomeWork8.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeWork8
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoadOrdersButton_Click(object sender, EventArgs e)
        {
            SetOrders();
        }

        private void SetOrders()
        {
            List<OrderDataObject> orders = OrderDataObject.ListOrders(CustomerIdTextBox.Text);

            if (orders.Any()) NoDataLabel.Visible = false;
            else
            {
                NoDataLabel.Text = "No data available";
                NoDataLabel.Visible = true;
            }

            OrderDataView.DataSource = orders;
            OrderDataView.DataBind();
        }
    }
}