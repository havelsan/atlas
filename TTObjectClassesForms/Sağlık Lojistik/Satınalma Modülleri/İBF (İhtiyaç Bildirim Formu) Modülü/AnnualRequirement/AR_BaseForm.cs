
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
    public partial class AR_BaseForm : TTForm
    {
        override protected void BindControlEvents()
        {
            MarketDrugsInGrid.CellContentClick += new TTGridCellEventDelegate(MarketDrugsInGrid_CellContentClick);
            VaccinesInGrid.CellContentClick += new TTGridCellEventDelegate(VaccinesInGrid_CellContentClick);
            SerumsInGrid.CellContentClick += new TTGridCellEventDelegate(SerumsInGrid_CellContentClick);
            MilitaryDrugsInGrid.CellContentClick += new TTGridCellEventDelegate(MilitaryDrugsInGrid_CellContentClick);
            MedicalConsumablesInGrid.CellContentClick += new TTGridCellEventDelegate(MedicalConsumablesInGrid_CellContentClick);
            SparePartsInGrid.CellContentClick += new TTGridCellEventDelegate(SparePartsInGrid_CellContentClick);
            PrintedDocumentsInGrid.CellContentClick += new TTGridCellEventDelegate(PrintedDocumentsInGrid_CellContentClick);
            MedicalEquipmentsInGrid.CellContentClick += new TTGridCellEventDelegate(MedicalEquipmentsInGrid_CellContentClick);
            KitsInGrid.CellContentClick += new TTGridCellEventDelegate(KitsInGrid_CellContentClick);
            XXXXXXDrugsInGrid.CellContentClick += new TTGridCellEventDelegate(XXXXXXDrugsInGrid_CellContentClick);
            MarketDrugsOutGrid.CellContentClick += new TTGridCellEventDelegate(MarketDrugsOutGrid_CellContentClick);
            XXXXXXDrugsOutGrid.CellContentClick += new TTGridCellEventDelegate(XXXXXXDrugsOutGrid_CellContentClick);
            KitsOutGrid.CellContentClick += new TTGridCellEventDelegate(KitsOutGrid_CellContentClick);
            VaccinesOutGrid.CellContentClick += new TTGridCellEventDelegate(VaccinesOutGrid_CellContentClick);
            MedicalConsumablesOutGrid.CellContentClick += new TTGridCellEventDelegate(MedicalConsumablesOutGrid_CellContentClick);
            SparePartsOutGrid.CellContentClick += new TTGridCellEventDelegate(SparePartsOutGrid_CellContentClick);
            MilitaryDrugsOutGrid.CellContentClick += new TTGridCellEventDelegate(MilitaryDrugsOutGrid_CellContentClick);
            SerumsOutGrid.CellContentClick += new TTGridCellEventDelegate(SerumsOutGrid_CellContentClick);
            MedicalEquipmentsOutGrid.CellContentClick += new TTGridCellEventDelegate(MedicalEquipmentsOutGrid_CellContentClick);
            PrintedDocumentsOutGrid.CellContentClick += new TTGridCellEventDelegate(PrintedDocumentsOutGrid_CellContentClick);
            Print.ItemClicked += new TTToolStripItemClicked(Print_ItemClicked);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            MarketDrugsInGrid.CellContentClick -= new TTGridCellEventDelegate(MarketDrugsInGrid_CellContentClick);
            VaccinesInGrid.CellContentClick -= new TTGridCellEventDelegate(VaccinesInGrid_CellContentClick);
            SerumsInGrid.CellContentClick -= new TTGridCellEventDelegate(SerumsInGrid_CellContentClick);
            MilitaryDrugsInGrid.CellContentClick -= new TTGridCellEventDelegate(MilitaryDrugsInGrid_CellContentClick);
            MedicalConsumablesInGrid.CellContentClick -= new TTGridCellEventDelegate(MedicalConsumablesInGrid_CellContentClick);
            SparePartsInGrid.CellContentClick -= new TTGridCellEventDelegate(SparePartsInGrid_CellContentClick);
            PrintedDocumentsInGrid.CellContentClick -= new TTGridCellEventDelegate(PrintedDocumentsInGrid_CellContentClick);
            MedicalEquipmentsInGrid.CellContentClick -= new TTGridCellEventDelegate(MedicalEquipmentsInGrid_CellContentClick);
            KitsInGrid.CellContentClick -= new TTGridCellEventDelegate(KitsInGrid_CellContentClick);
            XXXXXXDrugsInGrid.CellContentClick -= new TTGridCellEventDelegate(XXXXXXDrugsInGrid_CellContentClick);
            MarketDrugsOutGrid.CellContentClick -= new TTGridCellEventDelegate(MarketDrugsOutGrid_CellContentClick);
            XXXXXXDrugsOutGrid.CellContentClick -= new TTGridCellEventDelegate(XXXXXXDrugsOutGrid_CellContentClick);
            KitsOutGrid.CellContentClick -= new TTGridCellEventDelegate(KitsOutGrid_CellContentClick);
            VaccinesOutGrid.CellContentClick -= new TTGridCellEventDelegate(VaccinesOutGrid_CellContentClick);
            MedicalConsumablesOutGrid.CellContentClick -= new TTGridCellEventDelegate(MedicalConsumablesOutGrid_CellContentClick);
            SparePartsOutGrid.CellContentClick -= new TTGridCellEventDelegate(SparePartsOutGrid_CellContentClick);
            MilitaryDrugsOutGrid.CellContentClick -= new TTGridCellEventDelegate(MilitaryDrugsOutGrid_CellContentClick);
            SerumsOutGrid.CellContentClick -= new TTGridCellEventDelegate(SerumsOutGrid_CellContentClick);
            MedicalEquipmentsOutGrid.CellContentClick -= new TTGridCellEventDelegate(MedicalEquipmentsOutGrid_CellContentClick);
            PrintedDocumentsOutGrid.CellContentClick -= new TTGridCellEventDelegate(PrintedDocumentsOutGrid_CellContentClick);
            Print.ItemClicked -= new TTToolStripItemClicked(Print_ItemClicked);
            base.UnBindControlEvents();
        }

        private void MarketDrugsInGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region AR_BaseForm_MarketDrugsInGrid_CellContentClick
   if(MarketDrugsInGrid.CurrentCell == null)
                return;
            
            if(MarketDrugsInGrid.CurrentCell.OwningColumn == MarketDrugsInGrid.Columns[MDI_DETAILSBUTTON.Name])
            {
                ARDDetailForm detForm = new ARDDetailForm();
                AnnualRequirementDetail ard = (AnnualRequirementDetail)MarketDrugsInGrid.CurrentCell.OwningRow.TTObject;
                detForm.ShowEdit(this.FindForm(), ard);
            }
#endregion AR_BaseForm_MarketDrugsInGrid_CellContentClick
        }

        private void VaccinesInGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region AR_BaseForm_VaccinesInGrid_CellContentClick
   if(VaccinesInGrid.CurrentCell == null)
                return;
            
            if(VaccinesInGrid.CurrentCell.OwningColumn == VaccinesInGrid.Columns[VI_DETAILSBUTTON.Name])
            {
                ARDDetailForm detForm = new ARDDetailForm();
                AnnualRequirementDetail ard = (AnnualRequirementDetail)VaccinesInGrid.CurrentCell.OwningRow.TTObject;
                detForm.ShowEdit(this.FindForm(), ard);
            }
#endregion AR_BaseForm_VaccinesInGrid_CellContentClick
        }

        private void SerumsInGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region AR_BaseForm_SerumsInGrid_CellContentClick
   if(SerumsInGrid.CurrentCell == null)
                return;
            
            if(SerumsInGrid.CurrentCell.OwningColumn == SerumsInGrid.Columns[SI_DETAILSBUTTON.Name])
            {
                ARDDetailForm detForm = new ARDDetailForm();
                AnnualRequirementDetail ard = (AnnualRequirementDetail)SerumsInGrid.CurrentCell.OwningRow.TTObject;
                detForm.ShowEdit(this.FindForm(), ard);
            }
#endregion AR_BaseForm_SerumsInGrid_CellContentClick
        }

        private void MilitaryDrugsInGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region AR_BaseForm_MilitaryDrugsInGrid_CellContentClick
   if(MilitaryDrugsInGrid.CurrentCell == null)
                return;
            
            if(MilitaryDrugsInGrid.CurrentCell.OwningColumn == MilitaryDrugsInGrid.Columns[MIDI_DETAILSBUTTON.Name])
            {
                ARDDetailForm detForm = new ARDDetailForm();
                AnnualRequirementDetail ard = (AnnualRequirementDetail)MilitaryDrugsInGrid.CurrentCell.OwningRow.TTObject;
                detForm.ShowEdit(this.FindForm(), ard);
            }
#endregion AR_BaseForm_MilitaryDrugsInGrid_CellContentClick
        }

        private void MedicalConsumablesInGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region AR_BaseForm_MedicalConsumablesInGrid_CellContentClick
   if(MedicalConsumablesInGrid.CurrentCell == null)
                return;
            
            if(MedicalConsumablesInGrid.CurrentCell.OwningColumn == MedicalConsumablesInGrid.Columns[MCI_DETAILSBUTTON.Name])
            {
                ARDDetailForm detForm = new ARDDetailForm();
                AnnualRequirementDetail ard = (AnnualRequirementDetail)MedicalConsumablesInGrid.CurrentCell.OwningRow.TTObject;
                detForm.ShowEdit(this.FindForm(), ard);
            }
#endregion AR_BaseForm_MedicalConsumablesInGrid_CellContentClick
        }

        private void SparePartsInGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region AR_BaseForm_SparePartsInGrid_CellContentClick
   if(SparePartsInGrid.CurrentCell == null)
                return;
            
            if(SparePartsInGrid.CurrentCell.OwningColumn == SparePartsInGrid.Columns[SPI_DETAILSBUTTON.Name])
            {
                ARDDetailForm detForm = new ARDDetailForm();
                AnnualRequirementDetail ard = (AnnualRequirementDetail)SparePartsInGrid.CurrentCell.OwningRow.TTObject;
                detForm.ShowEdit(this.FindForm(), ard);
            }
#endregion AR_BaseForm_SparePartsInGrid_CellContentClick
        }

        private void PrintedDocumentsInGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region AR_BaseForm_PrintedDocumentsInGrid_CellContentClick
   if(PrintedDocumentsInGrid.CurrentCell == null)
                return;
            
            if(PrintedDocumentsInGrid.CurrentCell.OwningColumn == PrintedDocumentsInGrid.Columns[PDI_DETAILSBUTTON.Name])
            {
                ARDDetailForm detForm = new ARDDetailForm();
                AnnualRequirementDetail ard = (AnnualRequirementDetail)PrintedDocumentsInGrid.CurrentCell.OwningRow.TTObject;
                detForm.ShowEdit(this.FindForm(), ard);
            }
#endregion AR_BaseForm_PrintedDocumentsInGrid_CellContentClick
        }

        private void MedicalEquipmentsInGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region AR_BaseForm_MedicalEquipmentsInGrid_CellContentClick
   if(MedicalEquipmentsInGrid.CurrentCell == null)
                return;
            
            if(MedicalEquipmentsInGrid.CurrentCell.OwningColumn == MedicalEquipmentsInGrid.Columns[MEI_DETAILSBUTTON.Name])
            {
                ARDDetailForm detForm = new ARDDetailForm();
                AnnualRequirementDetail ard = (AnnualRequirementDetail)MedicalEquipmentsInGrid.CurrentCell.OwningRow.TTObject;
                detForm.ShowEdit(this.FindForm(), ard);
            }
#endregion AR_BaseForm_MedicalEquipmentsInGrid_CellContentClick
        }

        private void KitsInGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region AR_BaseForm_KitsInGrid_CellContentClick
   if(KitsInGrid.CurrentCell == null)
                return;
            
            if(KitsInGrid.CurrentCell.OwningColumn == KitsInGrid.Columns[KTI_DETAILSBUTTON.Name])
            {
                ARDDetailForm detForm = new ARDDetailForm();
                AnnualRequirementDetail ard = (AnnualRequirementDetail)KitsInGrid.CurrentCell.OwningRow.TTObject;
                detForm.ShowEdit(this.FindForm(), ard);
            }
#endregion AR_BaseForm_KitsInGrid_CellContentClick
        }

        private void XXXXXXDrugsInGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region AR_BaseForm_XXXXXXDrugsInGrid_CellContentClick
   if(XXXXXXDrugsInGrid.CurrentCell == null)
                return;
            
            if(XXXXXXDrugsInGrid.CurrentCell.OwningColumn == XXXXXXDrugsInGrid.Columns[GDI_DETAILSBUTTON.Name])
            {
                ARDDetailForm detForm = new ARDDetailForm();
                AnnualRequirementDetail ard = (AnnualRequirementDetail)XXXXXXDrugsInGrid.CurrentCell.OwningRow.TTObject;
                detForm.ShowEdit(this.FindForm(), ard);
            }
#endregion AR_BaseForm_XXXXXXDrugsInGrid_CellContentClick
        }

        private void MarketDrugsOutGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region AR_BaseForm_MarketDrugsOutGrid_CellContentClick
   if(MarketDrugsOutGrid.CurrentCell == null)
                return;
            
            if(MarketDrugsOutGrid.CurrentCell.OwningColumn == MarketDrugsOutGrid.Columns[MDO_DETAILSBUTTON.Name])
            {
                ARDDetailForm detForm = new ARDDetailForm();
                AnnualRequirementDetail ard = (AnnualRequirementDetail)MarketDrugsOutGrid.CurrentCell.OwningRow.TTObject;
                detForm.ShowEdit(this.FindForm(), ard);
            }
#endregion AR_BaseForm_MarketDrugsOutGrid_CellContentClick
        }

        private void XXXXXXDrugsOutGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region AR_BaseForm_XXXXXXDrugsOutGrid_CellContentClick
   if(XXXXXXDrugsOutGrid.CurrentCell == null)
                return;
            
            if(XXXXXXDrugsOutGrid.CurrentCell.OwningColumn == XXXXXXDrugsOutGrid.Columns[GDO_DETAILSBUTTON.Name])
            {
                ARDDetailForm detForm = new ARDDetailForm();
                AnnualRequirementDetail ard = (AnnualRequirementDetail)XXXXXXDrugsOutGrid.CurrentCell.OwningRow.TTObject;
                detForm.ShowEdit(this.FindForm(), ard);
            }
#endregion AR_BaseForm_XXXXXXDrugsOutGrid_CellContentClick
        }

        private void KitsOutGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region AR_BaseForm_KitsOutGrid_CellContentClick
   if(KitsOutGrid.CurrentCell == null)
                return;
            
            if(KitsOutGrid.CurrentCell.OwningColumn == KitsOutGrid.Columns[KTO_DETAILSBUTTON.Name])
            {
                ARDDetailForm detForm = new ARDDetailForm();
                AnnualRequirementDetail ard = (AnnualRequirementDetail)KitsOutGrid.CurrentCell.OwningRow.TTObject;
                detForm.ShowEdit(this.FindForm(), ard);
            }
#endregion AR_BaseForm_KitsOutGrid_CellContentClick
        }

        private void VaccinesOutGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region AR_BaseForm_VaccinesOutGrid_CellContentClick
   if(VaccinesOutGrid.CurrentCell == null)
                return;
            
            if(VaccinesOutGrid.CurrentCell.OwningColumn == VaccinesOutGrid.Columns[VO_DETAILSBUTTON.Name])
            {
                ARDDetailForm detForm = new ARDDetailForm();
                AnnualRequirementDetail ard = (AnnualRequirementDetail)VaccinesOutGrid.CurrentCell.OwningRow.TTObject;
                detForm.ShowEdit(this.FindForm(), ard);
            }
#endregion AR_BaseForm_VaccinesOutGrid_CellContentClick
        }

        private void MedicalConsumablesOutGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region AR_BaseForm_MedicalConsumablesOutGrid_CellContentClick
   if(MedicalConsumablesOutGrid.CurrentCell == null)
                return;
            
            if(MedicalConsumablesOutGrid.CurrentCell.OwningColumn == MedicalConsumablesOutGrid.Columns[MCO_DETAILSBUTTON.Name])
            {
                ARDDetailForm detForm = new ARDDetailForm();
                AnnualRequirementDetail ard = (AnnualRequirementDetail)MedicalConsumablesOutGrid.CurrentCell.OwningRow.TTObject;
                detForm.ShowEdit(this.FindForm(), ard);
            }
#endregion AR_BaseForm_MedicalConsumablesOutGrid_CellContentClick
        }

        private void SparePartsOutGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region AR_BaseForm_SparePartsOutGrid_CellContentClick
   if(SparePartsOutGrid.CurrentCell == null)
                return;
            
            if(SparePartsOutGrid.CurrentCell.OwningColumn == SparePartsOutGrid.Columns[SPO_DETAILSBUTTON.Name])
            {
                ARDDetailForm detForm = new ARDDetailForm();
                AnnualRequirementDetail ard = (AnnualRequirementDetail)SparePartsOutGrid.CurrentCell.OwningRow.TTObject;
                detForm.ShowEdit(this.FindForm(), ard);
            }
#endregion AR_BaseForm_SparePartsOutGrid_CellContentClick
        }

        private void MilitaryDrugsOutGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region AR_BaseForm_MilitaryDrugsOutGrid_CellContentClick
   if(MilitaryDrugsOutGrid.CurrentCell == null)
                return;
            
            if(MilitaryDrugsOutGrid.CurrentCell.OwningColumn == MilitaryDrugsOutGrid.Columns[MIDO_DETAILSBUTTON.Name])
            {
                ARDDetailForm detForm = new ARDDetailForm();
                AnnualRequirementDetail ard = (AnnualRequirementDetail)MilitaryDrugsOutGrid.CurrentCell.OwningRow.TTObject;
                detForm.ShowEdit(this.FindForm(), ard);
            }
#endregion AR_BaseForm_MilitaryDrugsOutGrid_CellContentClick
        }

        private void SerumsOutGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region AR_BaseForm_SerumsOutGrid_CellContentClick
   if(SerumsOutGrid.CurrentCell == null)
                return;
            
            if(SerumsOutGrid.CurrentCell.OwningColumn == SerumsOutGrid.Columns[SO_DETAILSBUTTON.Name])
            {
                ARDDetailForm detForm = new ARDDetailForm();
                AnnualRequirementDetail ard = (AnnualRequirementDetail)SerumsOutGrid.CurrentCell.OwningRow.TTObject;
                detForm.ShowEdit(this.FindForm(), ard);
            }
#endregion AR_BaseForm_SerumsOutGrid_CellContentClick
        }

        private void MedicalEquipmentsOutGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region AR_BaseForm_MedicalEquipmentsOutGrid_CellContentClick
   if(MedicalEquipmentsOutGrid.CurrentCell == null)
                return;
            
            if(MedicalEquipmentsOutGrid.CurrentCell.OwningColumn == MedicalEquipmentsOutGrid.Columns[MEO_DETAILSBUTTON.Name])
            {
                ARDDetailForm detForm = new ARDDetailForm();
                AnnualRequirementDetail ard = (AnnualRequirementDetail)MedicalEquipmentsOutGrid.CurrentCell.OwningRow.TTObject;
                detForm.ShowEdit(this.FindForm(), ard);
            }
#endregion AR_BaseForm_MedicalEquipmentsOutGrid_CellContentClick
        }

        private void PrintedDocumentsOutGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region AR_BaseForm_PrintedDocumentsOutGrid_CellContentClick
   if(PrintedDocumentsOutGrid.CurrentCell == null)
                return;
            
            if(PrintedDocumentsOutGrid.CurrentCell.OwningColumn == PrintedDocumentsOutGrid.Columns[PDO_DETAILSBUTTON.Name])
            {
                ARDDetailForm detForm = new ARDDetailForm();
                AnnualRequirementDetail ard = (AnnualRequirementDetail)PrintedDocumentsOutGrid.CurrentCell.OwningRow.TTObject;
                detForm.ShowEdit(this.FindForm(), ard);
            }
#endregion AR_BaseForm_PrintedDocumentsOutGrid_CellContentClick
        }

        private void Print_ItemClicked(ITTToolStripItem item)
        {
#region AR_BaseForm_Print_ItemClicked
   Dictionary<string, TTReportTool.PropertyCache<object>> parameter = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
            objectID.Add("VALUE", _AnnualRequirement.ObjectID.ToString());
            parameter.Add("TTOBJECTID", objectID);
            
            if(item.Name == "IBFReport")
            {
                switch (_AnnualRequirement.IBFType)
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
                if(_AnnualRequirement.AnnualRequirementDetailOutOfLists.Count > 0)
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_EkliListeReport), true, 1, parameter);
                else
                    InfoBox.Show(SystemMessage.GetMessage(67));
            }
#endregion AR_BaseForm_Print_ItemClicked
        }

        protected override void PreScript()
        {
#region AR_BaseForm_PreScript
    base.PreScript();
            
            ShowNeededGrids();
            
            if(_AnnualRequirement.CurrentStateDefID != null && _AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LogBrIBFRegisrty)
                this.Print.Visible = false;
            
            if(_AnnualRequirement.CurrentStateDefID != null && _AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.Completed)
                this.Print.Enabled = true;
#endregion AR_BaseForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region AR_BaseForm_PostScript
    base.PostScript(transDef);
            
            if(_AnnualRequirement.TransDef != null)
            {
                bool haveDetail = _AnnualRequirement.HaveDetails();
                if(!haveDetail)
                    throw new TTUtils.TTException(SystemMessage.GetMessage(68));
                
                string nulls = _AnnualRequirement.NullAmounts();
                
                if(string.IsNullOrEmpty(nulls) == false)
                    throw new TTUtils.TTException(SystemMessage.GetMessage(69) + nulls);
            }
#endregion AR_BaseForm_PostScript

            }
            
#region AR_BaseForm_Methods
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
            
            if(_AnnualRequirement.IBFType == null)
                return;
            
            int iType = Convert.ToInt32(_AnnualRequirement.IBFType.Value);
            //int ibfYear = ((DateTime)Common.RecTime()).Year;
            int ibfYear = Convert.ToInt32(_AnnualRequirement.IBFYear);
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
                    
                    if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LogBrIBFRegisrty)
                    {
                        MarketDrugsInGrid.Columns[MDI_REQUESTAMOUNT.Name].Visible = true;
                        MarketDrugsOutGrid.Columns[MDO_REQUESTAMOUNT.Name].Visible = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.AccountancyApproval)
                    {
                        MarketDrugsInGrid.Columns[MDI_REQUESTAMOUNT.Name].Visible = true;
                        MarketDrugsInGrid.Columns[MDI_ACC_APPROVEAMOUNT.Name].Visible = true;
                        MarketDrugsOutGrid.Columns[MDO_REQUESTAMOUNT.Name].Visible = true;
                        MarketDrugsOutGrid.Columns[MDO_ACC_APPROVEAMOUNT.Name].Visible = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LogBrApprove)
                    {
                        MarketDrugsInGrid.Columns[MDI_ACC_APPROVEAMOUNT.Name].Visible = true;
                        MarketDrugsInGrid.Columns[MDI_ACC_APPROVEAMOUNT.Name].HeaderText = "Talep Miktarı";
                        MarketDrugsInGrid.Columns[MDI_ACC_APPROVEAMOUNT.Name].ReadOnly = true;
                        MarketDrugsInGrid.Columns[MDI_LB_APPROVEAMOUNT.Name].Visible = true;
                        MarketDrugsOutGrid.Columns[MDO_ACC_APPROVEAMOUNT.Name].Visible = true;
                        MarketDrugsOutGrid.Columns[MDO_ACC_APPROVEAMOUNT.Name].HeaderText = "Talep Miktarı";
                        MarketDrugsOutGrid.Columns[MDO_ACC_APPROVEAMOUNT.Name].ReadOnly = true;
                        MarketDrugsOutGrid.Columns[MDO_LB_APPROVEAMOUNT.Name].Visible = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LDApprove)
                    {
                        MarketDrugsInGrid.Columns[MDI_LD_APPROVEAMOUNT.Name].Visible = true;
                        MarketDrugsInGrid.Columns[MDI_LB_APPROVEAMOUNT.Name].Visible = true;
                        MarketDrugsInGrid.Columns[MDI_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                        MarketDrugsOutGrid.Columns[MDO_LD_APPROVEAMOUNT.Name].Visible = true;
                        MarketDrugsOutGrid.Columns[MDO_LB_APPROVEAMOUNT.Name].Visible = true;
                        MarketDrugsOutGrid.Columns[MDO_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.Completed)
                    {
                        MarketDrugsInGrid.Columns[MDI_REQUESTAMOUNT.Name].Visible = false;
                        MarketDrugsInGrid.Columns[MDI_ACC_APPROVEAMOUNT.Name].Visible = false;
                        MarketDrugsInGrid.Columns[MDI_LB_APPROVEAMOUNT.Name].Visible = false;
                        MarketDrugsInGrid.Columns[MDI_LD_APPROVEAMOUNT.Name].Visible = true;
                        MarketDrugsOutGrid.Columns[MDO_REQUESTAMOUNT.Name].Visible = false;
                        MarketDrugsOutGrid.Columns[MDO_ACC_APPROVEAMOUNT.Name].Visible = false;
                        MarketDrugsOutGrid.Columns[MDO_LB_APPROVEAMOUNT.Name].Visible = false;
                        MarketDrugsOutGrid.Columns[MDO_LD_APPROVEAMOUNT.Name].Visible = true;
                    }
                    else
                    {
                        MarketDrugsInGrid.Columns[MDI_REQUESTAMOUNT.Name].Visible = true;
                        MarketDrugsInGrid.Columns[MDI_LB_APPROVEAMOUNT.Name].Visible = true;
                        MarketDrugsInGrid.Columns[MDI_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                        MarketDrugsOutGrid.Columns[MDO_REQUESTAMOUNT.Name].Visible = true;
                        MarketDrugsOutGrid.Columns[MDO_LB_APPROVEAMOUNT.Name].Visible = true;
                        MarketDrugsOutGrid.Columns[MDO_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                    }
                    
                    if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LDApprove || _AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.RegionalCommanderApprove || _AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.RegionalCommandLogBureauApproveForm)
                    {
                        MarketDrugsInGrid.Columns[MDI_DETAILSBUTTON.Name].Visible = false;
                        MarketDrugsOutGrid.Columns[MDO_DETAILSBUTTON.Name].Visible = false;
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
                    
                    if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LogBrIBFRegisrty)
                    {
                        MilitaryDrugsInGrid.Columns[MIDI_REQUESTAMOUNT.Name].Visible = true;
                        MilitaryDrugsOutGrid.Columns[MIDO_REQUESTAMOUNT.Name].Visible = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.AccountancyApproval)
                    {
                        MilitaryDrugsInGrid.Columns[MIDI_REQUESTAMOUNT.Name].Visible = true;
                        MilitaryDrugsInGrid.Columns[MIDI_ACC_APPROVEAMOUNT.Name].Visible = true;
                        MilitaryDrugsOutGrid.Columns[MIDO_REQUESTAMOUNT.Name].Visible = true;
                        MilitaryDrugsOutGrid.Columns[MIDO_ACC_APPROVEAMOUNT.Name].Visible = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LogBrApprove)
                    {
                        MilitaryDrugsInGrid.Columns[MIDI_ACC_APPROVEAMOUNT.Name].Visible = true;
                        MilitaryDrugsInGrid.Columns[MIDI_ACC_APPROVEAMOUNT.Name].HeaderText = "Talep Miktarı";
                        MilitaryDrugsInGrid.Columns[MIDI_ACC_APPROVEAMOUNT.Name].ReadOnly = true;
                        MilitaryDrugsInGrid.Columns[MIDI_LB_APPROVEAMOUNT.Name].Visible = true;
                        MilitaryDrugsOutGrid.Columns[MIDO_ACC_APPROVEAMOUNT.Name].Visible = true;
                        MilitaryDrugsOutGrid.Columns[MIDO_ACC_APPROVEAMOUNT.Name].HeaderText = "Talep Miktarı";
                        MilitaryDrugsOutGrid.Columns[MIDO_ACC_APPROVEAMOUNT.Name].ReadOnly = true;
                        MilitaryDrugsOutGrid.Columns[MIDO_LB_APPROVEAMOUNT.Name].Visible = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LDApprove)
                    {
                        MilitaryDrugsInGrid.Columns[MIDI_LD_APPROVEAMOUNT.Name].Visible = true;
                        MilitaryDrugsInGrid.Columns[MIDI_LB_APPROVEAMOUNT.Name].Visible = true;
                        MilitaryDrugsInGrid.Columns[MIDI_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                        MilitaryDrugsOutGrid.Columns[MIDO_LD_APPROVEAMOUNT.Name].Visible = true;
                        MilitaryDrugsOutGrid.Columns[MIDO_LB_APPROVEAMOUNT.Name].Visible = true;
                        MilitaryDrugsOutGrid.Columns[MIDO_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.Completed)
                    {
                        MilitaryDrugsInGrid.Columns[MIDI_REQUESTAMOUNT.Name].Visible = false;
                        MilitaryDrugsInGrid.Columns[MIDI_ACC_APPROVEAMOUNT.Name].Visible = false;
                        MilitaryDrugsInGrid.Columns[MIDI_LB_APPROVEAMOUNT.Name].Visible = false;
                        MilitaryDrugsInGrid.Columns[MIDI_LD_APPROVEAMOUNT.Name].Visible = true;
                        MilitaryDrugsOutGrid.Columns[MIDO_REQUESTAMOUNT.Name].Visible = false;
                        MilitaryDrugsOutGrid.Columns[MIDO_ACC_APPROVEAMOUNT.Name].Visible = false;
                        MilitaryDrugsOutGrid.Columns[MIDO_LB_APPROVEAMOUNT.Name].Visible = false;
                        MilitaryDrugsOutGrid.Columns[MIDO_LD_APPROVEAMOUNT.Name].Visible = true;
                    }
                    else
                    {
                        MilitaryDrugsInGrid.Columns[MIDI_REQUESTAMOUNT.Name].Visible = true;
                        MilitaryDrugsInGrid.Columns[MIDI_LB_APPROVEAMOUNT.Name].Visible = true;
                        MilitaryDrugsInGrid.Columns[MIDI_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                        MilitaryDrugsOutGrid.Columns[MIDO_REQUESTAMOUNT.Name].Visible = true;
                        MilitaryDrugsOutGrid.Columns[MIDO_LB_APPROVEAMOUNT.Name].Visible = true;
                        MilitaryDrugsOutGrid.Columns[MIDO_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                    }
                    
                    if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LDApprove || _AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.RegionalCommanderApprove || _AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.RegionalCommandLogBureauApproveForm)
                    {
                        MilitaryDrugsInGrid.Columns[MIDI_DETAILSBUTTON.Name].Visible = false;
                        MilitaryDrugsOutGrid.Columns[MIDO_DETAILSBUTTON.Name].Visible = false;
                    }
                    
                    break;

                case 2: //XXXXXX İlaç
                    XXXXXXDrugsInGrid.Visible = true;
                    //XXXXXXDrugsInGrid.Dock = /DockStyle.Fill;
                    XXXXXXDrugsInGrid.Columns[GDI_LASTIBFREQUESTAMOUNT.Name].HeaderText = XXXXXXDrugsInGrid.Columns[GDI_LASTIBFREQUESTAMOUNT.Name].HeaderText.Replace("xxx", (ibfYear - 1).ToString());
                    XXXXXXDrugsOutGrid.Visible = true;
                    //XXXXXXDrugsOutGrid.Dock = DockStyle.Fill;
                    XXXXXXDrugsOutGrid.Columns[GDO_LASTIBFREQUESTAMOUNT.Name].HeaderText = XXXXXXDrugsOutGrid.Columns[GDO_LASTIBFREQUESTAMOUNT.Name].HeaderText.Replace("xxx", (ibfYear - 1).ToString());
                    
                    if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LogBrIBFRegisrty)
                    {
                        XXXXXXDrugsInGrid.Columns[GDI_REQUESTAMOUNT.Name].Visible = true;
                        XXXXXXDrugsOutGrid.Columns[GDO_REQUESTAMOUNT.Name].Visible = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.AccountancyApproval)
                    {
                        XXXXXXDrugsInGrid.Columns[GDI_REQUESTAMOUNT.Name].Visible = true;
                        XXXXXXDrugsInGrid.Columns[GDI_ACC_APPROVEAMOUNT.Name].Visible = true;
                        XXXXXXDrugsOutGrid.Columns[GDO_REQUESTAMOUNT.Name].Visible = true;
                        XXXXXXDrugsOutGrid.Columns[GDO_ACC_APPROVEAMOUNT.Name].Visible = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LogBrApprove)
                    {
                        XXXXXXDrugsInGrid.Columns[GDI_ACC_APPROVEAMOUNT.Name].Visible = true;
                        XXXXXXDrugsInGrid.Columns[GDI_ACC_APPROVEAMOUNT.Name].HeaderText = "Talep Miktarı";
                        XXXXXXDrugsInGrid.Columns[GDI_ACC_APPROVEAMOUNT.Name].ReadOnly = true;
                        XXXXXXDrugsInGrid.Columns[GDI_LB_APPROVEAMOUNT.Name].Visible = true;
                        XXXXXXDrugsOutGrid.Columns[GDO_ACC_APPROVEAMOUNT.Name].Visible = true;
                        XXXXXXDrugsOutGrid.Columns[GDO_ACC_APPROVEAMOUNT.Name].HeaderText = "Talep Miktarı";
                        XXXXXXDrugsOutGrid.Columns[GDO_ACC_APPROVEAMOUNT.Name].ReadOnly = true;
                        XXXXXXDrugsOutGrid.Columns[GDO_LB_APPROVEAMOUNT.Name].Visible = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LDApprove)
                    {
                        XXXXXXDrugsInGrid.Columns[GDI_LD_APPROVEAMOUNT.Name].Visible = true;
                        XXXXXXDrugsInGrid.Columns[GDI_LB_APPROVEAMOUNT.Name].Visible = true;
                        XXXXXXDrugsInGrid.Columns[GDI_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                        XXXXXXDrugsOutGrid.Columns[GDO_LD_APPROVEAMOUNT.Name].Visible = true;
                        XXXXXXDrugsOutGrid.Columns[GDO_LB_APPROVEAMOUNT.Name].Visible = true;
                        XXXXXXDrugsOutGrid.Columns[GDO_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.Completed)
                    {
                        XXXXXXDrugsInGrid.Columns[GDI_REQUESTAMOUNT.Name].Visible = false;
                        XXXXXXDrugsInGrid.Columns[GDI_ACC_APPROVEAMOUNT.Name].Visible = false;
                        XXXXXXDrugsInGrid.Columns[GDI_LB_APPROVEAMOUNT.Name].Visible = false;
                        XXXXXXDrugsInGrid.Columns[GDI_LD_APPROVEAMOUNT.Name].Visible = true;
                        XXXXXXDrugsOutGrid.Columns[GDO_REQUESTAMOUNT.Name].Visible = false;
                        XXXXXXDrugsOutGrid.Columns[GDO_ACC_APPROVEAMOUNT.Name].Visible = false;
                        XXXXXXDrugsOutGrid.Columns[GDO_LB_APPROVEAMOUNT.Name].Visible = false;
                        XXXXXXDrugsOutGrid.Columns[GDO_LD_APPROVEAMOUNT.Name].Visible = true;
                    }
                    else
                    {
                        XXXXXXDrugsInGrid.Columns[GDI_REQUESTAMOUNT.Name].Visible = true;
                        XXXXXXDrugsInGrid.Columns[GDI_LB_APPROVEAMOUNT.Name].Visible = true;
                        XXXXXXDrugsInGrid.Columns[GDI_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                        XXXXXXDrugsOutGrid.Columns[GDO_REQUESTAMOUNT.Name].Visible = true;
                        XXXXXXDrugsOutGrid.Columns[GDO_LB_APPROVEAMOUNT.Name].Visible = true;
                        XXXXXXDrugsOutGrid.Columns[GDO_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                    }
                    
                    if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LDApprove || _AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.RegionalCommanderApprove || _AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.RegionalCommandLogBureauApproveForm)
                    {
                        XXXXXXDrugsInGrid.Columns[GDI_DETAILSBUTTON.Name].Visible = false;
                        XXXXXXDrugsOutGrid.Columns[GDO_DETAILSBUTTON.Name].Visible = false;
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
                    
                    if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LogBrIBFRegisrty)
                    {
                        MedicalConsumablesInGrid.Columns[MCI_REQUESTAMOUNT.Name].Visible = true;
                        MedicalConsumablesOutGrid.Columns[MCO_REQUESTAMOUNT.Name].Visible = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.AccountancyApproval)
                    {
                        MedicalConsumablesInGrid.Columns[MCI_REQUESTAMOUNT.Name].Visible = true;
                        MedicalConsumablesInGrid.Columns[MCI_ACC_APPROVEAMOUNT.Name].Visible = true;
                        MedicalConsumablesOutGrid.Columns[MCO_REQUESTAMOUNT.Name].Visible = true;
                        MedicalConsumablesOutGrid.Columns[MCO_ACC_APPROVEAMOUNT.Name].Visible = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LogBrApprove)
                    {
                        MedicalConsumablesInGrid.Columns[MCI_ACC_APPROVEAMOUNT.Name].Visible = true;
                        MedicalConsumablesInGrid.Columns[MCI_ACC_APPROVEAMOUNT.Name].HeaderText = "Talep Miktarı";
                        MedicalConsumablesInGrid.Columns[MCI_ACC_APPROVEAMOUNT.Name].ReadOnly = true;
                        MedicalConsumablesInGrid.Columns[MCI_LB_APPROVEAMOUNT.Name].Visible = true;
                        MedicalConsumablesOutGrid.Columns[MCO_ACC_APPROVEAMOUNT.Name].Visible = true;
                        MedicalConsumablesOutGrid.Columns[MCO_ACC_APPROVEAMOUNT.Name].HeaderText = "Talep Miktarı";
                        MedicalConsumablesOutGrid.Columns[MCO_ACC_APPROVEAMOUNT.Name].ReadOnly = true;
                        MedicalConsumablesOutGrid.Columns[MCO_LB_APPROVEAMOUNT.Name].Visible = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LDApprove)
                    {
                        MedicalConsumablesInGrid.Columns[MCI_LD_APPROVEAMOUNT.Name].Visible = true;
                        MedicalConsumablesInGrid.Columns[MCI_LB_APPROVEAMOUNT.Name].Visible = true;
                        MedicalConsumablesInGrid.Columns[MCI_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                        MedicalConsumablesOutGrid.Columns[MCO_LD_APPROVEAMOUNT.Name].Visible = true;
                        MedicalConsumablesOutGrid.Columns[MCO_LB_APPROVEAMOUNT.Name].Visible = true;
                        MedicalConsumablesOutGrid.Columns[MCO_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.Completed)
                    {
                        MedicalConsumablesInGrid.Columns[MCI_REQUESTAMOUNT.Name].Visible = false;
                        MedicalConsumablesInGrid.Columns[MCI_ACC_APPROVEAMOUNT.Name].Visible = false;
                        MedicalConsumablesInGrid.Columns[MCI_LB_APPROVEAMOUNT.Name].Visible = false;
                        MedicalConsumablesInGrid.Columns[MCI_LD_APPROVEAMOUNT.Name].Visible = true;
                        MedicalConsumablesOutGrid.Columns[MCO_REQUESTAMOUNT.Name].Visible = false;
                        MedicalConsumablesOutGrid.Columns[MCO_ACC_APPROVEAMOUNT.Name].Visible = false;
                        MedicalConsumablesOutGrid.Columns[MCO_LB_APPROVEAMOUNT.Name].Visible = false;
                        MedicalConsumablesOutGrid.Columns[MCO_LD_APPROVEAMOUNT.Name].Visible = true;
                    }
                    else
                    {
                        MedicalConsumablesInGrid.Columns[MCI_REQUESTAMOUNT.Name].Visible = true;
                        MedicalConsumablesInGrid.Columns[MCI_LB_APPROVEAMOUNT.Name].Visible = true;
                        MedicalConsumablesInGrid.Columns[MCI_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                        MedicalConsumablesOutGrid.Columns[MCO_REQUESTAMOUNT.Name].Visible = true;
                        MedicalConsumablesOutGrid.Columns[MCO_LB_APPROVEAMOUNT.Name].Visible = true;
                        MedicalConsumablesOutGrid.Columns[MCO_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                    }
                    
                    if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LDApprove || _AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.RegionalCommanderApprove || _AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.RegionalCommandLogBureauApproveForm)
                    {
                        MedicalConsumablesInGrid.Columns[MCI_DETAILSBUTTON.Name].Visible = false;
                        MedicalConsumablesOutGrid.Columns[MCO_DETAILSBUTTON.Name].Visible = false;
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
                    
                    if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LogBrIBFRegisrty)
                    {
                        MedicalEquipmentsInGrid.Columns[MEI_REQUESTAMOUNT.Name].Visible = true;
                        MedicalEquipmentsOutGrid.Columns[MEO_REQUESTAMOUNT.Name].Visible = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.AccountancyApproval)
                    {
                        MedicalEquipmentsInGrid.Columns[MEI_REQUESTAMOUNT.Name].Visible = true;
                        MedicalEquipmentsInGrid.Columns[MEI_ACC_APPROVEAMOUNT.Name].Visible = true;
                        MedicalEquipmentsOutGrid.Columns[MEO_REQUESTAMOUNT.Name].Visible = true;
                        MedicalEquipmentsOutGrid.Columns[MEO_ACC_APPROVEAMOUNT.Name].Visible = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LogBrApprove)
                    {
                        MedicalEquipmentsInGrid.Columns[MEI_ACC_APPROVEAMOUNT.Name].Visible = true;
                        MedicalEquipmentsInGrid.Columns[MEI_ACC_APPROVEAMOUNT.Name].HeaderText = "Talep Miktarı";
                        MedicalEquipmentsInGrid.Columns[MEI_ACC_APPROVEAMOUNT.Name].ReadOnly = true;
                        MedicalEquipmentsInGrid.Columns[MEI_LB_APPROVEAMOUNT.Name].Visible = true;
                        MedicalEquipmentsOutGrid.Columns[MEO_ACC_APPROVEAMOUNT.Name].Visible = true;
                        MedicalEquipmentsOutGrid.Columns[MEO_ACC_APPROVEAMOUNT.Name].HeaderText = "Talep Miktarı";
                        MedicalEquipmentsOutGrid.Columns[MEO_ACC_APPROVEAMOUNT.Name].ReadOnly = true;
                        MedicalEquipmentsOutGrid.Columns[MEO_LB_APPROVEAMOUNT.Name].Visible = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LDApprove)
                    {
                        MedicalEquipmentsInGrid.Columns[MEI_LD_APPROVEAMOUNT.Name].Visible = true;
                        MedicalEquipmentsInGrid.Columns[MEI_LB_APPROVEAMOUNT.Name].Visible = true;
                        MedicalEquipmentsInGrid.Columns[MEI_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                        MedicalEquipmentsOutGrid.Columns[MEO_LD_APPROVEAMOUNT.Name].Visible = true;
                        MedicalEquipmentsOutGrid.Columns[MEO_LB_APPROVEAMOUNT.Name].Visible = true;
                        MedicalEquipmentsOutGrid.Columns[MEO_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.Completed)
                    {
                        MedicalEquipmentsInGrid.Columns[MEI_REQUESTAMOUNT.Name].Visible = false;
                        MedicalEquipmentsInGrid.Columns[MEI_ACC_APPROVEAMOUNT.Name].Visible = false;
                        MedicalEquipmentsInGrid.Columns[MEI_LB_APPROVEAMOUNT.Name].Visible = false;
                        MedicalEquipmentsInGrid.Columns[MEI_LD_APPROVEAMOUNT.Name].Visible = true;
                        MedicalEquipmentsOutGrid.Columns[MEO_REQUESTAMOUNT.Name].Visible = false;
                        MedicalEquipmentsOutGrid.Columns[MEO_ACC_APPROVEAMOUNT.Name].Visible = false;
                        MedicalEquipmentsOutGrid.Columns[MEO_LB_APPROVEAMOUNT.Name].Visible = false;
                        MedicalEquipmentsOutGrid.Columns[MEO_LD_APPROVEAMOUNT.Name].Visible = true;
                    }
                    else
                    {
                        MedicalEquipmentsInGrid.Columns[MEI_REQUESTAMOUNT.Name].Visible = true;
                        MedicalEquipmentsInGrid.Columns[MEI_LB_APPROVEAMOUNT.Name].Visible = true;
                        MedicalEquipmentsInGrid.Columns[MEI_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                        MedicalEquipmentsOutGrid.Columns[MEO_REQUESTAMOUNT.Name].Visible = true;
                        MedicalEquipmentsOutGrid.Columns[MEO_LB_APPROVEAMOUNT.Name].Visible = true;
                        MedicalEquipmentsOutGrid.Columns[MEO_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                    }
                    
                    if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LDApprove || _AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.RegionalCommanderApprove || _AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.RegionalCommandLogBureauApproveForm)
                    {
                        MedicalEquipmentsInGrid.Columns[MEI_DETAILSBUTTON.Name].Visible = false;
                        MedicalEquipmentsOutGrid.Columns[MEO_DETAILSBUTTON.Name].Visible = false;
                    }
                    
                    break;

                case 5: //Yedek Parça
                    SparePartsInGrid.Visible = true;
                    //SparePartsInGrid.Dock = DockStyle.Fill;
                    SparePartsInGrid.Columns[SPI_CONSUMPTIONAMOUNT.Name].HeaderText = SparePartsInGrid.Columns[SPI_CONSUMPTIONAMOUNT.Name].HeaderText.Replace("xxx", (ibfYear - 1).ToString());
                    SparePartsOutGrid.Visible = true;
                    //SparePartsOutGrid.Dock = DockStyle.Fill;
                    SparePartsOutGrid.Columns[SPO_CONSUMPTIONAMOUNT.Name].HeaderText = SparePartsOutGrid.Columns[SPO_CONSUMPTIONAMOUNT.Name].HeaderText.Replace("xxx", (ibfYear - 1).ToString());
                    
                    if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LogBrIBFRegisrty)
                    {
                        SparePartsInGrid.Columns[SPI_REQUESTAMOUNT.Name].Visible = true;
                        SparePartsOutGrid.Columns[SPO_REQUESTAMOUNT.Name].Visible = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.AccountancyApproval)
                    {
                        SparePartsInGrid.Columns[SPI_REQUESTAMOUNT.Name].Visible = true;
                        SparePartsInGrid.Columns[SPI_ACC_APPROVEAMOUNT.Name].Visible = true;
                        SparePartsOutGrid.Columns[SPO_REQUESTAMOUNT.Name].Visible = true;
                        SparePartsOutGrid.Columns[SPO_ACC_APPROVEAMOUNT.Name].Visible = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LogBrApprove)
                    {
                        SparePartsInGrid.Columns[SPI_ACC_APPROVEAMOUNT.Name].Visible = true;
                        SparePartsInGrid.Columns[SPI_ACC_APPROVEAMOUNT.Name].HeaderText = "Talep Miktarı";
                        SparePartsInGrid.Columns[SPI_ACC_APPROVEAMOUNT.Name].ReadOnly = true;
                        SparePartsInGrid.Columns[SPI_LB_APPROVEAMOUNT.Name].Visible = true;
                        SparePartsOutGrid.Columns[SPO_ACC_APPROVEAMOUNT.Name].Visible = true;
                        SparePartsOutGrid.Columns[SPO_ACC_APPROVEAMOUNT.Name].HeaderText = "Talep Miktarı";
                        SparePartsOutGrid.Columns[SPO_ACC_APPROVEAMOUNT.Name].ReadOnly = true;
                        SparePartsOutGrid.Columns[SPO_LB_APPROVEAMOUNT.Name].Visible = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LDApprove)
                    {
                        SparePartsInGrid.Columns[SPI_LD_APPROVEAMOUNT.Name].Visible = true;
                        SparePartsInGrid.Columns[SPI_LB_APPROVEAMOUNT.Name].Visible = true;
                        SparePartsInGrid.Columns[SPI_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                        SparePartsOutGrid.Columns[SPO_LD_APPROVEAMOUNT.Name].Visible = true;
                        SparePartsOutGrid.Columns[SPO_LB_APPROVEAMOUNT.Name].Visible = true;
                        SparePartsOutGrid.Columns[SPO_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.Completed)
                    {
                        SparePartsInGrid.Columns[SPI_REQUESTAMOUNT.Name].Visible = false;
                        SparePartsInGrid.Columns[SPI_ACC_APPROVEAMOUNT.Name].Visible = false;
                        SparePartsInGrid.Columns[SPI_LB_APPROVEAMOUNT.Name].Visible = false;
                        SparePartsInGrid.Columns[SPI_LD_APPROVEAMOUNT.Name].Visible = true;
                        SparePartsOutGrid.Columns[SPO_REQUESTAMOUNT.Name].Visible = false;
                        SparePartsOutGrid.Columns[SPO_ACC_APPROVEAMOUNT.Name].Visible = false;
                        SparePartsOutGrid.Columns[SPO_LB_APPROVEAMOUNT.Name].Visible = false;
                        SparePartsOutGrid.Columns[SPO_LD_APPROVEAMOUNT.Name].Visible = true;
                    }
                    else
                    {
                        SparePartsInGrid.Columns[SPI_REQUESTAMOUNT.Name].Visible = true;
                        SparePartsInGrid.Columns[SPI_LB_APPROVEAMOUNT.Name].Visible = true;
                        SparePartsInGrid.Columns[SPI_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                        SparePartsOutGrid.Columns[SPO_REQUESTAMOUNT.Name].Visible = true;
                        SparePartsOutGrid.Columns[SPO_LB_APPROVEAMOUNT.Name].Visible = true;
                        SparePartsOutGrid.Columns[SPO_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                    }
                    
                    if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LDApprove || _AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.RegionalCommanderApprove || _AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.RegionalCommandLogBureauApproveForm)
                    {
                        SparePartsInGrid.Columns[SPI_DETAILSBUTTON.Name].Visible = false;
                        SparePartsOutGrid.Columns[SPO_DETAILSBUTTON.Name].Visible = false;
                    }
                    
                    break;

                case 6: //Serum
                    SerumsInGrid.Visible = true;
                    //SerumsInGrid.Dock = DockStyle.Fill;
                    SerumsInGrid.Columns[SI_CONSUMPTIONAMOUNT.Name].HeaderText = SerumsInGrid.Columns[SI_CONSUMPTIONAMOUNT.Name].HeaderText.Replace("xxx", (ibfYear - 2).ToString());
                    SerumsInGrid.Columns[SI_LASTIBFREQUESTAMOUNT.Name].HeaderText = SerumsInGrid.Columns[SI_LASTIBFREQUESTAMOUNT.Name].HeaderText.Replace("xxx", (ibfYear - 1).ToString());
                    SerumsOutGrid.Visible = true;
                    //SerumsOutGrid.Dock = DockStyle.Fill;
                    SerumsOutGrid.Columns[SO_CONSUMPTIONAMOUNT.Name].HeaderText = SerumsOutGrid.Columns[SO_CONSUMPTIONAMOUNT.Name].HeaderText.Replace("xxx", (ibfYear - 2).ToString());
                    SerumsOutGrid.Columns[SO_LASTIBFREQUESTAMOUNT.Name].HeaderText = SerumsOutGrid.Columns[SO_LASTIBFREQUESTAMOUNT.Name].HeaderText.Replace("xxx", (ibfYear - 1).ToString());
                    
                    if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LogBrIBFRegisrty)
                    {
                        SerumsInGrid.Columns[SI_REQUESTAMOUNT.Name].Visible = true;
                        SerumsOutGrid.Columns[SO_REQUESTAMOUNT.Name].Visible = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.AccountancyApproval)
                    {
                        SerumsInGrid.Columns[SI_REQUESTAMOUNT.Name].Visible = true;
                        SerumsInGrid.Columns[SI_ACC_APPROVEAMOUNT.Name].Visible = true;
                        SerumsOutGrid.Columns[SO_REQUESTAMOUNT.Name].Visible = true;
                        SerumsOutGrid.Columns[SO_ACC_APPROVEAMOUNT.Name].Visible = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LogBrApprove)
                    {
                        SerumsInGrid.Columns[SI_ACC_APPROVEAMOUNT.Name].Visible = true;
                        SerumsInGrid.Columns[SI_ACC_APPROVEAMOUNT.Name].HeaderText = "Talep Miktarı";
                        SerumsInGrid.Columns[SI_ACC_APPROVEAMOUNT.Name].ReadOnly = true;
                        SerumsInGrid.Columns[SI_LB_APPROVEAMOUNT.Name].Visible = true;
                        SerumsOutGrid.Columns[SO_ACC_APPROVEAMOUNT.Name].Visible = true;
                        SerumsOutGrid.Columns[SO_ACC_APPROVEAMOUNT.Name].HeaderText = "Talep Miktarı";
                        SerumsOutGrid.Columns[SO_ACC_APPROVEAMOUNT.Name].ReadOnly = true;
                        SerumsOutGrid.Columns[SO_LB_APPROVEAMOUNT.Name].Visible = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LDApprove)
                    {
                        SerumsInGrid.Columns[SI_LD_APPROVEAMOUNT.Name].Visible = true;
                        SerumsInGrid.Columns[SI_LB_APPROVEAMOUNT.Name].Visible = true;
                        SerumsInGrid.Columns[SI_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                        SerumsOutGrid.Columns[SO_LD_APPROVEAMOUNT.Name].Visible = true;
                        SerumsOutGrid.Columns[SO_LB_APPROVEAMOUNT.Name].Visible = true;
                        SerumsOutGrid.Columns[SO_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.Completed)
                    {
                        SerumsInGrid.Columns[SI_REQUESTAMOUNT.Name].Visible = false;
                        SerumsInGrid.Columns[SI_ACC_APPROVEAMOUNT.Name].Visible = false;
                        SerumsInGrid.Columns[SI_LB_APPROVEAMOUNT.Name].Visible = false;
                        SerumsInGrid.Columns[SI_LD_APPROVEAMOUNT.Name].Visible = true;
                        SerumsOutGrid.Columns[SO_REQUESTAMOUNT.Name].Visible = false;
                        SerumsOutGrid.Columns[SO_ACC_APPROVEAMOUNT.Name].Visible = false;
                        SerumsOutGrid.Columns[SO_LB_APPROVEAMOUNT.Name].Visible = false;
                        SerumsOutGrid.Columns[SO_LD_APPROVEAMOUNT.Name].Visible = true;
                    }
                    else
                    {
                        SerumsInGrid.Columns[SI_REQUESTAMOUNT.Name].Visible = true;
                        SerumsInGrid.Columns[SI_LB_APPROVEAMOUNT.Name].Visible = true;
                        SerumsInGrid.Columns[SI_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                        SerumsOutGrid.Columns[SO_REQUESTAMOUNT.Name].Visible = true;
                        SerumsOutGrid.Columns[SO_LB_APPROVEAMOUNT.Name].Visible = true;
                        SerumsOutGrid.Columns[SO_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                    }
                    
                    if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LDApprove || _AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.RegionalCommanderApprove || _AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.RegionalCommandLogBureauApproveForm)
                    {
                        SerumsInGrid.Columns[SI_DETAILSBUTTON.Name].Visible = false;
                        SerumsOutGrid.Columns[SO_DETAILSBUTTON.Name].Visible = false;
                    }
                    
                    break;

                case 7: //Kit
                    KitsInGrid.Visible = true;
                    //KitsInGrid.Dock = DockStyle.Fill;
                    KitsOutGrid.Visible = true;
                    //KitsOutGrid.Dock = DockStyle.Fill;
                    
                    if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LogBrIBFRegisrty)
                    {
                        KitsInGrid.Columns[KTI_REQUESTAMOUNT.Name].Visible = true;
                        KitsOutGrid.Columns[KTO_REQUESTAMOUNT.Name].Visible = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.AccountancyApproval)
                    {
                        KitsInGrid.Columns[KTI_REQUESTAMOUNT.Name].Visible = true;
                        KitsInGrid.Columns[KTI_ACC_APPROVEAMOUNT.Name].Visible = true;
                        KitsOutGrid.Columns[KTO_REQUESTAMOUNT.Name].Visible = true;
                        KitsOutGrid.Columns[KTO_ACC_APPROVEAMOUNT.Name].Visible = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LogBrApprove)
                    {
                        KitsInGrid.Columns[KTI_ACC_APPROVEAMOUNT.Name].Visible = true;
                        KitsInGrid.Columns[KTI_ACC_APPROVEAMOUNT.Name].HeaderText = "Talep Miktarı";
                        KitsInGrid.Columns[KTI_ACC_APPROVEAMOUNT.Name].ReadOnly = true;
                        KitsInGrid.Columns[KTI_LB_APPROVEAMOUNT.Name].Visible = true;
                        KitsOutGrid.Columns[KTO_ACC_APPROVEAMOUNT.Name].Visible = true;
                        KitsOutGrid.Columns[KTO_ACC_APPROVEAMOUNT.Name].HeaderText = "Talep Miktarı";
                        KitsOutGrid.Columns[KTO_ACC_APPROVEAMOUNT.Name].ReadOnly = true;
                        KitsOutGrid.Columns[KTO_LB_APPROVEAMOUNT.Name].Visible = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LDApprove)
                    {
                        KitsInGrid.Columns[KTI_LD_APPROVEAMOUNT.Name].Visible = true;
                        KitsInGrid.Columns[KTI_LB_APPROVEAMOUNT.Name].Visible = true;
                        KitsInGrid.Columns[KTI_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                        KitsOutGrid.Columns[KTO_LD_APPROVEAMOUNT.Name].Visible = true;
                        KitsOutGrid.Columns[KTO_LB_APPROVEAMOUNT.Name].Visible = true;
                        KitsOutGrid.Columns[KTO_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.Completed)
                    {
                        KitsInGrid.Columns[KTI_REQUESTAMOUNT.Name].Visible = false;
                        KitsInGrid.Columns[KTI_ACC_APPROVEAMOUNT.Name].Visible = false;
                        KitsInGrid.Columns[KTI_LB_APPROVEAMOUNT.Name].Visible = false;
                        KitsInGrid.Columns[KTI_LD_APPROVEAMOUNT.Name].Visible = true;
                        KitsOutGrid.Columns[KTO_REQUESTAMOUNT.Name].Visible = false;
                        KitsOutGrid.Columns[KTO_ACC_APPROVEAMOUNT.Name].Visible = false;
                        KitsOutGrid.Columns[KTO_LB_APPROVEAMOUNT.Name].Visible = false;
                        KitsOutGrid.Columns[KTO_LD_APPROVEAMOUNT.Name].Visible = true;
                    }
                    else
                    {
                        KitsInGrid.Columns[KTI_REQUESTAMOUNT.Name].Visible = true;
                        KitsInGrid.Columns[KTI_LB_APPROVEAMOUNT.Name].Visible = true;
                        KitsInGrid.Columns[KTI_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                        KitsOutGrid.Columns[KTO_REQUESTAMOUNT.Name].Visible = true;
                        KitsOutGrid.Columns[KTO_LB_APPROVEAMOUNT.Name].Visible = true;
                        KitsOutGrid.Columns[KTO_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                    }
                    
                    if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LDApprove || _AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.RegionalCommanderApprove || _AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.RegionalCommandLogBureauApproveForm)
                    {
                        KitsInGrid.Columns[KTI_DETAILSBUTTON.Name].Visible = false;
                        KitsOutGrid.Columns[KTO_DETAILSBUTTON.Name].Visible = false;
                    }
                    
                    break;

                case 8: //Basılı Evrak
                    PrintedDocumentsInGrid.Visible = true;
                    //PrintedDocumentsInGrid.Dock = DockStyle.Fill;
                    PrintedDocumentsOutGrid.Visible = true;
                    //PrintedDocumentsOutGrid.Dock = DockStyle.Fill;
                    
                    if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LogBrIBFRegisrty)
                    {
                        PrintedDocumentsInGrid.Columns[PDI_REQUESTAMOUNT.Name].Visible = true;
                        PrintedDocumentsOutGrid.Columns[PDO_REQUESTAMOUNT.Name].Visible = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.AccountancyApproval)
                    {
                        PrintedDocumentsInGrid.Columns[PDI_REQUESTAMOUNT.Name].Visible = true;
                        PrintedDocumentsInGrid.Columns[PDI_ACC_APPROVEAMOUNT.Name].Visible = true;
                        PrintedDocumentsOutGrid.Columns[PDO_REQUESTAMOUNT.Name].Visible = true;
                        PrintedDocumentsOutGrid.Columns[PDO_ACC_APPROVEAMOUNT.Name].Visible = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LogBrApprove)
                    {
                        PrintedDocumentsInGrid.Columns[PDI_ACC_APPROVEAMOUNT.Name].Visible = true;
                        PrintedDocumentsInGrid.Columns[PDI_ACC_APPROVEAMOUNT.Name].HeaderText = "Talep Miktarı";
                        PrintedDocumentsInGrid.Columns[PDI_ACC_APPROVEAMOUNT.Name].ReadOnly = true;
                        PrintedDocumentsInGrid.Columns[PDI_LB_APPROVEAMOUNT.Name].Visible = true;
                        PrintedDocumentsOutGrid.Columns[PDO_ACC_APPROVEAMOUNT.Name].Visible = true;
                        PrintedDocumentsOutGrid.Columns[PDO_ACC_APPROVEAMOUNT.Name].HeaderText = "Talep Miktarı";
                        PrintedDocumentsOutGrid.Columns[PDO_ACC_APPROVEAMOUNT.Name].ReadOnly = true;
                        PrintedDocumentsOutGrid.Columns[PDO_LB_APPROVEAMOUNT.Name].Visible = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LDApprove)
                    {
                        PrintedDocumentsInGrid.Columns[PDI_LD_APPROVEAMOUNT.Name].Visible = true;
                        PrintedDocumentsInGrid.Columns[PDI_LB_APPROVEAMOUNT.Name].Visible = true;
                        PrintedDocumentsInGrid.Columns[PDI_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                        PrintedDocumentsOutGrid.Columns[PDO_LD_APPROVEAMOUNT.Name].Visible = true;
                        PrintedDocumentsOutGrid.Columns[PDO_LB_APPROVEAMOUNT.Name].Visible = true;
                        PrintedDocumentsOutGrid.Columns[PDO_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.Completed)
                    {
                        PrintedDocumentsInGrid.Columns[PDI_REQUESTAMOUNT.Name].Visible = false;
                        PrintedDocumentsInGrid.Columns[PDI_ACC_APPROVEAMOUNT.Name].Visible = false;
                        PrintedDocumentsInGrid.Columns[PDI_LB_APPROVEAMOUNT.Name].Visible = false;
                        PrintedDocumentsInGrid.Columns[PDI_LD_APPROVEAMOUNT.Name].Visible = true;
                        PrintedDocumentsOutGrid.Columns[PDO_REQUESTAMOUNT.Name].Visible = false;
                        PrintedDocumentsOutGrid.Columns[PDO_ACC_APPROVEAMOUNT.Name].Visible = false;
                        PrintedDocumentsOutGrid.Columns[PDO_LB_APPROVEAMOUNT.Name].Visible = false;
                        PrintedDocumentsOutGrid.Columns[PDO_LD_APPROVEAMOUNT.Name].Visible = true;
                    }
                    else
                    {
                        PrintedDocumentsInGrid.Columns[PDI_REQUESTAMOUNT.Name].Visible = true;
                        PrintedDocumentsInGrid.Columns[PDI_LB_APPROVEAMOUNT.Name].Visible = true;
                        PrintedDocumentsInGrid.Columns[PDI_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                        PrintedDocumentsOutGrid.Columns[PDO_REQUESTAMOUNT.Name].Visible = true;
                        PrintedDocumentsOutGrid.Columns[PDO_LB_APPROVEAMOUNT.Name].Visible = true;
                        PrintedDocumentsOutGrid.Columns[PDO_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                    }
                    
                    if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LDApprove || _AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.RegionalCommanderApprove || _AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.RegionalCommandLogBureauApproveForm)
                    {
                        PrintedDocumentsInGrid.Columns[PDI_DETAILSBUTTON.Name].Visible = false;
                        PrintedDocumentsOutGrid.Columns[PDO_DETAILSBUTTON.Name].Visible = false;
                    }
                    
                    break;

                case 9: //Aşı
                    VaccinesInGrid.Visible = true;
                    //VaccinesInGrid.Dock = DockStyle.Fill;
                    VaccinesOutGrid.Visible = true;
                    //VaccinesOutGrid.Dock = DockStyle.Fill;
                    
                    if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LogBrIBFRegisrty)
                    {
                        VaccinesInGrid.Columns[VI_REQUESTAMOUNT.Name].Visible = true;
                        VaccinesOutGrid.Columns[VO_REQUESTAMOUNT.Name].Visible = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.AccountancyApproval)
                    {
                        VaccinesInGrid.Columns[VI_REQUESTAMOUNT.Name].Visible = true;
                        VaccinesInGrid.Columns[VI_ACC_APPROVEAMOUNT.Name].Visible = true;
                        VaccinesOutGrid.Columns[VO_REQUESTAMOUNT.Name].Visible = true;
                        VaccinesOutGrid.Columns[VO_ACC_APPROVEAMOUNT.Name].Visible = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LogBrApprove)
                    {
                        VaccinesInGrid.Columns[VI_ACC_APPROVEAMOUNT.Name].Visible = true;
                        VaccinesInGrid.Columns[VI_ACC_APPROVEAMOUNT.Name].HeaderText = "Talep Miktarı";
                        VaccinesInGrid.Columns[VI_ACC_APPROVEAMOUNT.Name].ReadOnly = true;
                        VaccinesInGrid.Columns[VI_LB_APPROVEAMOUNT.Name].Visible = true;
                        VaccinesOutGrid.Columns[VO_ACC_APPROVEAMOUNT.Name].Visible = true;
                        VaccinesOutGrid.Columns[VO_ACC_APPROVEAMOUNT.Name].HeaderText = "Talep Miktarı";
                        VaccinesOutGrid.Columns[VO_ACC_APPROVEAMOUNT.Name].ReadOnly = true;
                        VaccinesOutGrid.Columns[VO_LB_APPROVEAMOUNT.Name].Visible = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LDApprove)
                    {
                        VaccinesInGrid.Columns[VI_LD_APPROVEAMOUNT.Name].Visible = true;
                        VaccinesInGrid.Columns[VI_LB_APPROVEAMOUNT.Name].Visible = true;
                        VaccinesInGrid.Columns[VI_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                        VaccinesOutGrid.Columns[VO_LD_APPROVEAMOUNT.Name].Visible = true;
                        VaccinesOutGrid.Columns[VO_LB_APPROVEAMOUNT.Name].Visible = true;
                        VaccinesOutGrid.Columns[VO_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                    }
                    else if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.Completed)
                    {
                        VaccinesInGrid.Columns[VI_REQUESTAMOUNT.Name].Visible = false;
                        VaccinesInGrid.Columns[VI_ACC_APPROVEAMOUNT.Name].Visible = false;
                        VaccinesInGrid.Columns[VI_LB_APPROVEAMOUNT.Name].Visible = false;
                        VaccinesInGrid.Columns[VI_LD_APPROVEAMOUNT.Name].Visible = true;
                        VaccinesOutGrid.Columns[VO_REQUESTAMOUNT.Name].Visible = false;
                        VaccinesOutGrid.Columns[VO_ACC_APPROVEAMOUNT.Name].Visible = false;
                        VaccinesOutGrid.Columns[VO_LB_APPROVEAMOUNT.Name].Visible = false;
                        VaccinesOutGrid.Columns[VO_LD_APPROVEAMOUNT.Name].Visible = true;
                    }
                    else
                    {
                        VaccinesInGrid.Columns[VI_REQUESTAMOUNT.Name].Visible = true;
                        VaccinesInGrid.Columns[VI_LB_APPROVEAMOUNT.Name].Visible = true;
                        VaccinesInGrid.Columns[VI_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                        VaccinesOutGrid.Columns[VO_REQUESTAMOUNT.Name].Visible = true;
                        VaccinesOutGrid.Columns[VO_LB_APPROVEAMOUNT.Name].Visible = true;
                        VaccinesOutGrid.Columns[VO_LB_APPROVEAMOUNT.Name].ReadOnly = true;
                    }
                    
                    if(_AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.LDApprove || _AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.RegionalCommanderApprove || _AnnualRequirement.CurrentStateDefID == AnnualRequirement.States.RegionalCommandLogBureauApproveForm)
                    {
                        VaccinesInGrid.Columns[VI_DETAILSBUTTON.Name].Visible = false;
                        VaccinesOutGrid.Columns[VO_DETAILSBUTTON.Name].Visible = false;
                    }
                    
                    break;
                    
                default:
                    break;
            }
        }
        
#endregion AR_BaseForm_Methods
    }
}