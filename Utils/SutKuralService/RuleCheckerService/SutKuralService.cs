using Microsoft.Practices.ServiceLocation;
using RuleChecker.Interface;
using ServiceTestConsole;
using System;
using System.Collections;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.ServiceProcess;
using TTRemoting;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace RuleCheckerService
{
    partial class SutKuralService : ServiceBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        TcpServerChannel _tcpChannel = null;
        CompositionContainer _compositionContainer = null;

        public SutKuralService()
        {
            try
            {
                InitializeComponent();
                SetupCompositionContainer();
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw ex;
            }
        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject as Exception;
            if (exception != null)
                log.Error(exception);
        }


        void SetupCompositionContainer()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(SutKuralService).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(IRuleCheckEngine).Assembly));
            _compositionContainer = new CompositionContainer(catalog);
            var mef = new MefServiceLocator(_compositionContainer);
            ServiceLocator.SetLocatorProvider(() => mef);
        }

        protected override void OnStart(string[] args)
        {

            try
            {

                log.Info(RuleCheckStrings.ServiceStarting);
                LoadCacheList();
                var servicePort = AppSettingHelper.GetAppSettingAsInteger(GlobalConstants.ServicePort, 62000);
                IServerChannelSinkProvider provider = new TTServerChannelSinkProvider();

                BinaryServerFormatterSinkProvider serverProv = new BinaryServerFormatterSinkProvider();
                serverProv.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
                provider.Next = serverProv;

                RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off;

                Hashtable props = props = new Hashtable();
                props["port"] = servicePort;
                props["secure"] = false;
                _tcpChannel = new TcpServerChannel(props, provider);
                ChannelServices.RegisterChannel(_tcpChannel, false);

                RemotingConfiguration.RegisterWellKnownServiceType(typeof(RuleCheckerService), "RuleCheckerService.rem", WellKnownObjectMode.SingleCall);

                log.InfoFormat(RuleCheckStrings.ServiceStartCompleted, servicePort);

            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        protected override void OnStop()
        {
            try
            {
                log.Info(RuleCheckStrings.ServiceStopStarted);
                ChannelServices.UnregisterChannel(_tcpChannel);
                _tcpChannel = null;
                log.Info(RuleCheckStrings.ServiceStopCompleted);

            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        private void LoadCacheList()
        {
            try
            {
                log.Info(RuleCheckStrings.InitializeCacheStarted);
                var ruleRepository = ServiceLocator.Current.GetInstance<IRuleRepository>();
                if (ruleRepository != null)
                {
                    var ruleGroupList = ruleRepository.RuleGroupList();
                    log.InfoFormat(RuleCheckStrings.RuleCacheInitialized, ruleGroupList.Count);
                    var ruleList = ruleRepository.RuleList();
                    log.InfoFormat(RuleCheckStrings.RuleCacheInitialized, ruleList.Count);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

        }
    }
}
