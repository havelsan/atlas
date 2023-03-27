
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
    /// Doğrudan Temin İşlemi
    /// </summary>
    public partial class DirectPurchaseActionApprovalForm : BaseDirectPurchaseActionForm
    {
        override protected void BindControlEvents()
        {
            DirectPurchaseActionDetailsGrid.CellValueChanged += new TTGridCellEventDelegate(DirectPurchaseActionDetailsGrid_CellValueChanged);
            CommissionMembersGrid.CellValueChanged += new TTGridCellEventDelegate(CommissionMembersGrid_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            DirectPurchaseActionDetailsGrid.CellValueChanged -= new TTGridCellEventDelegate(DirectPurchaseActionDetailsGrid_CellValueChanged);
            CommissionMembersGrid.CellValueChanged -= new TTGridCellEventDelegate(CommissionMembersGrid_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void DirectPurchaseActionDetailsGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region DirectPurchaseActionApprovalForm_DirectPurchaseActionDetailsGrid_CellValueChanged
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
                                DirectPurchaseActionDetailsGrid.Rows[rowIndex].Cells["SUTName"].Value = productSUTMatchDefinition.SUTName;
                            }
                        }
                    }
                    break;

                default:
                    break;
            }
#endregion DirectPurchaseActionApprovalForm_DirectPurchaseActionDetailsGrid_CellValueChanged
        }

        private void CommissionMembersGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region DirectPurchaseActionApprovalForm_CommissionMembersGrid_CellValueChanged
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
#endregion DirectPurchaseActionApprovalForm_CommissionMembersGrid_CellValueChanged
        }

        protected override void PreScript()
        {
#region DirectPurchaseActionApprovalForm_PreScript
    base.PreScript();
            
            if(Convert.ToInt32(this.cmbDirectPurchaseActionType.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(DirectPurchaseActionTypeEnum.Titubb).Value)
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
            else if(Convert.ToInt32(this.cmbDirectPurchaseActionType.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(DirectPurchaseActionTypeEnum.RadioPharmaceutical).Value)
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
            else if(Convert.ToInt32(this.cmbDirectPurchaseActionType.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(DirectPurchaseActionTypeEnum.Codeless).Value)
            {
                this.tabDirectPurchaseActionDetails.HideTabPage(tabPageDirectPurchaseActionDetails);
                ((ITTGrid)this.DirectPurchaseActionDetailsGrid).Columns["SUTCode"].Required = false;
                ((ITTGrid)this.DirectPurchaseActionDetailsGrid).Columns["SUTName"].Required = false;
                ((ITTGrid)this.DirectPurchaseActionDetailsGrid).Columns["SUTPrice"].Required = false;
                this.tabDirectPurchaseActionDetails.HideTabPage(tabPageDPARadioPharmaceuticals);
                ((ITTGrid)this.DPARadioPharmaCeuticalsGrid).Columns["ProcedureSUTCode"].Required = false;
                ((ITTGrid)this.DPARadioPharmaCeuticalsGrid).Columns["RadioPharmaceuticalMaterial"].Required = false;
                ((ITTGrid)this.DPARadioPharmaCeuticalsGrid).Columns["ProcedureSUTPrice"].Required = false;
                this.tabDirectPurchaseActionDetails.ShowTabPage(tabPageCodelessMaterial);
                ((ITTGrid)this.DPACodelessMaterialGrid).Columns["CodelessMaterialName"].Required = true;
                ((ITTGrid)this.DPACodelessMaterialGrid).Columns["CDAmount"].Required = true;
                ((ITTGrid)this.DPACodelessMaterialGrid).Columns["CDDistributionType"].Required = true;
            }
#endregion DirectPurchaseActionApprovalForm_PreScript

            }
                }
}