using JC_HomeWork8.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JC_HomeWork6.DataObjects
{
    class OrderDO
    {
        public int orderID { get; set; }
        public Nullable<System.DateTime> orderDate { get; set; }
        public string lastName { get; set; }
        public string customerID { get; set; }

        //Create orders without parametrs
        public static List<OrderDO> GetOrders()
        {
            using (MyCSharpDotNetEntities context =
                new MyCSharpDotNetEntities())
            {
                return context.Orders
                    .Select(x => new OrderDO
                    {
                        orderID = x.OrderID,
                        orderDate = x.OrderDate,
                        lastName = x.Employee.LastName
                    }).ToList();
 
            }
        }

        //Create orders with parametr customerID
        public static List<OrderDO> GetOrders(string customerID)
        {
            using (MyCSharpDotNetEntities context =
                new MyCSharpDotNetEntities())
            {
                return  context.Orders
                    .Select(x => new OrderDO()
                    {
                        orderID = x.OrderID,
                        orderDate = x.OrderDate,
                        lastName = x.Employee.LastName,
                        customerID = x.CustomerID
                    })
                    .Where(x => x.customerID.Equals(customerID))
                    .ToList();
            }
        }
    }
}
