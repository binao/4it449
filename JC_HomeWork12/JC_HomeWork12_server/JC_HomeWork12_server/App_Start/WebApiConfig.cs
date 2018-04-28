using System.Web.Http;

namespace JC_HomeWork12_server
{
    public static class WebApiConfig
    {
        //Confiuration for server
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "Default",
                routeTemplate: "{controller}/{parametr}"

            );
        }
    }
}
