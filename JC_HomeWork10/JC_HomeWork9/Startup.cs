using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;


namespace JC_HomeWork9
{
    internal static partial class Startup
    {
       //Configuration for Owin
        public static void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
