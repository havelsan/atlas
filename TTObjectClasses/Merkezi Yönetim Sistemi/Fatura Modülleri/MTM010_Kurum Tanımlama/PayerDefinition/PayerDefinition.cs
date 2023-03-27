
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
    /// Kurum Tanımlama
    /// </summary>
    public partial class PayerDefinition : TerminologyManagerDef
    {
        public partial class GetPayerDefinitionsByCity_Class : TTReportNqlObject
        {
        }

        public partial class GetPayerDefinitions_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_PayerDefinition_WithDate_Class : TTReportNqlObject
        {
        }

        public partial class GetPayerDefinitionsWithCity_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_PayerDefinition_Class : TTReportNqlObject
        {
        }

        /// <summary>
        /// Kurum Kodu ve Adı
        /// </summary>
        public string CodeAndName
        {
            get
            {
                try
                {
                    #region CodeAndName_GetScript                    
                    return Code.ToString() + " " + Name;
                    #endregion CodeAndName_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "CodeAndName") + " : " + ex.Message, ex);
                }
            }
        }

        protected override void PostInsert()
        {
            #region PostInsert

            ControlAndCreateAPR();

            #endregion PostInsert
        }

        #region Methods
        public AccountPayableReceivable MyAPR()
        {
            if (APR.Count == 0)
                ControlAndCreateAPR();

            return APR[0];
        }

        public void ControlAndCreateAPR()
        {
            if (APR.Count > 0)
                return;

            AccountPayableReceivable apr = new AccountPayableReceivable(ObjectContext);
            apr.Type = APRTypeEnum.PAYER;
            apr.Name = Name;
            apr.Balance = 0;
            apr.PayerDefinition = this;
        }

        public string GetAccountCode()
        {
            if (string.IsNullOrEmpty(RevenueSubAccountCode.AccountCode))
                throw new TTException(SystemMessage.GetMessageV3(561, new string[] { Code.ToString(), Name.ToString() }));

            if (string.IsNullOrEmpty(RevenueSubAccountCode.AccountCode.Trim()))
                throw new TTException(SystemMessage.GetMessageV3(561, new string[] { Code.ToString(), Name.ToString() }));

            return RevenueSubAccountCode.AccountCode.Trim();
            /*
            if (code.IndexOf(".0000") == -1)
                throw new TTException("Kurumun hesap kodunda XXXXXX kodu ile değiştirilecek kısım (0000) bulunamadı! (" + this.Code.ToString() + " " + this.Name.ToString() + ")");
            else
            {
                if (SystemParameter.GetParameterValue("HOSPITALACCOUNTCODE", "") == "")
                    throw new TTException("XXXXXX muhasebe kodu sistem parametresi bulunamadı!");
                else
                {
                    code = code.Substring(0, code.IndexOf(".")+1) + SystemParameter.GetParameterValue("HOSPITALACCOUNTCODE", "") + code.Substring(code.IndexOf(".")+5, code.Length - (code.IndexOf(".")+5));
                    return code;
                }
            }
             */
        }

        public override SendDataTypesEnum? GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.PayerInfo;
        }

        public override bool GetMyChildTerminologyManagerDefs()
        {
            return false;
        }

        public string GetListFilterExpressionForValidProtocols(ProtocolDefinition protocol, ref bool protocolFound, ref ProtocolDefinition oneValidProtocol)
        {
            string protocolList = string.Empty;
            int validProtocolCount = 0;

            foreach (PayerProtocolDefinition payerProtocol in PayerProtocolDefinitions)
            {
                if ((!payerProtocol.ProtocolStartDate.HasValue || (payerProtocol.ProtocolStartDate.HasValue && payerProtocol.ProtocolStartDate.Value <= Common.RecTime())) &&
                    (!payerProtocol.ProtocolEndDate.HasValue || (payerProtocol.ProtocolEndDate.HasValue && payerProtocol.ProtocolEndDate.Value >= Common.RecTime())))
                {
                    if (protocol != null && protocol.ObjectID.Equals(payerProtocol.Protocol.ObjectID))
                        protocolFound = true;

                    protocolList += "OBJECTID = '" + payerProtocol.Protocol.ObjectID.ToString() + "' OR ";

                    // Sadece bir tane geçerli anlaşması varsa döndürülür
                    validProtocolCount++;
                    if (validProtocolCount == 1)
                        oneValidProtocol = payerProtocol.Protocol;
                    else
                        oneValidProtocol = null;
                }
            }

            if (!string.IsNullOrEmpty(protocolList))
                protocolList = protocolList.Substring(0, protocolList.Length - 3);
            else
                protocolList = "OBJECTID is null ";

            return protocolList;
        }

        public ProtocolDefinition FirstValidProtocol()
        {
            foreach (PayerProtocolDefinition payerProtocol in PayerProtocolDefinitions)
            {
                if ((!payerProtocol.ProtocolStartDate.HasValue || (payerProtocol.ProtocolStartDate.HasValue && payerProtocol.ProtocolStartDate.Value <= Common.RecTime())) &&
                    (!payerProtocol.ProtocolEndDate.HasValue || (payerProtocol.ProtocolEndDate.HasValue && payerProtocol.ProtocolEndDate.Value >= Common.RecTime())) &&
                    payerProtocol.Protocol.IsActive == true)
                    return payerProtocol.Protocol;
            }
            return null;
        }

        public List<ProtocolDefinition> ValidProtocols()
        {
            List<ProtocolDefinition> protocolList = new List<ProtocolDefinition>();
            foreach (PayerProtocolDefinition payerProtocol in PayerProtocolDefinitions)
            {
                if ((!payerProtocol.ProtocolStartDate.HasValue || (payerProtocol.ProtocolStartDate.HasValue && payerProtocol.ProtocolStartDate.Value <= Common.RecTime())) &&
                    (!payerProtocol.ProtocolEndDate.HasValue || (payerProtocol.ProtocolEndDate.HasValue && payerProtocol.ProtocolEndDate.Value >= Common.RecTime())) &&
                    payerProtocol.Protocol.IsActive == true)
                    protocolList.Add(payerProtocol.Protocol);
            }
            return protocolList;
        }

        public ProtocolDefinition GetProtocol(Patient patient, SigortaliTuru sigortaliTuru)
        {
            ProtocolDefinition protocol = null;

            if (IsSGKAll) // SGK
            {
                if (sigortaliTuru == null)
                    throw new TTException("Sigortalı Türü belli olmadığı için Alt Vaka anlaşması belirlenemiyor. (Kurum: " + Name + ")");

                string protocolGuid;
                if (sigortaliTuru.sigortaliTuruKodu.Equals("2"))
                    protocolGuid = SystemParameter.GetParameterValue("SGKRETIREDPROTOCOL", "b819e53b-07cd-43fb-937b-dd5a9b909da8");
                else
                    protocolGuid = SystemParameter.GetParameterValue("SGKPROTOCOL", "15b57761-eea5-4f12-b66a-349d0c187c8e");

                protocol = (ProtocolDefinition)ObjectContext.GetObject(new Guid(protocolGuid), "ProtocolDefinition");
            }
            else if (Type != null && Type.PayerType == PayerTypeEnum.Official) // Resmi
            {
                List<ProtocolDefinition> protocolList = ValidProtocols();
                if (protocolList.Count == 1)
                    protocol = protocolList[0] as ProtocolDefinition;
                else if (protocolList.Count > 1)
                {
                    if (sigortaliTuru == null)
                        throw new TTException("Sigortalı Türü belli olmadığı için Alt Vaka anlaşması belirlenemiyor. (Kurum: " + Name + ")");

                    string protocolGuid;
                    if (sigortaliTuru.sigortaliTuruKodu.Equals("2"))
                        protocolGuid = SystemParameter.GetParameterValue("OFFICIALRETIREDPROTOCOL", "7efe2ec0-eb13-46bf-9a29-1bbaecbec5f8");
                    else
                        protocolGuid = SystemParameter.GetParameterValue("OFFICIALPROTOCOL", "1644af67-5c08-498a-9800-be7ef25353fa");

                    protocol = (ProtocolDefinition)ObjectContext.GetObject(new Guid(protocolGuid), "ProtocolDefinition");
                }
            }
            else
            {
                if (patient == null || (patient != null && patient.Foreign != true))
                    protocol = FirstValidProtocol();
                else
                {
                    protocol = FirstValidProtocol();
                    // TODO : Mustafa Uygun sağlık turizmi anlaşması set edilmeli
                    /*
                    if (this is PA_PaidCivilian) // Ãœcretli Hasta
                    {
                        if (this.Patient != null && this.Patient.Foreign == true)
                        {
                            protocolGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("DEFAULTPATIENTTOURISTPROTOCOL", "5a3f6a41-2d80-4313-8a79-5057ff192c43"));
                            if (this.Patient.CountryOfBirth != null)
                            {
                                IList countryProtocolDefList = CountryProtocolDefinition.GetByCountryAndPatientType(this.ObjectContext, this.Patient.CountryOfBirth.ObjectID.ToString(), (int)PatientPayerEnum.Patient);
                                if (countryProtocolDefList.Count > 0)
                                    protocolGuid = ((CountryProtocolDefinition)countryProtocolDefList[0]).GetProperProtocol().ObjectID;
                            }
                            this.Protocol = (ProtocolDefinition)this.ObjectContext.GetObject(protocolGuid, "ProtocolDefinition");
                        }
                    }
                      Sivil Sevkli hastalarda seçilen kurum ve anlaşmanın geçerli olması istendiğinden aşağıdaki kısım kapatılmıştır
                    else if(this is PA_CivilianConsignment) // Sivil Sevkli Hasta
                    {
                        if(this.Patient != null && this.Patient.Foreign == true)
                        {
                            protocolGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("DEFAULTPAYERTOURISTPROTOCOL", "709b0cc7-4592-4cc1-893c-3b62e0011fdc"));
                            if(this.Patient.CountryOfBirth != null)
                            {
                                IList countryProtocolDefList = CountryProtocolDefinition.GetByCountryAndPatientType(this.ObjectContext, this.Patient.CountryOfBirth.ObjectID.ToString(), (int)PatientPayerEnum.Payer);
                                if(countryProtocolDefList.Count > 0)
                                    protocolGuid = ((CountryProtocolDefinition)countryProtocolDefList[0]).GetProperProtocol().ObjectID;
                            }
                            this.Protocol = (ProtocolDefinition)this.ObjectContext.GetObject(protocolGuid, "ProtocolDefinition");
                        }
                    }
                     */
                }
            }

            if (protocol == null)
                throw new TTException("Uygun anlaşma bulunamadı. (Kurum: " + Name + ")");

            return protocol;
        }

        public bool IsSGK
        {
            get
            {
                if (Type != null && Type.PayerType == PayerTypeEnum.SGK)
                    return true;

                return false;
            }
        }

        public bool IsSGKManual
        {
            get
            {
                if (Type != null && Type.PayerType == PayerTypeEnum.SGKManual)
                    return true;

                return false;
            }
        }

        public bool IsSGKAll
        {
            get
            {
                return (IsSGK || IsSGKManual);
            }
        }

        #endregion Methods

    }
}