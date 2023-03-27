
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
    public partial class InpatientPresciriptionDrugSupplyForm : InpatientPrescriptionBaseForm
    {
        override protected void BindControlEvents()
        {
            btnEReceteNoInQuiry.Click += new TTControlEventDelegate(btnEReceteNoInQuiry_Click);
            cmdAddDetail.Click += new TTControlEventDelegate(cmdAddDetail_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnEReceteNoInQuiry.Click -= new TTControlEventDelegate(btnEReceteNoInQuiry_Click);
            cmdAddDetail.Click -= new TTControlEventDelegate(cmdAddDetail_Click);
            base.UnBindControlEvents();
        }

        private void btnEReceteNoInQuiry_Click()
        {
#region InpatientPresciriptionDrugSupplyForm_btnEReceteNoInQuiry_Click
   //
//            EReceteIslemleri.ereceteSorguCevapDVO response = null;// = EReceteIslemleri.RemoteMethods.ereceteSorgula(Sites.SiteLocalHost,Prescription.GetEreceteInQuiry(_InpatientPrescription));
//            if (response != null)
//            {
//                if (response.sonucKodu.Equals("0000"))
//                {
//                    InfoBox.Show("e-Reçete Numarası : " + response.ereceteDVO.ereceteNo + " olan Reçete e-Reçete Sisteminde Kayıtlıdır");
//                }
//                else
//                {
//                    if (!string.IsNullOrEmpty(response.uyariMesaji))
//                    {
//                        throw new TTException("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji + "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :" + response.uyariMesaji);
//                    }
//                    else
//                    {
//                        InfoBox.Show("e-Reçete Servisinden Gelen Sonuç Mesajı : " + response.sonucMesaji);
//                    }
//
//
//                }
//            }
#endregion InpatientPresciriptionDrugSupplyForm_btnEReceteNoInQuiry_Click
        }

        private void cmdAddDetail_Click()
        {
#region InpatientPresciriptionDrugSupplyForm_cmdAddDetail_Click
   if(string.IsNullOrEmpty(_InpatientPrescription.EReceteNo) == false)
            {
                ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
                if(currentUser.UniqueNo.Equals(_InpatientPrescription.ProcedureDoctor.UniqueNo))
                {
                    TTVisual.TTForm eReceteDetailForm = new TTFormClasses.InpatientPresEReceteDetailForm();
                    eReceteDetailForm.ShowEdit(this, _InpatientPrescription ,true);
                }
                else
                {
                    InfoBox.Show("E-Reçete sizin adınıza alınmamış. Bu nedenle detay ekleyemezsiniz.", MessageIconEnum.ErrorMessage);
                }
            }
            else
                InfoBox.Show("Reçete E Reçete'ye yollanmamış. Bu nedenle detay ekleyemezsiniz.", MessageIconEnum.ErrorMessage);
#endregion InpatientPresciriptionDrugSupplyForm_cmdAddDetail_Click
        }

        protected override void PreScript()
        {
#region InpatientPresciriptionDrugSupplyForm_PreScript
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
            
            
            base.PreScript();
            if (!string.IsNullOrEmpty(this._InpatientPrescription.EReceteNo))
                EReceteNo.Text = this._InpatientPrescription.EReceteNo;
#endregion InpatientPresciriptionDrugSupplyForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region InpatientPresciriptionDrugSupplyForm_ClientSidePreScript
    base.ClientSidePreScript();
#endregion InpatientPresciriptionDrugSupplyForm_ClientSidePreScript

        }

        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region InpatientPresciriptionDrugSupplyForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            
            if(transDef != null && transDef.FromStateDefID == InpatientPrescription.States.Completed && transDef.ToStateDefID == InpatientPrescription.States.Cancelled)
                 _InpatientPrescription.CancelStockPrescriptionOut(this._InpatientPrescription);
#endregion InpatientPresciriptionDrugSupplyForm_ClientSidePostScript

        }
    }
}