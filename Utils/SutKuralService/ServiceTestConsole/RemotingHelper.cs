using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using TTRemoting;
using TTUtils;

namespace ServiceTestConsole
{
    class RemotingHelper
    {
        internal static TcpClientChannel RegisterClientChannel()
        {
            System.Threading.Thread.CurrentPrincipal = new System.Security.Principal.GenericPrincipal(new TTUserIdentity(), null);

            IClientChannelSinkProvider provider = new BinaryClientFormatterSinkProvider();
            provider.Next = new TTClientChannelSinkProvider(false, false);
            Hashtable props = new Hashtable();
            props["secure"] = false;
            TcpClientChannel tcpClientChannel = new TcpClientChannel(props, provider);
            ChannelServices.RegisterChannel(tcpClientChannel, false);

            return tcpClientChannel;
        }

        internal static ISutKuralService GetService()
        {
            var serverUrl = ConfigurationManager.AppSettings["serverUri"];
            var objectUri = "RuleCheckerService.rem";

            ISutKuralService sutKuralService =
            ActivatorHelper.GetService<ISutKuralService>("tcp", serverUrl, objectUri);

            return sutKuralService;
        }

    }
}
