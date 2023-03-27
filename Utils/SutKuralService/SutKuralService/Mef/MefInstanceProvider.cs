//===================================================================================
// Written by my@my.com
//===================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Dispatcher;
using System.ComponentModel.Composition.Hosting;
using System.ServiceModel;
using System.ComponentModel.Composition.Primitives;
using RuleChecker;
using RuleChecker.Interface;

namespace SutKuralService
{
    public class MefInstanceProvider : IInstanceProvider
    {

        readonly Type serviceContractType;
        private static CompositionContainer Container { get; set; }

        static MefInstanceProvider()
        {
            Compose();
        }

        public MefInstanceProvider(Type t)
        {

            if (t != null && !t.IsInterface)
            {
                throw new ArgumentException("Specified Type must be an interface");
            }

            serviceContractType = t;
        }

        public object GetInstance(InstanceContext instanceContext, System.ServiceModel.Channels.Message message)
        {
            if (serviceContractType != null)
            {
                ImportDefinition importDefinition = new ImportDefinition(i => i.ContractName.Equals(serviceContractType.FullName), serviceContractType.FullName, ImportCardinality.ZeroOrMore, false, false);
                AtomicComposition atomicComposition = new AtomicComposition();
                IEnumerable<Export> extensions = null;

                bool exportDiscovery = Container.TryGetExports(importDefinition, atomicComposition, out extensions);

                if (extensions != null && extensions.Count<Export>() > 0)
                {
                    return extensions.First().Value;
                }
            }

            return null;
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            IDisposable disposable = instance as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }

        private static void Compose()
        {
            var catalog = new AggregateCatalog();

            catalog.Catalogs.Add(new AssemblyCatalog(typeof(IRuleCheckerService).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(IRuleCheckEngine).Assembly));
            Container = new CompositionContainer(catalog);

            var checkEngine = Container.GetExport<IRuleCheckEngine>();

            Console.WriteLine(checkEngine.Value.ToString());

        }


    }
}
