
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
    /// Muvakkaten Sayım Düzeltme Belgesi
    /// </summary>
    public partial class BaseConsignedCensusFixed : StockActionBaseForm
    {
        override protected void BindControlEvents()
        {
            StockActionInDetails.CellValueChanged += new TTGridCellEventDelegate(StockActionInDetails_CellValueChanged);
            StockActionInDetails.CellDoubleClick += new TTGridCellEventDelegate(StockActionInDetails_CellDoubleClick);
            StockActionOutDetails.CellDoubleClick += new TTGridCellEventDelegate(StockActionOutDetails_CellDoubleClick);
            StockActionOutDetails.CellValueChanged += new TTGridCellEventDelegate(StockActionOutDetails_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            StockActionInDetails.CellValueChanged -= new TTGridCellEventDelegate(StockActionInDetails_CellValueChanged);
            StockActionInDetails.CellDoubleClick -= new TTGridCellEventDelegate(StockActionInDetails_CellDoubleClick);
            StockActionOutDetails.CellDoubleClick -= new TTGridCellEventDelegate(StockActionOutDetails_CellDoubleClick);
            StockActionOutDetails.CellValueChanged -= new TTGridCellEventDelegate(StockActionOutDetails_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void StockActionInDetails_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region BaseConsignedCensusFixed_StockActionInDetails_CellValueChanged
   if (this is ConsignedCensusFixedForm)
            {
                ITTGridCell changedCell = StockActionInDetails.Rows[rowIndex].Cells[columnIndex];
                ITTGridRow changedRow = changedCell.OwningRow;
                if (changedCell.OwningColumn.Name == CardAmount.Name || changedCell.OwningColumn.Name == CensusAmount.Name)
                {
                    if (changedCell.Value != null)
                    {
                        ConsignedCensusFixedMaterialIn consignedCensusFixedMaterialIn = changedRow.TTObject as ConsignedCensusFixedMaterialIn;
                        if (consignedCensusFixedMaterialIn != null && consignedCensusFixedMaterialIn.CardAmount.HasValue && consignedCensusFixedMaterialIn.CensusAmount.HasValue)
                            consignedCensusFixedMaterialIn.Amount = consignedCensusFixedMaterialIn.CensusAmount - consignedCensusFixedMaterialIn.CardAmount;
                    }
                }
            }
#endregion BaseConsignedCensusFixed_StockActionInDetails_CellValueChanged
        }

        private void StockActionInDetails_CellDoubleClick(Int32 rowIndex, Int32 columnIndex)
        {
#region BaseConsignedCensusFixed_StockActionInDetails_CellDoubleClick
   CheckWhetherTheInventoryOfMaterial(rowIndex, columnIndex, StockActionInDetails);
#endregion BaseConsignedCensusFixed_StockActionInDetails_CellDoubleClick
        }

        private void StockActionOutDetails_CellDoubleClick(Int32 rowIndex, Int32 columnIndex)
        {
#region BaseConsignedCensusFixed_StockActionOutDetails_CellDoubleClick
   CheckWhetherTheInventoryOfMaterial(rowIndex, columnIndex, StockActionOutDetails);
#endregion BaseConsignedCensusFixed_StockActionOutDetails_CellDoubleClick
        }

        private void StockActionOutDetails_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region BaseConsignedCensusFixed_StockActionOutDetails_CellValueChanged
   if (this is ConsignedCensusFixedForm)
            {
                ITTGridCell changedCell = StockActionOutDetails.Rows[rowIndex].Cells[columnIndex];
                ITTGridRow changedRow = changedCell.OwningRow;
                if (changedCell.OwningColumn.Name == CardAmountOut.Name || changedCell.OwningColumn.Name == CensusAmountOut.Name)
                {
                    if (changedCell.Value != null)
                    {
                        ConsignedCensusFixedMaterialOut consignedCensusFixedMaterialOut = changedRow.TTObject as ConsignedCensusFixedMaterialOut;
                        if (consignedCensusFixedMaterialOut != null && consignedCensusFixedMaterialOut.CardAmount.HasValue && consignedCensusFixedMaterialOut.CensusAmount.HasValue)
                            consignedCensusFixedMaterialOut.Amount = consignedCensusFixedMaterialOut.CardAmount - consignedCensusFixedMaterialOut.CensusAmount;
                    }
                }
            }
#endregion BaseConsignedCensusFixed_StockActionOutDetails_CellValueChanged
        }
    }
}