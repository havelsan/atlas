
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
    /// Ayaktan Hasta Reçetesi
    /// </summary>
    public partial class OutPatientPrescriptionApprovalForm : OutPatientPrescriptionBaseForm
    {
        override protected void BindControlEvents()
        {
            OutPatientDrugOrders.CellValueChanged += new TTGridCellEventDelegate(OutPatientDrugOrders_CellValueChanged);
            OutPatientDrugOrders.CellContentClick += new TTGridCellEventDelegate(OutPatientDrugOrders_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            OutPatientDrugOrders.CellValueChanged -= new TTGridCellEventDelegate(OutPatientDrugOrders_CellValueChanged);
            OutPatientDrugOrders.CellContentClick -= new TTGridCellEventDelegate(OutPatientDrugOrders_CellContentClick);
            base.UnBindControlEvents();
        }

        private void OutPatientDrugOrders_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region OutPatientPrescriptionApprovalForm_OutPatientDrugOrders_CellValueChanged
   if (OutPatientDrugOrders.CurrentCell.OwningColumn.Name == "PackageAmount")
            {
                ITTGridRow outPatientDrugOrderRow = OutPatientDrugOrders.Rows[OutPatientDrugOrders.CurrentCell.RowIndex];
                OutPatientDrugOrder drugOrder = ((OutPatientDrugOrder)outPatientDrugOrderRow.TTObject);
                if (drugOrder.PackageAmount != null)
                {
                    drugOrder.Amount = drugOrder.PackageAmount * drugOrder.Material.PackageAmount;
                }
            }
#endregion OutPatientPrescriptionApprovalForm_OutPatientDrugOrders_CellValueChanged
        }

        private void OutPatientDrugOrders_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region OutPatientPrescriptionApprovalForm_OutPatientDrugOrders_CellContentClick
   if (OutPatientDrugOrders.CurrentCell.OwningColumn.Name == "cmdSelectBarcodeLevel")
            {
                if (OutPatientDrugOrders.Rows[rowIndex].Cells["Drug"].Value != null)
                {
                    Dictionary<Guid, MaterialBarcodeLevel> levels = new Dictionary<Guid, MaterialBarcodeLevel>();
                    DrugDefinition drugDefinition = (DrugDefinition)_OutPatientPrescription.ObjectContext.GetObject(new Guid(OutPatientDrugOrders.Rows[rowIndex].Cells["Drug"].Value.ToString()), "DRUGDEFINITION");
                    MultiSelectForm multiSelectForm = new MultiSelectForm();
                    foreach (MaterialBarcodeLevel barcodeLevel in drugDefinition.MaterialBarcodeLevels)
                    {
                        if (levels.ContainsKey(barcodeLevel.ObjectID) == false)
                            levels.Add(barcodeLevel.ObjectID, barcodeLevel);
                    }
                    if (levels.Count == 0)
                        TTVisual.InfoBox.Show("Bu ilacın hiçbir ambalaj şekli tanımlanmamıştır.Ambalaj şekli tanımı yapıp işleme devam edebilirsiniz.", MessageIconEnum.InformationMessage);

                    foreach (KeyValuePair<Guid, MaterialBarcodeLevel> level in levels)
                    {
                        multiSelectForm.AddMSItem(level.Value.Name.ToString(), level.Value.Name.ToString(), level.Value);
                    }

                    string key = multiSelectForm.GetMSItem(ParentForm, "İlaç Formunu Seçiniz");
                    if (!string.IsNullOrEmpty(key))
                    {
                        OutPatientDrugOrders.Rows[rowIndex].Cells["BarcodeLevel"].Value = ((MaterialBarcodeLevel)multiSelectForm.MSSelectedItemObject).Name.ToString();
                        ((OutPatientDrugOrder)OutPatientDrugOrders.Rows[rowIndex].TTObject).MaterialBarcodeLevel = (MaterialBarcodeLevel)multiSelectForm.MSSelectedItemObject;
                        if (OutPatientDrugOrders.Rows[rowIndex].Cells["PackageAmount"].Value != null)
                            OutPatientDrugOrders.Rows[rowIndex].Cells["Amount"].Value = ((double)((MaterialBarcodeLevel)multiSelectForm.MSSelectedItemObject).PackageAmount.Value) * ((double)OutPatientDrugOrders.Rows[rowIndex].Cells["PackageAmount"].Value);
                    }
                }
            }
            //Muadiller
            if (OutPatientDrugOrders.CurrentCell.OwningColumn.Name == "cmdChangeDrug")
            {
                if (OutPatientDrugOrders.Rows[rowIndex].Cells["PhysicianDrug"].Value != null)
                {
                    double rAmount = (OutPatientDrugOrders.Rows[rowIndex].Cells["RequiredAmount"].Value) == null ? 0 : ((double)OutPatientDrugOrders.Rows[rowIndex].Cells["RequiredAmount"].Value);
                    PharmacyStoreDefinition pharmacy = null;
                    pharmacy = (PharmacyStoreDefinition)_OutPatientPrescription.MasterResource.Store;
                    DrugDefinition drugDefinition = (DrugDefinition)_OutPatientPrescription.ObjectContext.GetObject(new Guid(OutPatientDrugOrders.Rows[rowIndex].Cells["PhysicianDrug"].Value.ToString()), "DRUGDEFINITION");
                    MultiSelectForm multiSelectForm = new MultiSelectForm();
                    foreach (DrugRelation relation in drugDefinition.DrugRelations)
                    {

                        if (((Material)relation.RelationDrug).StockInheld((Store)pharmacy) > rAmount)
                        {
                            multiSelectForm.AddMSItem(relation.RelationDrug.Name, relation.RelationDrug.Name, relation.RelationDrug);
                        }
                    }

                    if (multiSelectForm.GetMSItemCount() == 0)
                        TTVisual.InfoBox.Show("Bu ilacın hiçbir muadilinin eczanede mevcudu yoktur", MessageIconEnum.InformationMessage);

                    string key = multiSelectForm.GetMSItem(ParentForm, "Muadil Seçiniz");
                    if (!string.IsNullOrEmpty(key))
                    {
                        OutPatientDrugOrders.Rows[rowIndex].Cells["Drug"].Value = ((DrugDefinition)multiSelectForm.MSSelectedItemObject).ObjectID;
                        OutPatientDrugOrders.Rows[rowIndex].Cells["BarcodeLevel"].Value = null;
                        OutPatientDrugOrders.Rows[rowIndex].Cells["StoreInheld"].Value = ((Material)multiSelectForm.MSSelectedItemObject).StockInheld((Store)pharmacy);


                        double i = (int)DrugOrder.GetDetailCount((FrequencyEnum)OutPatientDrugOrders.Rows[rowIndex].Cells["Frequency"].Value) * (double)OutPatientDrugOrders.Rows[rowIndex].Cells["DoseAmount"].Value;
                        OutPatientDrugOrders.Rows[rowIndex].Cells["RequiredAmount"].Value = 1 + Math.Round(i / (double)((Material)multiSelectForm.MSSelectedItemObject).PackageAmount);
                    }
                }
            }

            //Muadil İlaçlar Full
            if (OutPatientDrugOrders.CurrentCell.OwningColumn.Name == "cmdChangeDrugFull")
            {
                if (OutPatientDrugOrders.Rows[rowIndex].Cells["PhysicianDrug"].Value != null)
                {
                    double rAmount = (OutPatientDrugOrders.Rows[rowIndex].Cells["RequiredAmount"].Value) == null ? 0 : ((double)OutPatientDrugOrders.Rows[rowIndex].Cells["RequiredAmount"].Value);
                    PharmacyStoreDefinition pharmacy = null;
                    pharmacy = (PharmacyStoreDefinition)_OutPatientPrescription.MasterResource.Store;
                    DrugDefinition drugDefinition = (DrugDefinition)_OutPatientPrescription.ObjectContext.GetObject(new Guid(OutPatientDrugOrders.Rows[rowIndex].Cells["PhysicianDrug"].Value.ToString()), "DRUGDEFINITION");
                    MultiSelectForm multiSelectForm = new MultiSelectForm();

                    TTObjectContext objectContext = new TTObjectContext(true);
                    if (pharmacy.ObjectID.ToString() != null)
                    {
                        IList drugsInStock = objectContext.QueryObjects("STOCK", "STORE = '" + pharmacy.ObjectID.ToString() + "' AND INHELD > " + rAmount);
                        foreach (Stock stock in drugsInStock)
                        {
                            if (stock.Material.MaterialType == "İlaç")
                            {
                                multiSelectForm.AddMSItem(stock.Material.Name, stock.Material.Name, stock);
                            }
                        }

                        if (multiSelectForm.GetMSItemCount() == 0)
                            TTVisual.InfoBox.Show("Eczanede yeterli miktarda ilaç bulunmamaktadır.", MessageIconEnum.InformationMessage);

                        string key = multiSelectForm.GetMSItem(ParentForm, "Bir İlaç Seçiniz");
                        if (!string.IsNullOrEmpty(key))
                        {
                            OutPatientDrugOrders.Rows[rowIndex].Cells["Drug"].Value = ((Stock)multiSelectForm.MSSelectedItemObject).Material.ObjectID;
                            OutPatientDrugOrders.Rows[rowIndex].Cells["BarcodeLevel"].Value = null;
                            OutPatientDrugOrders.Rows[rowIndex].Cells["StoreInheld"].Value = ((Stock)multiSelectForm.MSSelectedItemObject).Inheld;


                            double i = (int)DrugOrder.GetDetailCount((FrequencyEnum)OutPatientDrugOrders.Rows[rowIndex].Cells["Frequency"].Value) * (double)OutPatientDrugOrders.Rows[rowIndex].Cells["DoseAmount"].Value;
                            OutPatientDrugOrders.Rows[rowIndex].Cells["RequiredAmount"].Value = 1 + Math.Round(i / (double)((Stock)multiSelectForm.MSSelectedItemObject).Material.PackageAmount);
                        }
                    }
                }
            }
#endregion OutPatientPrescriptionApprovalForm_OutPatientDrugOrders_CellContentClick
        }

        protected override void PreScript()
        {
#region OutPatientPrescriptionApprovalForm_PreScript
    base.PreScript();

            PharmacyStoreDefinition pharmacy = null;
            pharmacy = (PharmacyStoreDefinition)_OutPatientPrescription.MasterResource.Store;

            //Tanılar yazılıyor.
            Dictionary<Guid, string> diagForPres = new Dictionary<Guid, string>();
            Dictionary<Guid, SPTSDiagnosisInfo> diagnosisInfo = new Dictionary<Guid, SPTSDiagnosisInfo>();
            foreach (DiagnosisGrid diag in _OutPatientPrescription.Episode.Diagnosis)
            {
                if (diagForPres.ContainsKey(diag.Diagnose.ObjectID) == false)
                {
                    DiagnosisForPresc diagForPresc = new DiagnosisForPresc(_OutPatientPrescription.ObjectContext);
                    diagForPresc.Code = diag.Diagnose.Code;
                    diagForPresc.Name = diag.Diagnose.Name.ToString();
                    _OutPatientPrescription.SPTSDiagnosises.Add(diagForPresc);
                    diagForPres.Add(diag.Diagnose.ObjectID, diag.Diagnose.Code);
                    foreach (SPTSMatchICD SPTSDiag in diag.Diagnose.SPTSMatchICDs)
                    {
                        if (!diagnosisInfo.ContainsKey(SPTSDiag.SPTSDiagnosisInfo.ObjectID))
                        {
                            diagnosisInfo.Add(SPTSDiag.SPTSDiagnosisInfo.ObjectID, SPTSDiag.SPTSDiagnosisInfo);
                        }

                    }
                }
            }
            if (diagnosisInfo.Count > 0)
            {
                foreach (KeyValuePair<Guid, SPTSDiagnosisInfo> diagnosisSPTS in diagnosisInfo)
                {
                    DiagnosisForSPTS diagnosisForSPTS = new DiagnosisForSPTS(_OutPatientPrescription.ObjectContext);
                    diagnosisForSPTS.SPTSDiagnosisInfo = ((SPTSDiagnosisInfo)diagnosisSPTS.Value);
                    _OutPatientPrescription.DiagnosisForSPTSs.Add(diagnosisForSPTS);
                }
            }


            //Muadilleri listeler
            //            foreach (ITTGridRow drugOrderRow in this.OutPatientDrugOrders.Rows)
            //            {
            ////                OutPatientDrugOrder outPatientDrugOrder = (OutPatientDrugOrder)drugOrderRow.TTObject;
            ////                string objectIDs = string.Empty;
            ////                string filter = string.Empty;
            ////                foreach (DrugRelation relation in ((DrugDefinition)outPatientDrugOrder.Material).DrugRelations)
            ////                {
            ////                    objectIDs += ConnectionManager.GuidToString(relation.ObjectID) + ",";
            ////                }
            ////                if (objectIDs == string.Empty)
            ////                {
            ////                    ((ITTListBoxColumn)drugOrderRow.Cells[1]).ListFilterExpression = "";
            ////                }
            ////                else
            ////                {
            ////                    filter = objectIDs.Substring(0, filter.Length);
            ////                    ((ITTListBoxColumn)drugOrderRow.Cells[1]).ListFilterExpression = "OBJECTID in (" + filter + ")";
            ////                }
            //            }

            
                bool allDrugInheld = true;
                foreach (OutPatientDrugOrder drugOrder in _OutPatientPrescription.OutPatientDrugOrders)
                {
                    if (drugOrder.Material.StockInheld((Store)pharmacy) > drugOrder.Amount)
                    {
                        drugOrder.StoreInheld = drugOrder.Material.StockInheld((Store)pharmacy);
                        //drugOrder.DrugSupply = OutPatientDrugSupplyEnum.Supply;
                    }
                    else
                    {
                        drugOrder.StoreInheld = drugOrder.Material.StockInheld((Store)pharmacy);
                        //drugOrder.DrugSupply = OutPatientDrugSupplyEnum.UnSupply;
                        allDrugInheld = false;
                    }
                }
                /*if (allDrugInheld == false)
                {
                    this.DropStateButton(OutPatientPrescription.States.DrugPayables);
                }
                this.DropStateButton(OutPatientPrescription.States.ProvisionTake);
                this.DropStateButton(OutPatientPrescription.States.MagistralPreparation);

                string dailyPresDistribution = TTObjectClasses.SystemParameter.GetParameterValue("DAILYPRESDISTRIBUTION", "FALSE");
                bool gunuBirlikHastaMi =_OutPatientPrescription.SubEpisode.PatientAdmission.AdmissionType.Equals(AdmissionTypeEnum.Daily);
                if (gunuBirlikHastaMi == false && dailyPresDistribution == "FALSE")
                    this.DropStateButton(OutPatientPrescription.States.ExternalPharmacySupply);*/




            
#endregion OutPatientPrescriptionApprovalForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region OutPatientPrescriptionApprovalForm_PostScript
    base.PostScript(transDef);

            OutPatientPrescription outPatientPrescription = (OutPatientPrescription)this._ttObject;
            string message = "";
            int messageCount = 0;

            if (TTObjectClasses.SystemParameter.GetParameterValue("INPATIENTPRESDRUGCONTROL", "FALSE") == "TRUE")
            {
                foreach (OutPatientDrugOrder outPatientDrugOrder in outPatientPrescription.OutPatientDrugOrders)
                {
                    if (outPatientDrugOrder.RequiredAmount > outPatientDrugOrder.Amount)
                    {
                        message = message + " " + outPatientDrugOrder.Material.Name.ToString() + " ilacının karşılanan miktarı istenen miktarından az olamaz. ";
                        messageCount = messageCount + 1;
                    }
                }
            }
            if (messageCount > 0)
            {
                throw new Exception(message);
            }
#endregion OutPatientPrescriptionApprovalForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region OutPatientPrescriptionApprovalForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);

            if (transDef != null && transDef.FromStateDefID == OutPatientPrescription.States.DrugControl && transDef.ToStateDefID == InpatientPrescription.States.Cancelled)
                _OutPatientPrescription.CancelStockPrescriptionOut(this._OutPatientPrescription);
#endregion OutPatientPrescriptionApprovalForm_ClientSidePostScript

        }
    }
}