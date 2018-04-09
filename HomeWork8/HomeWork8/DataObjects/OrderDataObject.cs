using HomeWork8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeWork8.DataObjects
{
    public class OrderDataObject
    {
        public int OrderID { get; private set; }
        public DateTime? OrderDate { get; private set; }
        public string EmployeeLastName { get; private set; }
        public string CustomerID { get; private set; }

        public static List<OrderDataObject> ListOrders(string customerId)
        {
            using (MyCSharpDotNetEntities context =
                new MyCSharpDotNetEntities())
            {
                List<OrderDataObject> orders = context.Orders
                    .Where(order => order.CustomerID == customerId)
                    .Select(order => new OrderDataObject()
                    {
                        OrderID = order.OrderID,
                        OrderDate = order.OrderDate,
                        EmployeeLastName = order.Employee.LastName,
                        CustomerID = order.CustomerID
                    }).ToList();
                return orders;
            }
        }
    }
}