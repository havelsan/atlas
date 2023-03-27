
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
    /// Onay (Malzeme İsteği)
    /// </summary>
    public partial class DemandApproveForm : TTForm
    {
        override protected void BindControlEvents()
        {
            ItemsGrid.CellValueChanged += new TTGridCellEventDelegate(ItemsGrid_CellValueChanged);
            ItemsGrid.CellContentClick += new TTGridCellEventDelegate(ItemsGrid_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ItemsGrid.CellValueChanged -= new TTGridCellEventDelegate(ItemsGrid_CellValueChanged);
            ItemsGrid.CellContentClick -= new TTGridCellEventDelegate(ItemsGrid_CellContentClick);
            base.UnBindControlEvents();
        }

        private void ItemsGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region DemandApproveForm_ItemsGrid_CellValueChanged
   if(columnIndex == ItemsGrid.Columns[ApprovedAmount.Name].Index)
            {
                DemandDetail dd = (DemandDetail)ItemsGrid.CurrentCell.OwningRow.TTObject;
                double amount = 0;
                
                if(dd.ClinicApprovedAmount != null)
                    amount = (double)dd.ClinicApprovedAmount;
                
                if(dd.RequestAmount == amount)
                    ((TTGrid)ItemsGrid).Rows[rowIndex].Cells[PurchaseItem.Name].Style.BackColor = System.Drawing.Color.Aqua;
                else if(dd.RequestAmount < amount)
                    ((TTGrid)ItemsGrid).Rows[rowIndex].Cells[PurchaseItem.Name].Style.BackColor = System.Drawing.Color.Red;
                else
                    ((TTGrid)ItemsGrid).Rows[rowIndex].Cells[PurchaseItem.Name].Style.BackColor = System.Drawing.Color.LightBlue;
            }
#endregion DemandApproveForm_ItemsGrid_CellValueChanged
        }

        private void ItemsGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region DemandApproveForm_ItemsGrid_CellContentClick
   if(ItemsGrid.CurrentCell == null)
                return;
            
            if(ItemsGrid.CurrentCell.Value == null)
                return;
            

            else if(ItemsGrid.CurrentCell.OwningColumn == ItemsGrid.Columns[Amount.Name])
            {
                ItemsGrid.CurrentCell.OwningRow.Cells[ApprovedAmount.Name].Value = ItemsGrid.CurrentCell.Value;
            }
#endregion DemandApproveForm_ItemsGrid_CellContentClick
        }

        protected override void PreScript()
        {
#region DemandApproveForm_PreScript
    base.PreScript();
            
            if(_Demand.DemandType == DemandTypeEnum.ServicePurchase)
            {
                this.DropStateButton(Demand.States.AccountancyApproval);
                this.DropStateButton(Demand.States.LogisticDepartmentApproval);
            }
            else
            {
                this.DropStateButton(Demand.States.Completed);
                if(_Demand.PassedFromAccountancy == true)
                    this.DropStateButton(Demand.States.AccountancyApproval);
                else
                    this.DropStateButton(Demand.States.LogisticDepartmentApproval);
            }
#endregion DemandApproveForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DemandApproveForm_PostScript
    _Demand.CheckNullAmounts();
#endregion DemandApproveForm_PostScript

            }
                }
}