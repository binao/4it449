using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeWork9.Models;

namespace HomeWork9.Controllers
{
    public class OrdersController : Controller
    {
        private MyCSharpDotNetEntities db = new MyCSharpDotNetEntities();

        // GET: Orders
        public async Task<ActionResult> Index(String CustomerId)
        {
            var orders = db.Orders
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Where(order => order.CustomerID == CustomerId);

            return View(await orders.ToListAsync());
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
