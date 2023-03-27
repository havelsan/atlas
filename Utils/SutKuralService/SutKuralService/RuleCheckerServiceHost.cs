using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using RuleChecker;

namespace SutKuralService
{
    public class RuleCheckerServiceHost : ServiceHost
    {
       
        public RuleCheckerServiceHost(Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {

        }


    }
}
