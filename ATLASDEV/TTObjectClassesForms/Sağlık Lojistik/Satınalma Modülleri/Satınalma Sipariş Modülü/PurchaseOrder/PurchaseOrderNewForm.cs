
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
    /// Sipariş
    /// </summary>
    public partial class PurchaseOrderNewForm : TTForm
    {
        override protected void BindControlEvents()
        {
            ContractsGrid.CellContentClick += new TTGridCellEventDelegate(ContractsGrid_CellContentClick);
            cmdAddAll.Click += new TTControlEventDelegate(cmdAddAll_Click);
            txtProjectNO.TextChanged += new TTControlEventDelegate(txtProjectNO_TextChanged);
            txtConfirmNO.TextChanged += new TTControlEventDelegate(txtConfirmNO_TextChanged);
            cmdList.Click += new TTControlEventDelegate(cmdList_Click);
            PurchaseOrderDetailsGrid.CellContentClick += new TTGridCellEventDelegate(PurchaseOrderDetailsGrid_CellContentClick);
            PurchaseOrderDetailsGrid.CellValueChanged += new TTGridCellEventDelegate(PurchaseOrderDetailsGrid_CellValueChanged);
            cmdOldOrders.Click += new TTControlEventDelegate(cmdOldOrders_Click);
            ContractDetailsGrid.CellContentClick += new TTGridCellEventDelegate(ContractDetailsGrid_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ContractsGrid.CellContentClick -= new TTGridCellEventDelegate(ContractsGrid_CellContentClick);
            cmdAddAll.Click -= new TTControlEventDelegate(cmdAddAll_Click);
            txtProjectNO.TextChanged -= new TTControlEventDelegate(txtProjectNO_TextChanged);
            txtConfirmNO.TextChanged -= new TTControlEventDelegate(txtConfirmNO_TextChanged);
            cmdList.Click -= new TTControlEventDelegate(cmdList_Click);
            PurchaseOrderDetailsGrid.CellContentClick -= new TTGridCellEventDelegate(PurchaseOrderDetailsGrid_CellContentClick);
            PurchaseOrderDetailsGrid.CellValueChanged -= new TTGridCellEventDelegate(PurchaseOrderDetailsGrid_CellValueChanged);
            cmdOldOrders.Click -= new TTControlEventDelegate(cmdOldOrders_Click);
            ContractDetailsGrid.CellContentClick -= new TTGridCellEventDelegate(ContractDetailsGrid_CellContentClick);
            base.UnBindControlEvents();
        }

        private void ContractsGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region PurchaseOrderNewForm_ContractsGrid_CellContentClick
   _PurchaseOrder.TmpContract = (Contract)ContractsGrid.CurrentCell.OwningRow.TTObject;
#endregion PurchaseOrderNewForm_ContractsGrid_CellContentClick
        }

        private void cmdAddAll_Click()
        {
#region PurchaseOrderNewForm_cmdAddAll_Click
   foreach(ITTGridRow row in ContractDetailsGrid.Rows)
            {
                if(row.TTObject != null)
                {
                    ContractDetail cd = (ContractDetail)row.TTObject;
                    _PurchaseOrder.AddDetailFromContractDetail(cd, _PurchaseOrder.ObjectContext);
                }
            }
#endregion PurchaseOrderNewForm_cmdAddAll_Click
        }

        private void txtProjectNO_TextChanged()
        {
#region PurchaseOrderNewForm_txtProjectNO_TextChanged
   if(string.IsNullOrEmpty(txtProjectNO.Text))
                txtConfirmNO.Enabled = true;
            else
                txtConfirmNO.Enabled = false;
#endregion PurchaseOrderNewForm_txtProjectNO_TextChanged
        }

        private void txtConfirmNO_TextChanged()
        {
#region PurchaseOrderNewForm_txtConfirmNO_TextChanged
   if(string.IsNullOrEmpty(txtConfirmNO.Text))
                txtProjectNO.Enabled = true;
            else
                txtProjectNO.Enabled = false;
#endregion PurchaseOrderNewForm_txtConfirmNO_TextChanged
        }

        private void cmdList_Click()
        {
#region PurchaseOrderNewForm_cmdList_Click
   if (String.IsNullOrEmpty(txtConfirmNO.Text) && String.IsNullOrEmpty(txtProjectNO.Text))
            {
                InfoBox.Show(SystemMessage.GetMessage(63));
                return;
            }
            
            Supplier supp = null;
            if(txtSupplier.SelectedObject != null)
                supp = (Supplier)_PurchaseOrder.ObjectContext.GetObject((Guid)txtSupplier.SelectedObjectID, "SUPPLIER");
            
            if (String.IsNullOrEmpty(txtProjectNO.Text))
                _PurchaseOrder.FillTmpContractsGrid(0, txtConfirmNO.Text, supp);
            else
            {
                IList list = PurchaseProject.GetPurchaseProjectByProjectNo(_PurchaseOrder.ObjectContext, Convert.ToInt32(txtProjectNO.Text));
                if(list.Count == 0)
                    InfoBox.Show(SystemMessage.GetMessage(506));
                else
                    _PurchaseOrder.FillTmpContractsGrid(Convert.ToInt32(txtProjectNO.Text), txtConfirmNO.Text, supp);
            }
#endregion PurchaseOrderNewForm_cmdList_Click
        }

        private void PurchaseOrderDetailsGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region PurchaseOrderNewForm_PurchaseOrderDetailsGrid_CellContentClick
   if(PurchaseOrderDetailsGrid.CurrentCell == null)
                return;
            
            if(PurchaseOrderDetailsGrid.CurrentCell.OwningColumn.Name == "Release")
            {
                PurchaseOrderDetail pod = (PurchaseOrderDetail)PurchaseOrderDetailsGrid.CurrentCell.OwningRow.TTObject;
                ((ITTObject)pod).Delete();
                
                if(PurchaseOrderDetailsGrid.Rows.Count == 0)
                {
                    _PurchaseOrder.Supplier = null;
                    _PurchaseOrder.Contract = null;
                }
            }
#endregion PurchaseOrderNewForm_PurchaseOrderDetailsGrid_CellContentClick
        }

        private void PurchaseOrderDetailsGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region PurchaseOrderNewForm_PurchaseOrderDetailsGrid_CellValueChanged
   if (PurchaseOrderDetailsGrid.CurrentCell.OwningColumn.Name == "Amount")
            {
                _PurchaseOrder.SetOrderPrices((PurchaseOrderDetail)PurchaseOrderDetailsGrid.CurrentCell.OwningRow.TTObject);
                _PurchaseOrder.SetFooterValues();
            }
#endregion PurchaseOrderNewForm_PurchaseOrderDetailsGrid_CellValueChanged
        }

        private void cmdOldOrders_Click()
        {
#region PurchaseOrderNewForm_cmdOldOrders_Click
   if (_PurchaseOrder.Contract != null)
            {
                RelatedOrdersForm oof = new RelatedOrdersForm();
                Contract c = _PurchaseOrder.Contract;
                oof.ShowEdit(this.FindForm(),c);
            }
            else
                InfoBox.Show(SystemMessage.GetMessage(64));
#endregion PurchaseOrderNewForm_cmdOldOrders_Click
        }

        private void ContractDetailsGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region PurchaseOrderNewForm_ContractDetailsGrid_CellContentClick
   if (ContractDetailsGrid.CurrentCell == null)
                return;
            
            if(ContractDetailsGrid.CurrentCell.OwningColumn.Name == "clmAdd")
            {
                ContractDetail cd = (ContractDetail)ContractDetailsGrid.CurrentCell.OwningRow.TTObject;
                if (cd == null)
                    throw new TTUtils.TTException(SystemMessage.GetMessage(59));
                
                if(_PurchaseOrder.Contract != null)
                {
                    if(_PurchaseOrder.Contract.Supplier != cd.Contract.Supplier)
                        InfoBox.Show(SystemMessage.GetMessage(60));
                    else
                        _PurchaseOrder.AddDetailFromContractDetail(cd, _PurchaseOrder.ObjectContext);
                }
                else
                    _PurchaseOrder.AddDetailFromContractDetail(cd, _PurchaseOrder.ObjectContext);
            }
#endregion PurchaseOrderNewForm_ContractDetailsGrid_CellContentClick
        }
    }
}