
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
    public partial class InpatientPresciriptionForm : InpatientPrescriptionBaseForm
    {
        override protected void BindControlEvents()
        {
            cmdAddDetail.Click += new TTControlEventDelegate(cmdAddDetail_Click);
            InpatientDrugOrders.RowLeave += new TTGridCellEventDelegate(InpatientDrugOrders_RowLeave);
            tttoolstrip1.ItemClicked += new TTToolStripItemClicked(tttoolstrip1_ItemClicked);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdAddDetail.Click -= new TTControlEventDelegate(cmdAddDetail_Click);
            InpatientDrugOrders.RowLeave -= new TTGridCellEventDelegate(InpatientDrugOrders_RowLeave);
            tttoolstrip1.ItemClicked -= new TTToolStripItemClicked(tttoolstrip1_ItemClicked);
            base.UnBindControlEvents();
        }

        private void cmdAddDetail_Click()
        {
#region InpatientPresciriptionForm_cmdAddDetail_Click
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
#endregion InpatientPresciriptionForm_cmdAddDetail_Click
        }

        private void InpatientDrugOrders_RowLeave(Int32 rowIndex, Int32 columnIndex)
        {
#region InpatientPresciriptionForm_InpatientDrugOrders_RowLeave
   ITTGridRow inpatientDrugOrderRow = InpatientDrugOrders.Rows[InpatientDrugOrders.CurrentCell.RowIndex];
            if (inpatientDrugOrderRow.Cells["Drug"].Value != null)
            {
                if (inpatientDrugOrderRow.Cells["Frequency"].Value != null & inpatientDrugOrderRow.Cells["DoseAmount"].Value != null & inpatientDrugOrderRow.Cells["Day"].Value != null)
                {
                    double detailCount = DrugOrder.GetDetailCount((FrequencyEnum)inpatientDrugOrderRow.Cells["Frequency"].Value);
                    double detailTimePeriod = DrugOrder.GetDetailTimePeriod((FrequencyEnum)inpatientDrugOrderRow.Cells["Frequency"].Value);
                    DrugDefinition drugDefinition = (DrugDefinition)_InpatientPrescription.ObjectContext.GetObject(new Guid(inpatientDrugOrderRow.Cells["Drug"].Value.ToString()), "DRUGDEFINITION");
                    double unitAmount = 0;
                    bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);
                    if (drugType)
                    {
                        unitAmount = (double)inpatientDrugOrderRow.Cells["DoseAmount"].Value;
                    }
                    else
                    {
                        unitAmount = (double)inpatientDrugOrderRow.Cells["DoseAmount"].Value * (double)drugDefinition.Dose / (double)drugDefinition.Volume;
                    }

                    detailCount = detailCount * (int)inpatientDrugOrderRow.Cells["Day"].Value;
                    inpatientDrugOrderRow.Cells["Amount"].Value = unitAmount * (double)(detailCount * (int)inpatientDrugOrderRow.Cells["Day"].Value);
                }
                else
                {
                    throw new TTException(SystemMessage.GetMessage(1009));
                }
            }
#endregion InpatientPresciriptionForm_InpatientDrugOrders_RowLeave
        }

        private void tttoolstrip1_ItemClicked(ITTToolStripItem item)
        {
#region InpatientPresciriptionForm_tttoolstrip1_ItemClicked
   Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            TTReportTool.PropertyCache<object> prescritiontype = new TTReportTool.PropertyCache<object>();
            switch (item.Name)
            {
                case "PrescriptionReportByDrungOrderIntroduction":
                    prescritiontype.Add("VALUE", _InpatientPrescription.PrescriptionType.Value.ToString());
                    parameters.Add("PRESCRIPTIONTYPE", prescritiontype);
                   
                    prescritiontype.Add("VALUE", _InpatientPrescription.ObjectID.ToString());
                    parameters.Add("TTOBJECTID", prescritiontype);
                    
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_PrescriptionReportByDrungOrderIntroduction), true, 1, parameters);
                    break;
                default:
                    break;
            }
#endregion InpatientPresciriptionForm_tttoolstrip1_ItemClicked
        }

        protected override void PreScript()
        {
#region InpatientPresciriptionForm_PreScript
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
            
            double totalPrice = 0;
            foreach (InpatientDrugOrder inpatientDrugOrder in _InpatientPrescription.InpatientDrugOrders)
            {
                if(inpatientDrugOrder.Material.PackageAmount != null)
                {
                    DrugDefinition drugDefinition = ((DrugDefinition)inpatientDrugOrder.Material);
                    if (inpatientDrugOrder.Amount > (double)inpatientDrugOrder.Material.PackageAmount.Value)
                    {
                        inpatientDrugOrder.PackageAmount = Math.Ceiling((double)inpatientDrugOrder.Amount / ((double)inpatientDrugOrder.Material.PackageAmount.Value));
                        inpatientDrugOrder.Amount = ((double)inpatientDrugOrder.PackageAmount) * ((double)inpatientDrugOrder.Material.PackageAmount.Value);
                    }
                    else
                    {
                        inpatientDrugOrder.PackageAmount = 1;
                        inpatientDrugOrder.Amount = ((double)inpatientDrugOrder.Material.PackageAmount.Value);
                    }
                }
                
                if (inpatientDrugOrder.Material.CurrentPrice != null && inpatientDrugOrder.PackageAmount != null)
                    totalPrice += (double)inpatientDrugOrder.Material.CurrentPrice * (double)inpatientDrugOrder.PackageAmount;
            }
            _InpatientPrescription.PrescriptionPrice = totalPrice;
            
            if(_InpatientPrescription.IsInfectionApproval() == false)
                this.DropStateButton(InpatientPrescription.States.InfectionApproval);
            // this.DropStateButton(InpatientPrescription.States.DrugControl);
            //else
                
            
            //this.ID.Text = this._InpatientPrescription.ID.Value.ToString();
            //if (!string.IsNullOrEmpty(this._InpatientPrescription.EReceteNo))
            //    EReceteNo.Text = this._InpatientPrescription.EReceteNo;
#endregion InpatientPresciriptionForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region InpatientPresciriptionForm_PostScript
    InpatientPrescription inpatientPrescription = (InpatientPrescription)this._ttObject;
            Dictionary<Guid, Object> dictionary = new Dictionary<Guid, object>();

            for (int i = 0; i < inpatientPrescription.InpatientDrugOrders.Count; i++)
            {
                Guid guid = new Guid(this.InpatientDrugOrders.Rows[i].Cells[0].Value.ToString());
                dictionary.Add(guid, _ttObject);
                if (dictionary.ContainsKey(guid))
                {
                    //throw new Exception("Aynı İlaçtan Bu Reçete de Yazmıştınız");
                }

            }
#endregion InpatientPresciriptionForm_PostScript

            }
                }
}