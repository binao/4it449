using JC_HomeWork11.DataModels;
using JC_HomeWork11.DataObjects;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;

namespace JC_HomeWork11
{
    [ServiceBehavior(
    InstanceContextMode = InstanceContextMode.PerCall,
    ConcurrencyMode = ConcurrencyMode.Multiple)]
    
    public class ServiceHomeWork : IServiceHomeWork
    {

        //Create orders with parametr customerID
        public List<OrderDO> GetOrders(string customerID)
        {
            using (MyCSharpDotNetEntities context =
                new MyCSharpDotNetEntities())
            {
                return context.Orders
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
