using System.Web.Mvc;
using System.Web.Routing;

namespace JC_HomeWork9
{
    public class MvcApplication : System.Web.HttpApplication
    {
        //global configuration
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
}
