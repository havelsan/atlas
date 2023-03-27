
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
    /// Saymanlık Onay
    /// </summary>
    public partial class DemandAccountacyApprovalForm : TTForm
    {
        override protected void BindControlEvents()
        {
            ItemsGrid.CellContentClick += new TTGridCellEventDelegate(ItemsGrid_CellContentClick);
            ItemsGrid.CellValueChanged += new TTGridCellEventDelegate(ItemsGrid_CellValueChanged);
            TransfersGrid.CellContentClick += new TTGridCellEventDelegate(TransfersGrid_CellContentClick);
            cmdApproveAll.Click += new TTControlEventDelegate(cmdApproveAll_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ItemsGrid.CellContentClick -= new TTGridCellEventDelegate(ItemsGrid_CellContentClick);
            ItemsGrid.CellValueChanged -= new TTGridCellEventDelegate(ItemsGrid_CellValueChanged);
            TransfersGrid.CellContentClick -= new TTGridCellEventDelegate(TransfersGrid_CellContentClick);
            cmdApproveAll.Click -= new TTControlEventDelegate(cmdApproveAll_Click);
            base.UnBindControlEvents();
        }

        private void ItemsGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region DemandAccountacyApprovalForm_ItemsGrid_CellContentClick
   if(ItemsGrid.CurrentCell == null)
                return;
            
            if(ItemsGrid.CurrentCell.OwningColumn == ItemsGrid.Columns[StockDetails.Name])
            {
                DemandDetail demandDetail = (DemandDetail)ItemsGrid.CurrentCell.OwningRow.TTObject;
                demandDetail.SetPurchaseItemStoreStocks();
                StockExaminationForm seForm = new StockExaminationForm();
                seForm.ShowEdit(this.FindForm(), demandDetail);
            }
            else if (ItemsGrid.CurrentCell.OwningColumn == ItemsGrid.Columns[Amount.Name])
            {
                if(ItemsGrid.CurrentCell.OwningRow.Cells[TransferAmount.Name].Value == null)
                    ItemsGrid.CurrentCell.OwningRow.Cells[ApprovedAmount.Name].Value = ItemsGrid.CurrentCell.Value;
                else
                    ItemsGrid.CurrentCell.OwningRow.Cells[ApprovedAmount.Name].Value = (Convert.ToDouble(ItemsGrid.CurrentCell.Value) - Convert.ToDouble(ItemsGrid.CurrentCell.OwningRow.Cells[TransferAmount.Name].Value)).ToString();
            }
#endregion DemandAccountacyApprovalForm_ItemsGrid_CellContentClick
        }

        private void ItemsGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region DemandAccountacyApprovalForm_ItemsGrid_CellValueChanged
   if(columnIndex == ItemsGrid.Columns[ApprovedAmount.Name].Index)
            {
                DemandDetail dd = (DemandDetail)ItemsGrid.CurrentCell.OwningRow.TTObject;
                double trAmount = 0;
                double amount = 0;
                if(dd.TransferAmount != null)
                    trAmount = (double)dd.TransferAmount;
                
                if(dd.Amount != null)
                    amount = (double)dd.Amount;
                
                if(dd.ClinicApprovedAmount == (trAmount + amount))
                    ((TTGrid)ItemsGrid).Rows[rowIndex].Cells[PurchaseItem.Name].Style.BackColor = System.Drawing.Color.Aqua;
                else if(dd.ClinicApprovedAmount < (trAmount + amount))
                    ((TTGrid)ItemsGrid).Rows[rowIndex].Cells[PurchaseItem.Name].Style.BackColor = System.Drawing.Color.Red;
                else
                    ((TTGrid)ItemsGrid).Rows[rowIndex].Cells[PurchaseItem.Name].Style.BackColor = System.Drawing.Color.LightBlue;
            }
#endregion DemandAccountacyApprovalForm_ItemsGrid_CellValueChanged
        }

        private void TransfersGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region DemandAccountacyApprovalForm_TransfersGrid_CellContentClick
   if (TransfersGrid.CurrentCell == null)
                return;
            
            if(TransfersGrid.CurrentCell.OwningColumn.Name == "cmdCancel")
            {
                TransferForDemand tf = (TransferForDemand)TransfersGrid.CurrentCell.OwningRow.TTObject;
                DemandDetStoreStockDetail ddsd = tf.DemandDetStoreStockDetail;
                ddsd.TransferAmount = 0;
                double totalTransferAmount = 0;
                double storeTransferAmount = 0;
                foreach(DemandDetailStoreStock ds in tf.DemandDetail.DemandDetailStoreStocks)
                {
                    storeTransferAmount = 0;
                    foreach(DemandDetStoreStockDetail dds in ds.StoreStockDetails)
                    {
                        if(dds.TransferAmount != null)
                        {
                            storeTransferAmount += (double)dds.TransferAmount;
                            totalTransferAmount += (double)dds.TransferAmount;
                        }
                    }
                    ds.TransferAmount = storeTransferAmount;
                }
                tf.DemandDetail.TransferAmount = totalTransferAmount;
                
                ((ITTObject)tf).Delete();
            }
            
            TransfersGrid.RefreshRows();
#endregion DemandAccountacyApprovalForm_TransfersGrid_CellContentClick
        }

        private void cmdApproveAll_Click()
        {
#region DemandAccountacyApprovalForm_cmdApproveAll_Click
   foreach(DemandDetail dd in _Demand.DemandDetails)
            {
                dd.Amount = dd.ClinicApprovedAmount;
            }
#endregion DemandAccountacyApprovalForm_cmdApproveAll_Click
        }

        protected override void PreScript()
        {
#region DemandAccountacyApprovalForm_PreScript
    base.PreScript();
            
            foreach(DemandDetail demandDetail in _Demand.DemandDetails)
            {
                demandDetail.SetPurchaseItemStoreStocks();
            }
#endregion DemandAccountacyApprovalForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DemandAccountacyApprovalForm_PostScript
    base.PostScript(transDef);
#endregion DemandAccountacyApprovalForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region DemandAccountacyApprovalForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            
            _Demand.CheckNullAmounts();
            if(_Demand.TransferForDemands.Count > 0 && _Demand.TransDef != null)
            {
                string result = ShowBox.Show(ShowBoxTypeEnum.Message,"&Evet,&Hayır","E,H","Uyarı","Uyarı","Muvazene edilecek kalemler için otomatik Dağıtım ve İade işlemleri başlatılacaktır. Devam etmek istiyor musunuz?", 1);
                if (result == "H")
                    throw new Exception("İşlemden vazgeçildi.");
            }
            
            foreach(DemandDetail dd in _Demand.DemandDetails)
            {
                dd.TmpDemandDetailStoreStock = null;
            }
#endregion DemandAccountacyApprovalForm_ClientSidePostScript

        }
    }
}