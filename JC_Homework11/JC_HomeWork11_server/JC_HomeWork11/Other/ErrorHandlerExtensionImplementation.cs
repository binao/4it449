using System;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;

namespace JC_HomeWork11.Other
{
    public class ErrorHandlerExtensionImplementation : IErrorHandler
    {
        public bool HandleError(Exception exception)
        {
            // HandleError. Log an error, then allow the error to be handled
            // as usual.
            // Return true if the error is considered as already handled

            return true;
        }

        public void ProvideFault(
            Exception exception,
            MessageVersion messageVersion,
            ref Message message)
        {
            // Provide a fault. The Message fault parameter can be replaced,
            // or set to null to suppress reporting a fault.
        }
    }
}