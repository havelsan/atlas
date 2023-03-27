
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
    /// Emekli XXXXXX Ailesi Kabülü
    /// </summary>
    public partial class PA_MilitaryRetiredFamiliyForm : PatientAdmissionForm
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
#region PA_MilitaryRetiredFamiliyForm_Payer_SelectedObjectChanged
   ArrangeProtocol();
#endregion PA_MilitaryRetiredFamiliyForm_Payer_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region PA_MilitaryRetiredFamiliyForm_PreScript
    base.PreScript();
            /*
            if (_PA_MilitaryRetiredFamily.CurrentStateDef.BaseStateDefID == PA_MilitaryRetiredFamily.States.New)
            {
                IList patientGroupList = PatientGroupDefinition.GetAll(_PA_MilitaryRetiredFamily.ObjectContext);
                
                foreach (PatientGroupDefinition pg in patientGroupList)
                {
                    if (_PA_MilitaryRetiredFamily.PatientGroup == pg.PatientGroupEnum)
                    {
                        if (pg.InvoiceAccountDefinition != null)
                        {
                            _PA_MilitaryRetiredFamily.Payer = pg.InvoiceAccountDefinition.Payer;
                            _PA_MilitaryRetiredFamily.Protocol = pg.InvoiceAccountDefinition.Protocol;
                        }
                        break;
                    }
                }
            }
            
            // Faturalama Yöntemindeki Hasta Grubuna göre Kurumların filtreli gelmesi
            string payerTypeList = null;
            PatientGroupDefinition pGroup = Common.PatientGroupDefinitionByEnum(this._PA_MilitaryRetiredFamily.ObjectContext,this._PA_MilitaryRetiredFamily.Episode.PatientGroup.Value);
            
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
#endregion PA_MilitaryRetiredFamiliyForm_PreScript

            }
            
#region PA_MilitaryRetiredFamiliyForm_Methods
        public void ArrangeProtocol()
        {
            _PA_MilitaryRetiredFamily.Protocol = null;
            _PA_MilitaryRetiredFamily.PayerCity = null;

            if (_PA_MilitaryRetiredFamily.Payer != null)
            {
                ProtocolDefinition defaultPublicProtocol = null;
                ProtocolDefinition oneValidProtocol = null;
                bool protocolFound = false;
                
                try
                {
                    Guid defaultProtocolGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SGKRETIREDPROTOCOL", "b819e53b-07cd-43fb-937b-dd5a9b909da8"));
                    defaultPublicProtocol = (ProtocolDefinition)_PA_MilitaryRetiredFamily.ObjectContext.GetObject(defaultProtocolGuid,"ProtocolDefinition");
                }
                catch
                {
                    throw new TTException(SystemMessage.GetMessage(508));
                }
                
                this.Protocol.ListFilterExpression = _PA_MilitaryRetiredFamily.Payer.GetListFilterExpressionForValidProtocols(defaultPublicProtocol, ref protocolFound, ref oneValidProtocol);
                
                if (protocolFound)
                    _PA_MilitaryRetiredFamily.Protocol = defaultPublicProtocol;
                else
                    _PA_MilitaryRetiredFamily.Protocol = oneValidProtocol; // Kurumun sadece bir geçerli anlaşması varsa, Anlaşma alanına gelmesi için

                _PA_MilitaryRetiredFamily.PayerCity = _PA_MilitaryRetiredFamily.Payer.City;
            }
        }
        
#endregion PA_MilitaryRetiredFamiliyForm_Methods
    }
}