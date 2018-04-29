using HomeWork11WcfService.DataModels;
using HomeWork11WcfService.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HomeWork11WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductsService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductsService.svc or ProductsService.svc.cs at the Solution Explorer and start debugging.
    public class OrdersService : IOrdersService
    {
        public List<OrderDataModel> GetOrders(string customerId)
        {
            using (MyCSharpDotNetEntities context =
                new MyCSharpDotNetEntities())
            {
                return context.Orders
                    .Where(order => order.CustomerID == customerId)
                    .Select(order => new OrderDataModel
                    {
                        OrderID = order.OrderID,
                        OrderDate = order.OrderDate,
                        EmployeeLastName = order.Employee.LastName,
                        CustomerID = order.CustomerID
                    }).ToList();
            }
        }
    }
}
