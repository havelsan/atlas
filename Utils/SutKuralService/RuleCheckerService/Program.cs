using Microsoft.Practices.ServiceLocation;
using RuleChecker.Interface;
using System;
using System.Collections;
using System.ComponentModel.Composition.Hosting;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.ServiceProcess;
using TTRemoting;

namespace RuleCheckerService
{
    class Program
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static CompositionContainer Container { get; set; }

        static void SetupCompositionContainer()
        {
            var catalog = new AggregateCatalog();

            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(IRuleCheckEngine).Assembly));
            Container = new CompositionContainer(catalog);

            var mef = new MefServiceLocator(Container);

            ServiceLocator.SetLocatorProvider(() => mef);

        }

        static void StartService()
        {

            SetupCompositionContainer();

            var servicePort = AppSettingHelper.GetAppSettingAsInteger(GlobalConstants.ServicePort, 45100);
            
            RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off;
            
            //TCP Channel
            Hashtable props = new Hashtable();
            IServerChannelSinkProvider provider = new TTServerChannelSinkProvider();

            BinaryServerFormatterSinkProvider serverProv = new BinaryServerFormatterSinkProvider();
            serverProv.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
            provider.Next = serverProv;

            props = new Hashtable();
            props["port"] = servicePort;
            props["secure"] = false;
            TcpServerChannel tcpChannel = new TcpServerChannel(props, provider);
            ChannelServices.RegisterChannel(tcpChannel, false);

            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RuleCheckerService), "RuleCheckerService.rem", WellKnownObjectMode.Singleton);

        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject as Exception;
            if (exception != null)
            {
                log.Error(exception);
            }
        }

        static void Main(string[] args)
        {
            var service = new SutKuralService();
            var servicesToRun = new ServiceBase[] { service };
            ServiceBase.Run(servicesToRun);
        }
    }
}
