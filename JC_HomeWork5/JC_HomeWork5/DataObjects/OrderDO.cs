using JC_HomeWork5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JC_HomeWork5.DataObjects
{
    class OrderDO
    {
        public int orderID { get; set; }
        public Nullable<System.DateTime> orderDate { get; set; }
        public string lastName { get; set; }
        public string customerID { get; set; }

        //Create orders async without parametrs
        public static async Task<List<OrderDO>> GetOrdersAsync()
        {
            using (MyCSharpDotNetEntities context =
                new MyCSharpDotNetEntities())
            {
                return await context.Orders
                    .Select(x => new OrderDO()
                    {
                        orderID = x.OrderID,
                        orderDate = x.OrderDate,
                        lastName = x.Employee.LastName
                    })
                    .ToListAsync();
            }
        }

        //Create orders async with parametr customerID
        public static async Task<List<OrderDO>> GetOrdersAsync(string customerID)
        {
            using (MyCSharpDotNetEntities context =
                new MyCSharpDotNetEntities())
            {
                return await context.Orders
                    .Select(x => new OrderDO()
                    {
                        orderID = x.OrderID,
                        orderDate = x.OrderDate,
                        lastName = x.Employee.LastName,
                        customerID = x.CustomerID
                    })
                    .Where(x => x.customerID.Equals(customerID))
                    .ToListAsync();
            }
        }
    }
}
