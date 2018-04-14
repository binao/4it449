using JC_HomeWork9.DataObjects;
using JC_HomeWork9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JC_HomeWork9.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        // inicialization
        public ActionResult Index()
        {
            ViewBag.Orders = new List<OrderDO>();
            OrderModel model = new OrderModel();
            return View(model);
        }


        // Get data about Customer async
        [HttpPost]
        public async Task<ActionResult> Index(String customerID)
        {
            List<OrderDO> orders = await OrderDO.GetOrdersAsync(customerID);
            ViewBag.Orders = orders;

            return View();
        }

    }
}