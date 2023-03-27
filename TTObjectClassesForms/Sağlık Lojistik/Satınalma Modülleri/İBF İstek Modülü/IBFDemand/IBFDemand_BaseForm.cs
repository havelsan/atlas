
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
    public partial class IBFDemand_BaseForm : TTForm
    {
        override protected void BindControlEvents()
        {
            MarketDrugsInGrid.CellContentClick += new TTGridCellEventDelegate(MarketDrugsInGrid_CellContentClick);
            MarketDrugsInGrid.CellValueChanged += new TTGridCellEventDelegate(MarketDrugsInGrid_CellValueChanged);
            VaccinesInGrid.CellValueChanged += new TTGridCellEventDelegate(VaccinesInGrid_CellValueChanged);
            VaccinesInGrid.CellContentClick += new TTGridCellEventDelegate(VaccinesInGrid_CellContentClick);
            SparePartsInGrid.CellValueChanged += new TTGridCellEventDelegate(SparePartsInGrid_CellValueChanged);
            SparePartsInGrid.CellContentClick += new TTGridCellEventDelegate(SparePartsInGrid_CellContentClick);
            SerumsInGrid.CellValueChanged += new TTGridCellEventDelegate(SerumsInGrid_CellValueChanged);
            SerumsInGrid.CellContentClick += new TTGridCellEventDelegate(SerumsInGrid_CellContentClick);
            PrintedDocumentsInGrid.CellValueChanged += new TTGridCellEventDelegate(PrintedDocumentsInGrid_CellValueChanged);
            PrintedDocumentsInGrid.CellContentClick += new TTGridCellEventDelegate(PrintedDocumentsInGrid_CellContentClick);
            MilitaryDrugsInGrid.CellContentClick += new TTGridCellEventDelegate(MilitaryDrugsInGrid_CellContentClick);
            MilitaryDrugsInGrid.CellValueChanged += new TTGridCellEventDelegate(MilitaryDrugsInGrid_CellValueChanged);
            MedicalEquipmentsInGrid.CellValueChanged += new TTGridCellEventDelegate(MedicalEquipmentsInGrid_CellValueChanged);
            MedicalEquipmentsInGrid.CellContentClick += new TTGridCellEventDelegate(MedicalEquipmentsInGrid_CellContentClick);
            MedicalConsumablesInGrid.CellValueChanged += new TTGridCellEventDelegate(MedicalConsumablesInGrid_CellValueChanged);
            MedicalConsumablesInGrid.CellContentClick += new TTGridCellEventDelegate(MedicalConsumablesInGrid_CellContentClick);
            KitsInGrid.CellValueChanged += new TTGridCellEventDelegate(KitsInGrid_CellValueChanged);
            KitsInGrid.CellContentClick += new TTGridCellEventDelegate(KitsInGrid_CellContentClick);
            XXXXXXDrugsInGrid.CellValueChanged += new TTGridCellEventDelegate(XXXXXXDrugsInGrid_CellValueChanged);
            XXXXXXDrugsInGrid.CellContentClick += new TTGridCellEventDelegate(XXXXXXDrugsInGrid_CellContentClick);
            MarketDrugsOutGrid.CellValueChanged += new TTGridCellEventDelegate(MarketDrugsOutGrid_CellValueChanged);
            VaccinesOutGrid.CellValueChanged += new TTGridCellEventDelegate(VaccinesOutGrid_CellValueChanged);
            KitsOutGrid.CellValueChanged += new TTGridCellEventDelegate(KitsOutGrid_CellValueChanged);
            XXXXXXDrugsOutGrid.CellValueChanged += new TTGridCellEventDelegate(XXXXXXDrugsOutGrid_CellValueChanged);
            MedicalConsumablesOutGrid.CellValueChanged += new TTGridCellEventDelegate(MedicalConsumablesOutGrid_CellValueChanged);
            SparePartsOutGrid.CellValueChanged += new TTGridCellEventDelegate(SparePartsOutGrid_CellValueChanged);
            MedicalEquipmentsOutGrid.CellValueChanged += new TTGridCellEventDelegate(MedicalEquipmentsOutGrid_CellValueChanged);
            SerumsOutGrid.CellValueChanged += new TTGridCellEventDelegate(SerumsOutGrid_CellValueChanged);
            MilitaryDrugsOutGrid.CellValueChanged += new TTGridCellEventDelegate(MilitaryDrugsOutGrid_CellValueChanged);
            PrintedDocumentsOutGrid.CellValueChanged += new TTGridCellEventDelegate(PrintedDocumentsOutGrid_CellValueChanged);
            Print.ItemClicked += new TTToolStripItemClicked(Print_ItemClicked);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            MarketDrugsInGrid.CellContentClick -= new TTGridCellEventDelegate(MarketDrugsInGrid_CellContentClick);
            MarketDrugsInGrid.CellValueChanged -= new TTGridCellEventDelegate(MarketDrugsInGrid_CellValueChanged);
            VaccinesInGrid.CellValueChanged -= new TTGridCellEventDelegate(VaccinesInGrid_CellValueChanged);
            VaccinesInGrid.CellContentClick -= new TTGridCellEventDelegate(VaccinesInGrid_CellContentClick);
            SparePartsInGrid.CellValueChanged -= new TTGridCellEventDelegate(SparePartsInGrid_CellValueChanged);
            SparePartsInGrid.CellContentClick -= new TTGridCellEventDelegate(SparePartsInGrid_CellContentClick);
            SerumsInGrid.CellValueChanged -= new TTGridCellEventDelegate(SerumsInGrid_CellValueChanged);
            SerumsInGrid.CellContentClick -= new TTGridCellEventDelegate(SerumsInGrid_CellContentClick);
            PrintedDocumentsInGrid.CellValueChanged -= new TTGridCellEventDelegate(PrintedDocumentsInGrid_CellValueChanged);
            PrintedDocumentsInGrid.CellContentClick -= new TTGridCellEventDelegate(PrintedDocumentsInGrid_CellContentClick);
            MilitaryDrugsInGrid.CellContentClick -= new TTGridCellEventDelegate(MilitaryDrugsInGrid_CellContentClick);
            MilitaryDrugsInGrid.CellValueChanged -= new TTGridCellEventDelegate(MilitaryDrugsInGrid_CellValueChanged);
            MedicalEquipmentsInGrid.CellValueChanged -= new TTGridCellEventDelegate(MedicalEquipmentsInGrid_CellValueChanged);
            MedicalEquipmentsInGrid.CellContentClick -= new TTGridCellEventDelegate(MedicalEquipmentsInGrid_CellContentClick);
            MedicalConsumablesInGrid.CellValueChanged -= new TTGridCellEventDelegate(MedicalConsumablesInGrid_CellValueChanged);
            MedicalConsumablesInGrid.CellContentClick -= new TTGridCellEventDelegate(MedicalConsumablesInGrid_CellContentClick);
            KitsInGrid.CellValueChanged -= new TTGridCellEventDelegate(KitsInGrid_CellValueChanged);
            KitsInGrid.CellContentClick -= new TTGridCellEventDelegate(KitsInGrid_CellContentClick);
            XXXXXXDrugsInGrid.CellValueChanged -= new TTGridCellEventDelegate(XXXXXXDrugsInGrid_CellValueChanged);
            XXXXXXDrugsInGrid.CellContentClick -= new TTGridCellEventDelegate(XXXXXXDrugsInGrid_CellContentClick);
            MarketDrugsOutGrid.CellValueChanged -= new TTGridCellEventDelegate(MarketDrugsOutGrid_CellValueChanged);
            VaccinesOutGrid.CellValueChanged -= new TTGridCellEventDelegate(VaccinesOutGrid_CellValueChanged);
            KitsOutGrid.CellValueChanged -= new TTGridCellEventDelegate(KitsOutGrid_CellValueChanged);
            XXXXXXDrugsOutGrid.CellValueChanged -= new TTGridCellEventDelegate(XXXXXXDrugsOutGrid_CellValueChanged);
            MedicalConsumablesOutGrid.CellValueChanged -= new TTGridCellEventDelegate(MedicalConsumablesOutGrid_CellValueChanged);
            SparePartsOutGrid.CellValueChanged -= new TTGridCellEventDelegate(SparePartsOutGrid_CellValueChanged);
            MedicalEquipmentsOutGrid.CellValueChanged -= new TTGridCellEventDelegate(MedicalEquipmentsOutGrid_CellValueChanged);
            SerumsOutGrid.CellValueChanged -= new TTGridCellEventDelegate(SerumsOutGrid_CellValueChanged);
            MilitaryDrugsOutGrid.CellValueChanged -= new TTGridCellEventDelegate(MilitaryDrugsOutGrid_CellValueChanged);
            PrintedDocumentsOutGrid.CellValueChanged -= new TTGridCellEventDelegate(PrintedDocumentsOutGrid_CellValueChanged);
            Print.ItemClicked -= new TTToolStripItemClicked(Print_ItemClicked);
            base.UnBindControlEvents();
        }

        private void MarketDrugsInGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region IBFDemand_BaseForm_MarketDrugsInGrid_CellContentClick
   //            if(MarketDrugsInGrid.CurrentCell == null)
//                return;
//            
//            if(MarketDrugsInGrid.CurrentCell.Value == null)
//                return;
//            
//            if (MarketDrugsInGrid.CurrentCell.OwningColumn == MarketDrugsInGrid.Columns[MDI_SPECIFICATIONDEFINITIONNO.Name])
//            {
//                string filtre = "NO = '" + MarketDrugsInGrid.CurrentCell.Value + "'";
//                TTListDef listDef = TTObjectDefManager.Instance.ListDefs["SDDefinitionFormList"];
//                TTDefinitionForm frm = TTDefinitionForm.GetEditForm(listDef, filtre);
//                frm.ShowReadOnly(this.FindForm(), listDef);
//            }
#endregion IBFDemand_BaseForm_MarketDrugsInGrid_CellContentClick
        }

        private void MarketDrugsInGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region IBFDemand_BaseForm_MarketDrugsInGrid_CellValueChanged
   if(MarketDrugsInGrid.CurrentCell == null)
                return;
            
            if(MarketDrugsInGrid.CurrentCell.Value == null)
                return;
            
            if (MarketDrugsInGrid.CurrentCell.OwningColumn == MarketDrugsInGrid.Columns[MDI_PURCHASEITEMDEF.Name] && columnIndex == MDI_PURCHASEITEMDEF.Index)
            {
                IBFBaseDemandDetail ibfdb = (IBFBaseDemandDetail)MarketDrugsInGrid.CurrentCell.OwningRow.TTObject;
                if(ibfdb.PurchaseItemDef != null && ibfdb.OrderNo == null)
                {
                    ibfdb.OrderNo = MarketDrugsInGrid.CurrentCell.OwningRow.Index + 1;
                }
            }
#endregion IBFDemand_BaseForm_MarketDrugsInGrid_CellValueChanged
        }

        private void VaccinesInGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region IBFDemand_BaseForm_VaccinesInGrid_CellValueChanged
   if(VaccinesInGrid.CurrentCell == null)
                return;
            
            if(VaccinesInGrid.CurrentCell.Value == null)
                return;
            
            if (VaccinesInGrid.CurrentCell.OwningColumn == VaccinesInGrid.Columns[VI_PURCHASEITEMDEF.Name] && columnIndex == VI_PURCHASEITEMDEF.Index)
            {
                IBFBaseDemandDetail ibfdb = (IBFBaseDemandDetail)VaccinesInGrid.CurrentCell.OwningRow.TTObject;
                if(ibfdb.PurchaseItemDef != null && ibfdb.OrderNo == null)
                {
                    ibfdb.OrderNo = VaccinesInGrid.CurrentCell.OwningRow.Index + 1;
                }
            }
#endregion IBFDemand_BaseForm_VaccinesInGrid_CellValueChanged
        }

        private void VaccinesInGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region IBFDemand_BaseForm_VaccinesInGrid_CellContentClick
   //            if(VaccinesInGrid.CurrentCell == null)
//                return;
//            
//            if(VaccinesInGrid.CurrentCell.Value == null)
//                return;
//            
//            if (VaccinesInGrid.CurrentCell.OwningColumn == VaccinesInGrid.Columns[VI_SPECIFICATIONDEFINITIONNO.Name])
//            {
//                string filtre = "NO = '" + VaccinesInGrid.CurrentCell.Value + "'";
//                TTListDef listDef = TTObjectDefManager.Instance.ListDefs["SDDefinitionFormList"];
//                TTDefinitionForm frm = TTDefinitionForm.GetEditForm(listDef, filtre);
//                frm.ShowReadOnly(this.FindForm(), listDef, null);
//            }
#endregion IBFDemand_BaseForm_VaccinesInGrid_CellContentClick
        }

        private void SparePartsInGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region IBFDemand_BaseForm_SparePartsInGrid_CellValueChanged
   if(SparePartsInGrid.CurrentCell == null)
                return;
            
            if(SparePartsInGrid.CurrentCell.Value == null)
                return;
            
            if (SparePartsInGrid.CurrentCell.OwningColumn == SparePartsInGrid.Columns[SPI_PURCHASEITEMDEF.Name] && columnIndex == SPI_PURCHASEITEMDEF.Index)
            {
                IBFBaseDemandDetail ibfdb = (IBFBaseDemandDetail)SparePartsInGrid.CurrentCell.OwningRow.TTObject;
                if(ibfdb.PurchaseItemDef != null && ibfdb.OrderNo == null)
                {
                    ibfdb.OrderNo = SparePartsInGrid.CurrentCell.OwningRow.Index + 1;
                }
            }
#endregion IBFDemand_BaseForm_SparePartsInGrid_CellValueChanged
        }

        private void SparePartsInGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region IBFDemand_BaseForm_SparePartsInGrid_CellContentClick
   //            if(SparePartsInGrid.CurrentCell == null)
//                return;
//            
//            if(SparePartsInGrid.CurrentCell.Value == null)
//                return;
//            
//            if (SparePartsInGrid.CurrentCell.OwningColumn == SparePartsInGrid.Columns[SPI_SPECIFICATIONDEFINITIONNO.Name])
//            {
//                string filtre = "NO = '" + SparePartsInGrid.CurrentCell.Value + "'";
//                TTListDef listDef = TTObjectDefManager.Instance.ListDefs["SDDefinitionFormList"];
//                TTDefinitionForm frm = TTDefinitionForm.GetEditForm(listDef, filtre);
//                frm.ShowReadOnly(this.FindForm(), listDef, null);
//            }
#endregion IBFDemand_BaseForm_SparePartsInGrid_CellContentClick
        }

        private void SerumsInGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region IBFDemand_BaseForm_SerumsInGrid_CellValueChanged
   if(SerumsInGrid.CurrentCell == null)
                return;
            
            if(SerumsInGrid.CurrentCell.Value == null)
                return;
            
            if (SerumsInGrid.CurrentCell.OwningColumn == SerumsInGrid.Columns[SI_PURCHASEITEMDEF.Name] && columnIndex == SI_PURCHASEITEMDEF.Index)
            {
                IBFBaseDemandDetail ibfdb = (IBFBaseDemandDetail)SerumsInGrid.CurrentCell.OwningRow.TTObject;
                if(ibfdb.PurchaseItemDef != null && ibfdb.OrderNo == null)
                {
                    ibfdb.OrderNo = SerumsInGrid.CurrentCell.OwningRow.Index + 1;
                }
            }
#endregion IBFDemand_BaseForm_SerumsInGrid_CellValueChanged
        }

        private void SerumsInGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region IBFDemand_BaseForm_SerumsInGrid_CellContentClick
   //            if(SerumsInGrid.CurrentCell == null)
//                return;
//            
//            if(SerumsInGrid.CurrentCell.Value == null)
//                return;
//            
//            if (SerumsInGrid.CurrentCell.OwningColumn == SerumsInGrid.Columns[SI_SPECIFICATIONDEFINITIONNO.Name])
//            {
//                string filtre = "NO = '" + SerumsInGrid.CurrentCell.Value + "'";
//                TTListDef listDef = TTObjectDefManager.Instance.ListDefs["SDDefinitionFormList"];
//                TTDefinitionForm frm = TTDefinitionForm.GetEditForm(listDef, filtre);
//                frm.ShowReadOnly(this.FindForm(), listDef, null);
//            }
#endregion IBFDemand_BaseForm_SerumsInGrid_CellContentClick
        }

        private void PrintedDocumentsInGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region IBFDemand_BaseForm_PrintedDocumentsInGrid_CellValueChanged
   if(PrintedDocumentsInGrid.CurrentCell == null)
                return;
            
            if(PrintedDocumentsInGrid.CurrentCell.Value == null)
                return;
            
            if (PrintedDocumentsInGrid.CurrentCell.OwningColumn == PrintedDocumentsInGrid.Columns[PDI_PURCHASEITEMDEF.Name] && columnIndex == PDI_PURCHASEITEMDEF.Index)
            {
                IBFBaseDemandDetail ibfdb = (IBFBaseDemandDetail)PrintedDocumentsInGrid.CurrentCell.OwningRow.TTObject;
                if(ibfdb.PurchaseItemDef != null && ibfdb.OrderNo == null)
                {
                    ibfdb.OrderNo = PrintedDocumentsInGrid.CurrentCell.OwningRow.Index + 1;
                }
            }
#endregion IBFDemand_BaseForm_PrintedDocumentsInGrid_CellValueChanged
        }

        private void PrintedDocumentsInGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region IBFDemand_BaseForm_PrintedDocumentsInGrid_CellContentClick
   //            if(PrintedDocumentsInGrid.CurrentCell == null)
//                return;
//            
//            if(PrintedDocumentsInGrid.CurrentCell.Value == null)
//                return;
//            
//            if (PrintedDocumentsInGrid.CurrentCell.OwningColumn == PrintedDocumentsInGrid.Columns[PDI_SPECIFICATIONDEFINITIONNO.Name])
//            {
//                string filtre = "NO = '" + PrintedDocumentsInGrid.CurrentCell.Value + "'";
//                TTListDef listDef = TTObjectDefManager.Instance.ListDefs["SDDefinitionFormList"];
//                TTDefinitionForm frm = TTDefinitionForm.GetEditForm(listDef, filtre);
//                frm.ShowReadOnly(this.FindForm(), listDef, null);
//            }
#endregion IBFDemand_BaseForm_PrintedDocumentsInGrid_CellContentClick
        }

        private void MilitaryDrugsInGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region IBFDemand_BaseForm_MilitaryDrugsInGrid_CellContentClick
   //            if(MilitaryDrugsInGrid.CurrentCell == null)
//                return;
//            
//            if(MilitaryDrugsInGrid.CurrentCell.Value == null)
//                return;
//            
//            if (MilitaryDrugsInGrid.CurrentCell.OwningColumn == MilitaryDrugsInGrid.Columns[MIDI_SPECIFICATIONDEFINITIONNO.Name])
//            {
//                string filtre = "NO = '" + MilitaryDrugsInGrid.CurrentCell.Value + "'";
//                TTListDef listDef = TTObjectDefManager.Instance.ListDefs["SDDefinitionFormList"];
//                TTDefinitionForm frm = TTDefinitionForm.GetEditForm(listDef, filtre);
//                frm.ShowReadOnly(this.FindForm(), listDef, null);
//            }
#endregion IBFDemand_BaseForm_MilitaryDrugsInGrid_CellContentClick
        }

        private void MilitaryDrugsInGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region IBFDemand_BaseForm_MilitaryDrugsInGrid_CellValueChanged
   if(MilitaryDrugsInGrid.CurrentCell == null)
                return;
            
            if(MilitaryDrugsInGrid.CurrentCell.Value == null)
                return;
            
            if (MilitaryDrugsInGrid.CurrentCell.OwningColumn == MilitaryDrugsInGrid.Columns[MIDI_PURCHASEITEMDEF.Name] && columnIndex == MIDI_PURCHASEITEMDEF.Index)
            {
                IBFBaseDemandDetail ibfdb = (IBFBaseDemandDetail)MilitaryDrugsInGrid.CurrentCell.OwningRow.TTObject;
                if(ibfdb.PurchaseItemDef != null && ibfdb.OrderNo == null)
                {
                    ibfdb.OrderNo = MilitaryDrugsInGrid.CurrentCell.OwningRow.Index + 1;
                }
            }
#endregion IBFDemand_BaseForm_MilitaryDrugsInGrid_CellValueChanged
        }

        private void MedicalEquipmentsInGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region IBFDemand_BaseForm_MedicalEquipmentsInGrid_CellValueChanged
   if(MedicalEquipmentsInGrid.CurrentCell == null)
                return;
            
            if(MedicalEquipmentsInGrid.CurrentCell.Value == null)
                return;
            
            if (MedicalEquipmentsInGrid.CurrentCell.OwningColumn == MedicalEquipmentsInGrid.Columns[MEI_PURCHASEITEMDEF.Name] && columnIndex == MEI_PURCHASEITEMDEF.Index)
            {
                IBFBaseDemandDetail ibfdb = (IBFBaseDemandDetail)MedicalEquipmentsInGrid.CurrentCell.OwningRow.TTObject;
                if(ibfdb.PurchaseItemDef != null && ibfdb.OrderNo == null)
                {
                    ibfdb.OrderNo = MedicalEquipmentsInGrid.CurrentCell.OwningRow.Index + 1;
                }
            }
#endregion IBFDemand_BaseForm_MedicalEquipmentsInGrid_CellValueChanged
        }

        private void MedicalEquipmentsInGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region IBFDemand_BaseForm_MedicalEquipmentsInGrid_CellContentClick
   //            if(MedicalEquipmentsInGrid.CurrentCell == null)
//                return;
//            
//            if(MedicalEquipmentsInGrid.CurrentCell.Value == null)
//                return;
//            
//            if (MedicalEquipmentsInGrid.CurrentCell.OwningColumn == MedicalEquipmentsInGrid.Columns[MEI_SPECIFICATIONDEFINITIONNO.Name])
//            {
//                string filtre = "NO = '" + MedicalEquipmentsInGrid.CurrentCell.Value + "'";
//                TTListDef listDef = TTObjectDefManager.Instance.ListDefs["SDDefinitionFormList"];
//                TTDefinitionForm frm = TTDefinitionForm.GetEditForm(listDef, filtre);
//                frm.ShowReadOnly(this.FindForm(), listDef, null);
//            }
#endregion IBFDemand_BaseForm_MedicalEquipmentsInGrid_CellContentClick
        }

        private void MedicalConsumablesInGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region IBFDemand_BaseForm_MedicalConsumablesInGrid_CellValueChanged
   if(MedicalConsumablesInGrid.CurrentCell == null)
                return;
            
            if(MedicalConsumablesInGrid.CurrentCell.Value == null)
                return;
            
            if (MedicalConsumablesInGrid.CurrentCell.OwningColumn == MedicalConsumablesInGrid.Columns[MCI_PURCHASEITEMDEF.Name] && columnIndex == MCI_PURCHASEITEMDEF.Index)
            {
                IBFBaseDemandDetail ibfdb = (IBFBaseDemandDetail)MedicalConsumablesInGrid.CurrentCell.OwningRow.TTObject;
                if(ibfdb.PurchaseItemDef != null && ibfdb.OrderNo == null)
                {
                    ibfdb.OrderNo = MedicalConsumablesInGrid.CurrentCell.OwningRow.Index + 1;
                }
            }
#endregion IBFDemand_BaseForm_MedicalConsumablesInGrid_CellValueChanged
        }

        private void MedicalConsumablesInGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region IBFDemand_BaseForm_MedicalConsumablesInGrid_CellContentClick
   //            if(MedicalConsumablesInGrid.CurrentCell == null)
//                return;
//            
//            if(MedicalConsumablesInGrid.CurrentCell.Value == null)
//                return;
//            
//            if (MedicalConsumablesInGrid.CurrentCell.OwningColumn == MedicalConsumablesInGrid.Columns[MCI_SPECIFICATIONDEFINITIONNO.Name])
//            {
//                string filtre = "NO = '" + MedicalConsumablesInGrid.CurrentCell.Value + "'";
//                TTListDef listDef = TTObjectDefManager.Instance.ListDefs["SDDefinitionFormList"];
//                TTDefinitionForm frm = TTDefinitionForm.GetEditForm(listDef, filtre);
//                frm.ShowReadOnly(this.FindForm(), listDef, null);
//            }
#endregion IBFDemand_BaseForm_MedicalConsumablesInGrid_CellContentClick
        }

        private void KitsInGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region IBFDemand_BaseForm_KitsInGrid_CellValueChanged
   if(KitsInGrid.CurrentCell == null)
                return;
            
            if(KitsInGrid.CurrentCell.Value == null)
                return;
            
            if (KitsInGrid.CurrentCell.OwningColumn == KitsInGrid.Columns[KTI_PURCHASEITEMDEF.Name] && columnIndex == KTI_PURCHASEITEMDEF.Index)
            {
                IBFBaseDemandDetail ibfdb = (IBFBaseDemandDetail)KitsInGrid.CurrentCell.OwningRow.TTObject;
                if(ibfdb.PurchaseItemDef != null && ibfdb.OrderNo == null)
                {
                    ibfdb.OrderNo = KitsInGrid.CurrentCell.OwningRow.Index + 1;
                }
            }
#endregion IBFDemand_BaseForm_KitsInGrid_CellValueChanged
        }

        private void KitsInGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region IBFDemand_BaseForm_KitsInGrid_CellContentClick
   //            if(KitsInGrid.CurrentCell == null)
//                return;
//            
//            if(KitsInGrid.CurrentCell.Value == null)
//                return;
//            
//            if (KitsInGrid.CurrentCell.OwningColumn == KitsInGrid.Columns[KTI_SPECIFICATIONDEFINITIONNO.Name])
//            {
//                string filtre = "NO = '" + KitsInGrid.CurrentCell.Value + "'";
//                TTListDef listDef = TTObjectDefManager.Instance.ListDefs["SDDefinitionFormList"];
//                TTDefinitionForm frm = TTDefinitionForm.GetEditForm(listDef, filtre);
//                frm.ShowReadOnly(this.FindForm(), listDef, null);
//            }
#endregion IBFDemand_BaseForm_KitsInGrid_CellContentClick
        }

        private void XXXXXXDrugsInGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region IBFDemand_BaseForm_XXXXXXDrugsInGrid_CellValueChanged
   if(XXXXXXDrugsInGrid.CurrentCell == null)
                return;
            
            if(XXXXXXDrugsInGrid.CurrentCell.Value == null)
                return;
            
            if (XXXXXXDrugsInGrid.CurrentCell.OwningColumn == XXXXXXDrugsInGrid.Columns[GDI_PURCHASEITEMDEF.Name] && columnIndex == GDI_PURCHASEITEMDEF.Index)
            {
                IBFBaseDemandDetail ibfdb = (IBFBaseDemandDetail)XXXXXXDrugsInGrid.CurrentCell.OwningRow.TTObject;
                if(ibfdb.PurchaseItemDef != null && ibfdb.OrderNo == null)
                {
                    ibfdb.OrderNo = XXXXXXDrugsInGrid.CurrentCell.OwningRow.Index + 1;
                }
            }
#endregion IBFDemand_BaseForm_XXXXXXDrugsInGrid_CellValueChanged
        }

        private void XXXXXXDrugsInGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region IBFDemand_BaseForm_XXXXXXDrugsInGrid_CellContentClick
   //            if(XXXXXXDrugsInGrid.CurrentCell == null)
//                return;
//            
//            if(XXXXXXDrugsInGrid.CurrentCell.Value == null)
//                return;
//            
//            if (XXXXXXDrugsInGrid.CurrentCell.OwningColumn == XXXXXXDrugsInGrid.Columns[GDI_SPECIFICATIONDEFINITIONNO.Name])
//            {
//                string filtre = "NO = '" + XXXXXXDrugsInGrid.CurrentCell.Value + "'";
//                TTListDef listDef = TTObjectDefManager.Instance.ListDefs["SDDefinitionFormList"];
//                TTDefinitionForm frm = TTDefinitionForm.GetEditForm(listDef, filtre);
//                frm.ShowReadOnly(this.FindForm(), listDef, null);
//            }
#endregion IBFDemand_BaseForm_XXXXXXDrugsInGrid_CellContentClick
        }

        private void MarketDrugsOutGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region IBFDemand_BaseForm_MarketDrugsOutGrid_CellValueChanged
   if(MarketDrugsOutGrid.CurrentCell == null)
                return;
            
            if (columnIndex == MDO_PURCHASEITEMDEF.Index)
            {
                ITTGridRow row = MarketDrugsOutGrid.Rows[rowIndex];
                Guid guid = new Guid(row.Cells[MDO_PURCHASEITEMDEF.Index].Value.ToString());
                PurchaseItemDef pi = (PurchaseItemDef)_IBFDemand.ObjectContext.GetObject(guid, "PURCHASEITEMDEF");
                row.Cells[MDO_NSN.Name].Value = pi.GetNSN();
                
                IBFBaseDemandDetail ibfdb = (IBFBaseDemandDetail)row.TTObject;
                if(ibfdb.PurchaseItemDef != null && ibfdb.OrderNo == null)
                {
                    ibfdb.OrderNo = rowIndex + 1;
                }
            }
#endregion IBFDemand_BaseForm_MarketDrugsOutGrid_CellValueChanged
        }

        private void VaccinesOutGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region IBFDemand_BaseForm_VaccinesOutGrid_CellValueChanged
   if(VaccinesOutGrid.CurrentCell == null)
                return;
            
            if (columnIndex == VO_PURCHASEITEMDEF.Index)
            {
                ITTGridRow row = VaccinesOutGrid.Rows[rowIndex];
                Guid guid = new Guid(row.Cells[VO_PURCHASEITEMDEF.Index].Value.ToString());
                PurchaseItemDef pi = (PurchaseItemDef)_IBFDemand.ObjectContext.GetObject(guid, "PURCHASEITEMDEF");
                row.Cells[VO_NSN.Name].Value = pi.GetNSN();
                IBFBaseDemandDetail ibfdb = (IBFBaseDemandDetail)row.TTObject;
                if(ibfdb.PurchaseItemDef != null && ibfdb.OrderNo == null)
                {
                    ibfdb.OrderNo = rowIndex + 1;
                }
            }
#endregion IBFDemand_BaseForm_VaccinesOutGrid_CellValueChanged
        }

        private void KitsOutGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region IBFDemand_BaseForm_KitsOutGrid_CellValueChanged
   if(KitsOutGrid.CurrentCell == null)
                return;
            
            if (columnIndex == KTO_PURCHASEITEMDEF.Index)
            {
                ITTGridRow row = KitsOutGrid.Rows[rowIndex];
                Guid guid = new Guid(row.Cells[KTO_PURCHASEITEMDEF.Index].Value.ToString());
                PurchaseItemDef pi = (PurchaseItemDef)_IBFDemand.ObjectContext.GetObject(guid, "PURCHASEITEMDEF");
                row.Cells[KTO_NSN.Name].Value = pi.GetNSN();
                IBFBaseDemandDetail ibfdb = (IBFBaseDemandDetail)row.TTObject;
                if(ibfdb.PurchaseItemDef != null && ibfdb.OrderNo == null)
                {
                    ibfdb.OrderNo = rowIndex + 1;
                }
            }
#endregion IBFDemand_BaseForm_KitsOutGrid_CellValueChanged
        }

        private void XXXXXXDrugsOutGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region IBFDemand_BaseForm_XXXXXXDrugsOutGrid_CellValueChanged
   if(XXXXXXDrugsOutGrid.CurrentCell == null)
                return;
            
            if (columnIndex == GDO_PURCHASEITEMDEF.Index)
            {
                ITTGridRow row = XXXXXXDrugsOutGrid.Rows[rowIndex];
                Guid guid = new Guid(row.Cells[GDO_PURCHASEITEMDEF.Index].Value.ToString());
                PurchaseItemDef pi = (PurchaseItemDef)_IBFDemand.ObjectContext.GetObject(guid, "PURCHASEITEMDEF");
                row.Cells[GDO_NSN.Name].Value = pi.GetNSN();
                IBFBaseDemandDetail ibfdb = (IBFBaseDemandDetail)row.TTObject;
                if(ibfdb.PurchaseItemDef != null && ibfdb.OrderNo == null)
                {
                    ibfdb.OrderNo = rowIndex + 1;
                }
            }
#endregion IBFDemand_BaseForm_XXXXXXDrugsOutGrid_CellValueChanged
        }

        private void MedicalConsumablesOutGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region IBFDemand_BaseForm_MedicalConsumablesOutGrid_CellValueChanged
   if(MedicalConsumablesOutGrid.CurrentCell == null)
                return;
            
            if (columnIndex == MCO_PURCHASEITEMDEF.Index)
            {
                ITTGridRow row = MedicalConsumablesOutGrid.Rows[rowIndex];
                Guid guid = new Guid(row.Cells[MCO_PURCHASEITEMDEF.Index].Value.ToString());
                PurchaseItemDef pi = (PurchaseItemDef)_IBFDemand.ObjectContext.GetObject(guid, "PURCHASEITEMDEF");
                row.Cells[MCO_NSN.Name].Value = pi.GetNSN();
                IBFBaseDemandDetail ibfdb = (IBFBaseDemandDetail)row.TTObject;
                if(ibfdb.PurchaseItemDef != null && ibfdb.OrderNo == null)
                {
                    ibfdb.OrderNo = rowIndex + 1;
                }
            }
#endregion IBFDemand_BaseForm_MedicalConsumablesOutGrid_CellValueChanged
        }

        private void SparePartsOutGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region IBFDemand_BaseForm_SparePartsOutGrid_CellValueChanged
   if(SparePartsOutGrid.CurrentCell == null)
                return;
            
            if (columnIndex == SPO_PURCHASEITEMDEF.Index)
            {
                ITTGridRow row = SparePartsOutGrid.Rows[rowIndex];
                Guid guid = new Guid(row.Cells[SPO_PURCHASEITEMDEF.Index].Value.ToString());
                PurchaseItemDef pi = (PurchaseItemDef)_IBFDemand.ObjectContext.GetObject(guid, "PURCHASEITEMDEF");
                row.Cells[SPO_NSN.Name].Value = pi.GetNSN();
                IBFBaseDemandDetail ibfdb = (IBFBaseDemandDetail)row.TTObject;
                if(ibfdb.PurchaseItemDef != null && ibfdb.OrderNo == null)
                {
                    ibfdb.OrderNo = rowIndex + 1;
                }
            }
#endregion IBFDemand_BaseForm_SparePartsOutGrid_CellValueChanged
        }

        private void MedicalEquipmentsOutGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region IBFDemand_BaseForm_MedicalEquipmentsOutGrid_CellValueChanged
   if(MedicalEquipmentsOutGrid.CurrentCell == null)
                return;
            
            if (columnIndex == MEO_PURCHASEITEMDEF.Index)
            {
                ITTGridRow row = MedicalEquipmentsOutGrid.Rows[rowIndex];
                Guid guid = new Guid(row.Cells[MEO_PURCHASEITEMDEF.Index].Value.ToString());
                PurchaseItemDef pi = (PurchaseItemDef)_IBFDemand.ObjectContext.GetObject(guid, "PURCHASEITEMDEF");
                row.Cells[MEO_NSN.Name].Value = pi.GetNSN();
                IBFBaseDemandDetail ibfdb = (IBFBaseDemandDetail)row.TTObject;
                if(ibfdb.PurchaseItemDef != null && ibfdb.OrderNo == null)
                {
                    ibfdb.OrderNo = rowIndex + 1;
                }
            }
#endregion IBFDemand_BaseForm_MedicalEquipmentsOutGrid_CellValueChanged
        }

        private void SerumsOutGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region IBFDemand_BaseForm_SerumsOutGrid_CellValueChanged
   if(SerumsOutGrid.CurrentCell == null)
                return;
            
            if (columnIndex == SO_PURCHASEITEMDEF.Index)
            {
                ITTGridRow row = SerumsOutGrid.Rows[rowIndex];
                Guid guid = new Guid(row.Cells[SO_PURCHASEITEMDEF.Index].Value.ToString());
                PurchaseItemDef pi = (PurchaseItemDef)_IBFDemand.ObjectContext.GetObject(guid, "PURCHASEITEMDEF");
                row.Cells[SO_NSN.Name].Value = pi.GetNSN();
                IBFBaseDemandDetail ibfdb = (IBFBaseDemandDetail)row.TTObject;
                if(ibfdb.PurchaseItemDef != null && ibfdb.OrderNo == null)
                {
                    ibfdb.OrderNo = rowIndex + 1;
                }
            }
#endregion IBFDemand_BaseForm_SerumsOutGrid_CellValueChanged
        }

        private void MilitaryDrugsOutGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region IBFDemand_BaseForm_MilitaryDrugsOutGrid_CellValueChanged
   if(MilitaryDrugsOutGrid.CurrentCell == null)
                return;
            
            if (columnIndex == MIDO_PURCHASEITEMDEF.Index)
            {
                ITTGridRow row = MilitaryDrugsOutGrid.Rows[rowIndex];
                Guid guid = new Guid(row.Cells[MIDO_PURCHASEITEMDEF.Index].Value.ToString());
                PurchaseItemDef pi = (PurchaseItemDef)_IBFDemand.ObjectContext.GetObject(guid, "PURCHASEITEMDEF");
                row.Cells[MIDO_NSN.Name].Value = pi.GetNSN();
                IBFBaseDemandDetail ibfdb = (IBFBaseDemandDetail)row.TTObject;
                if(ibfdb.PurchaseItemDef != null && ibfdb.OrderNo == null)
                {
                    ibfdb.OrderNo = rowIndex + 1;
                }
            }
#endregion IBFDemand_BaseForm_MilitaryDrugsOutGrid_CellValueChanged
        }

        private void PrintedDocumentsOutGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region IBFDemand_BaseForm_PrintedDocumentsOutGrid_CellValueChanged
   if(PrintedDocumentsOutGrid.CurrentCell == null)
                return;
            
            if (columnIndex == PDO_PURCHASEITEMDEF.Index)
            {
                ITTGridRow row = PrintedDocumentsOutGrid.Rows[rowIndex];
                Guid guid = new Guid(row.Cells[PDO_PURCHASEITEMDEF.Index].Value.ToString());
                PurchaseItemDef pi = (PurchaseItemDef)_IBFDemand.ObjectContext.GetObject(guid, "PURCHASEITEMDEF");
                row.Cells[PDO_NSN.Name].Value = pi.GetNSN();
                IBFBaseDemandDetail ibfdb = (IBFBaseDemandDetail)row.TTObject;
                if(ibfdb.PurchaseItemDef != null && ibfdb.OrderNo == null)
                {
                    ibfdb.OrderNo = rowIndex + 1;
                }
            }
#endregion IBFDemand_BaseForm_PrintedDocumentsOutGrid_CellValueChanged
        }

        private void Print_ItemClicked(ITTToolStripItem item)
        {
#region IBFDemand_BaseForm_Print_ItemClicked
   Dictionary<string, TTReportTool.PropertyCache<object>> parameter = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
            objectID.Add("VALUE", _IBFDemand.ObjectID.ToString());
            parameter.Add("TTOBJECTID", objectID);
            
            if(item.Name == "IBFReport")
            {
                switch (_IBFDemand.IBFType)
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
                if(_IBFDemand.IBFDetDetailOuts.Count > 0)
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_EkliListeReport), true, 1, parameter);
                else
                    InfoBox.Show("Ekli liste boş olduğundan dolayı raporu basılamaz.");
            }
#endregion IBFDemand_BaseForm_Print_ItemClicked
        }

        protected override void PreScript()
        {
#region IBFDemand_BaseForm_PreScript
    base.PreScript();
            
            ShowNeededGrids();
            
            if(_IBFDemand.CurrentStateDefID == IBFDemand.States.New)
                this.Print.Visible = false;            
            
            if(_IBFDemand.CurrentStateDefID == IBFDemand.States.Completed)
                this.Print.Enabled = true;
#endregion IBFDemand_BaseForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region IBFDemand_BaseForm_PostScript
    base.PostScript(transDef);
            
            if(_IBFDemand.TransDef != null)
            {
                bool haveDetail = _IBFDemand.HaveDetails();
                if(!haveDetail)
                    throw new TTUtils.TTException("Detaysız işlem devam ettirilemez");
                
                string nulls = _IBFDemand.NullAmounts();
                
                if(string.IsNullOrEmpty(nulls) == false)
                    throw new TTUtils.TTException("Onaylanan miktar boş olamaz.\n\n" + nulls);
            }
#endregion IBFDemand_BaseForm_PostScript

            }
            
#region IBFDemand_BaseForm_Methods
        public void ClearChildrenCollections()
        {
            _IBFDemand.IBFDet_MarketDrugIns.DeleteChildren();
            _IBFDemand.IBFDet_MarketDrugOuts.DeleteChildren();
            _IBFDemand.IBFDet_MilitaryDrugIns.DeleteChildren();
            _IBFDemand.IBFDet_MilitaryDrugOuts.DeleteChildren();
            _IBFDemand.IBFDet_XXXXXXDrugIns.DeleteChildren();
            _IBFDemand.IBFDet_XXXXXXDrugOuts.DeleteChildren();
            _IBFDemand.IBFDet_MedicalEquipmentIns .DeleteChildren();
            _IBFDemand.IBFDet_MedicalEquipmentOuts.DeleteChildren();
            _IBFDemand.IBFDet_MedicalConsIns.DeleteChildren();
            _IBFDemand.IBFDet_MedicalConsOuts.DeleteChildren();
            _IBFDemand.IBFDet_SparePartIns.DeleteChildren();
            _IBFDemand.IBFDet_SparePartOuts.DeleteChildren();
            _IBFDemand.IBFDet_SerumIns.DeleteChildren();
            _IBFDemand.IBFDet_SerumOuts.DeleteChildren();
            _IBFDemand.IBFDet_KitIns.DeleteChildren();
            _IBFDemand.IBFDet_KitOuts.DeleteChildren();
            _IBFDemand.IBFDet_PrintedDocumentIns.DeleteChildren();
            _IBFDemand.IBFDet_PrintedDocumentOuts.DeleteChildren();
            _IBFDemand.IBFDet_VaccineIns.DeleteChildren();
            _IBFDemand.IBFDet_VaccineOuts.DeleteChildren();

        }
        
        public void ShowNeededGrids()
        {
            MarketDrugsInGrid.Visible = false;
            MarketDrugsOutGrid.Visible = false;
            MilitaryDrugsInGrid.Visible = false;
            MilitaryDrugsOutGrid.Visible = false;
            XXXXXXDrugsInGrid.Visible = false;
            XXXXXXDrugsOutGrid.Visible = false;
            MedicalConsumablesInGrid.Visible = false;
            MedicalConsumablesOutGrid.Visible = false;
            MedicalEquipmentsInGrid.Visible = false;
            MedicalEquipmentsOutGrid.Visible = false;
            SparePartsInGrid.Visible = false;
            SparePartsOutGrid.Visible = false;
            SerumsInGrid.Visible = false;
            SerumsOutGrid.Visible = false;
            KitsInGrid.Visible = false;
            KitsOutGrid.Visible = false;
            PrintedDocumentsInGrid.Visible = false;
            PrintedDocumentsOutGrid.Visible = false;
            VaccinesInGrid.Visible = false;
            VaccinesOutGrid.Visible = false;
            
            if(_IBFDemand.IBFType == null)
                return;
            
            int iType = Convert.ToInt32(_IBFDemand.IBFType.Value);
            int ibfYear = Convert.ToInt32(_IBFDemand.IBFYear);
            switch(iType)
            {
                case 0: //Piyasa İlaç
                    MarketDrugsInGrid.Visible = true;
                    //MarketDrugsInGrid.Dock = DockStyle.Fill;
                    MarketDrugsInGrid.Columns[MDI_LASTIBFREQUESTAMOUNT.Name].HeaderText = MarketDrugsInGrid.Columns[MDI_LASTIBFREQUESTAMOUNT.Name].HeaderText.Replace("xxx", (ibfYear - 1).ToString());
                    MarketDrugsInGrid.Columns[MDI_CONSUMPTIONAMOUNT.Name].HeaderText = MarketDrugsInGrid.Columns[MDI_CONSUMPTIONAMOUNT.Name].HeaderText.Replace("xxx", (ibfYear - 2).ToString());
                    MarketDrugsOutGrid.Visible = true;
                    //MarketDrugsOutGrid.Dock = DockStyle.Fill;
                    MarketDrugsOutGrid.Columns[MDO_LASTIBFREQUESTAMOUNT.Name].HeaderText = MarketDrugsOutGrid.Columns[MDO_LASTIBFREQUESTAMOUNT.Name].HeaderText.Replace("xxx", (ibfYear - 1).ToString());
                    MarketDrugsOutGrid.Columns[MDO_CONSUMPTIONAMOUNT.Name].HeaderText = MarketDrugsOutGrid.Columns[MDO_CONSUMPTIONAMOUNT.Name].HeaderText.Replace("xxx", (ibfYear - 2).ToString());
                    
                    if(_IBFDemand.CurrentStateDefID == IBFDemand.States.New)
                    {
                        MarketDrugsInGrid.Columns[MDI_CLINICAPPROVEDAMOUNT .Name].Visible = false;
                        MarketDrugsOutGrid.Columns[MDO_CLINICAPPROVEDAMOUNT.Name].Visible = false;
                        MarketDrugsInGrid.Columns[MDI_AMOUNT.Name].Visible = false;
                        MarketDrugsOutGrid.Columns[MDO_AMOUNT.Name].Visible = false;
                        MarketDrugsOutGrid.AllowUserToAddRows = true;
                        MarketDrugsOutGrid.Columns[MDO_PURCHASEITEMDEF.Name].ReadOnly = false;
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.ClinicApproval)
                    {
                        MarketDrugsInGrid.Columns[MDI_AMOUNT.Name].Visible = false;
                        MarketDrugsOutGrid.Columns[MDO_AMOUNT.Name].Visible = false;
                        MarketDrugsInGrid.Columns[MDI_REQUESTAMOUNT.Name].ReadOnly = true;
                        MarketDrugsOutGrid.Columns[MDO_REQUESTAMOUNT.Name].ReadOnly = true;
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.AccountancyApproval)
                    {
                        MarketDrugsInGrid.Columns[MDI_REQUESTAMOUNT.Name].Visible = false;
                        MarketDrugsOutGrid.Columns[MDO_REQUESTAMOUNT.Name].Visible = false;
                        MarketDrugsInGrid.Columns[MDI_CLINICAPPROVEDAMOUNT.Name].ReadOnly = true;
                        MarketDrugsInGrid.Columns[MDI_CLINICAPPROVEDAMOUNT.Name].HeaderText = "Talep Miktarı";
                        MarketDrugsOutGrid.Columns[MDO_CLINICAPPROVEDAMOUNT.Name].ReadOnly = true;
                        MarketDrugsOutGrid.Columns[MDO_CLINICAPPROVEDAMOUNT.Name].HeaderText = "Talep Miktarı";
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.RequisiteEvaluationCommision)
                    {
                        MarketDrugsInGrid.Columns[MDI_REQUESTAMOUNT.Name].Visible = false;
                        MarketDrugsOutGrid.Columns[MDO_REQUESTAMOUNT.Name].Visible = false;
                        MarketDrugsInGrid.Columns[MDI_REQUESTAMOUNTBOX.Name].Visible = false;
                        MarketDrugsOutGrid.Columns[MDO_REQUESTAMOUNTBOX.Name].Visible = false;
                        MarketDrugsInGrid.Columns[MDI_CLINICAPPROVEDAMOUNT.Name].Visible = false;
                        MarketDrugsOutGrid.Columns[MDO_CLINICAPPROVEDAMOUNT.Name].Visible = false;
                        MarketDrugsInGrid.Columns[MDI_AMOUNT.Name].ReadOnly = true;
                        MarketDrugsOutGrid.Columns[MDO_AMOUNT.Name].ReadOnly = true;
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.Completed)
                    {
                        MarketDrugsInGrid.Columns[MDI_CLINICAPPROVEDAMOUNT.Name].Visible = false;
                        MarketDrugsOutGrid.Columns[MDO_CLINICAPPROVEDAMOUNT.Name].Visible = false;
                    }
                    
                    break;
                    
                case 1: //XXXXXX İlaç
                    MilitaryDrugsInGrid.Visible = true;
                    //MilitaryDrugsInGrid.Dock = DockStyle.Fill;
                    MilitaryDrugsInGrid.Columns[MIDI_CONSUMPTIONAMOUNT.Name].HeaderText = MilitaryDrugsInGrid.Columns[MIDI_CONSUMPTIONAMOUNT.Name].HeaderText.Replace("xxx", (ibfYear - 3).ToString());
                    MilitaryDrugsInGrid.Columns[MIDI_LASTIBFREQUESTAMOUNT.Name].HeaderText = MilitaryDrugsInGrid.Columns[MIDI_LASTIBFREQUESTAMOUNT.Name].HeaderText.Replace("xxx", (ibfYear - 1).ToString());
                    MilitaryDrugsOutGrid.Visible = true;
                    //MilitaryDrugsOutGrid.Dock = DockStyle.Fill;
                    MilitaryDrugsOutGrid.Columns[MIDO_CONSUMPTIONAMOUNT.Name].HeaderText = MilitaryDrugsOutGrid.Columns[MIDO_CONSUMPTIONAMOUNT.Name].HeaderText.Replace("xxx", (ibfYear - 3).ToString());
                    MilitaryDrugsOutGrid.Columns[MIDO_LASTIBFREQUESTAMOUNT.Name].HeaderText = MilitaryDrugsOutGrid.Columns[MIDO_LASTIBFREQUESTAMOUNT.Name].HeaderText.Replace("xxx", (ibfYear - 1).ToString());
                    
                    if(_IBFDemand.CurrentStateDefID == IBFDemand.States.New)
                    {
                        MilitaryDrugsInGrid.Columns[MIDI_CLINICAPPROVEDAMOUNT .Name].Visible = false;
                        MilitaryDrugsOutGrid.Columns[MIDO_CLINICAPPROVEDAMOUNT.Name].Visible = false;
                        MilitaryDrugsInGrid.Columns[MIDI_AMOUNT.Name].Visible = false;
                        MilitaryDrugsOutGrid.Columns[MIDO_AMOUNT.Name].Visible = false;
                        MilitaryDrugsOutGrid.AllowUserToAddRows = true;
                        MilitaryDrugsOutGrid.Columns[MIDO_PURCHASEITEMDEF.Name].ReadOnly = false;
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.ClinicApproval)
                    {
                        MilitaryDrugsInGrid.Columns[MIDI_AMOUNT.Name].Visible = false;
                        MilitaryDrugsOutGrid.Columns[MIDO_AMOUNT.Name].Visible = false;
                        MilitaryDrugsInGrid.Columns[MIDI_REQUESTAMOUNT.Name].ReadOnly = true;
                        MilitaryDrugsOutGrid.Columns[MIDO_REQUESTAMOUNT.Name].ReadOnly = true;
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.AccountancyApproval)
                    {
                        MilitaryDrugsInGrid.Columns[MIDI_REQUESTAMOUNT.Name].Visible = false;
                        MilitaryDrugsOutGrid.Columns[MIDO_REQUESTAMOUNT.Name].Visible = false;
                        MilitaryDrugsInGrid.Columns[MIDI_CLINICAPPROVEDAMOUNT.Name].ReadOnly = true;
                        MilitaryDrugsInGrid.Columns[MIDI_CLINICAPPROVEDAMOUNT.Name].HeaderText = "Talep Miktarı";
                        MilitaryDrugsOutGrid.Columns[MIDO_CLINICAPPROVEDAMOUNT.Name].ReadOnly = true;
                        MilitaryDrugsOutGrid.Columns[MIDO_CLINICAPPROVEDAMOUNT.Name].HeaderText = "Talep Miktarı";
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.RequisiteEvaluationCommision)
                    {
                        
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.Completed)
                    {
                        MilitaryDrugsInGrid.Columns[MIDI_CLINICAPPROVEDAMOUNT.Name].Visible = false;
                        MilitaryDrugsOutGrid.Columns[MIDO_CLINICAPPROVEDAMOUNT.Name].Visible = false;
                    }
                    
                    break;

                case 2: //XXXXXX İlaç
                    XXXXXXDrugsInGrid.Visible = true;
                    //XXXXXXDrugsInGrid.Dock = DockStyle.Fill;
                    XXXXXXDrugsInGrid.Columns[GDI_LASTIBFREQUESTAMOUNT.Name].HeaderText = XXXXXXDrugsInGrid.Columns[GDI_LASTIBFREQUESTAMOUNT.Name].HeaderText.Replace("xxx", (ibfYear - 1).ToString());
                    XXXXXXDrugsOutGrid.Visible = true;
                    //XXXXXXDrugsOutGrid.Dock = DockStyle.Fill;
                    XXXXXXDrugsOutGrid.Columns[GDO_LASTIBFREQUESTAMOUNT.Name].HeaderText = XXXXXXDrugsOutGrid.Columns[GDO_LASTIBFREQUESTAMOUNT.Name].HeaderText.Replace("xxx", (ibfYear - 1).ToString());
                    
                    if(_IBFDemand.CurrentStateDefID == IBFDemand.States.New)
                    {
                        XXXXXXDrugsInGrid.Columns[GDI_CLINICAPPROVEDAMOUNT .Name].Visible = false;
                        XXXXXXDrugsOutGrid.Columns[GDO_CLINICAPPROVEDAMOUNT.Name].Visible = false;
                        XXXXXXDrugsInGrid.Columns[GDI_AMOUNT.Name].Visible = false;
                        XXXXXXDrugsOutGrid.Columns[GDO_AMOUNT.Name].Visible = false;
                        XXXXXXDrugsOutGrid.AllowUserToAddRows = true;
                        XXXXXXDrugsOutGrid.Columns[GDO_PURCHASEITEMDEF.Name].ReadOnly = false;
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.ClinicApproval)
                    {
                        XXXXXXDrugsInGrid.Columns[GDI_AMOUNT.Name].Visible = false;
                        XXXXXXDrugsOutGrid.Columns[GDO_AMOUNT.Name].Visible = false;
                        XXXXXXDrugsInGrid.Columns[GDI_REQUESTAMOUNT.Name].ReadOnly = true;
                        XXXXXXDrugsOutGrid.Columns[GDO_REQUESTAMOUNT.Name].ReadOnly = true;
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.AccountancyApproval)
                    {
                        XXXXXXDrugsInGrid.Columns[GDI_REQUESTAMOUNT.Name].Visible = false;
                        XXXXXXDrugsOutGrid.Columns[GDO_REQUESTAMOUNT.Name].Visible = false;
                        XXXXXXDrugsInGrid.Columns[GDI_CLINICAPPROVEDAMOUNT.Name].ReadOnly = true;
                        XXXXXXDrugsInGrid.Columns[GDI_CLINICAPPROVEDAMOUNT.Name].HeaderText = "Talep Miktarı";
                        XXXXXXDrugsOutGrid.Columns[GDO_CLINICAPPROVEDAMOUNT.Name].ReadOnly = true;
                        XXXXXXDrugsOutGrid.Columns[GDO_CLINICAPPROVEDAMOUNT.Name].HeaderText = "Talep Miktarı";
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.RequisiteEvaluationCommision)
                    {
                        
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.Completed)
                    {
                        XXXXXXDrugsInGrid.Columns[GDI_CLINICAPPROVEDAMOUNT.Name].Visible = false;
                        XXXXXXDrugsOutGrid.Columns[GDO_CLINICAPPROVEDAMOUNT.Name].Visible = false;
                    }
                    
                    break;

                case 3: //Tıbbi Sarf
                    MedicalConsumablesInGrid.Visible = true;
                    //MedicalConsumablesInGrid.Dock = DockStyle.Fill;
                    MedicalConsumablesInGrid.Columns[MCI_CONSUMPTIONAMOUNT.Name].HeaderText = MedicalConsumablesInGrid.Columns[MCI_CONSUMPTIONAMOUNT.Name].HeaderText.Replace("xxx", (ibfYear - 2).ToString());
                    MedicalConsumablesInGrid.Columns[MCI_LASTIBFREQUESTAMOUNT.Name].HeaderText = MedicalConsumablesInGrid.Columns[MCI_LASTIBFREQUESTAMOUNT.Name].HeaderText.Replace("xxx", (ibfYear - 1).ToString());
                    MedicalConsumablesOutGrid.Visible = true;
                    //MedicalConsumablesOutGrid.Dock = DockStyle.Fill;
                    MedicalConsumablesOutGrid.Columns[MCO_CONSUMPTIONAMOUNT.Name].HeaderText = MedicalConsumablesOutGrid.Columns[MCO_CONSUMPTIONAMOUNT.Name].HeaderText.Replace("xxx", (ibfYear - 2).ToString());
                    MedicalConsumablesOutGrid.Columns[MCO_LASTIBFREQUESTAMOUNT.Name].HeaderText = MedicalConsumablesOutGrid.Columns[MCO_LASTIBFREQUESTAMOUNT.Name].HeaderText.Replace("xxx", (ibfYear - 1).ToString());
                    
                    if(_IBFDemand.CurrentStateDefID == IBFDemand.States.New)
                    {
                        MedicalConsumablesInGrid.Columns[MCI_CLINICAPPROVEDAMOUNT .Name].Visible = false;
                        MedicalConsumablesOutGrid.Columns[MCO_CLINICAPPROVEDAMOUNT.Name].Visible = false;
                        MedicalConsumablesInGrid.Columns[MCI_AMOUNT.Name].Visible = false;
                        MedicalConsumablesOutGrid.Columns[MCO_AMOUNT.Name].Visible = false;
                        MedicalConsumablesOutGrid.AllowUserToAddRows = true;
                        MedicalConsumablesOutGrid.Columns[MCO_PURCHASEITEMDEF.Name].ReadOnly = false;
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.ClinicApproval)
                    {
                        MedicalConsumablesInGrid.Columns[MCI_AMOUNT.Name].Visible = false;
                        MedicalConsumablesOutGrid.Columns[MCO_AMOUNT.Name].Visible = false;
                        MedicalConsumablesInGrid.Columns[MCI_REQUESTAMOUNT.Name].ReadOnly = true;
                        MedicalConsumablesOutGrid.Columns[MCO_REQUESTAMOUNT.Name].ReadOnly = true;
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.AccountancyApproval)
                    {
                        MedicalConsumablesInGrid.Columns[MCI_REQUESTAMOUNT.Name].Visible = false;
                        MedicalConsumablesOutGrid.Columns[MCO_REQUESTAMOUNT.Name].Visible = false;
                        MedicalConsumablesInGrid.Columns[MCI_CLINICAPPROVEDAMOUNT.Name].ReadOnly = true;
                        MedicalConsumablesInGrid.Columns[MCI_CLINICAPPROVEDAMOUNT.Name].HeaderText = "Talep Miktarı";
                        MedicalConsumablesOutGrid.Columns[MCO_CLINICAPPROVEDAMOUNT.Name].ReadOnly = true;
                        MedicalConsumablesOutGrid.Columns[MCO_CLINICAPPROVEDAMOUNT.Name].HeaderText = "Talep Miktarı";
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.RequisiteEvaluationCommision)
                    {
                        
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.Completed)
                    {
                        MedicalConsumablesInGrid.Columns[MCI_CLINICAPPROVEDAMOUNT.Name].Visible = false;
                        MedicalConsumablesOutGrid.Columns[MCO_CLINICAPPROVEDAMOUNT.Name].Visible = false;
                    }
                    
                    break;

                case 4: //Tıbbi Cihaz
                    MedicalEquipmentsInGrid.Visible = true;
                    //MedicalEquipmentsInGrid.Dock = DockStyle.Fill;
                    MedicalEquipmentsInGrid.Columns[MEI_CONSUMPTIONAMOUNT.Name].HeaderText = MedicalEquipmentsInGrid.Columns[MEI_CONSUMPTIONAMOUNT.Name].HeaderText.Replace("xxx", (ibfYear - 4).ToString());
                    MedicalEquipmentsInGrid.Columns[MEI_CONSUMPTIONAMOUNT1.Name].HeaderText = MedicalEquipmentsInGrid.Columns[MEI_CONSUMPTIONAMOUNT1.Name].HeaderText.Replace("xxx", (ibfYear - 3).ToString());
                    MedicalEquipmentsInGrid.Columns[MEI_CONSUMPTIONAMOUNT2.Name].HeaderText = MedicalEquipmentsInGrid.Columns[MEI_CONSUMPTIONAMOUNT2.Name].HeaderText.Replace("xxx", (ibfYear - 2).ToString());
                    MedicalEquipmentsInGrid.Columns[MEI_STORESTOCK.Name].HeaderText = MedicalEquipmentsInGrid.Columns[MEI_STORESTOCK.Name].HeaderText.Replace("xxx", (ibfYear - 2).ToString());
                    MedicalEquipmentsOutGrid.Visible = true;
                    //MedicalEquipmentsOutGrid.Dock = DockStyle.Fill;
                    MedicalEquipmentsOutGrid.Columns[MEO_CONSUMPTIONAMOUNT.Name].HeaderText = MedicalEquipmentsOutGrid.Columns[MEO_CONSUMPTIONAMOUNT.Name].HeaderText.Replace("xxx", (ibfYear - 4).ToString());
                    MedicalEquipmentsOutGrid.Columns[MEO_CONSUMPTIONAMOUNT1.Name].HeaderText = MedicalEquipmentsOutGrid.Columns[MEO_CONSUMPTIONAMOUNT1.Name].HeaderText.Replace("xxx", (ibfYear - 3).ToString());
                    MedicalEquipmentsOutGrid.Columns[MEO_CONSUMPTIONAMOUNT2.Name].HeaderText = MedicalEquipmentsOutGrid.Columns[MEO_CONSUMPTIONAMOUNT2.Name].HeaderText.Replace("xxx", (ibfYear - 2).ToString());
                    MedicalEquipmentsOutGrid.Columns[MEO_STORESTOCK.Name].HeaderText = MedicalEquipmentsOutGrid.Columns[MEO_STORESTOCK.Name].HeaderText.Replace("xxx", (ibfYear - 2).ToString());
                    
                    if(_IBFDemand.CurrentStateDefID == IBFDemand.States.New)
                    {
                        MedicalEquipmentsInGrid.Columns[MEI_CLINICAPPROVEDAMOUNT .Name].Visible = false;
                        MedicalEquipmentsOutGrid.Columns[MEO_CLINICAPPROVEDAMOUNT.Name].Visible = false;
                        MedicalEquipmentsInGrid.Columns[MEI_AMOUNT.Name].Visible = false;
                        MedicalEquipmentsOutGrid.Columns[MEO_AMOUNT.Name].Visible = false;
                        MedicalEquipmentsOutGrid.AllowUserToAddRows = true;
                        MedicalEquipmentsOutGrid.Columns[MEO_PURCHASEITEMDEF.Name].ReadOnly = false;
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.ClinicApproval)
                    {
                        MedicalEquipmentsInGrid.Columns[MEI_AMOUNT.Name].Visible = false;
                        MedicalEquipmentsOutGrid.Columns[MEO_AMOUNT.Name].Visible = false;
                        MedicalEquipmentsInGrid.Columns[MEI_REQUESTAMOUNT.Name].ReadOnly = true;
                        MedicalEquipmentsOutGrid.Columns[MEO_REQUESTAMOUNT.Name].ReadOnly = true;
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.AccountancyApproval)
                    {
                        MedicalEquipmentsInGrid.Columns[MEI_REQUESTAMOUNT.Name].Visible = false;
                        MedicalEquipmentsOutGrid.Columns[MEO_REQUESTAMOUNT.Name].Visible = false;
                        MedicalEquipmentsInGrid.Columns[MEI_CLINICAPPROVEDAMOUNT.Name].ReadOnly = true;
                        MedicalEquipmentsInGrid.Columns[MEI_CLINICAPPROVEDAMOUNT.Name].HeaderText = "Talep Miktarı";
                        MedicalEquipmentsOutGrid.Columns[MEO_CLINICAPPROVEDAMOUNT.Name].ReadOnly = true;
                        MedicalEquipmentsOutGrid.Columns[MEO_CLINICAPPROVEDAMOUNT.Name].HeaderText = "Talep Miktarı";
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.RequisiteEvaluationCommision)
                    {
                        
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.Completed)
                    {
                        MedicalEquipmentsInGrid.Columns[MEI_CLINICAPPROVEDAMOUNT.Name].Visible = false;
                        MedicalEquipmentsOutGrid.Columns[MEO_CLINICAPPROVEDAMOUNT.Name].Visible = false;
                    }
                    
                    break;

                case 5: //Yedek Parça
                    SparePartsInGrid.Visible = true;
                    //SparePartsInGrid.Dock = DockStyle.Fill;
                    SparePartsInGrid.Columns[SPI_CONSUMPTIONAMOUNT.Name].HeaderText = SparePartsInGrid.Columns[SPI_CONSUMPTIONAMOUNT.Name].HeaderText.Replace("xxx", (ibfYear - 1).ToString());
                    SparePartsOutGrid.Visible = true;
                    //SparePartsOutGrid.Dock = DockStyle.Fill;
                    SparePartsOutGrid.Columns[SPO_CONSUMPTIONAMOUNT.Name].HeaderText = SparePartsOutGrid.Columns[SPO_CONSUMPTIONAMOUNT.Name].HeaderText.Replace("xxx", (ibfYear - 1).ToString());
                    
                    if(_IBFDemand.CurrentStateDefID == IBFDemand.States.New)
                    {
                        SparePartsInGrid.Columns[SPI_CLINICAPPROVEDAMOUNT .Name].Visible = false;
                        SparePartsOutGrid.Columns[SPO_CLINICAPPROVEDAMOUNT.Name].Visible = false;
                        SparePartsInGrid.Columns[SPI_AMOUNT.Name].Visible = false;
                        SparePartsOutGrid.Columns[SPO_AMOUNT.Name].Visible = false;
                        SparePartsOutGrid.AllowUserToAddRows = true;
                        SparePartsOutGrid.Columns[SPO_PURCHASEITEMDEF.Name].ReadOnly = false;
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.ClinicApproval)
                    {
                        SparePartsInGrid.Columns[SPI_AMOUNT.Name].Visible = false;
                        SparePartsOutGrid.Columns[SPO_AMOUNT.Name].Visible = false;
                        SparePartsInGrid.Columns[SPI_REQUESTAMOUNT.Name].ReadOnly = true;
                        SparePartsOutGrid.Columns[SPO_REQUESTAMOUNT.Name].ReadOnly = true;
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.AccountancyApproval)
                    {
                        SparePartsInGrid.Columns[SPI_REQUESTAMOUNT.Name].Visible = false;
                        SparePartsOutGrid.Columns[SPO_REQUESTAMOUNT.Name].Visible = false;
                        SparePartsInGrid.Columns[SPI_CLINICAPPROVEDAMOUNT.Name].ReadOnly = true;
                        SparePartsInGrid.Columns[SPI_CLINICAPPROVEDAMOUNT.Name].HeaderText = "Talep Miktarı";
                        SparePartsOutGrid.Columns[SPO_CLINICAPPROVEDAMOUNT.Name].ReadOnly = true;
                        SparePartsOutGrid.Columns[SPO_CLINICAPPROVEDAMOUNT.Name].HeaderText = "Talep Miktarı";
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.RequisiteEvaluationCommision)
                    {
                        
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.Completed)
                    {
                        SparePartsInGrid.Columns[SPI_CLINICAPPROVEDAMOUNT.Name].Visible = false;
                        SparePartsOutGrid.Columns[SPO_CLINICAPPROVEDAMOUNT.Name].Visible = false;
                    }
                    
                    break;

                case 6: //Serum
                    SerumsInGrid.Visible = true;
                    //SerumsInGrid.Dock = DockStyle.Fill;
                    SerumsInGrid.Columns[SI_CONSUMPTIONAMOUNT.Name].HeaderText = SerumsInGrid.Columns[SI_CONSUMPTIONAMOUNT.Name].HeaderText.Replace("xxx", (ibfYear - 2).ToString());
                    SerumsInGrid.Columns[SI_LASTIBFREQUESTAMOUNT.Name].HeaderText = SerumsInGrid.Columns[SI_LASTIBFREQUESTAMOUNT.Name].HeaderText.Replace("xxx", (ibfYear - 1).ToString());
                    SerumsOutGrid.Visible = true;
//                    SerumsOutGrid.Dock = /DockStyle.Fill;
                    SerumsOutGrid.Columns[SO_CONSUMPTIONAMOUNT.Name].HeaderText = SerumsOutGrid.Columns[SO_CONSUMPTIONAMOUNT.Name].HeaderText.Replace("xxx", (ibfYear - 2).ToString());
                    SerumsOutGrid.Columns[SO_LASTIBFREQUESTAMOUNT.Name].HeaderText = SerumsOutGrid.Columns[SO_LASTIBFREQUESTAMOUNT.Name].HeaderText.Replace("xxx", (ibfYear - 1).ToString());
                    
                    if(_IBFDemand.CurrentStateDefID == IBFDemand.States.New)
                    {
                        SerumsInGrid.Columns[SI_CLINICAPPROVEDAMOUNT .Name].Visible = false;
                        SerumsOutGrid.Columns[SO_CLINICAPPROVEDAMOUNT.Name].Visible = false;
                        SerumsInGrid.Columns[SI_AMOUNT.Name].Visible = false;
                        SerumsOutGrid.Columns[SO_AMOUNT.Name].Visible = false;
                        SerumsOutGrid.AllowUserToAddRows = true;
                        SerumsOutGrid.Columns[SO_PURCHASEITEMDEF.Name].ReadOnly = false;
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.ClinicApproval)
                    {
                        SerumsInGrid.Columns[SI_AMOUNT.Name].Visible = false;
                        SerumsOutGrid.Columns[SO_AMOUNT.Name].Visible = false;
                        SerumsInGrid.Columns[SI_REQUESTAMOUNT.Name].ReadOnly = true;
                        SerumsOutGrid.Columns[SO_REQUESTAMOUNT.Name].ReadOnly = true;
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.AccountancyApproval)
                    {
                        SerumsInGrid.Columns[SI_REQUESTAMOUNT.Name].Visible = false;
                        SerumsOutGrid.Columns[SO_REQUESTAMOUNT.Name].Visible = false;
                        SerumsInGrid.Columns[SI_CLINICAPPROVEDAMOUNT.Name].ReadOnly = true;
                        SerumsInGrid.Columns[SI_CLINICAPPROVEDAMOUNT.Name].HeaderText = "Talep Miktarı";
                        SerumsOutGrid.Columns[SO_CLINICAPPROVEDAMOUNT.Name].ReadOnly = true;
                        SerumsOutGrid.Columns[SO_CLINICAPPROVEDAMOUNT.Name].HeaderText = "Talep Miktarı";
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.RequisiteEvaluationCommision)
                    {
                        
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.Completed)
                    {
                        SerumsInGrid.Columns[SI_CLINICAPPROVEDAMOUNT.Name].Visible = false;
                        SerumsOutGrid.Columns[SO_CLINICAPPROVEDAMOUNT.Name].Visible = false;
                    }
                    
                    break;

                case 7: //Kit
                    KitsInGrid.Visible = true;
                    //KitsInGrid.Dock = DockStyle.Fill;
                    KitsOutGrid.Visible = true;
                    //KitsOutGrid.Dock = DockStyle.Fill;
                    
                    if(_IBFDemand.CurrentStateDefID == IBFDemand.States.New)
                    {
                        KitsInGrid.Columns[KTI_CLINICAPPROVEDAMOUNT .Name].Visible = false;
                        KitsOutGrid.Columns[KTO_CLINICAPPROVEDAMOUNT.Name].Visible = false;
                        KitsInGrid.Columns[KTI_AMOUNT.Name].Visible = false;
                        KitsOutGrid.Columns[KTO_AMOUNT.Name].Visible = false;
                        KitsOutGrid.AllowUserToAddRows = true;
                        KitsOutGrid.Columns[KTO_PURCHASEITEMDEF.Name].ReadOnly = false;
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.ClinicApproval)
                    {
                        KitsInGrid.Columns[KTI_AMOUNT.Name].Visible = false;
                        KitsOutGrid.Columns[KTO_AMOUNT.Name].Visible = false;
                        KitsInGrid.Columns[KTI_REQUESTAMOUNT.Name].ReadOnly = true;
                        KitsOutGrid.Columns[KTO_REQUESTAMOUNT.Name].ReadOnly = true;
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.AccountancyApproval)
                    {
                        KitsInGrid.Columns[KTI_REQUESTAMOUNT.Name].Visible = false;
                        KitsOutGrid.Columns[KTO_REQUESTAMOUNT.Name].Visible = false;
                        KitsInGrid.Columns[KTI_CLINICAPPROVEDAMOUNT.Name].ReadOnly = true;
                        KitsInGrid.Columns[KTI_CLINICAPPROVEDAMOUNT.Name].HeaderText = "Talep Miktarı";
                        KitsOutGrid.Columns[KTO_CLINICAPPROVEDAMOUNT.Name].ReadOnly = true;
                        KitsOutGrid.Columns[KTO_CLINICAPPROVEDAMOUNT.Name].HeaderText = "Talep Miktarı";
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.RequisiteEvaluationCommision)
                    {
                        
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.Completed)
                    {
                        KitsInGrid.Columns[KTI_CLINICAPPROVEDAMOUNT.Name].Visible = false;
                        KitsOutGrid.Columns[KTO_CLINICAPPROVEDAMOUNT.Name].Visible = false;
                    }
                    
                    break;

                case 8: //Basılı Evrak
                    PrintedDocumentsInGrid.Visible = true;
                    //PrintedDocumentsInGrid.Dock = DockStyle.Fill;
                    PrintedDocumentsOutGrid.Visible = true;
                    //PrintedDocumentsOutGrid.Dock = DockStyle.Fill;
                    
                    if(_IBFDemand.CurrentStateDefID == IBFDemand.States.New)
                    {
                        PrintedDocumentsInGrid.Columns[PDI_CLINICAPPROVEDAMOUNT .Name].Visible = false;
                        PrintedDocumentsOutGrid.Columns[PDO_CLINICAPPROVEDAMOUNT.Name].Visible = false;
                        PrintedDocumentsInGrid.Columns[PDI_AMOUNT.Name].Visible = false;
                        PrintedDocumentsOutGrid.Columns[PDO_AMOUNT.Name].Visible = false;
                        PrintedDocumentsOutGrid.AllowUserToAddRows = true;
                        PrintedDocumentsOutGrid.Columns[PDO_PURCHASEITEMDEF.Name].ReadOnly = false;
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.ClinicApproval)
                    {
                        PrintedDocumentsInGrid.Columns[PDI_AMOUNT.Name].Visible = false;
                        PrintedDocumentsOutGrid.Columns[PDO_AMOUNT.Name].Visible = false;
                        PrintedDocumentsInGrid.Columns[PDI_REQUESTAMOUNT.Name].ReadOnly = true;
                        PrintedDocumentsOutGrid.Columns[PDO_REQUESTAMOUNT.Name].ReadOnly = true;
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.AccountancyApproval)
                    {
                        PrintedDocumentsInGrid.Columns[PDI_REQUESTAMOUNT.Name].Visible = false;
                        PrintedDocumentsOutGrid.Columns[PDO_REQUESTAMOUNT.Name].Visible = false;
                        PrintedDocumentsInGrid.Columns[PDI_CLINICAPPROVEDAMOUNT.Name].ReadOnly = true;
                        PrintedDocumentsInGrid.Columns[PDI_CLINICAPPROVEDAMOUNT.Name].HeaderText = "Talep Miktarı";
                        PrintedDocumentsOutGrid.Columns[PDO_CLINICAPPROVEDAMOUNT.Name].ReadOnly = true;
                        PrintedDocumentsOutGrid.Columns[PDO_CLINICAPPROVEDAMOUNT.Name].HeaderText = "Talep Miktarı";
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.RequisiteEvaluationCommision)
                    {
                        
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.Completed)
                    {
                        PrintedDocumentsInGrid.Columns[PDI_CLINICAPPROVEDAMOUNT.Name].Visible = false;
                        PrintedDocumentsOutGrid.Columns[PDO_CLINICAPPROVEDAMOUNT.Name].Visible = false;
                    }
                    
                    break;

                case 9: //Aşı
                    VaccinesInGrid.Visible = true;
                    //VaccinesInGrid.Dock = DockStyle.Fill;
                    VaccinesOutGrid.Visible = true;
                    //VaccinesOutGrid.Dock = DockStyle.Fill;
                    
                    if(_IBFDemand.CurrentStateDefID == IBFDemand.States.New)
                    {
                        VaccinesInGrid.Columns[VI_CLINICAPPROVEDAMOUNT .Name].Visible = false;
                        VaccinesOutGrid.Columns[VO_CLINICAPPROVEDAMOUNT.Name].Visible = false;
                        VaccinesInGrid.Columns[VI_AMOUNT.Name].Visible = false;
                        VaccinesOutGrid.Columns[VO_AMOUNT.Name].Visible = false;
                        VaccinesOutGrid.AllowUserToAddRows = true;
                        VaccinesOutGrid.Columns[VO_PURCHASEITEMDEF.Name].ReadOnly = false;
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.ClinicApproval)
                    {
                        VaccinesInGrid.Columns[VI_AMOUNT.Name].Visible = false;
                        VaccinesOutGrid.Columns[VO_AMOUNT.Name].Visible = false;
                        VaccinesInGrid.Columns[VI_REQUESTAMOUNT.Name].ReadOnly = true;
                        VaccinesOutGrid.Columns[VO_REQUESTAMOUNT.Name].ReadOnly = true;
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.AccountancyApproval)
                    {
                        VaccinesInGrid.Columns[VI_REQUESTAMOUNT.Name].Visible = false;
                        VaccinesOutGrid.Columns[VO_REQUESTAMOUNT.Name].Visible = false;
                        VaccinesInGrid.Columns[VI_CLINICAPPROVEDAMOUNT.Name].ReadOnly = true;
                        VaccinesInGrid.Columns[VI_CLINICAPPROVEDAMOUNT.Name].HeaderText = "Talep Miktarı";
                        VaccinesOutGrid.Columns[VO_CLINICAPPROVEDAMOUNT.Name].ReadOnly = true;
                        VaccinesOutGrid.Columns[VO_CLINICAPPROVEDAMOUNT.Name].HeaderText = "Talep Miktarı";
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.RequisiteEvaluationCommision)
                    {
                        
                    }
                    else if(_IBFDemand.CurrentStateDefID == IBFDemand.States.Completed)
                    {
                        VaccinesInGrid.Columns[VI_CLINICAPPROVEDAMOUNT.Name].Visible = false;
                        VaccinesOutGrid.Columns[VO_CLINICAPPROVEDAMOUNT.Name].Visible = false;
                    }
                    
                    break;
                    
                default:
                    break;
            }
        }
        
#endregion IBFDemand_BaseForm_Methods
    }
}