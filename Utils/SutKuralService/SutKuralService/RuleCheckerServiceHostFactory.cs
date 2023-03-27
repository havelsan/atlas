using System;
using System.ServiceModel.Activation;

namespace SutKuralService
{
    public class RuleCheckerServiceHostFactory : ServiceHostFactoryBase
    {
        public override System.ServiceModel.ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            return new RuleCheckerServiceHost(typeof(RuleCheckerService), baseAddresses);
        }

    }
}
