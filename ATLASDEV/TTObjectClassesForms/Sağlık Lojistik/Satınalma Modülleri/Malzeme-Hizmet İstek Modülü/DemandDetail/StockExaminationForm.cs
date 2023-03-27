
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
    /// Stok Detayları
    /// </summary>
    public partial class StockExaminationForm : TTForm
    {
        override protected void BindControlEvents()
        {
            MaterialsGrid.CellValueChanged += new TTGridCellEventDelegate(MaterialsGrid_CellValueChanged);
            StoreStocksGrid.CellContentClick += new TTGridCellEventDelegate(StoreStocksGrid_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            MaterialsGrid.CellValueChanged -= new TTGridCellEventDelegate(MaterialsGrid_CellValueChanged);
            StoreStocksGrid.CellContentClick -= new TTGridCellEventDelegate(StoreStocksGrid_CellContentClick);
            base.UnBindControlEvents();
        }

        private void MaterialsGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region StockExaminationForm_MaterialsGrid_CellValueChanged
   if(MaterialsGrid.CurrentCell == null)
                return;
            
            if(MaterialsGrid.CurrentCell.OwningColumn.Name == "TransferAmount")
            {
                double totalAmount = 0;
                DemandDetStoreStockDetail ddsd = (DemandDetStoreStockDetail)MaterialsGrid.CurrentCell.OwningRow.TTObject;
                foreach(DemandDetStoreStockDetail ds in ddsd.DemandDetailStoreStock.StoreStockDetails)
                {
                    if(ds.TransferAmount != null)
                        totalAmount += (double)ds.TransferAmount;
                }
                ddsd.DemandDetailStoreStock.TransferAmount = totalAmount;
            }
#endregion StockExaminationForm_MaterialsGrid_CellValueChanged
        }

        private void StoreStocksGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region StockExaminationForm_StoreStocksGrid_CellContentClick
   if(StoreStocksGrid.CurrentCell == null)
                return;
            
            _DemandDetail.TmpDemandDetailStoreStock = (DemandDetailStoreStock)StoreStocksGrid.CurrentCell.OwningRow.TTObject;
#endregion StockExaminationForm_StoreStocksGrid_CellContentClick
        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region StockExaminationForm_PostScript
    base.PostScript(transDef);
            
            _DemandDetail.AddTransferForDemand();
#endregion StockExaminationForm_PostScript

            }
                }
}