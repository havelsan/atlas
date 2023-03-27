
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
    public partial class LBBaseForm : TTForm
    {
        override protected void BindControlEvents()
        {
            LBD_VaccineIns.CellContentClick += new TTGridCellEventDelegate(LBD_VaccineIns_CellContentClick);
            LBD_SpareIns.CellContentClick += new TTGridCellEventDelegate(LBD_SpareIns_CellContentClick);
            LBD_SerumIns.CellContentClick += new TTGridCellEventDelegate(LBD_SerumIns_CellContentClick);
            LBD_PrintedDocumentIns.CellContentClick += new TTGridCellEventDelegate(LBD_PrintedDocumentIns_CellContentClick);
            LBD_MilitaryDrugIns.CellContentClick += new TTGridCellEventDelegate(LBD_MilitaryDrugIns_CellContentClick);
            LBD_MedicalEquipmentIns.CellContentClick += new TTGridCellEventDelegate(LBD_MedicalEquipmentIns_CellContentClick);
            LBD_MedicalConsIns.CellContentClick += new TTGridCellEventDelegate(LBD_MedicalConsIns_CellContentClick);
            LBD_MarketDrugIns.CellContentClick += new TTGridCellEventDelegate(LBD_MarketDrugIns_CellContentClick);
            LBD_KitIns.CellContentClick += new TTGridCellEventDelegate(LBD_KitIns_CellContentClick);
            LBD_XXXXXXDrugIns.CellContentClick += new TTGridCellEventDelegate(LBD_XXXXXXDrugIns_CellContentClick);
            LBD_VaccineOuts.CellContentClick += new TTGridCellEventDelegate(LBD_VaccineOuts_CellContentClick);
            LBD_SpareOuts.CellContentClick += new TTGridCellEventDelegate(LBD_SpareOuts_CellContentClick);
            LBD_SerumOuts.CellContentClick += new TTGridCellEventDelegate(LBD_SerumOuts_CellContentClick);
            LBD_PrintedDocumentOuts.CellContentClick += new TTGridCellEventDelegate(LBD_PrintedDocumentOuts_CellContentClick);
            LBD_MilitaryDrugOuts.CellContentClick += new TTGridCellEventDelegate(LBD_MilitaryDrugOuts_CellContentClick);
            LBD_MedicalEquipmentOuts.CellContentClick += new TTGridCellEventDelegate(LBD_MedicalEquipmentOuts_CellContentClick);
            LBD_MedicalConsOuts.CellContentClick += new TTGridCellEventDelegate(LBD_MedicalConsOuts_CellContentClick);
            LBD_MarketDrugOuts.CellContentClick += new TTGridCellEventDelegate(LBD_MarketDrugOuts_CellContentClick);
            LBD_KitOuts.CellContentClick += new TTGridCellEventDelegate(LBD_KitOuts_CellContentClick);
            LBD_XXXXXXDrugOuts.CellContentClick += new TTGridCellEventDelegate(LBD_XXXXXXDrugOuts_CellContentClick);
            tttoolstrip1.ItemClicked += new TTToolStripItemClicked(tttoolstrip1_ItemClicked);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            LBD_VaccineIns.CellContentClick -= new TTGridCellEventDelegate(LBD_VaccineIns_CellContentClick);
            LBD_SpareIns.CellContentClick -= new TTGridCellEventDelegate(LBD_SpareIns_CellContentClick);
            LBD_SerumIns.CellContentClick -= new TTGridCellEventDelegate(LBD_SerumIns_CellContentClick);
            LBD_PrintedDocumentIns.CellContentClick -= new TTGridCellEventDelegate(LBD_PrintedDocumentIns_CellContentClick);
            LBD_MilitaryDrugIns.CellContentClick -= new TTGridCellEventDelegate(LBD_MilitaryDrugIns_CellContentClick);
            LBD_MedicalEquipmentIns.CellContentClick -= new TTGridCellEventDelegate(LBD_MedicalEquipmentIns_CellContentClick);
            LBD_MedicalConsIns.CellContentClick -= new TTGridCellEventDelegate(LBD_MedicalConsIns_CellContentClick);
            LBD_MarketDrugIns.CellContentClick -= new TTGridCellEventDelegate(LBD_MarketDrugIns_CellContentClick);
            LBD_KitIns.CellContentClick -= new TTGridCellEventDelegate(LBD_KitIns_CellContentClick);
            LBD_XXXXXXDrugIns.CellContentClick -= new TTGridCellEventDelegate(LBD_XXXXXXDrugIns_CellContentClick);
            LBD_VaccineOuts.CellContentClick -= new TTGridCellEventDelegate(LBD_VaccineOuts_CellContentClick);
            LBD_SpareOuts.CellContentClick -= new TTGridCellEventDelegate(LBD_SpareOuts_CellContentClick);
            LBD_SerumOuts.CellContentClick -= new TTGridCellEventDelegate(LBD_SerumOuts_CellContentClick);
            LBD_PrintedDocumentOuts.CellContentClick -= new TTGridCellEventDelegate(LBD_PrintedDocumentOuts_CellContentClick);
            LBD_MilitaryDrugOuts.CellContentClick -= new TTGridCellEventDelegate(LBD_MilitaryDrugOuts_CellContentClick);
            LBD_MedicalEquipmentOuts.CellContentClick -= new TTGridCellEventDelegate(LBD_MedicalEquipmentOuts_CellContentClick);
            LBD_MedicalConsOuts.CellContentClick -= new TTGridCellEventDelegate(LBD_MedicalConsOuts_CellContentClick);
            LBD_MarketDrugOuts.CellContentClick -= new TTGridCellEventDelegate(LBD_MarketDrugOuts_CellContentClick);
            LBD_KitOuts.CellContentClick -= new TTGridCellEventDelegate(LBD_KitOuts_CellContentClick);
            LBD_XXXXXXDrugOuts.CellContentClick -= new TTGridCellEventDelegate(LBD_XXXXXXDrugOuts_CellContentClick);
            tttoolstrip1.ItemClicked -= new TTToolStripItemClicked(tttoolstrip1_ItemClicked);
            base.UnBindControlEvents();
        }

        private void LBD_VaccineIns_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region LBBaseForm_LBD_VaccineIns_CellContentClick
   if(LBD_VaccineIns.CurrentCell == null)
                return;
            
            if (LBD_VaccineIns.CurrentCell.OwningColumn == LBD_VaccineIns.Columns[VI_DetailsIn.Name])
            {
                PurchaseItemAnalysesFormIn paaf = new PurchaseItemAnalysesFormIn();
                paaf.ShowEdit(this.FindForm(),_LBPurchaseProject.LBPurchaseProjectDetailInLists[LBD_VaccineIns.CurrentCell.RowIndex], true);
            }
            
            else if (LBD_VaccineIns.CurrentCell.OwningColumn == LBD_VaccineIns.Columns[VI_ToOutList.Name])
            {
                _LBPurchaseProject.TransferItem((LBPurchaseProjectDetailInList)LBD_VaccineIns.CurrentCell.OwningRow.TTObject, _LBPurchaseProject.IBFType.Value);
                LBD_VaccineIns.RefreshRows();
                LBD_VaccineOuts.RefreshRows();
            }
#endregion LBBaseForm_LBD_VaccineIns_CellContentClick
        }

        private void LBD_SpareIns_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region LBBaseForm_LBD_SpareIns_CellContentClick
   if(LBD_SpareIns.CurrentCell == null)
                return;
            
            if (LBD_SpareIns.CurrentCell.OwningColumn == LBD_SpareIns.Columns[SPI_DetailsIn.Name])
            {
                PurchaseItemAnalysesFormIn paaf = new PurchaseItemAnalysesFormIn();
                paaf.ShowEdit(this.FindForm(),_LBPurchaseProject.LBPurchaseProjectDetailInLists[LBD_SpareIns.CurrentCell.RowIndex], true);
            }
            
            else if (LBD_SpareIns.CurrentCell.OwningColumn == LBD_SpareIns.Columns[SPI_ToOutList.Name])
            {
                _LBPurchaseProject.TransferItem((LBPurchaseProjectDetailInList)LBD_SpareIns.CurrentCell.OwningRow.TTObject, _LBPurchaseProject.IBFType.Value);
                LBD_SpareIns.RefreshRows();
                LBD_SpareOuts.RefreshRows();
            }
#endregion LBBaseForm_LBD_SpareIns_CellContentClick
        }

        private void LBD_SerumIns_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region LBBaseForm_LBD_SerumIns_CellContentClick
   if(LBD_SerumIns.CurrentCell == null)
                return;
            
            if (LBD_SerumIns.CurrentCell.OwningColumn == LBD_SerumIns.Columns[SI_DetailsIn.Name])
            {
                PurchaseItemAnalysesFormIn paaf = new PurchaseItemAnalysesFormIn();
                paaf.ShowEdit(this.FindForm(),_LBPurchaseProject.LBPurchaseProjectDetailInLists[LBD_SerumIns.CurrentCell.RowIndex], true);
            }
            
            else if (LBD_SerumIns.CurrentCell.OwningColumn == LBD_SerumIns.Columns[SI_ToOutList.Name])
            {
                _LBPurchaseProject.TransferItem((LBPurchaseProjectDetailInList)LBD_SerumIns.CurrentCell.OwningRow.TTObject, _LBPurchaseProject.IBFType.Value);
                LBD_SerumIns.RefreshRows();
                LBD_SerumOuts.RefreshRows();
            }
#endregion LBBaseForm_LBD_SerumIns_CellContentClick
        }

        private void LBD_PrintedDocumentIns_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region LBBaseForm_LBD_PrintedDocumentIns_CellContentClick
   if(LBD_PrintedDocumentIns.CurrentCell == null)
                return;
            
            if (LBD_PrintedDocumentIns.CurrentCell.OwningColumn == LBD_PrintedDocumentIns.Columns[PDI_DetailsIn.Name])
            {
                PurchaseItemAnalysesFormIn paaf = new PurchaseItemAnalysesFormIn();
                paaf.ShowEdit(this.FindForm(),_LBPurchaseProject.LBPurchaseProjectDetailInLists[LBD_PrintedDocumentIns.CurrentCell.RowIndex], true);
            }
            
            else if (LBD_PrintedDocumentIns.CurrentCell.OwningColumn == LBD_PrintedDocumentIns.Columns[PDI_ToOutList.Name])
            {
                _LBPurchaseProject.TransferItem((LBPurchaseProjectDetailInList)LBD_PrintedDocumentIns.CurrentCell.OwningRow.TTObject, _LBPurchaseProject.IBFType.Value);
                LBD_PrintedDocumentIns.RefreshRows();
                LBD_PrintedDocumentOuts.RefreshRows();
            }
#endregion LBBaseForm_LBD_PrintedDocumentIns_CellContentClick
        }

        private void LBD_MilitaryDrugIns_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region LBBaseForm_LBD_MilitaryDrugIns_CellContentClick
   if(LBD_MilitaryDrugIns.CurrentCell == null)
                return;
            
            if (LBD_MilitaryDrugIns.CurrentCell.OwningColumn == LBD_MilitaryDrugIns.Columns[MIDI_DetailsIn.Name])
            {
                PurchaseItemAnalysesFormIn paaf = new PurchaseItemAnalysesFormIn();
                paaf.ShowEdit(this.FindForm(),_LBPurchaseProject.LBPurchaseProjectDetailInLists[LBD_MilitaryDrugIns.CurrentCell.RowIndex], true);
            }
            
            else if (LBD_MilitaryDrugIns.CurrentCell.OwningColumn == LBD_MilitaryDrugIns.Columns[MIDI_ToOutList.Name])
            {
                _LBPurchaseProject.TransferItem((LBPurchaseProjectDetailInList)LBD_MilitaryDrugIns.CurrentCell.OwningRow.TTObject, _LBPurchaseProject.IBFType.Value);
                LBD_MilitaryDrugIns.RefreshRows();
                LBD_MilitaryDrugOuts.RefreshRows();
            }
#endregion LBBaseForm_LBD_MilitaryDrugIns_CellContentClick
        }

        private void LBD_MedicalEquipmentIns_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region LBBaseForm_LBD_MedicalEquipmentIns_CellContentClick
   if(LBD_MedicalEquipmentIns.CurrentCell == null)
                return;
            
            if (LBD_MedicalEquipmentIns.CurrentCell.OwningColumn == LBD_MedicalEquipmentIns.Columns[MEI_DetailsIn.Name])
            {
                PurchaseItemAnalysesFormIn paaf = new PurchaseItemAnalysesFormIn();
                paaf.ShowEdit(this.FindForm(),_LBPurchaseProject.LBPurchaseProjectDetailInLists[LBD_MedicalEquipmentIns.CurrentCell.RowIndex], true);
            }
            
            else if (LBD_MedicalEquipmentIns.CurrentCell.OwningColumn == LBD_MedicalEquipmentIns.Columns[MEI_ToOutList.Name])
            {
                _LBPurchaseProject.TransferItem((LBPurchaseProjectDetailInList)LBD_MedicalEquipmentIns.CurrentCell.OwningRow.TTObject, _LBPurchaseProject.IBFType.Value);
                LBD_MedicalEquipmentIns.RefreshRows();
                LBD_MedicalEquipmentOuts.RefreshRows();
            }
#endregion LBBaseForm_LBD_MedicalEquipmentIns_CellContentClick
        }

        private void LBD_MedicalConsIns_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region LBBaseForm_LBD_MedicalConsIns_CellContentClick
   if(LBD_MedicalConsIns.CurrentCell == null)
                return;
            
            if (LBD_MedicalConsIns.CurrentCell.OwningColumn == LBD_MedicalConsIns.Columns[MCI_DetailsIn.Name])
            {
                PurchaseItemAnalysesFormIn paaf = new PurchaseItemAnalysesFormIn();
                paaf.ShowEdit(this.FindForm(),_LBPurchaseProject.LBPurchaseProjectDetailInLists[LBD_MedicalConsIns.CurrentCell.RowIndex], true);
            }
            
            else if (LBD_MedicalConsIns.CurrentCell.OwningColumn == LBD_MedicalConsIns.Columns[MCI_ToOutList.Name])
            {
                _LBPurchaseProject.TransferItem((LBPurchaseProjectDetailInList)LBD_MedicalConsIns.CurrentCell.OwningRow.TTObject, _LBPurchaseProject.IBFType.Value);
                LBD_MedicalConsIns.RefreshRows();
                LBD_MedicalConsOuts.RefreshRows();
            }
#endregion LBBaseForm_LBD_MedicalConsIns_CellContentClick
        }

        private void LBD_MarketDrugIns_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region LBBaseForm_LBD_MarketDrugIns_CellContentClick
   if(LBD_MarketDrugIns.CurrentCell == null)
                return;
            
            if (LBD_MarketDrugIns.CurrentCell.OwningColumn == LBD_MarketDrugIns.Columns[MDI_DetailsIn.Name])
            {
                PurchaseItemAnalysesFormIn paaf = new PurchaseItemAnalysesFormIn();
                paaf.ShowEdit(this.FindForm(),_LBPurchaseProject.LBPurchaseProjectDetailInLists[LBD_MarketDrugIns.CurrentCell.RowIndex], true);
            }
            
            else if (LBD_MarketDrugIns.CurrentCell.OwningColumn == LBD_MarketDrugIns.Columns[MDI_ToOutList.Name])
            {
                _LBPurchaseProject.TransferItem((LBPurchaseProjectDetailInList)LBD_MarketDrugIns.CurrentCell.OwningRow.TTObject, _LBPurchaseProject.IBFType.Value);
                LBD_MarketDrugIns.RefreshRows();
                LBD_MarketDrugOuts.RefreshRows();
            }
#endregion LBBaseForm_LBD_MarketDrugIns_CellContentClick
        }

        private void LBD_KitIns_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region LBBaseForm_LBD_KitIns_CellContentClick
   if(LBD_KitIns.CurrentCell == null)
                return;
            
            if (LBD_KitIns.CurrentCell.OwningColumn == LBD_KitIns.Columns[KTI_DetailsIn.Name])
            {
                PurchaseItemAnalysesFormIn paaf = new PurchaseItemAnalysesFormIn();
                paaf.ShowEdit(this.FindForm(),_LBPurchaseProject.LBPurchaseProjectDetailInLists[LBD_KitIns.CurrentCell.RowIndex], true);
            }
            
            else if (LBD_KitIns.CurrentCell.OwningColumn == LBD_KitIns.Columns[KTI_ToOutList.Name])
            {
                _LBPurchaseProject.TransferItem((LBPurchaseProjectDetailInList)LBD_KitIns.CurrentCell.OwningRow.TTObject, _LBPurchaseProject.IBFType.Value);
                LBD_KitIns.RefreshRows();
                LBD_KitOuts.RefreshRows();
            }
#endregion LBBaseForm_LBD_KitIns_CellContentClick
        }

        private void LBD_XXXXXXDrugIns_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region LBBaseForm_LBD_XXXXXXDrugIns_CellContentClick
   if(LBD_XXXXXXDrugIns.CurrentCell == null)
                return;
            
            if (LBD_XXXXXXDrugIns.CurrentCell.OwningColumn == LBD_XXXXXXDrugIns.Columns[GDI_DetailsIn.Name])
            {
                PurchaseItemAnalysesFormIn paaf = new PurchaseItemAnalysesFormIn();
                paaf.ShowEdit(this.FindForm(),_LBPurchaseProject.LBPurchaseProjectDetailInLists[LBD_XXXXXXDrugIns.CurrentCell.RowIndex], true);
            }
            
            else if (LBD_XXXXXXDrugIns.CurrentCell.OwningColumn == LBD_XXXXXXDrugIns.Columns[GDI_ToOutList.Name])
            {
                _LBPurchaseProject.TransferItem((LBPurchaseProjectDetailInList)LBD_XXXXXXDrugIns.CurrentCell.OwningRow.TTObject, _LBPurchaseProject.IBFType.Value);
                LBD_XXXXXXDrugIns.RefreshRows();
                LBD_XXXXXXDrugOuts.RefreshRows();
            }
#endregion LBBaseForm_LBD_XXXXXXDrugIns_CellContentClick
        }

        private void LBD_VaccineOuts_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region LBBaseForm_LBD_VaccineOuts_CellContentClick
   if(LBD_VaccineOuts.CurrentCell == null)
                return;
            
            if (LBD_VaccineOuts.CurrentCell.OwningColumn == LBD_VaccineOuts.Columns[VO_DetailsOut.Name])
            {
                PurchaseItemAnalysesFormOut paaf = new PurchaseItemAnalysesFormOut();
                paaf.ShowEdit(this.FindForm(),_LBPurchaseProject.LBPurchaseProjectDetailOutOfLists[LBD_VaccineOuts.CurrentCell.RowIndex], true);
            }
            
            else if (LBD_VaccineOuts.CurrentCell.OwningColumn == LBD_VaccineOuts.Columns[VO_ToInList.Name])
            {
                _LBPurchaseProject.TransferItem((LBPurchaseProjectDetailOutOfList)LBD_VaccineOuts.CurrentCell.OwningRow.TTObject, _LBPurchaseProject.IBFType.Value);
                LBD_VaccineIns.RefreshRows();
                LBD_VaccineOuts.RefreshRows();
            }
#endregion LBBaseForm_LBD_VaccineOuts_CellContentClick
        }

        private void LBD_SpareOuts_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region LBBaseForm_LBD_SpareOuts_CellContentClick
   if(LBD_SpareOuts.CurrentCell == null)
                return;
            
            if (LBD_SpareOuts.CurrentCell.OwningColumn == LBD_SpareOuts.Columns[SPO_DetailsOut.Name])
            {
                PurchaseItemAnalysesFormOut paaf = new PurchaseItemAnalysesFormOut();
                paaf.ShowEdit(this.FindForm(),_LBPurchaseProject.LBPurchaseProjectDetailOutOfLists[LBD_SpareOuts.CurrentCell.RowIndex], true);
            }
            
            else if (LBD_SpareOuts.CurrentCell.OwningColumn == LBD_SpareOuts.Columns[SPO_ToInList.Name])
            {
                _LBPurchaseProject.TransferItem((LBPurchaseProjectDetailOutOfList)LBD_SpareOuts.CurrentCell.OwningRow.TTObject, _LBPurchaseProject.IBFType.Value);
                LBD_SpareIns.RefreshRows();
                LBD_SpareOuts.RefreshRows();
            }
#endregion LBBaseForm_LBD_SpareOuts_CellContentClick
        }

        private void LBD_SerumOuts_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region LBBaseForm_LBD_SerumOuts_CellContentClick
   if(LBD_SerumOuts.CurrentCell == null)
                return;
            
            if (LBD_SerumOuts.CurrentCell.OwningColumn == LBD_SerumOuts.Columns[SO_DetailsOut.Name])
            {
                PurchaseItemAnalysesFormOut paaf = new PurchaseItemAnalysesFormOut();
                paaf.ShowEdit(this.FindForm(),_LBPurchaseProject.LBPurchaseProjectDetailOutOfLists[LBD_SerumOuts.CurrentCell.RowIndex], true);
            }
            
            else if (LBD_SerumOuts.CurrentCell.OwningColumn == LBD_SerumOuts.Columns[SO_ToInList.Name])
            {
                _LBPurchaseProject.TransferItem((LBPurchaseProjectDetailOutOfList)LBD_SerumOuts.CurrentCell.OwningRow.TTObject, _LBPurchaseProject.IBFType.Value);
                LBD_SerumIns.RefreshRows();
                LBD_SerumOuts.RefreshRows();
            }
#endregion LBBaseForm_LBD_SerumOuts_CellContentClick
        }

        private void LBD_PrintedDocumentOuts_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region LBBaseForm_LBD_PrintedDocumentOuts_CellContentClick
   if(LBD_PrintedDocumentOuts.CurrentCell == null)
                return;
            
            if (LBD_PrintedDocumentOuts.CurrentCell.OwningColumn == LBD_PrintedDocumentOuts.Columns[PDO_DetailsOut.Name])
            {
                PurchaseItemAnalysesFormOut paaf = new PurchaseItemAnalysesFormOut();
                paaf.ShowEdit(this.FindForm(),_LBPurchaseProject.LBPurchaseProjectDetailOutOfLists[LBD_PrintedDocumentOuts.CurrentCell.RowIndex], true);
            }
            
            else if (LBD_PrintedDocumentOuts.CurrentCell.OwningColumn == LBD_PrintedDocumentOuts.Columns[PDO_ToInList.Name])
            {
                _LBPurchaseProject.TransferItem((LBPurchaseProjectDetailOutOfList)LBD_PrintedDocumentOuts.CurrentCell.OwningRow.TTObject, _LBPurchaseProject.IBFType.Value);
                LBD_PrintedDocumentIns.RefreshRows();
                LBD_PrintedDocumentOuts.RefreshRows();
            }
#endregion LBBaseForm_LBD_PrintedDocumentOuts_CellContentClick
        }

        private void LBD_MilitaryDrugOuts_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region LBBaseForm_LBD_MilitaryDrugOuts_CellContentClick
   if(LBD_MilitaryDrugOuts.CurrentCell == null)
                return;
            
            if (LBD_MilitaryDrugOuts.CurrentCell.OwningColumn == LBD_MilitaryDrugOuts.Columns[MIDO_DetailsOut.Name])
            {
                PurchaseItemAnalysesFormOut paaf = new PurchaseItemAnalysesFormOut();
                paaf.ShowEdit(this.FindForm(),_LBPurchaseProject.LBPurchaseProjectDetailOutOfLists[LBD_MilitaryDrugOuts.CurrentCell.RowIndex], true);
            }
            
            else if (LBD_MilitaryDrugOuts.CurrentCell.OwningColumn == LBD_MilitaryDrugOuts.Columns[MIDO_ToInList.Name])
            {
                _LBPurchaseProject.TransferItem((LBPurchaseProjectDetailOutOfList)LBD_MilitaryDrugOuts.CurrentCell.OwningRow.TTObject, _LBPurchaseProject.IBFType.Value);
                LBD_MilitaryDrugIns.RefreshRows();
                LBD_MilitaryDrugOuts.RefreshRows();
            }
#endregion LBBaseForm_LBD_MilitaryDrugOuts_CellContentClick
        }

        private void LBD_MedicalEquipmentOuts_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region LBBaseForm_LBD_MedicalEquipmentOuts_CellContentClick
   if(LBD_MedicalEquipmentOuts.CurrentCell == null)
                return;
            
            if (LBD_MedicalEquipmentOuts.CurrentCell.OwningColumn == LBD_MedicalEquipmentOuts.Columns[MEO_DetailsOut.Name])
            {
                PurchaseItemAnalysesFormOut paaf = new PurchaseItemAnalysesFormOut();
                paaf.ShowEdit(this.FindForm(),_LBPurchaseProject.LBPurchaseProjectDetailOutOfLists[LBD_MedicalEquipmentOuts.CurrentCell.RowIndex], true);
            }
            
            else if (LBD_MedicalEquipmentOuts.CurrentCell.OwningColumn == LBD_MedicalEquipmentOuts.Columns[MEO_ToInList.Name])
            {
                _LBPurchaseProject.TransferItem((LBPurchaseProjectDetailOutOfList)LBD_MedicalConsOuts.CurrentCell.OwningRow.TTObject, _LBPurchaseProject.IBFType.Value);
                LBD_MedicalEquipmentIns.RefreshRows();
                LBD_MedicalEquipmentOuts.RefreshRows();
            }
#endregion LBBaseForm_LBD_MedicalEquipmentOuts_CellContentClick
        }

        private void LBD_MedicalConsOuts_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region LBBaseForm_LBD_MedicalConsOuts_CellContentClick
   if(LBD_MedicalConsOuts.CurrentCell == null)
                return;
            
            if (LBD_MedicalConsOuts.CurrentCell.OwningColumn == LBD_MedicalConsOuts.Columns[MCO_DetailsOut.Name])
            {
                PurchaseItemAnalysesFormOut paaf = new PurchaseItemAnalysesFormOut();
                paaf.ShowEdit(this.FindForm(),_LBPurchaseProject.LBPurchaseProjectDetailOutOfLists[LBD_MedicalConsOuts.CurrentCell.RowIndex], true);
            }
            
            else if (LBD_MedicalConsOuts.CurrentCell.OwningColumn == LBD_MedicalConsOuts.Columns[MCO_ToInList.Name])
            {
                _LBPurchaseProject.TransferItem((LBPurchaseProjectDetailOutOfList)LBD_MedicalConsOuts.CurrentCell.OwningRow.TTObject, _LBPurchaseProject.IBFType.Value);
                LBD_MedicalConsIns.RefreshRows();
                LBD_MedicalConsOuts.RefreshRows();
            }
#endregion LBBaseForm_LBD_MedicalConsOuts_CellContentClick
        }

        private void LBD_MarketDrugOuts_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region LBBaseForm_LBD_MarketDrugOuts_CellContentClick
   if(LBD_MarketDrugOuts.CurrentCell == null)
                return;
            
            if (LBD_MarketDrugOuts.CurrentCell.OwningColumn == LBD_MarketDrugOuts.Columns[MDO_DetailsOut.Name])
            {
                PurchaseItemAnalysesFormOut paaf = new PurchaseItemAnalysesFormOut();
                paaf.ShowEdit(this.FindForm(),_LBPurchaseProject.LBPurchaseProjectDetailOutOfLists[LBD_MarketDrugOuts.CurrentCell.RowIndex], true);
            }
            
            else if (LBD_MarketDrugOuts.CurrentCell.OwningColumn == LBD_MarketDrugOuts.Columns[MDO_ToInList.Name])
            {
                _LBPurchaseProject.TransferItem((LBPurchaseProjectDetailOutOfList)LBD_MarketDrugOuts.CurrentCell.OwningRow.TTObject, _LBPurchaseProject.IBFType.Value);
                LBD_MarketDrugIns.RefreshRows();
                LBD_MarketDrugOuts.RefreshRows();
            }
#endregion LBBaseForm_LBD_MarketDrugOuts_CellContentClick
        }

        private void LBD_KitOuts_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region LBBaseForm_LBD_KitOuts_CellContentClick
   if(LBD_KitOuts.CurrentCell == null)
                return;
            
            if (LBD_KitOuts.CurrentCell.OwningColumn == LBD_KitOuts.Columns[KTO_DetailsOut.Name])
            {
                PurchaseItemAnalysesFormOut paaf = new PurchaseItemAnalysesFormOut();
                paaf.ShowEdit(this.FindForm(),_LBPurchaseProject.LBPurchaseProjectDetailOutOfLists[LBD_KitOuts.CurrentCell.RowIndex], true);
            }
            
            else if (LBD_KitOuts.CurrentCell.OwningColumn == LBD_KitOuts.Columns[KTO_ToInList.Name])
            {
                _LBPurchaseProject.TransferItem((LBPurchaseProjectDetailOutOfList)LBD_KitOuts.CurrentCell.OwningRow.TTObject, _LBPurchaseProject.IBFType.Value);
                LBD_KitIns.RefreshRows();
                LBD_KitOuts.RefreshRows();
            }
#endregion LBBaseForm_LBD_KitOuts_CellContentClick
        }

        private void LBD_XXXXXXDrugOuts_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region LBBaseForm_LBD_XXXXXXDrugOuts_CellContentClick
   if(LBD_XXXXXXDrugOuts.CurrentCell == null)
                return;
            
            if (LBD_XXXXXXDrugOuts.CurrentCell.OwningColumn == LBD_XXXXXXDrugOuts.Columns[GDO_DetailsOut.Name])
            {
                PurchaseItemAnalysesFormOut paaf = new PurchaseItemAnalysesFormOut();
                paaf.ShowEdit(this.FindForm(),_LBPurchaseProject.LBPurchaseProjectDetailOutOfLists[LBD_XXXXXXDrugOuts.CurrentCell.RowIndex], true);
            }
            
            else if (LBD_XXXXXXDrugOuts.CurrentCell.OwningColumn == LBD_XXXXXXDrugOuts.Columns[GDO_ToInList.Name])
            {
                _LBPurchaseProject.TransferItem((LBPurchaseProjectDetailOutOfList)LBD_XXXXXXDrugOuts.CurrentCell.OwningRow.TTObject, _LBPurchaseProject.IBFType.Value);
                LBD_XXXXXXDrugIns.RefreshRows();
                LBD_XXXXXXDrugOuts.RefreshRows();
            }
#endregion LBBaseForm_LBD_XXXXXXDrugOuts_CellContentClick
        }

        private void tttoolstrip1_ItemClicked(ITTToolStripItem item)
        {
#region LBBaseForm_tttoolstrip1_ItemClicked
   Dictionary<string, TTReportTool.PropertyCache<object>> parameter = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
            objectID.Add("VALUE", _LBPurchaseProject.ObjectID.ToString());
            parameter.Add("TTOBJECTID", objectID);
            
            if(item.Name == "IBFReport")
            {
                switch (_LBPurchaseProject.IBFType.Value)
                {
                    case IBFTypeEnum.Asi:
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_VaccineIBFReport), true, 1, parameter);
                        break;
                        
                    case IBFTypeEnum.BasiliEvrak:
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_PrintedDocumentIBFReport), true, 1, parameter);
                        break;
                        
                    case IBFTypeEnum.XXXXXXIlac:
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_XXXXXXDrugIBFReport), true, 1, parameter);
                        break;
                        
                    case IBFTypeEnum.Kit:
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_KitIBFReport), true, 1, parameter);
                        break;
                        
                    case IBFTypeEnum.OrduIlac:
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_MilitaryDrugIBFReport), true, 1, parameter);
                        break;
                        
                    case IBFTypeEnum.PiyasaIlac:
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_MarketDrugIBFReport), true, 1, parameter);
                        break;
                        
                    case IBFTypeEnum.Serum:
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_SerumIBFReport), true, 1, parameter);
                        break;
                        
                    case IBFTypeEnum.TibbiCihaz:
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_MedicalEquipmentIBFReport), true, 1, parameter);
                        break;
                        
                    case IBFTypeEnum.TibbiSarf:
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_MedicalConsIBFReport), true, 1, parameter);
                        break;
                        
                    case IBFTypeEnum.YedekParca:
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_SpareIBFReport), true, 1, parameter);
                        break;
                        
                    default:
                        break;
                }
            }
            else if(item.Name == "EkliListe")
            {
                if(_LBPurchaseProject.LBPurchaseProjectDetailOutOfLists.Count > 0)
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_EkliListeReport), true, 1, parameter);
                else
                    InfoBox.Show(SystemMessage.GetMessage(67));
            }
#endregion LBBaseForm_tttoolstrip1_ItemClicked
        }

        protected override void PreScript()
        {
#region LBBaseForm_PreScript
    base.PreScript();
            
            if(_LBPurchaseProject.IBFYear.HasValue || _LBPurchaseProject.IBFType.HasValue)
                ShowNeededGrids();
#endregion LBBaseForm_PreScript

            }
            
#region LBBaseForm_Methods
        public void ShowNeededGrids()
        {
            //Bu kodlar geçici olarak yazıldı, gerekli olduğu zaman silinecektir.
            //Vaccine - Aşı
            LBD_VaccineIns.Columns[VI_Clinic.Name].Visible = false;
            LBD_VaccineIns.Columns[VI_DistributionPlace.Name].Visible = false;
            LBD_VaccineIns.Columns[VI_MKS.Name].Visible = false;
            LBD_VaccineIns.Columns[VI_ResourceType.Name].Visible = false;
            LBD_VaccineIns.Columns[VI_SupportingPlace.Name].Visible = false;
            LBD_VaccineIns.Columns[VI_ApprovedAmount.Name].HeaderText = "Onaylanan";
            LBD_VaccineIns.Columns[VI_RequestedAmount.Name].HeaderText = "İstek";
            LBD_VaccineOuts.Columns[VO_Clinic.Name].Visible = false;
            LBD_VaccineOuts.Columns[VO_DistributionPlace.Name].Visible = false;
            LBD_VaccineOuts.Columns[VO_MKS.Name].Visible = false;
            LBD_VaccineOuts.Columns[VO_ResourceType.Name].Visible = false;
            LBD_VaccineOuts.Columns[VO_SupportingPlace.Name].Visible = false;
            LBD_VaccineOuts.Columns[VO_ApprovedAmount.Name].HeaderText = "Onaylanan";
            LBD_VaccineOuts.Columns[VO_RequestedAmount.Name].HeaderText = "İstek";
            
            //Basılı Evrak - PrinttedDocument
            LBD_PrintedDocumentIns.Columns[PDI_ApprovedAmount.Name].HeaderText = "Onaylanan";
            LBD_PrintedDocumentIns.Columns[PDI_RequestedAmount.Name].HeaderText = "İstek";
            LBD_PrintedDocumentOuts.Columns[PDO_ApprovedAmount.Name].HeaderText = "Onaylanan";
            LBD_PrintedDocumentOuts.Columns[PDO_RequestedAmount.Name].HeaderText = "İstek";
            
            //XXXXXX İlaç - XXXXXXDrug
            LBD_XXXXXXDrugIns.Columns[GDI_FormulaPurchaseItemUnitType.Name].Visible = false;
            LBD_XXXXXXDrugIns.Columns[GDI_LastIBFRequestAmount.Name].Visible = false;
            LBD_XXXXXXDrugIns.Columns[GDI_ApprovedAmount.Name].HeaderText = "Onaylanan";
            LBD_XXXXXXDrugIns.Columns[GDI_RequestedAmount.Name].HeaderText = "İstek";
            LBD_XXXXXXDrugOuts.Columns[GDO_FormulaPurchaseItemUnitType.Name].Visible = false;
            LBD_XXXXXXDrugOuts.Columns[GDO_LastIBFRequestAmount.Name].Visible = false;
            LBD_XXXXXXDrugOuts.Columns[GDO_ApprovedAmount.Name].HeaderText = "Onaylanan";
            LBD_XXXXXXDrugOuts.Columns[GDO_RequestedAmount.Name].HeaderText = "İstek";
            
            //Kit
            LBD_KitIns.Columns[KTI_ConsumptionAmount.Name].Visible = false;
            LBD_KitIns.Columns[KTI_FirstRequestAmount.Name].Visible = false;
            LBD_KitIns.Columns[KTI_ProductStatus.Name].Visible = false;
            LBD_KitIns.Columns[KTI_SecondRequestAmount.Name].Visible = false;
            LBD_KitIns.Columns[KTI_ApprovedAmount.Name].HeaderText = "Onaylanan";
            LBD_KitIns.Columns[KTI_RequestedAmount.Name].HeaderText = "İstek";
            LBD_KitOuts.Columns[KTO_ConsumptionAmount.Name].Visible = false;
            LBD_KitOuts.Columns[KTO_FirstRequestAmount.Name].Visible = false;
            LBD_KitOuts.Columns[KTO_ProductStatus.Name].Visible = false;
            LBD_KitOuts.Columns[KTO_SecondRequestAmount.Name].Visible = false;
            LBD_KitOuts.Columns[KTO_ApprovedAmount.Name].HeaderText = "Onaylanan";
            LBD_KitOuts.Columns[KTO_RequestedAmount.Name].HeaderText = "İstek";
            
            //XXXXXX İlaç - MilitaryDrug
            LBD_MilitaryDrugIns.Columns[MIDI_ConsumptionAmount.Name].Visible = false;
            LBD_MilitaryDrugIns.Columns[MIDI_LastIBFRequestAmount.Name].Visible = false;
            LBD_MilitaryDrugIns.Columns[MIDI_RequestAmountBox.Name].Visible = false;
            LBD_MilitaryDrugIns.Columns[MIDI_ApprovedAmount.Name].HeaderText = "Onaylanan";
            LBD_MilitaryDrugIns.Columns[MIDI_RequestedAmount.Name].HeaderText = "İstek";
            LBD_MilitaryDrugOuts.Columns[MIDO_ConsumptionAmount.Name].Visible = false;
            LBD_MilitaryDrugOuts.Columns[MIDO_LastIBFRequestAmount.Name].Visible = false;
            LBD_MilitaryDrugOuts.Columns[MIDO_RequestAmountBox.Name].Visible = false;
            LBD_MilitaryDrugOuts.Columns[MIDO_ApprovedAmount.Name].HeaderText = "Onaylanan";
            LBD_MilitaryDrugOuts.Columns[MIDO_RequestedAmount.Name].HeaderText = "İstek";
            
            //Piyasa İlaç - MarketDrug
            LBD_MarketDrugIns.Columns[MDI_ConsumptionAmount.Name].Visible = false;
            LBD_MarketDrugIns.Columns[MDI_LastIBFRequestAmount.Name].Visible = false;
            LBD_MarketDrugIns.Columns[MDI_PharmacologicalEffect.Name].Visible = false;
            LBD_MarketDrugIns.Columns[MDI_RequestAmountBox.Name].Visible = false;
            LBD_MarketDrugIns.Columns[MDI_ApprovedAmount.Name].HeaderText = "Onaylanan";
            LBD_MarketDrugIns.Columns[MDI_RequestedAmount.Name].HeaderText = "İstek";
            LBD_MarketDrugOuts.Columns[MDO_ConsumptionAmount.Name].Visible = false;
            LBD_MarketDrugOuts.Columns[MDO_LastIBFRequestAmount.Name].Visible = false;
            LBD_MarketDrugOuts.Columns[MDO_PharmacologicalEffect.Name].Visible = false;
            LBD_MarketDrugOuts.Columns[MDO_RequestAmountBox.Name].Visible = false;
            LBD_MarketDrugOuts.Columns[MDO_ApprovedAmount.Name].HeaderText = "Onaylanan";
            LBD_MarketDrugOuts.Columns[MDO_RequestedAmount.Name].HeaderText = "İstek";
            
            //Serum
            LBD_SerumIns.Columns[SI_ConsumptionAmount.Name].Visible = false;
            LBD_SerumIns.Columns[SI_LastIBFRequestAmount.Name].Visible = false;
            LBD_SerumIns.Columns[SI_RequestAmountBox.Name].Visible = false;
            LBD_SerumIns.Columns[SI_ApprovedAmount.Name].HeaderText = "Onaylanan";
            LBD_SerumIns.Columns[SI_RequestedAmount.Name].HeaderText = "İstek";
            LBD_SerumOuts.Columns[SO_ConsumptionAmount.Name].Visible = false;
            LBD_SerumOuts.Columns[SO_LastIBFRequestAmount.Name].Visible = false;
            LBD_SerumOuts.Columns[SO_RequestAmountBox.Name].Visible = false;
            LBD_SerumOuts.Columns[SO_ApprovedAmount.Name].HeaderText = "Onaylanan";
            LBD_SerumOuts.Columns[SO_RequestedAmount.Name].HeaderText = "İstek";
            
            //Tıbbi Cihaz - MedicalEquipment
            LBD_MedicalEquipmentIns.Columns[MEI_ConsumptionAmount.Name].Visible = false;
            LBD_MedicalEquipmentIns.Columns[MEI_ConsumptionAmount1.Name].Visible = false;
            LBD_MedicalEquipmentIns.Columns[MEI_ConsumptionAmount2.Name].Visible = false;
            LBD_MedicalEquipmentIns.Columns[MEI_DependentSpare.Name].Visible = false;
            LBD_MedicalEquipmentIns.Columns[MEI_LastIBFRequestAmount.Name].Visible = false;
            LBD_MedicalEquipmentIns.Columns[MEI_Purpose.Name].Visible = false;
            LBD_MedicalEquipmentIns.Columns[MEI_StoreStock.Name].Visible = false;
            LBD_MedicalEquipmentIns.Columns[MEI_ApprovedAmount.Name].HeaderText = "Onaylanan";
            LBD_MedicalEquipmentIns.Columns[MEI_RequestedAmount.Name].HeaderText = "İstek";
            LBD_MedicalEquipmentOuts.Columns[MEO_ConsumptionAmount.Name].Visible = false;
            LBD_MedicalEquipmentOuts.Columns[MEO_ConsumptionAmount1.Name].Visible = false;
            LBD_MedicalEquipmentOuts.Columns[MEO_ConsumptionAmount2.Name].Visible = false;
            LBD_MedicalEquipmentOuts.Columns[MEO_DependentSpare.Name].Visible = false;
            LBD_MedicalEquipmentOuts.Columns[MEO_LastIBFRequestAmount.Name].Visible = false;
            LBD_MedicalEquipmentOuts.Columns[MEO_Purpose.Name].Visible = false;
            LBD_MedicalEquipmentOuts.Columns[MEO_StoreStock.Name].Visible = false;
            LBD_MedicalEquipmentOuts.Columns[MEO_ApprovedAmount.Name].HeaderText = "Onaylanan";
            LBD_MedicalEquipmentOuts.Columns[MEO_RequestedAmount.Name].HeaderText = "İstek";
            
            //Tıbbi Sarf - Medical Consumption
            LBD_MedicalConsIns.Columns[MCI_ConsumptionAmount.Name].Visible = false;
            LBD_MedicalConsIns.Columns[MCI_LastIBFRequestAmount.Name].Visible = false;
            LBD_MedicalConsIns.Columns[MCI_ApprovedAmount.Name].HeaderText = "Onaylanan";
            LBD_MedicalConsIns.Columns[MCI_RequestedAmount.Name].HeaderText = "İstek";
            LBD_MedicalConsOuts.Columns[MCO_ConsumptionAmount.Name].Visible = false;
            LBD_MedicalConsOuts.Columns[MCO_LastIBFRequestAmount.Name].Visible = false;
            LBD_MedicalConsOuts.Columns[MCO_ApprovedAmount.Name].HeaderText = "Onaylanan";
            LBD_MedicalConsOuts.Columns[MCO_RequestedAmount.Name].HeaderText = "İstek";
            
            //Yedek Parça - Spare
            LBD_SpareIns.Columns[SPI_ConsumptionAmount.Name].Visible = false;
            LBD_SpareIns.Columns[SPI_DependentSpare.Name].Visible = false;
            LBD_SpareIns.Columns[SPI_Purpose.Name].Visible = false;
            LBD_SpareIns.Columns[SPI_ApprovedAmount.Name].HeaderText = "Onaylanan";
            LBD_SpareIns.Columns[SPI_RequestedAmount.Name].HeaderText = "İstek";
            LBD_SpareOuts.Columns[SPO_ConsumptionAmount.Name].Visible = false;
            LBD_SpareOuts.Columns[SPO_DependentSpare.Name].Visible = false;
            LBD_SpareOuts.Columns[SPO_Purpose.Name].Visible = false;
            LBD_SpareOuts.Columns[SPO_ApprovedAmount.Name].HeaderText = "Onaylanan";
            LBD_SpareOuts.Columns[SPO_RequestedAmount.Name].HeaderText = "İstek";
            //Buraya kadar...
            
            LBD_XXXXXXDrugIns.Visible = false;
            LBD_XXXXXXDrugOuts.Visible = false;
            LBD_KitIns.Visible = false;
            LBD_KitOuts.Visible = false;
            LBD_MarketDrugIns.Visible = false;
            LBD_MarketDrugOuts.Visible = false;
            LBD_MedicalConsIns.Visible = false;
            LBD_MedicalConsOuts.Visible = false;
            LBD_MedicalEquipmentIns.Visible = false;
            LBD_MedicalEquipmentOuts.Visible = false;
            LBD_MilitaryDrugIns.Visible = false;
            LBD_MilitaryDrugOuts.Visible = false;
            LBD_PrintedDocumentIns.Visible = false;
            LBD_PrintedDocumentOuts.Visible = false;
            LBD_SerumIns.Visible = false;
            LBD_SerumOuts.Visible = false;
            LBD_SpareIns.Visible = false;
            LBD_SpareOuts.Visible = false;
            LBD_VaccineIns.Visible = false;
            LBD_VaccineOuts.Visible = false;
            
            int ibfYear = _LBPurchaseProject.IBFYear.Value;
            
            switch(_LBPurchaseProject.IBFType.Value)
            {
                case IBFTypeEnum.Asi:
                    LBD_VaccineIns.Visible = true;
                    LBD_VaccineOuts.Visible = true;
                    //LBD_VaccineIns.Dock = DockStyle.Fill;
                    //LBD_VaccineOuts.Dock = DockStyle.Fill;
                    if(_LBPurchaseProject.CurrentStateDefID.Value == LBPurchaseProject.States.Completed)
                    {
                        LBD_VaccineIns.Columns[VI_ToOutList.Name].Visible = false;
                        LBD_VaccineOuts.Columns[VO_ToInList.Name].Visible = false;
                    }
                    if(_LBPurchaseProject.CurrentStateDefID.Value != LBPurchaseProject.States.Analyse)
                    {
//                        LBD_VaccineIns.Columns[VI_DetailsIn.Name].Visible = false;
//                        LBD_VaccineOuts.Columns[VO_DetailsOut.Name].Visible = false;
                    }
                    break;
                    
                case IBFTypeEnum.BasiliEvrak:
                    LBD_PrintedDocumentIns.Visible = true;
                    LBD_PrintedDocumentOuts.Visible = true;
                    //LBD_PrintedDocumentIns.Dock = DockStyle.Fill;
                    //LBD_PrintedDocumentOuts.Dock = DockStyle.Fill;
                    if(_LBPurchaseProject.CurrentStateDefID.Value == LBPurchaseProject.States.Completed)
                    {
                        LBD_PrintedDocumentIns.Columns[PDI_ToOutList.Name].Visible = false;
                        LBD_PrintedDocumentOuts.Columns[PDO_ToInList.Name].Visible = false;
                    }
                    if(_LBPurchaseProject.CurrentStateDefID.Value != LBPurchaseProject.States.Analyse)
                    {
//                        LBD_PrintedDocumentIns.Columns[PDI_DetailsIn.Name].Visible = false;
//                        LBD_PrintedDocumentOuts.Columns[PDO_DetailsOut.Name].Visible = false;
                    }
                    break;
                    
                case IBFTypeEnum.XXXXXXIlac:
                    LBD_XXXXXXDrugIns.Visible = true;
                    LBD_XXXXXXDrugOuts.Visible = true;
                    //LBD_XXXXXXDrugIns.Dock = DockStyle.Fill;
                    //LBD_XXXXXXDrugOuts.Dock = DockStyle.Fill;
                    LBD_XXXXXXDrugIns.Columns[GDI_LastIBFRequestAmount.Name].HeaderText = LBD_XXXXXXDrugIns.Columns[GDI_LastIBFRequestAmount.Name].HeaderText.Replace("xxx", (ibfYear - 1).ToString());
                    LBD_XXXXXXDrugOuts.Columns[GDO_LastIBFRequestAmount.Name].HeaderText = LBD_XXXXXXDrugOuts.Columns[GDO_LastIBFRequestAmount.Name].HeaderText.Replace("xxx", (ibfYear - 1).ToString());
                    if(_LBPurchaseProject.CurrentStateDefID.Value == LBPurchaseProject.States.Completed)
                    {
                        LBD_XXXXXXDrugIns.Columns[GDI_ToOutList.Name].Visible = false;
                        LBD_XXXXXXDrugOuts.Columns[GDO_ToInList.Name].Visible = false;
                    }
                    if(_LBPurchaseProject.CurrentStateDefID.Value != LBPurchaseProject.States.Analyse)
                    {
//                        LBD_XXXXXXDrugIns.Columns[GDI_DetailsIn.Name].Visible = false;
//                        LBD_XXXXXXDrugOuts.Columns[GDO_DetailsOut.Name].Visible = false;
                    }
                    break;
                    
                case IBFTypeEnum.Kit:
                    LBD_KitIns.Visible = true;
                    LBD_KitOuts.Visible = true;
                    //LBD_KitIns.Dock = DockStyle.Fill;
                    //LBD_KitOuts.Dock = DockStyle.Fill;
                    if(_LBPurchaseProject.CurrentStateDefID.Value == LBPurchaseProject.States.Completed)
                    {
                        LBD_KitIns.Columns[KTI_ToOutList.Name].Visible = false;
                        LBD_KitOuts.Columns[KTO_ToInList.Name].Visible = false;
                    }
                    if(_LBPurchaseProject.CurrentStateDefID.Value != LBPurchaseProject.States.Analyse)
                    {
//                        LBD_KitIns.Columns[KTI_DetailsIn.Name].Visible = false;
//                        LBD_KitOuts.Columns[KTO_DetailsOut.Name].Visible = false;
                    }
                    break;
                    
                case IBFTypeEnum.OrduIlac:
                    LBD_MilitaryDrugIns.Visible = true;
                    LBD_MilitaryDrugOuts.Visible = true;
                    //LBD_MilitaryDrugIns.Dock = DockStyle.Fill;
                    //LBD_MilitaryDrugOuts.Dock = DockStyle.Fill;
                    LBD_MilitaryDrugIns.Columns[MIDI_ConsumptionAmount.Name].HeaderText = LBD_MilitaryDrugIns.Columns[MIDI_ConsumptionAmount.Name].HeaderText.Replace("xxx", (ibfYear - 3).ToString());
                    LBD_MilitaryDrugIns.Columns[MIDI_LastIBFRequestAmount.Name].HeaderText = LBD_MilitaryDrugIns.Columns[MIDI_LastIBFRequestAmount.Name].HeaderText.Replace("xxx", (ibfYear - 1).ToString());
                    LBD_MilitaryDrugOuts.Columns[MIDO_ConsumptionAmount.Name].HeaderText = LBD_MilitaryDrugOuts.Columns[MIDO_ConsumptionAmount.Name].HeaderText.Replace("xxx", (ibfYear - 3).ToString());
                    LBD_MilitaryDrugOuts.Columns[MIDO_LastIBFRequestAmount.Name].HeaderText = LBD_MilitaryDrugOuts.Columns[MIDO_LastIBFRequestAmount.Name].HeaderText.Replace("xxx", (ibfYear - 1).ToString());
                    if(_LBPurchaseProject.CurrentStateDefID.Value == LBPurchaseProject.States.Completed)
                    {
                        LBD_MilitaryDrugIns.Columns[MIDI_ToOutList.Name].Visible = false;
                        LBD_MilitaryDrugOuts.Columns[MIDO_ToInList.Name].Visible = false;
                    }
                    if(_LBPurchaseProject.CurrentStateDefID.Value != LBPurchaseProject.States.Analyse)
                    {
//                        LBD_MilitaryDrugIns.Columns[MIDI_DetailsIn.Name].Visible = false;
//                        LBD_MilitaryDrugOuts.Columns[MIDO_DetailsOut.Name].Visible = false;
                    }
                    break;
                    
                case IBFTypeEnum.PiyasaIlac:
                    LBD_MarketDrugIns.Visible = true;
                    LBD_MarketDrugOuts.Visible = true;
                    //LBD_MarketDrugIns.Dock = DockStyle.Fill;
                    //LBD_MarketDrugOuts.Dock = DockStyle.Fill;
                    LBD_MarketDrugIns.Columns[MDI_LastIBFRequestAmount.Name].HeaderText = LBD_MarketDrugIns.Columns[MDI_LastIBFRequestAmount.Name].HeaderText.Replace("xxx", (ibfYear - 1).ToString());
                    LBD_MarketDrugIns.Columns[MDI_ConsumptionAmount.Name].HeaderText = LBD_MarketDrugIns.Columns[MDI_ConsumptionAmount.Name].HeaderText.Replace("xxx", (ibfYear - 2).ToString());
                    LBD_MarketDrugOuts.Columns[MDO_LastIBFRequestAmount.Name].HeaderText = LBD_MarketDrugOuts.Columns[MDO_LastIBFRequestAmount.Name].HeaderText.Replace("xxx", (ibfYear - 1).ToString());
                    LBD_MarketDrugOuts.Columns[MDO_ConsumptionAmount.Name].HeaderText = LBD_MarketDrugOuts.Columns[MDO_ConsumptionAmount.Name].HeaderText.Replace("xxx", (ibfYear - 2).ToString());
                    if(_LBPurchaseProject.CurrentStateDefID.Value == LBPurchaseProject.States.Completed)
                    {
                        LBD_MarketDrugIns.Columns[MDI_ToOutList.Name].Visible = false;
                        LBD_MarketDrugOuts.Columns[MDO_ToInList.Name].Visible = false;
                    }
                    if(_LBPurchaseProject.CurrentStateDefID.Value != LBPurchaseProject.States.Analyse)
                    {
//                        LBD_MarketDrugIns.Columns[MDI_DetailsIn.Name].Visible = false;
//                        LBD_MarketDrugOuts.Columns[MDO_DetailsOut.Name].Visible = false;
                    }
                    break;
                    
                case IBFTypeEnum.Serum:
                    LBD_SerumIns.Visible = true;
                    LBD_SerumOuts.Visible = true;
                    //LBD_SerumIns.Dock = DockStyle.Fill;
                    //LBD_SerumOuts.Dock = DockStyle.Fill;
                    LBD_SerumIns.Columns[SI_ConsumptionAmount.Name].HeaderText = LBD_SerumIns.Columns[SI_ConsumptionAmount.Name].HeaderText.Replace("xxx", (ibfYear - 2).ToString());
                    LBD_SerumIns.Columns[SI_LastIBFRequestAmount.Name].HeaderText = LBD_SerumIns.Columns[SI_LastIBFRequestAmount.Name].HeaderText.Replace("xxx", (ibfYear - 1).ToString());
                    LBD_SerumOuts.Columns[SO_ConsumptionAmount.Name].HeaderText = LBD_SerumOuts.Columns[SO_ConsumptionAmount.Name].HeaderText.Replace("xxx", (ibfYear - 2).ToString());
                    LBD_SerumOuts.Columns[SO_LastIBFRequestAmount.Name].HeaderText = LBD_SerumOuts.Columns[SO_LastIBFRequestAmount.Name].HeaderText.Replace("xxx", (ibfYear - 1).ToString());
                    if(_LBPurchaseProject.CurrentStateDefID.Value == LBPurchaseProject.States.Completed)
                    {
                        LBD_SerumIns.Columns[SI_ToOutList.Name].Visible = false;
                        LBD_SerumOuts.Columns[SO_ToInList.Name].Visible = false;
                    }
                    if(_LBPurchaseProject.CurrentStateDefID.Value != LBPurchaseProject.States.Analyse)
                    {
//                        LBD_SerumIns.Columns[SI_DetailsIn.Name].Visible = false;
//                        LBD_SerumOuts.Columns[SO_DetailsOut.Name].Visible = false;
                    }
                    break;
                    
                case IBFTypeEnum.TibbiCihaz:
                    LBD_MedicalEquipmentIns.Visible = true;
                    LBD_MedicalEquipmentOuts.Visible = true;
                    //LBD_MedicalEquipmentIns.Dock = DockStyle.Fill;
                    //LBD_MedicalEquipmentOuts.Dock = DockStyle.Fill;
                    LBD_MedicalEquipmentIns.Columns[MEI_ConsumptionAmount.Name].HeaderText = LBD_MedicalEquipmentIns.Columns[MEI_ConsumptionAmount.Name].HeaderText.Replace("xxx", (ibfYear - 4).ToString());
                    LBD_MedicalEquipmentIns.Columns[MEI_ConsumptionAmount1.Name].HeaderText = LBD_MedicalEquipmentIns.Columns[MEI_ConsumptionAmount1.Name].HeaderText.Replace("xxx", (ibfYear - 3).ToString());
                    LBD_MedicalEquipmentIns.Columns[MEI_ConsumptionAmount2.Name].HeaderText = LBD_MedicalEquipmentIns.Columns[MEI_ConsumptionAmount2.Name].HeaderText.Replace("xxx", (ibfYear - 2).ToString());
                    LBD_MedicalEquipmentIns.Columns[MEI_StoreStock.Name].HeaderText = LBD_MedicalEquipmentIns.Columns[MEI_StoreStock.Name].HeaderText.Replace("xxx", (ibfYear - 2).ToString());
                    LBD_MedicalEquipmentOuts.Columns[MEO_ConsumptionAmount.Name].HeaderText = LBD_MedicalEquipmentOuts.Columns[MEO_ConsumptionAmount.Name].HeaderText.Replace("xxx", (ibfYear - 4).ToString());
                    LBD_MedicalEquipmentOuts.Columns[MEO_ConsumptionAmount1.Name].HeaderText = LBD_MedicalEquipmentOuts.Columns[MEO_ConsumptionAmount1.Name].HeaderText.Replace("xxx", (ibfYear - 3).ToString());
                    LBD_MedicalEquipmentOuts.Columns[MEO_ConsumptionAmount2.Name].HeaderText = LBD_MedicalEquipmentOuts.Columns[MEO_ConsumptionAmount2.Name].HeaderText.Replace("xxx", (ibfYear - 2).ToString());
                    LBD_MedicalEquipmentOuts.Columns[MEO_StoreStock.Name].HeaderText = LBD_MedicalEquipmentOuts.Columns[MEO_StoreStock.Name].HeaderText.Replace("xxx", (ibfYear - 2).ToString());
                    if(_LBPurchaseProject.CurrentStateDefID.Value == LBPurchaseProject.States.Completed)
                    {
                        LBD_MedicalEquipmentIns.Columns[MEI_ToOutList.Name].Visible = false;
                        LBD_MedicalEquipmentOuts.Columns[MEO_ToInList.Name].Visible = false;
                    }
                    if(_LBPurchaseProject.CurrentStateDefID.Value != LBPurchaseProject.States.Analyse)
                    {
//                        LBD_MedicalEquipmentIns.Columns[MEI_DetailsIn.Name].Visible = false;
//                        LBD_MedicalEquipmentOuts.Columns[MEO_DetailsOut.Name].Visible = false;
                    }
                    break;
                    
                case IBFTypeEnum.TibbiSarf:
                    LBD_MedicalConsIns.Visible = true;
                    LBD_MedicalConsOuts.Visible = true;
                    //LBD_MedicalConsIns.Dock = DockStyle.Fill;
                    //LBD_MedicalConsOuts.Dock = DockStyle.Fill;
                    LBD_MedicalConsIns.Columns[MCI_ConsumptionAmount.Name].HeaderText = LBD_MedicalConsIns.Columns[MCI_ConsumptionAmount.Name].HeaderText.Replace("xxx", (ibfYear - 2).ToString());
                    LBD_MedicalConsIns.Columns[MCI_LastIBFRequestAmount.Name].HeaderText = LBD_MedicalConsIns.Columns[MCI_LastIBFRequestAmount.Name].HeaderText.Replace("xxx", (ibfYear - 1).ToString());
                    LBD_MedicalConsOuts.Columns[MCO_ConsumptionAmount.Name].HeaderText = LBD_MedicalConsOuts.Columns[MCO_ConsumptionAmount.Name].HeaderText.Replace("xxx", (ibfYear - 2).ToString());
                    LBD_MedicalConsOuts.Columns[MCO_LastIBFRequestAmount.Name].HeaderText = LBD_MedicalConsOuts.Columns[MCO_LastIBFRequestAmount.Name].HeaderText.Replace("xxx", (ibfYear - 1).ToString());
                    if(_LBPurchaseProject.CurrentStateDefID.Value == LBPurchaseProject.States.Completed)
                    {
                        LBD_MedicalConsIns.Columns[MCI_ToOutList.Name].Visible = false;
                        LBD_MedicalConsOuts.Columns[MCO_ToInList.Name].Visible = false;
                    }
                    if(_LBPurchaseProject.CurrentStateDefID.Value != LBPurchaseProject.States.Analyse)
                    {
//                        LBD_MedicalConsIns.Columns[MCI_DetailsIn.Name].Visible = false;
//                        LBD_MedicalConsOuts.Columns[MCO_DetailsOut.Name].Visible = false;
                    }
                    break;
                    
                case IBFTypeEnum.YedekParca:
                    LBD_SpareIns.Visible = true;
                    LBD_SpareOuts.Visible = true;
                    //LBD_SpareIns.Dock = DockStyle.Fill;
                    //LBD_SpareOuts.Dock = DockStyle.Fill;
                    LBD_SpareIns.Columns[SPI_ConsumptionAmount.Name].HeaderText = LBD_SpareIns.Columns[SPI_ConsumptionAmount.Name].HeaderText.Replace("xxx", (ibfYear - 1).ToString());
                    LBD_SpareOuts.Columns[SPO_ConsumptionAmount.Name].HeaderText = LBD_SpareOuts.Columns[SPO_ConsumptionAmount.Name].HeaderText.Replace("xxx", (ibfYear - 1).ToString());
                    if(_LBPurchaseProject.CurrentStateDefID.Value == LBPurchaseProject.States.Completed)
                    {
                        LBD_SpareIns.Columns[SPI_ToOutList.Name].Visible = false;
                        LBD_SpareOuts.Columns[SPO_ToInList.Name].Visible = false;
                    }
                    if(_LBPurchaseProject.CurrentStateDefID.Value != LBPurchaseProject.States.Analyse)
                    {
//                        LBD_SpareIns.Columns[SPI_DetailsIn.Name].Visible = false;
//                        LBD_SpareOuts.Columns[SPO_DetailsOut.Name].Visible = false;
                    }
                    break;
                    
                default:
                    break;
            }
        }
        
#endregion LBBaseForm_Methods
    }
}