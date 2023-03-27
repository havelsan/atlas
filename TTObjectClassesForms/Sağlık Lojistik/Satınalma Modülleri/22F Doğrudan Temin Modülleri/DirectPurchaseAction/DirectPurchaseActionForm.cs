
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
    public partial class DirectPurchaseActionForm : BaseDirectPurchaseActionForm
    {
        override protected void BindControlEvents()
        {
            cmbDirectPurchaseActionType.SelectedIndexChanged += new TTControlEventDelegate(cmbDirectPurchaseActionType_SelectedIndexChanged);
            DirectPurchaseActionDetailsGrid.CellValueChanged += new TTGridCellEventDelegate(DirectPurchaseActionDetailsGrid_CellValueChanged);
            DPARadioPharmaCeuticalsGrid.CellValueChanged += new TTGridCellEventDelegate(DPARadioPharmaCeuticalsGrid_CellValueChanged);
            CommissionMembersGrid.CellValueChanged += new TTGridCellEventDelegate(CommissionMembersGrid_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmbDirectPurchaseActionType.SelectedIndexChanged -= new TTControlEventDelegate(cmbDirectPurchaseActionType_SelectedIndexChanged);
            DirectPurchaseActionDetailsGrid.CellValueChanged -= new TTGridCellEventDelegate(DirectPurchaseActionDetailsGrid_CellValueChanged);
            DPARadioPharmaCeuticalsGrid.CellValueChanged -= new TTGridCellEventDelegate(DPARadioPharmaCeuticalsGrid_CellValueChanged);
            CommissionMembersGrid.CellValueChanged -= new TTGridCellEventDelegate(CommissionMembersGrid_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void cmbDirectPurchaseActionType_SelectedIndexChanged()
        {
#region DirectPurchaseActionForm_cmbDirectPurchaseActionType_SelectedIndexChanged
   this.DirectPurchaseActionDetailsGrid.Rows.Clear();
            this.DPARadioPharmaCeuticalsGrid.Rows.Clear();
            this.DPACodelessMaterialGrid.Rows.Clear();
            
            SetGrids(Convert.ToInt32(this.cmbDirectPurchaseActionType.SelectedItem.Value));
#endregion DirectPurchaseActionForm_cmbDirectPurchaseActionType_SelectedIndexChanged
        }

        private void DirectPurchaseActionDetailsGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region DirectPurchaseActionForm_DirectPurchaseActionDetailsGrid_CellValueChanged
   switch (DirectPurchaseActionDetailsGrid.CurrentCell.OwningColumn.Name)
            {
                case "SUTCode":
                    {
                        if(DirectPurchaseActionDetailsGrid.CurrentCell.Value != null)
                        {
                            ProductSUTMatchDefinition productSUTMatchDefinition = (ProductSUTMatchDefinition)this._DirectPurchaseAction.ObjectContext.GetObject((Guid)DirectPurchaseActionDetailsGrid.CurrentCell.Value,typeof(ProductSUTMatchDefinition));
                            if(productSUTMatchDefinition != null)
                            {
                                DirectPurchaseActionDetailsGrid.Rows[rowIndex].Cells["SUTPrice"].Value = productSUTMatchDefinition.SUTPrice;
                                if(productSUTMatchDefinition.Product != null)
                                    DirectPurchaseActionDetailsGrid.Rows[rowIndex].Cells["SUTName"].Value = productSUTMatchDefinition.Product.Name;
                                else
                                    DirectPurchaseActionDetailsGrid.Rows[rowIndex].Cells["SUTName"].Value = productSUTMatchDefinition.SUTName;
                            }
                        }
                    }
                    break;

                default:
                    break;
            }
#endregion DirectPurchaseActionForm_DirectPurchaseActionDetailsGrid_CellValueChanged
        }

        private void DPARadioPharmaCeuticalsGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region DirectPurchaseActionForm_DPARadioPharmaCeuticalsGrid_CellValueChanged
   switch (DPARadioPharmaCeuticalsGrid.CurrentCell.OwningColumn.Name)
            {
                case "ProcedureSUTCode":
                    {
                        if(DPARadioPharmaCeuticalsGrid.CurrentCell.Value != null)
                        {
                            NuclearMedicineTestDefinition nuclearMedicineTestDefinition = (NuclearMedicineTestDefinition)this._DirectPurchaseAction.ObjectContext.GetObject((Guid)DPARadioPharmaCeuticalsGrid.CurrentCell.Value,typeof(NuclearMedicineTestDefinition));
                            if(nuclearMedicineTestDefinition != null)
                            {
                                //SUT Price List getiriliyor.
                                PricingListDefinition SUTPriceList = null ;
                                SUTPriceList = (PricingListDefinition)PricingListDefinition.GetByObjectID(_DirectPurchaseAction.ObjectContext, TTObjectClasses.SystemParameter.GetParameterValue("SUTPRICELISTOBJECTID", "").ToString())[0];
                                ArrayList pricingDetailList = new ArrayList();
                                pricingDetailList = nuclearMedicineTestDefinition.GetProcedurePricingDetail(SUTPriceList, (DateTime)this._DirectPurchaseAction.ActionDate);
                                if(pricingDetailList.Count == 0)
                                {
                                    InfoBox.Alert(nuclearMedicineTestDefinition.Code + " " + nuclearMedicineTestDefinition.Name + " hizmetinin eşleştiği aktif SUT fiyatı bulunamadı!", TTDefinitionManagement.MessageIconEnum.WarningMessage);
                                    DPARadioPharmaCeuticalsGrid.Rows[rowIndex].Cells["ProcedureSUTPrice"].Value = null;
                                }
                                else
                                {
                                    DPARadioPharmaCeuticalsGrid.Rows[rowIndex].Cells["ProcedureSUTPrice"].Value = ((PricingDetailDefinition)pricingDetailList[0]).Price;
                                }
                            }
                            DPARadioPharmaCeuticalsGrid.Rows[rowIndex].Cells["RadioPharmaceuticalMaterial"].Value = null;
                        }
                    }
                    break;

                default:
                    break;
            }
#endregion DirectPurchaseActionForm_DPARadioPharmaCeuticalsGrid_CellValueChanged
        }

        private void CommissionMembersGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region DirectPurchaseActionForm_CommissionMembersGrid_CellValueChanged
   switch (CommissionMembersGrid.CurrentCell.OwningColumn.Name)
            {
                case "MemberName":
                    {
                        if(CommissionMembersGrid.CurrentCell.Value == null)
                        {
                            CommissionMembersGrid.Rows[rowIndex].Cells["MemberTitle"].Value = null;
                            CommissionMembersGrid.Rows[rowIndex].Cells["MemberRank"].Value = null;                           
                        }
                    }
                    break;

                default:
                    break;
            }
#endregion DirectPurchaseActionForm_CommissionMembersGrid_CellValueChanged
        }

        protected override void PreScript()
        {
#region DirectPurchaseActionForm_PreScript
    base.PreScript();
            
            if(this.CommissionMembersGrid.Rows.Count == 0)
            {
                for(int i=1;i<7;i++)
                {
                    ITTGridRow row = this.CommissionMembersGrid.Rows.Add();
                    row.Cells["CommisionOrderNo"].Value = i.ToString();
                    if(i%3 == 1)
                        row.Cells["MemberDuty"].Value = DPACommisionMemberDutyEnum.Chief;
                    else
                        row.Cells["MemberDuty"].Value = DPACommisionMemberDutyEnum.Member;
                    if(i<=3)
                        row.Cells["PrimeBackup"].Value = true;
                    else
                        row.Cells["PrimeBackup"].Value = false;
                }
            }
            
            if(this._DirectPurchaseAction.DirectPurchaseActionType.HasValue == false)
                this._DirectPurchaseAction.DirectPurchaseActionType = DirectPurchaseActionTypeEnum.Titubb;
            
//            if(this._DirectPurchaseAction.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.Titubb)
//            {
//                this.tabDirectPurchaseActionDetails.ShowTabPage(tabPageDirectPurchaseActionDetails);
//                ((ITTGrid)this.DirectPurchaseActionDetailsGrid).Columns["SUTCode"].Required = true;
//                ((ITTGrid)this.DirectPurchaseActionDetailsGrid).Columns["SUTName"].Required = true;
//                this.tabDirectPurchaseActionDetails.HideTabPage(tabPageDPARadioPharmaceuticals);
//                ((ITTGrid)this.DPARadioPharmaCeuticalsGrid).Columns["ProcedureSUTCode"].Required = false;
//                ((ITTGrid)this.DPARadioPharmaCeuticalsGrid).Columns["RadioPharmaceuticalMaterial"].Required = false;
//            }
//            else if(this._DirectPurchaseAction.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.RadioPharmaceutical)
//            {
//                this.tabDirectPurchaseActionDetails.HideTabPage(tabPageDirectPurchaseActionDetails);
//                ((ITTGrid)this.DirectPurchaseActionDetailsGrid).Columns["SUTCode"].Required = false;
//                ((ITTGrid)this.DirectPurchaseActionDetailsGrid).Columns["SUTName"].Required = false;
//                this.tabDirectPurchaseActionDetails.ShowTabPage(tabPageDPARadioPharmaceuticals);
//                ((ITTGrid)this.DPARadioPharmaCeuticalsGrid).Columns["ProcedureSUTCode"].Required = true;
//                ((ITTGrid)this.DPARadioPharmaCeuticalsGrid).Columns["RadioPharmaceuticalMaterial"].Required = true;
//            }

                SetGrids(Convert.ToInt32(this.cmbDirectPurchaseActionType.SelectedItem.Value));
#endregion DirectPurchaseActionForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DirectPurchaseActionForm_PostScript
    base.PostScript(transDef);
            
            if(this._DirectPurchaseAction.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.Titubb)
            {
                if(this.DirectPurchaseActionDetailsGrid.Rows.Count <= 0)
                    throw new Exception("'UBB Kodlu Malzemeler' alanı boş geçilemez");
            }
            else if(this._DirectPurchaseAction.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.RadioPharmaceutical)
            {
                if(this.DPARadioPharmaCeuticalsGrid.Rows.Count <= 0)
                    throw new Exception("'Radyofarmasötik Malzemeler' alanı boş geçilemez");
            }
#endregion DirectPurchaseActionForm_PostScript

            }
            
#region DirectPurchaseActionForm_Methods
        public void SetGrids(int value)
        {
            if(value == Common.GetEnumValueDefOfEnumValue(DirectPurchaseActionTypeEnum.Titubb).Value)
            {
                this.tabDirectPurchaseActionDetails.ShowTabPage(tabPageDirectPurchaseActionDetails);
                ((ITTGrid)this.DirectPurchaseActionDetailsGrid).Columns["SUTCode"].Required = true;
                ((ITTGrid)this.DirectPurchaseActionDetailsGrid).Columns["SUTName"].Required = true;
                this.tabDirectPurchaseActionDetails.HideTabPage(tabPageDPARadioPharmaceuticals);
                ((ITTGrid)this.DPARadioPharmaCeuticalsGrid).Columns["ProcedureSUTCode"].Required = false;
                ((ITTGrid)this.DPARadioPharmaCeuticalsGrid).Columns["RadioPharmaceuticalMaterial"].Required = false;
                this.tabDirectPurchaseActionDetails.HideTabPage(tabPageCodelessMaterial);
                ((ITTGrid)this.DPACodelessMaterialGrid).Columns["CodelessMaterialName"].Required = false;
                ((ITTGrid)this.DPACodelessMaterialGrid).Columns["CDAmount"].Required = false;
                ((ITTGrid)this.DPACodelessMaterialGrid).Columns["CDDistributionType"].Required = false;
            }
            else if(value == Common.GetEnumValueDefOfEnumValue(DirectPurchaseActionTypeEnum.RadioPharmaceutical).Value)
            {
                this.tabDirectPurchaseActionDetails.HideTabPage(tabPageDirectPurchaseActionDetails);
                ((ITTGrid)this.DirectPurchaseActionDetailsGrid).Columns["SUTCode"].Required = false;
                ((ITTGrid)this.DirectPurchaseActionDetailsGrid).Columns["SUTName"].Required = false;
                this.tabDirectPurchaseActionDetails.ShowTabPage(tabPageDPARadioPharmaceuticals);
                ((ITTGrid)this.DPARadioPharmaCeuticalsGrid).Columns["ProcedureSUTCode"].Required = true;
                ((ITTGrid)this.DPARadioPharmaCeuticalsGrid).Columns["RadioPharmaceuticalMaterial"].Required = true;
                this.tabDirectPurchaseActionDetails.HideTabPage(tabPageCodelessMaterial);
                ((ITTGrid)this.DPACodelessMaterialGrid).Columns["CodelessMaterialName"].Required = false;
                ((ITTGrid)this.DPACodelessMaterialGrid).Columns["CDAmount"].Required = false;
                ((ITTGrid)this.DPACodelessMaterialGrid).Columns["CDDistributionType"].Required = false;
            }
            else if(value == Common.GetEnumValueDefOfEnumValue(DirectPurchaseActionTypeEnum.Codeless).Value)
            {
                this.tabDirectPurchaseActionDetails.HideTabPage(tabPageDirectPurchaseActionDetails);
                ((ITTGrid)this.DirectPurchaseActionDetailsGrid).Columns["SUTCode"].Required = false;
                ((ITTGrid)this.DirectPurchaseActionDetailsGrid).Columns["SUTName"].Required = false;
                this.tabDirectPurchaseActionDetails.HideTabPage(tabPageDPARadioPharmaceuticals);
                ((ITTGrid)this.DPARadioPharmaCeuticalsGrid).Columns["ProcedureSUTCode"].Required = false;
                ((ITTGrid)this.DPARadioPharmaCeuticalsGrid).Columns["RadioPharmaceuticalMaterial"].Required = false;
                this.tabDirectPurchaseActionDetails.ShowTabPage(tabPageCodelessMaterial);
                ((ITTGrid)this.DPACodelessMaterialGrid).Columns["CodelessMaterialName"].Required = true;
                ((ITTGrid)this.DPACodelessMaterialGrid).Columns["CDAmount"].Required = true;
                ((ITTGrid)this.DPACodelessMaterialGrid).Columns["CDDistributionType"].Required = true;
            }
        }
        
#endregion DirectPurchaseActionForm_Methods
    }
}