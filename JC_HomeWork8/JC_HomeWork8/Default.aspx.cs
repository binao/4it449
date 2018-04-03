using JC_HomeWork6.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JC_HomeWork8
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoadButton_Click(object sender, EventArgs e)
        {
            //Get data from DB throw the entity Framework
            if (ContentTextBox.Text != null)
            {
                List<OrderDO> data = OrderDO.GetOrders(ContentTextBox.Text);

                //Check if exist any data from db
                if (data.Any())
                {
                    OrderDataView.DataSource = data;
                    OrderDataView.DataBind();

                    OrderDataView.Visible = true;
                    DataLabel.Visible = false;
                }
                else
                {
                    OrderDataView.Visible = false;
                    DataLabel.Visible = true;
                }
            }
        }

        protected void OrderDataView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}