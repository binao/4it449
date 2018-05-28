using Autorepair.DataModel;
using Autorepair.DataObjects;
using Autorepair.Models;
using Autorepair.Others;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace Autorepair.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.pageContentBox = PageContent.CONTENT;
            return View();
        }
        
        //Route for displaz svg files
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Picture(string file)
        {
            var dir = Server.MapPath("/Pictures");
            var path = Path.Combine(dir, file + ".svg");
            return base.File(path, "image/svg+xml");

        }

        //Controller for partial content - tables and contact form
        [AllowAnonymous]
        public ActionResult ContentTable(string typeOfContent)
        {
            if (!typeOfContent.Equals(MenuItem.MESSAGE.ToString()))
            {
                List<CategoryDO> Categories = CategoryDO.GetCategory(typeOfContent);
                ViewBag.Products = ProductDO.GetProducts(Categories);

                return PartialView("_PartialTableContent");
            }
            else {
                return PartialView("Contact");
            }
        }

        //Controller for menus 
        [AllowAnonymous]
        [HttpGet]
        public ActionResult ContentMenu(string contentPage)
        {
            MenuItem MyStatus = new MenuItem();
            Enum.TryParse(contentPage, out MyStatus);
            if (Enum.TryParse(contentPage.ToUpper(), out MyStatus))
            {
                ViewBag.primaryContent = PageContent.getPrimaryContent(MyStatus);
                ViewBag.secondaryContentBox = PageContent.getSecondaryContent(MyStatus);
                return View("SpecificContent");
            }
            return new HttpNotFoundResult("Not Found");
        }

        // Controller for send a requir for service and other
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ContactUs(RequirementModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Děkujeme za zaslání! Budete v nejbližší době kontaktován";
                RequirmentDO.insertRequirment(model);
                ModelState.Clear();
            }
            else
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Chyby jsou vypsané pod okýnky!");
            }

            return View("ContactUs");
        }

        //Controller for access to admin page - for teacher - admin/password
        [Authorize]
        public async Task<ActionResult> AdminRequirment() {
            List < RequirmentDO > Requirments =  await RequirmentDO.GetRequirmentAsync();
            ViewBag.Requirments = Requirments;
            return View("AdminRequirment");
        }

        // Update status of requirment
        [Authorize]
        [HttpPost]
        public async  Task<ActionResult> UpdateRequirment(RequirementModel model)
        {
            RequirmentDO.updateRequirment(model.ID, model.Status);

            return await AdminRequirment();
        }

        public ActionResult LogOff()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Index");
        }

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
                        return RedirectToAction("AdminRequirment", "Home");
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
    }

}
