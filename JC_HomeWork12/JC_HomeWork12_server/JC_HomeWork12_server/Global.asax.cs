using JC_HomeWork12_server.Other;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace JC_HomeWork12_server
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.Services.Add(
                typeof(IExceptionLogger),
                new ErrorHandler());

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
