
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Başbakanlık(F022)  Kabulü
    /// </summary>
    public partial class PA_PrimeMinistryForm : PatientAdmissionForm
    {
        override protected void BindControlEvents()
        {
            Payer.SelectedObjectChanged += new TTControlEventDelegate(Payer_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            Payer.SelectedObjectChanged -= new TTControlEventDelegate(Payer_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void Payer_SelectedObjectChanged()
        {
#region PA_PrimeMinistryForm_Payer_SelectedObjectChanged
   ArrangeProtocol();
#endregion PA_PrimeMinistryForm_Payer_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region PA_PrimeMinistryForm_PreScript
    base.PreScript();
            //ArrangeProtocol();
               
            // Faturalama Yöntemindeki Hasta Grubuna göre Kurumların filtreli gelmesi
            /*
            string payerTypeList = null;
            PatientGroupDefinition pGroup = Common.PatientGroupDefinitionByEnum(this._PA_PrimeMinistry.ObjectContext, _PA_PrimeMinistry.Episode.PatientGroup.Value);
            
            foreach (InvoiceAccountPayerType pType in pGroup.InvoiceAccountDefinition.PayerTypes)
            {
                payerTypeList = payerTypeList + "TYPE = '" + pType.PayerType.ObjectID.ToString() + "' OR ";
            }
            // payerTypeList = "TYPE = '4562f73a-5a40-4e7c-98b8-ad4717dde2b0'" ;
            if (payerTypeList != null)
            {
                payerTypeList = payerTypeList.Substring(0, (payerTypeList.Length - 3));
                this.Payer.ListFilterExpression = payerTypeList;
            }
            else
                this.Payer.ListFilterExpression = "TYPE is null ";
                */
#endregion PA_PrimeMinistryForm_PreScript

            }
            
#region PA_PrimeMinistryForm_Methods
        public void ArrangeProtocol()
        {
            _PA_PrimeMinistry.Protocol = null;
            _PA_PrimeMinistry.PayerCity = null;
            
            if (_PA_PrimeMinistry.Payer != null)
            {
                ProtocolDefinition defaultPublicProtocol = null;
                ProtocolDefinition oneValidProtocol = null;
                bool protocolFound = false;
                
                try
                {
                    Guid defaultProtocolGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SGKPROTOCOL", "15b57761-eea5-4f12-b66a-349d0c187c8e"));
                    defaultPublicProtocol = (ProtocolDefinition)_PA_PrimeMinistry.ObjectContext.GetObject(defaultProtocolGuid,"ProtocolDefinition");
                }
                catch
                {
                    throw new TTException(SystemMessage.GetMessage(508));
                }
                
                this.Protocol.ListFilterExpression = _PA_PrimeMinistry.Payer.GetListFilterExpressionForValidProtocols(defaultPublicProtocol, ref protocolFound, ref oneValidProtocol);
                
                if (protocolFound)
                    _PA_PrimeMinistry.Protocol = defaultPublicProtocol;
                else
                    _PA_PrimeMinistry.Protocol = oneValidProtocol; // Kurumun sadece bir geçerli anlaşması varsa, Anlaşma alanına gelmesi için

                _PA_PrimeMinistry.PayerCity = _PA_PrimeMinistry.Payer.City;
            }
        }
        
#endregion PA_PrimeMinistryForm_Methods
    }
}