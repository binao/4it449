using System.Web.Mvc;

namespace JC_HomeWork9
{
    internal static class FilterConfig
    {
        //Set first page - Log on and no access for other withou login
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new AuthorizeAttribute());
        }
    }
}