using JC_HomeWork9.DataObjects;
using JC_HomeWork9.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using JC_HomeWork9.Other;

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
        // lOGIN METHOD
        [AllowAnonymous]
        public ActionResult LogOn(string returnAddress)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (Url.IsLocalUrl(returnAddress))
                {
                    return Redirect(returnAddress);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.ReturnAddress = returnAddress;
                return View();
            }
        }
        
        //async lOGIN METHOD
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LogOn(
            LogOnModel model,
            string returnAddress)
        {
            if (ModelState.IsValid)
            {
                UserManager<IdentityUser> userManager =
                    new UserManager<IdentityUser>(new UserStore());

                var user =
                    await userManager.FindAsync(model.UserName, model.Password);

                if (user != null)
                {
                    HttpContext.GetOwinContext().Authentication.SignOut(
                        DefaultAuthenticationTypes.ExternalCookie);

                    var identity = await userManager.CreateIdentityAsync(
                        user,
                        DefaultAuthenticationTypes.ApplicationCookie);

                    HttpContext.GetOwinContext().Authentication.SignIn(
                        new AuthenticationProperties()
                        {
                            IsPersistent = model.RememberMe
                        },
                        identity);

                    if (Url.IsLocalUrl(returnAddress))
                    {
                        return Redirect(returnAddress);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError(
                        string.Empty,
                        "Invalid user name or password.");
                }
            }

            return View(model);
        }

        public ActionResult LogOff()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Index");
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