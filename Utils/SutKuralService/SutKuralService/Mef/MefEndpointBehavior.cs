//===================================================================================
// Written by my@my.com
//===================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace SutKuralService
{
    public class MefEndpointBehavior : BehaviorExtensionElement, IEndpointBehavior
    {

        public override Type BehaviorType
        {
            get { return typeof(MefEndpointBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new MefEndpointBehavior();
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            Type contractType = endpoint.Contract.ContractType;
            endpointDispatcher.DispatchRuntime.InstanceProvider = new MefInstanceProvider(contractType);
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }

    }
}
