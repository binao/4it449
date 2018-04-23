using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace JC_HomeWork9
{
    internal partial class Startup
    {

        public static void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information
            // for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Home/LogOn")
            });
        }
    }
}