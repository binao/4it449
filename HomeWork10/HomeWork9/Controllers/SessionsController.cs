using HomeWork9.DomainClasses;
using HomeWork9.Models;
using HomeWork9.Models.SessionsViewModels;
using HomeWork9.Services;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HomeWork9.Controllers
{
    public class SessionsController : Controller
    {
        [AllowAnonymous]
        public ActionResult Create(string returnAddress)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (Url.IsLocalUrl(returnAddress))
                {
                    return Redirect(returnAddress);
                }
                else
                {
                    return RedirectToAction("Index", "Orders");
                }
            }
            else
            {
                ViewBag.ReturnAddress = returnAddress;
                return View();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LoginViewModel loginModel, string returnAddress)
        {
            if (ModelState.IsValid)
            {
                UserManager<ApplicationUser> userManager =
                    new UserManager<ApplicationUser>(new UserStore());

                var user = await userManager.FindAsync(loginModel.UserName, loginModel.Password);

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
                            IsPersistent = loginModel.RememberMe
                        },
                        identity);

                    if (Url.IsLocalUrl(returnAddress))
                    {
                        return Redirect(returnAddress);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Orders");
                    }
                }
                else
                {
                    ModelState.AddModelError(
                        string.Empty,
                        "Invalid user name or password.");
                }
            }
            return View(loginModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Create");
        }
    }
}