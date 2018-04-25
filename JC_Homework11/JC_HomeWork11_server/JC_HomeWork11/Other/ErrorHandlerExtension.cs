using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;

namespace JC_HomeWork11.Other
{
    public class ErrorHandlerExtension :
        BehaviorExtensionElement, IServiceBehavior
{
    public override Type BehaviorType
    {
        get
        {
            return GetType();
        }
    }

    protected override object CreateBehavior()
    {
        return this;
    }

    private IErrorHandler GetInstance()
    {
        return new ErrorHandlerExtensionImplementation();
    }

    void IServiceBehavior.AddBindingParameters(
        ServiceDescription serviceDescription,
        ServiceHostBase serviceHostBase,
        Collection<ServiceEndpoint> endpoints,
        BindingParameterCollection bindingParameters)
    {
    }

    void IServiceBehavior.ApplyDispatchBehavior(
        ServiceDescription serviceDescription,
        ServiceHostBase serviceHostBase)
    {
        IErrorHandler errorHandlerInstance = GetInstance();

        foreach (ChannelDispatcher dispatcher
            in serviceHostBase.ChannelDispatchers)
        {
            dispatcher.ErrorHandlers.Add(errorHandlerInstance);
        }
    }

    void IServiceBehavior.Validate(
        ServiceDescription serviceDescription,
        ServiceHostBase serviceHostBase)
    {
    }
}
}