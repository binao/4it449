using System.Diagnostics;
using System.Web.Http.ExceptionHandling;

namespace JC_HomeWork12_server.Other
{
    public class ErrorHandler : ExceptionLogger
    {
        //Error handlerer
        public override void Log(ExceptionLoggerContext context)
        {
            if (Debugger.IsAttached)
            {
                throw context.Exception;
            }
            else
            {
                // Log the exception here
            }
        }
    }
}