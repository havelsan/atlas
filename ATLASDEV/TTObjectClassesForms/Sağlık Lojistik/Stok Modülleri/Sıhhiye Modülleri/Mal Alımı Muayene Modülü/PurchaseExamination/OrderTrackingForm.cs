
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
    /// Sipariş İzleme Formu
    /// </summary>
    public partial class OrderTrackingForm : TTForm
    {
        override protected void BindControlEvents()
        {
            FirmsGrid.CellContentClick += new TTGridCellEventDelegate(FirmsGrid_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            FirmsGrid.CellContentClick -= new TTGridCellEventDelegate(FirmsGrid_CellContentClick);
            base.UnBindControlEvents();
        }

        private void FirmsGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region OrderTrackingForm_FirmsGrid_CellContentClick
   if(FirmsGrid.CurrentCell == null)
                return;
            
            AvailableItemsGrid.Rows.Clear();
            
            Guid guid = new Guid(FirmsGrid.CurrentCell.OwningRow.Cells["GUID"].Value.ToString());
            Supplier supplier = (Supplier)_PurchaseExamination.ObjectContext.GetObject(guid, "SUPPLIER") ;
            _PurchaseExamination.TmpSupplier = supplier;            
            
            IList<PurchaseOrder> activeOrders = PurchaseOrder.GetAllOrdersByFirm(_PurchaseExamination.ObjectContext,_PurchaseExamination.TmpSupplier.ObjectID.ToString());
            int count=0;
            if (activeOrders.Count > 0)
            {
                foreach(PurchaseOrder purchaseOrder in activeOrders)
                {
                    foreach(PurchaseOrderDetail purchaseOrderDetail in purchaseOrder.PurchaseOrderDetails)
                    {
                        if(purchaseOrderDetail.RestAmount > 0 && purchaseOrderDetail.Status == OrderDetailStatusEnum.IlkTeslimBekleniyor)
                        {
                            ITTGridRow newRow = this.AvailableItemsGrid.Rows.Add();
                            newRow.Cells["clmPurchaseItem"].Value = purchaseOrderDetail.PurchaseItemDef.ObjectID;
                            if(purchaseOrderDetail.ContractDetail.Material != null)
                                newRow.Cells["clmMaterial"].Value = purchaseOrderDetail.ContractDetail.Material.ObjectID;
                            newRow.Cells["clmOrderAmount"].Value = purchaseOrderDetail.Amount;
                            newRow.Cells["clmOrderDate"].Value = ((DateTime)purchaseOrderDetail.PurchaseOrder.OrderDate).ToShortDateString();
                            newRow.Cells["clmDueDate"].Value = ((DateTime)purchaseOrderDetail.PurchaseOrder.DueDate).ToShortDateString();
                            newRow.Cells["clmGUID"].Value = purchaseOrderDetail.ObjectID;
                        }
                    }
                }
            }
            else
            {
                InfoBox.Show("Bu firmaya ait ve teslimata uygun bir sipariş işlemi bulunamadı");
                this.Close();
            }
#endregion OrderTrackingForm_FirmsGrid_CellContentClick
        }

        protected override void PreScript()
        {
#region OrderTrackingForm_PreScript
    base.PreScript();
            
            this.DropStateButton(PurchaseExamination.States.InspectionMemorandumPreparing);
            
            ArrayList suppliers = new ArrayList();
            
            IList<PurchaseOrder> activeOrders = PurchaseOrder.GetActiveOrders(_PurchaseExamination.ObjectContext);
            foreach(PurchaseOrder po in activeOrders)
            {
                if(suppliers.Contains(po.Supplier) == false)
                {
                    foreach(PurchaseOrderDetail pod in po.PurchaseOrderDetails)
                    {
                        if(pod.Status == OrderDetailStatusEnum.IlkTeslimBekleniyor)
                        {
                            suppliers.Add(po.Supplier);
                            break;
                        }
                    }
                }
            }
            
            FirmsGrid.Rows.Clear();
            foreach(Supplier supp in suppliers)
            {
                ITTGridRow row = FirmsGrid.Rows.Add();
                row.Cells["SUPPLIER"].Value = supp.ObjectID;
                row.Cells["GUID"].Value = supp.ObjectID.ToString();
            }
#endregion OrderTrackingForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region OrderTrackingForm_PostScript
    base.PostScript(transDef);
            
            int orderNo = 0;
            Contract contract = null;
            string existingItems = null;
            
            foreach(ITTGridRow row in AvailableItemsGrid.Rows)
            {
                if(row.Cells[clmCheck.Name].Value != null)
                {
                    if((bool)row.Cells[clmCheck.Name].Value)
                    {
                        Guid guid = new Guid(row.Cells[clmGUID.Name].Value.ToString());
                        PurchaseOrderDetail pod = (PurchaseOrderDetail)_PurchaseExamination.ObjectContext.GetObject(guid, "PURCHASEORDERDETAIL");
                        
                        foreach(PurchaseExaminationDetail ped in _PurchaseExamination.PurchaseExaminationDetails)
                        {
                            if(ped.PurchaseItemDef.ObjectID == pod.PurchaseItemDef.ObjectID)
                            {
                                existingItems += "\n" + ped.PurchaseItemDef.ItemName;
                                break;
                            }
                        }
                        
                        if(string.IsNullOrEmpty(existingItems))
                        {
                            orderNo++;
                            PurchaseExaminationDetail pd = new PurchaseExaminationDetail(_PurchaseExamination.ObjectContext);
                            pd.PurchaseOrderDetail = pod;
                            pd.StockAction = (StockAction)_PurchaseExamination;
                            pd.StockLevelType = StockLevelType.NewStockLevel;
                            pd.OrderNO = orderNo;
                            pd.UnitPrice = pod.ContractDetail.UnitPrice;
                            pd.PurchaseItemDef = pod.PurchaseItemDef;
                            if(pod.ContractDetail.Material != null)
                                pd.Material = pod.ContractDetail.Material;
                            pd.Amount = pod.Amount;
                            contract = pod.PurchaseOrder.Contract;
                        }
                    }
                }
                row.ReadOnly = true;
            }
            
            if(string.IsNullOrEmpty(existingItems) == false)
                InfoBox.Alert("Aşağıdaki kalemler muayene işleminde zaten mevcut olduğu için ikinci defa eklenmeyecektir." + existingItems);
            
            if(contract != null)
            {
                _PurchaseExamination.Contract = contract;
            }
#endregion OrderTrackingForm_PostScript

            }
                }
}