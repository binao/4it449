using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HomeWork12Api.Models;
using HomeWork12Library.DataModels;

namespace HomeWork12Api.Controllers
{
    public class OrdersController : ApiController
    {
        private MyCSharpDotNetEntities db = new MyCSharpDotNetEntities();

        // GET: Orders/GODOS
        [ResponseType(typeof(List<OrderDataModel>))]
        public async Task<IHttpActionResult> GetOrders(string id)
        {
            List<OrderDataModel> orders = await db.Orders
                    .Where(order => order.CustomerID == id)
                    .Select(order => new OrderDataModel
                    {
                        OrderID = order.OrderID,
                        OrderDate = order.OrderDate,
                        EmployeeLastName = order.Employee.LastName,
                        CustomerID = order.CustomerID
                    }).ToListAsync();

            return Ok(orders);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}