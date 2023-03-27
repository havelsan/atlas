
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
    /// Emekli XXXXXX Kabülü
    /// </summary>
    public partial class PA_MilitaryRetiredForm : PatientAdmissionForm
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
#region PA_MilitaryRetiredForm_Payer_SelectedObjectChanged
   ArrangeProtocol();
#endregion PA_MilitaryRetiredForm_Payer_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region PA_MilitaryRetiredForm_PreScript
    base.PreScript();
            /*
            if (_PA_MilitaryRetired.CurrentStateDef.BaseStateDefID == PA_MilitaryRetired.States.New)
            {
                IList patientGroupList = PatientGroupDefinition.GetAll(_PA_MilitaryRetired.ObjectContext);
                
                foreach (PatientGroupDefinition pg in patientGroupList)
                {
                    if (_PA_MilitaryRetired.PatientGroup == pg.PatientGroupEnum)
                    {
                        if (pg.InvoiceAccountDefinition != null)
                        {
                            _PA_MilitaryRetired.Payer = pg.InvoiceAccountDefinition.Payer;
                            _PA_MilitaryRetired.Protocol = pg.InvoiceAccountDefinition.Protocol;
                        }
                        break;
                    }
                }
            }
            // Faturalama Yöntemindeki Hasta Grubuna göre Kurumların filtreli gelmesi
            string payerTypeList = null;
            PatientGroupDefinition pGroup = Common.PatientGroupDefinitionByEnum(this._PA_MilitaryRetired.ObjectContext,this._PA_MilitaryRetired.Episode.PatientGroup.Value);
            
            foreach (InvoiceAccountPayerType pType in pGroup.InvoiceAccountDefinition.PayerTypes)
            {
                payerTypeList = payerTypeList + "TYPE = '" + pType.PayerType.ObjectID.ToString() + "' OR ";
            }
         
            if (payerTypeList != null)
            {
                payerTypeList = payerTypeList.Substring(0, (payerTypeList.Length - 3));
                this.Payer.ListFilterExpression = payerTypeList;
            }
            else
                this.Payer.ListFilterExpression = "TYPE is null " ;
                */
#endregion PA_MilitaryRetiredForm_PreScript

            }
            
#region PA_MilitaryRetiredForm_Methods
        public void ArrangeProtocol()
        {
            _PA_MilitaryRetired.Protocol = null;
            _PA_MilitaryRetired.PayerCity = null;
            
            if (_PA_MilitaryRetired.Payer != null)
            {
                ProtocolDefinition defaultPublicProtocol = null;
                ProtocolDefinition oneValidProtocol = null;
                bool protocolFound = false;
                
                try
                {
                    Guid defaultProtocolGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SGKRETIREDPROTOCOL", "b819e53b-07cd-43fb-937b-dd5a9b909da8"));
                    defaultPublicProtocol = (ProtocolDefinition)_PA_MilitaryRetired.ObjectContext.GetObject(defaultProtocolGuid,"ProtocolDefinition");
                }
                catch
                {
                    throw new TTException(SystemMessage.GetMessage(508));
                }
                
                this.Protocol.ListFilterExpression = _PA_MilitaryRetired.Payer.GetListFilterExpressionForValidProtocols(defaultPublicProtocol, ref protocolFound, ref oneValidProtocol);
                
                if (protocolFound)
                    _PA_MilitaryRetired.Protocol = defaultPublicProtocol;
                else
                    _PA_MilitaryRetired.Protocol = oneValidProtocol; // Kurumun sadece bir geçerli anlaşması varsa, Anlaşma alanına gelmesi için

                _PA_MilitaryRetired.PayerCity = _PA_MilitaryRetired.Payer.City;
            }
        }
        
#endregion PA_MilitaryRetiredForm_Methods
    }
}