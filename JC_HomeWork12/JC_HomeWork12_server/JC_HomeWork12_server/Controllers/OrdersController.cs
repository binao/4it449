using JC_HomeWork12_server.DataModels;
using JC_HomeWork12_library.DataObjects;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using JC_HomeWork12_library.Parametrs;
using System.Data.Entity;

namespace JC_HomeWork12_server.Controllers
{
    public class OrdersController : ApiController
    {

        //Create orders async with parametr customerID
        [HttpGet]
        public async Task<IHttpActionResult> GetOrders([FromUri]string parametr)
        {
            using (MyCSharpDotNetEntities context =
                new MyCSharpDotNetEntities())
            {
                return Ok(await context.Orders
                    .Select(x => new OrderDO()
                    {
                        orderID = x.OrderID,
                        orderDate = x.OrderDate,
                        lastName = x.Employee.LastName,
                        customerID = x.CustomerID
                    })
                    .Where(x => x.customerID == parametr)
                    .ToListAsync());
            }
        }

        //Create orders async with parametr customerID
        //[HttpGet]
        //public async Task<IHttpActionResult> GetOrders()
        //{
        //    using (MyCSharpDotNetEntities context =
        //        new MyCSharpDotNetEntities())
        //    {
        //        return Ok(await context.Orders
        //            .Select(x => new OrderDO()
        //            {
        //                orderID = x.OrderID,
        //                orderDate = x.OrderDate,
        //                lastName = x.Employee.LastName,
        //                customerID = x.CustomerID
        //            })
        //            .ToListAsync());
        //    }
        //}
    }
}

