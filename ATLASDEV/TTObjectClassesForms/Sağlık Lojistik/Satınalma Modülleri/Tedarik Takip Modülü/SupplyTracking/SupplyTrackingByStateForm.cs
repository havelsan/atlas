
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
    /// Sözleşme Arama
    /// </summary>
    public partial class SupplyTrackingByStateForm : TTForm
    {
        override protected void BindControlEvents()
        {
            cmdList.Click += new TTControlEventDelegate(cmdList_Click);
            ItemsGrid.CellContentClick += new TTGridCellEventDelegate(ItemsGrid_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdList.Click -= new TTControlEventDelegate(cmdList_Click);
            ItemsGrid.CellContentClick -= new TTGridCellEventDelegate(ItemsGrid_CellContentClick);
            base.UnBindControlEvents();
        }

        private void cmdList_Click()
        {
#region SupplyTrackingByStateForm_cmdList_Click
   ItemsGrid.Rows.Clear();
            BindingList<PurchaseOrderDetail> orderDetList = PurchaseOrderDetail.GetByStatus(_SupplyTracking.ObjectContext, Convert.ToInt32(txt2DetailStatus.ControlValue));
            foreach(PurchaseOrderDetail pod in orderDetList)
            {
                if(pod.CurrentStateDefID != PurchaseOrderDetail.States.Cancelled)
                {
                    AddOrderDetRow(pod);
                }
            }
#endregion SupplyTrackingByStateForm_cmdList_Click
        }

        private void ItemsGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region SupplyTrackingByStateForm_ItemsGrid_CellContentClick
   if(ItemsGrid.CurrentCell.OwningColumn.Name == "ShowOrder")
            {
                Guid guid = new Guid(ItemsGrid.CurrentCell.OwningRow.Cells["OrderGUID"].Value.ToString());
                PurchaseOrder po = (PurchaseOrder)_SupplyTracking.ObjectContext.GetObject(guid, "PURCHASEORDER");
                TTForm frm = TTForm.GetEditForm(po);
                frm.ShowEdit(this.FindForm(), po);
                
            }
#endregion SupplyTrackingByStateForm_ItemsGrid_CellContentClick
        }

        protected override void PreScript()
        {
#region SupplyTrackingByStateForm_PreScript
    base.PreScript();
            
            this.DropStateButton(SupplyTracking.States.Completed);
#endregion SupplyTrackingByStateForm_PreScript

            }
            
#region SupplyTrackingByStateForm_Methods
        public void AddOrderDetRow(PurchaseOrderDetail purchaseOrderDetail)
        {
            ITTGridRow row = ItemsGrid.Rows.Add();
            row.Cells["PURCHASEITEM"].Value = purchaseOrderDetail.PurchaseItemDef.ObjectID;
            if(purchaseOrderDetail.ContractDetail.Material != null)
                row.Cells["MATERIAL"].Value = purchaseOrderDetail.ContractDetail.Material.ObjectID;
            row.Cells["ORDERDATE"].Value = ((DateTime)purchaseOrderDetail.PurchaseOrder.OrderDate).ToShortDateString();
            row.Cells["DUEDATE"].Value = ((DateTime)purchaseOrderDetail.PurchaseOrder.DueDate).ToShortDateString();
            row.Cells["AMOUNT"].Value = purchaseOrderDetail.Amount;
            row.Cells["OrderGUID"].Value = purchaseOrderDetail.PurchaseOrder.ObjectID;
        }
        
#endregion SupplyTrackingByStateForm_Methods
    }
}