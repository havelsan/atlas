
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
    /// Sivil Emekli Kabulü
    /// </summary>
    public partial class PA_RetiredCivilianForm : PatientAdmissionForm
    {
        override protected void BindControlEvents()
        {
            chkIsSGKPatient.CheckedChanged += new TTControlEventDelegate(chkIsSGKPatient_CheckedChanged);
            Payer.SelectedObjectChanged += new TTControlEventDelegate(Payer_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            chkIsSGKPatient.CheckedChanged -= new TTControlEventDelegate(chkIsSGKPatient_CheckedChanged);
            Payer.SelectedObjectChanged -= new TTControlEventDelegate(Payer_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void chkIsSGKPatient_CheckedChanged()
        {
#region PA_RetiredCivilianForm_chkIsSGKPatient_CheckedChanged
   if (this.Payer.Enabled == true)
            {
                if (this.chkIsSGKPatient.Value == true)
                {
                    Guid sivilEmekliSGKKurumuObjID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SIVILEMEKLISGKKURUMUOBJECTID", Guid.Empty.ToString()));
                    if(!sivilEmekliSGKKurumuObjID.Equals(Guid.Empty))
                    {
                        try
                        {
                            PayerDefinition sivilEmekliSGKKurumu = (PayerDefinition)this._PA_RetiredCivilian.ObjectContext.GetObject(sivilEmekliSGKKurumuObjID, typeof(PayerDefinition));
                            if (sivilEmekliSGKKurumu != null)
                                this.Payer.SelectedObject = sivilEmekliSGKKurumu;
                        }
                        catch (Exception ex)
                        {
                            InfoBox.Show(ex);
                            this._PA_RetiredCivilian.IsSGKPatient = false;
                            return;
                        }
                    }
                    else
                    {
                        InfoBox.Show("'SIVILEMEKLISGKKURUMUOBJECTID' sistem parametresinin değeri bulunamadı. Bilgi İşleme haber veriniz.",MessageIconEnum.InformationMessage);
                        this._PA_RetiredCivilian.IsSGKPatient = false;
                        return;
                    }
                }
                else
                {
                    this.Payer.SelectedObject = null;
                }
            }
#endregion PA_RetiredCivilianForm_chkIsSGKPatient_CheckedChanged
        }

        private void Payer_SelectedObjectChanged()
        {
#region PA_RetiredCivilianForm_Payer_SelectedObjectChanged
   ArrangeProtocol();
#endregion PA_RetiredCivilianForm_Payer_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region PA_RetiredCivilianForm_PreScript
    base.PreScript();
            //ArrangeProtocol();
            
            // Faturalama Yöntemindeki Hasta Grubuna göre Kurumların filtreli gelmesi
            /*
            string payerTypeList = null;
            PatientGroupDefinition pGroup = Common.PatientGroupDefinitionByEnum(_PA_RetiredCivilian.ObjectContext, _PA_RetiredCivilian.Episode.PatientGroup.Value);
            
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
                this.Payer.ListFilterExpression = "TYPE is null ";
                */
            
            Guid sivilEmekliSGKKurumuObjID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SIVILEMEKLISGKKURUMUOBJECTID", Guid.Empty.ToString()));
            if(sivilEmekliSGKKurumuObjID == Guid.Empty)
                this.chkIsSGKPatient.Visible = false;
            else
                this.chkIsSGKPatient.Visible = true;
            
#endregion PA_RetiredCivilianForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region PA_RetiredCivilianForm_PostScript
    base.PostScript(transDef);
#endregion PA_RetiredCivilianForm_PostScript

            }
            
#region PA_RetiredCivilianForm_Methods
        public void ArrangeProtocol()
        {
            _PA_RetiredCivilian.Protocol = null;
            _PA_RetiredCivilian.PayerCity = null;
            
            if (_PA_RetiredCivilian.Payer != null)
            {
                ProtocolDefinition defaultPublicProtocol = null;
                ProtocolDefinition oneValidProtocol = null;
                bool protocolFound = false;
                
                try
                {
                    Guid defaultProtocolGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SGKRETIREDPROTOCOL", "b819e53b-07cd-43fb-937b-dd5a9b909da8"));
                    defaultPublicProtocol = (ProtocolDefinition)_PA_RetiredCivilian.ObjectContext.GetObject(defaultProtocolGuid,"ProtocolDefinition");
                }
                catch
                {
                    throw new TTException(SystemMessage.GetMessage(508));
                }
                
                this.Protocol.ListFilterExpression = _PA_RetiredCivilian.Payer.GetListFilterExpressionForValidProtocols(defaultPublicProtocol, ref protocolFound, ref oneValidProtocol);
                
                if (protocolFound)
                    _PA_RetiredCivilian.Protocol = defaultPublicProtocol;
                else
                    _PA_RetiredCivilian.Protocol = oneValidProtocol; // Kurumun sadece bir geçerli anlaşması varsa, Anlaşma alanına gelmesi için

                _PA_RetiredCivilian.PayerCity = _PA_RetiredCivilian.Payer.City;
            }
        }
        
#endregion PA_RetiredCivilianForm_Methods
    }
}