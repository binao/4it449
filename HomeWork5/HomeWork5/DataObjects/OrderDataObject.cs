using HomeWork5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5.DataObjects
{
    class OrderDataObject
    {
        public int OrderID { get; private set; }
        public DateTime? OrderDate { get; private set; }
        public string EmployeeLastName { get; private set; }
        public string CustomerID { get; private set; }

        public static async Task<List<OrderDataObject>> ListOrdersAsync(string customerId)
        {
            using (MyCSharpDotNetEntities context =
                new MyCSharpDotNetEntities())
            {
                await Task.Delay(1000);

                List<OrderDataObject> orders = context.Orders
                    .Where(order => order.CustomerID == customerId)
                    .Select(order => new OrderDataObject()
                    {
                        OrderID = order.OrderID,
                        OrderDate = order.OrderDate,
                        EmployeeLastName = order.Employee.LastName,
                        CustomerID = order.CustomerID
                    }).ToList();
                return await Task.FromResult(orders);
            }
        }
    }
}
