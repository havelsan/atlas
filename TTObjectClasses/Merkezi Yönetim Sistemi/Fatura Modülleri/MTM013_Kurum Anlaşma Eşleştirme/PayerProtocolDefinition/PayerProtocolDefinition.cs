
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    /// <summary>
    /// Kurum anlasma eslestirme
    /// </summary>
    public partial class PayerProtocolDefinition : TerminologyManagerDef
    {
        public partial class GetPayerProtocolDefinitions_Class : TTReportNqlObject
        {
        }

        public partial class GetEffectivePayerProtocolDefsByEndDate_Class : TTReportNqlObject
        {
        }

        #region Methods
        public override SendDataTypesEnum? GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.PayerProtocolInfo;
        }

        public override bool SendMeWithMyParentTerminologyManagerDefs()
        {
            return false;
        }

        public void ControlValidProtocolsOfPayer()
        {
            List<ProtocolDefinition> protocols = Payer.ValidProtocols();

            if (Payer.IsSGKAll) // SGK
            {
                if (protocols.Count > 2)
                    throw new TTException(TTUtils.CultureService.GetText("M26868", "SGK kurumunun 'SGK Çalışan Anlaşması' ve 'SGK Emekli Anlaşması' adında iki tane geçerli anlaşması olabilir."));

                foreach (ProtocolDefinition protocol in protocols)
                {
                    if (protocol.ObjectID.ToString().ToUpper().Equals(SystemParameter.GetParameterValue("SGKPROTOCOL", "15b57761-eea5-4f12-b66a-349d0c187c8e").ToUpper()) == false &&
                       protocol.ObjectID.ToString().ToUpper().Equals(SystemParameter.GetParameterValue("SGKRETIREDPROTOCOL", "b819e53b-07cd-43fb-937b-dd5a9b909da8").ToUpper()) == false)
                        throw new TTException(TTUtils.CultureService.GetText("M26868", "SGK kurumunun 'SGK Çalışan Anlaşması' ve 'SGK Emekli Anlaşması' adında iki tane geçerli anlaşması olabilir."));
                }
            }
            else if (Payer.Type != null && Payer.Type.PayerType == PayerTypeEnum.Official) // Resmi
            {
                if (protocols.Count > 2)
                    throw new TTException(TTUtils.CultureService.GetText("M26766", "Resmi kurumun 'Resmi Kurum Çalışan Anlaşması' ve 'Resmi Kurum Emekli Anlaşması' adında iki tane geçerli anlaşması olabilir."));

                foreach (ProtocolDefinition protocol in protocols)
                {
                    if (protocol.ObjectID.ToString().ToUpper().Equals(SystemParameter.GetParameterValue("OFFICIALPROTOCOL", "1644af67-5c08-498a-9800-be7ef25353fa").ToUpper()) == false &&
                       protocol.ObjectID.ToString().ToUpper().Equals(SystemParameter.GetParameterValue("OFFICIALRETIREDPROTOCOL", "7efe2ec0-eb13-46bf-9a29-1bbaecbec5f8").ToUpper()) == false)
                        throw new TTException(TTUtils.CultureService.GetText("M26766", "Resmi kurumun 'Resmi Kurum Çalışan Anlaşması' ve 'Resmi Kurum Emekli Anlaşması' adında iki tane geçerli anlaşması olabilir."));
                }
            }
            else
            {
                if (protocols.Count > 1)
                    throw new TTException(TTUtils.CultureService.GetText("M26372", "Kurumun bir tane geçerli anlaşması olabilir."));
            }
        }

        protected override void PreInsert()
        {
            ControlValidProtocolsOfPayer();
        }

        protected override void PreUpdate()
        {
            ControlValidProtocolsOfPayer();
        }

        #endregion Methods

    }
}