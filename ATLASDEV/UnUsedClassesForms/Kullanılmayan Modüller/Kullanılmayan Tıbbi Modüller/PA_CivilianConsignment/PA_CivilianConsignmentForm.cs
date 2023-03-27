
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
    /// Sivil Sevkli Kabulü
    /// </summary>
    public partial class PA_CivilianConsignmentForm : PatientAdmissionForm
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
#region PA_CivilianConsignmentForm_chkIsSGKPatient_CheckedChanged
   if (this.Payer.Enabled == true)
            {
                if (this.chkIsSGKPatient.Value == true)
                {
                    Guid sivilSevkliSGKKurumuObjID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SIVILSEVKLISGKKURUMUOBJECTID", Guid.Empty.ToString()));
                    if(!sivilSevkliSGKKurumuObjID.Equals(Guid.Empty))
                    {
                        try
                        {
                            PayerDefinition sivilSevkliSGKKurumu = (PayerDefinition)this._PA_CivilianConsignment.ObjectContext.GetObject(sivilSevkliSGKKurumuObjID, typeof(PayerDefinition));
                            if (sivilSevkliSGKKurumu != null)
                                this.Payer.SelectedObject = sivilSevkliSGKKurumu;
                        }
                        catch (Exception ex)
                        {
                            InfoBox.Show(ex);
                            this._PA_CivilianConsignment.IsSGKPatient = false;
                            return;
                        }
                    }
                    else
                    {
                        InfoBox.Show("'SIVILSEVKLISGKKURUMUOBJECTID' sistem parametresinin değeri bulunamadı. Bilgi İşleme haber veriniz.",MessageIconEnum.InformationMessage);
                        this._PA_CivilianConsignment.IsSGKPatient = false;
                        return;
                    }
                }
                else
                {
                    this.Payer.SelectedObject = null;
                }
            }
#endregion PA_CivilianConsignmentForm_chkIsSGKPatient_CheckedChanged
        }

        private void Payer_SelectedObjectChanged()
        {
#region PA_CivilianConsignmentForm_Payer_SelectedObjectChanged
   this.ConsignmentDocumentTakenCheckBox.Value = false;
            this.IdCardCopyTakenCheckBox.Value = false;
            
            ArrangeProtocol();

            if (_PA_CivilianConsignment.Payer != null)
            {
                // Sivil Sevkli Hastalarda SGK'lı olma durumu Patient'ın bağlı olduğu Kurum alanından kontrol edildi.
                ShowOrHideMedulaTabByPatientPayerAndReasonForAdmission();
                
                if(!this._PA_CivilianConsignment.IsSGKPatientAdmission) // SGK lı olmayan kurumlar için checkboxlar, sevk tarihi ve sevk evrak sayısı zorunlu
                {
                    this.ConsignmentDocumentTakenCheckBox.ReadOnly = false;
                    this.IdCardCopyTakenCheckBox.ReadOnly = false;
                }
                else
                {
                    this.ConsignmentDocumentTakenCheckBox.ReadOnly = true;
                    this.IdCardCopyTakenCheckBox.ReadOnly = true;
                }
            }
            else
            {
                this.ConsignmentDocumentTakenCheckBox.ReadOnly = true;
                this.IdCardCopyTakenCheckBox.ReadOnly = true;
            }
#endregion PA_CivilianConsignmentForm_Payer_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region PA_CivilianConsignmentForm_PreScript
    base.PreScript();
            

           // this.ttlabel1.Visible = false;
            
//            if(this._PatientAdmission.Patient.IsRelativeOfSoldier.HasValue == true && this._PatientAdmission.Patient.IsRelativeOfSoldier.Value == true)
//                this._PA_CivilianConsignment.IsRelativeOfSoldier=true;
//            else
//                this._PA_CivilianConsignment.IsRelativeOfSoldier=false;
//            
//            if (_PA_CivilianConsignment.Payer != null)
//            {
//                //ArrangeProtocol();
//                if(!this._PA_CivilianConsignment.NeedProvision()) // SGK lı olmayan kurumlar için checkboxlar, sevk tarihi ve sevk evrak sayısı zorunlu
//                {
//                    this.ConsignmentDocumentTakenCheckBox.ReadOnly = false;
//                    this.IdCardCopyTakenCheckBox.ReadOnly = false;
//                }
//                else
//                {
//                    this.ConsignmentDocumentTakenCheckBox.ReadOnly = true;
//                    this.IdCardCopyTakenCheckBox.ReadOnly = true;
//                }
//            }
            
            // Faturalama Yöntemindeki Hasta Grubuna göre Kurumların filtreli gelmesi
            /*
            string payerTypeList = null;
            PatientGroupDefinition pGroup = Common.PatientGroupDefinitionByEnum(this._PA_CivilianConsignment.ObjectContext,this._PA_CivilianConsignment.Episode.PatientGroup.Value);
            
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

            Guid sivilSevkliSGKKurumuObjID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SIVILSEVKLISGKKURUMUOBJECTID", Guid.Empty.ToString()));
            if(sivilSevkliSGKKurumuObjID == Guid.Empty)
                this.chkIsSGKPatient.Visible = false;
            else
                this.chkIsSGKPatient.Visible = true;
            
            // Sivil Sevkli Hastalarda SGK'lı olma durumu Patient'ın bağlı olduğu Kurum alanından kontrol edildi.
            ShowOrHideMedulaTabByPatientPayerAndReasonForAdmission();
            
#endregion PA_CivilianConsignmentForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region PA_CivilianConsignmentForm_PostScript
    base.PostScript(transDef);
#endregion PA_CivilianConsignmentForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region PA_CivilianConsignmentForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
#endregion PA_CivilianConsignmentForm_ClientSidePostScript

        }

#region PA_CivilianConsignmentForm_Methods
        public void ArrangeProtocol()
        {
            _PA_CivilianConsignment.Protocol = null;
            _PA_CivilianConsignment.PayerCity = null;

            if (_PA_CivilianConsignment.Payer != null)
            {
                ProtocolDefinition defaultPublicProtocol = null;
                ProtocolDefinition oneValidProtocol = null;
                bool protocolFound = false;
                
                try
                {
                    Guid defaultProtocolGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SGKPROTOCOL", "15b57761-eea5-4f12-b66a-349d0c187c8e"));
                    defaultPublicProtocol = (ProtocolDefinition)_PA_CivilianConsignment.ObjectContext.GetObject(defaultProtocolGuid,"ProtocolDefinition");
                }
                catch
                {
                    throw new TTException(SystemMessage.GetMessage(508));
                }
                
                this.Protocol.ListFilterExpression = _PA_CivilianConsignment.Payer.GetListFilterExpressionForValidProtocols(defaultPublicProtocol, ref protocolFound, ref oneValidProtocol);
                
                if (protocolFound)
                    _PA_CivilianConsignment.Protocol = defaultPublicProtocol;
                else
                    _PA_CivilianConsignment.Protocol = oneValidProtocol; // Kurumun sadece bir geçerli anlaşması varsa, Anlaşma alanına gelmesi için

                _PA_CivilianConsignment.PayerCity = _PA_CivilianConsignment.Payer.City;
            }
        }
        
#endregion PA_CivilianConsignmentForm_Methods
    }
}