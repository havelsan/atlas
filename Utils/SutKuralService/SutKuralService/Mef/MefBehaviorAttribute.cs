//===================================================================================
// Written by my@my.com
//===================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace SutKuralService
{
    public class MefBehaviorAttribute : Attribute, IContractBehavior, IContractBehaviorAttribute
    {
        public Type TargetContract
        {
            get
            {
                return null; //null means we apply to all contracts
            }
        }


        public void AddBindingParameters(ContractDescription description, ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection parameters)
        {
            return;
        }

        public void ApplyClientBehavior(ContractDescription description, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            return;
        }

        public void ApplyDispatchBehavior(ContractDescription description, ServiceEndpoint endpoint, DispatchRuntime dispatch)
        {
            Type contractType = description.ContractType;
            dispatch.InstanceProvider = new MefInstanceProvider(contractType);
        }

        public void Validate(ContractDescription description, ServiceEndpoint endpoint)
        {
            return;
        }

    }
}
