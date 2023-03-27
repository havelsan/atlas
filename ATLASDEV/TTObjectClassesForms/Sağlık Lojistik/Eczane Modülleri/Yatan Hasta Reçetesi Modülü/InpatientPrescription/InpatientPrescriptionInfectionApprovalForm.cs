
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
    /// Yatan Hasta Reçetesi
    /// </summary>
    public partial class InpatientPrescriptionInfectionApprovalForm : InpatientPrescriptionBaseForm
    {
        override protected void BindControlEvents()
        {
            cmdUpdate.Click += new TTControlEventDelegate(cmdUpdate_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdUpdate.Click -= new TTControlEventDelegate(cmdUpdate_Click);
            base.UnBindControlEvents();
        }

        private void cmdUpdate_Click()
        {
#region InpatientPrescriptionInfectionApprovalForm_cmdUpdate_Click
   bool change = false;
            foreach (InfectionApprovalDrugOrder infectionApprovalDrugOrder in _InpatientPrescription.InfectionApprovalDrugOrder)
            {
                InpatientDrugOrder inpatientDrugOrder = infectionApprovalDrugOrder.InpatientDrugOrder;
                DrugOrder drugOrder = (DrugOrder)_InpatientPrescription.ObjectContext.GetObject((Guid)inpatientDrugOrder.DrugOrderID, typeof(DrugOrder));
                if (inpatientDrugOrder.Day != infectionApprovalDrugOrder.Day)
                {
                    inpatientDrugOrder.Day = infectionApprovalDrugOrder.Day;
                    drugOrder.Day = infectionApprovalDrugOrder.Day;
                    change = true;
                }
                if (inpatientDrugOrder.DoseAmount  != infectionApprovalDrugOrder.DoseAmount)
                {
                    inpatientDrugOrder.DoseAmount = infectionApprovalDrugOrder.DoseAmount;
                    drugOrder.DoseAmount = infectionApprovalDrugOrder.DoseAmount;
                    change = true;
                }
                if (inpatientDrugOrder.Frequency != infectionApprovalDrugOrder.Frequency)
                {
                    inpatientDrugOrder.Frequency = infectionApprovalDrugOrder.Frequency;
                    drugOrder.Frequency = infectionApprovalDrugOrder.Frequency;
                    change = true;
                }
                if (inpatientDrugOrder.PackageAmount != infectionApprovalDrugOrder.PackageAmount)
                {
                    inpatientDrugOrder.PackageAmount = infectionApprovalDrugOrder.PackageAmount;
                    //drugOrder.Day = infectionApprovalDrugOrder.Day;
                    change = true;
                }
            }
            if (change)
                _InpatientPrescription.ChangePres = true;
#endregion InpatientPrescriptionInfectionApprovalForm_cmdUpdate_Click
        }

        protected override void PreScript()
        {
#region InpatientPrescriptionInfectionApprovalForm_PreScript
    base.PreScript();
            
            Dictionary<Guid, SPTSDiagnosisInfo> diagnosisInfo = new Dictionary<Guid, SPTSDiagnosisInfo>();
            Dictionary<Guid, DiagnosisDefinition> diags = new Dictionary<Guid, DiagnosisDefinition>();

            foreach (DiagnosisGrid diag in _InpatientPrescription.Episode.Diagnosis)
            {
                if (!diags.ContainsKey(diag.Diagnose.ObjectID))
                    diags.Add(diag.Diagnose.ObjectID, diag.Diagnose);
            }
            
            if (diags.Count > 0)
            {
                foreach (KeyValuePair<Guid, DiagnosisDefinition> diag in diags)
                {
                    DiagnosisForPresc diagForPresc = new DiagnosisForPresc(_InpatientPrescription.ObjectContext);
                    diagForPresc.Code = diag.Value.Code;
                    diagForPresc.Name = diag.Value.Name.ToString();
                    diagForPresc.Prescription  = _InpatientPrescription;
                    foreach (SPTSMatchICD SPTSDiag in diag.Value.SPTSMatchICDs)
                    {
                        if (!diagnosisInfo.ContainsKey(SPTSDiag.SPTSDiagnosisInfo.ObjectID))
                        {
                            diagnosisInfo.Add(SPTSDiag.SPTSDiagnosisInfo.ObjectID, SPTSDiag.SPTSDiagnosisInfo);
                        }
                    }
                }
                if (diagnosisInfo.Count > 0)
                {
                    foreach (KeyValuePair<Guid, SPTSDiagnosisInfo> diagnosisSPTS in diagnosisInfo)
                    {
                        DiagnosisForSPTS diagnosisForSPTS = new DiagnosisForSPTS(_InpatientPrescription.ObjectContext);
                        diagnosisForSPTS.SPTSDiagnosisInfo = ((SPTSDiagnosisInfo)diagnosisSPTS.Value);
                        diagnosisForSPTS.Prescription = _InpatientPrescription;
                    }
                }
            }
            
            foreach(InpatientDrugOrder inpatientDrugOrder in _InpatientPrescription.InpatientDrugOrders)
            {
                DrugDefinition drug = (DrugDefinition)inpatientDrugOrder.Material ;
                if(drug.InfectionApproval.HasValue && (bool)drug.InfectionApproval)
                {
                    InfectionApprovalDrugOrder infectionApprovalDrugOrder = new InfectionApprovalDrugOrder(_InpatientPrescription.ObjectContext);
                    infectionApprovalDrugOrder.InpatientDrugOrder = inpatientDrugOrder;
                    infectionApprovalDrugOrder.Day = inpatientDrugOrder.Day;
                    infectionApprovalDrugOrder.DoseAmount = inpatientDrugOrder.DoseAmount;
                    infectionApprovalDrugOrder.Frequency = inpatientDrugOrder.Frequency;
                    infectionApprovalDrugOrder.PackageAmount = inpatientDrugOrder.PackageAmount;
                    infectionApprovalDrugOrder.UsageNote = inpatientDrugOrder.UsageNote;
                    infectionApprovalDrugOrder.InpatientPrescription = _InpatientPrescription;
                }
            }
#endregion InpatientPrescriptionInfectionApprovalForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region InpatientPrescriptionInfectionApprovalForm_PostScript
    base.PostScript(transDef);
#endregion InpatientPrescriptionInfectionApprovalForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region InpatientPrescriptionInfectionApprovalForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            
           /* if(transDef != null && transDef.ToStateDefID == InpatientPrescription.States.DrugControl)
            {
                ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
                ((ITTObject)currentUser).Refresh();
                if (_InpatientPrescription.ChangePres.HasValue == false || _InpatientPrescription.ChangePres == false)
                {
                    if (SubEpisode.IsSGKSubEpisode(_InpatientPrescription.SubEpisode))
                    {
                        if (string.IsNullOrEmpty(_InpatientPrescription.EReceteNo) == false)
                        {
                            if (string.IsNullOrEmpty(currentUser.ErecetePassword))
                            {
                                TTVisual.TTForm passwordForm = new TTFormClasses.EHUPasswordForm();
                                passwordForm.ShowEdit(null, _InpatientPrescription, true);
                            }
                            else
                                _InpatientPrescription.EHURecetePassword = currentUser.ErecetePassword;

                            if (_InpatientPrescription.IsSigned ?? false )
                                 SendSignedEreceteEHUApproval(currentUser);
                            else
                                _InpatientPrescription.SendEreceteEHUApproval(currentUser);
                        }
                        else
                            throw new TTException("Bu reçete henüz E Reçete ye gönderilmediği için EHU onayı alınamaz");
                    }
                }
                else
                {
                    if (_InpatientPrescription.IsSigned ?? false )
                    {
                        throw new TTException("Bu reçete E-İmzalı olduğu için mevut değiştirdiğiniz zaman Doktor tarafından iptal edilmelidir");
                    }
                    else
                    {
                        if (SubEpisode.IsSGKSubEpisode(_InpatientPrescription.SubEpisode))
                        {
                            if (string.IsNullOrEmpty(_InpatientPrescription.EReceteNo) == false)
                            {
                                CancelERecete(false);
                                _InpatientPrescription.SendErecete();
                                if (string.IsNullOrEmpty(currentUser.ErecetePassword))
                                {
                                    TTVisual.TTForm passwordForm = new TTFormClasses.EHUPasswordForm();
                                    passwordForm.ShowEdit(null, _InpatientPrescription, true);
                                }
                                else
                                    _InpatientPrescription.EHURecetePassword = currentUser.ErecetePassword;

                                _InpatientPrescription.SendEreceteEHUApproval(currentUser);
                            }
                            else
                                throw new TTException("Bu reçete henüz E Reçete ye gönderilmediği için EHU onayı alınamaz");
                        }
                    }
                }
            }
            
             if(transDef != null && transDef.FromStateDefID == InpatientPrescription.States.InfectionApproval && transDef.ToStateDefID == InpatientPrescription.States.Cancelled)
                 _InpatientPrescription.CancelStockPrescriptionOut(this._InpatientPrescription);
             
               if ( transDef != null && transDef.FromStateDefID == InpatientPrescription.States.InfectionApproval && transDef.ToStateDefID == InpatientPrescription.States.Cancelled)
                {
                
                    CancelERecete(false);
                }*/
#endregion InpatientPrescriptionInfectionApprovalForm_ClientSidePostScript

        }
    }
}