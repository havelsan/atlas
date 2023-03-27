
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
    /// Geçici Köy Korucusu Kabulü
    /// </summary>
    public partial class PA_TemporaryVillageSecurityForm : PatientAdmissionForm
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
#region PA_TemporaryVillageSecurityForm_Payer_SelectedObjectChanged
   ArrangeProtocol();
#endregion PA_TemporaryVillageSecurityForm_Payer_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region PA_TemporaryVillageSecurityForm_PreScript
    base.PreScript();
            //ArrangeProtocol();
#endregion PA_TemporaryVillageSecurityForm_PreScript

            }
            
#region PA_TemporaryVillageSecurityForm_Methods
        public void ArrangeProtocol()
        {
            _PA_TemporaryVillageSecurity.Protocol = null;

            if (_PA_TemporaryVillageSecurity.Payer != null)
            {
                ProtocolDefinition defaultPublicProtocol = null;
                ProtocolDefinition oneValidProtocol = null;
                bool protocolFound = false;
                
                try
                {
                    Guid defaultProtocolGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SGKPROTOCOL", "15b57761-eea5-4f12-b66a-349d0c187c8e"));
                    defaultPublicProtocol = (ProtocolDefinition)_PA_TemporaryVillageSecurity.ObjectContext.GetObject(defaultProtocolGuid,"ProtocolDefinition");
                }
                catch
                {
                    throw new TTException(SystemMessage.GetMessage(508));
                }
                
                this.Protocol.ListFilterExpression = _PA_TemporaryVillageSecurity.Payer.GetListFilterExpressionForValidProtocols(defaultPublicProtocol, ref protocolFound, ref oneValidProtocol);
                
                if (protocolFound)
                    _PA_TemporaryVillageSecurity.Protocol = defaultPublicProtocol;
                else
                    _PA_TemporaryVillageSecurity.Protocol = oneValidProtocol; // Kurumun sadece bir geçerli anlaşması varsa, Anlaşma alanına gelmesi için
            }
        }
        
#endregion PA_TemporaryVillageSecurityForm_Methods
    }
}