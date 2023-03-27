
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
    /// Sayım Düzeltme Belgesi (Reçeteler İçin)
    /// </summary>
    public partial class BasePresCensusFixedForm : StockActionBaseForm
    {
        override protected void BindControlEvents()
        {
            PresCensusFixedInMaterials.CellContentClick += new TTGridCellEventDelegate(PresCensusFixedInMaterials_CellContentClick);
            PresCensusFixedInMaterials.CellValueChanged += new TTGridCellEventDelegate(PresCensusFixedInMaterials_CellValueChanged);
            PresCensusFixedInMaterials.CellDoubleClick += new TTGridCellEventDelegate(PresCensusFixedInMaterials_CellDoubleClick);
            PresCensusFixedOutMaterials.CellContentClick += new TTGridCellEventDelegate(PresCensusFixedOutMaterials_CellContentClick);
            PresCensusFixedOutMaterials.CellValueChanged += new TTGridCellEventDelegate(PresCensusFixedOutMaterials_CellValueChanged);
            PresCensusFixedOutMaterials.CellDoubleClick += new TTGridCellEventDelegate(PresCensusFixedOutMaterials_CellDoubleClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            PresCensusFixedInMaterials.CellContentClick -= new TTGridCellEventDelegate(PresCensusFixedInMaterials_CellContentClick);
            PresCensusFixedInMaterials.CellValueChanged -= new TTGridCellEventDelegate(PresCensusFixedInMaterials_CellValueChanged);
            PresCensusFixedInMaterials.CellDoubleClick -= new TTGridCellEventDelegate(PresCensusFixedInMaterials_CellDoubleClick);
            PresCensusFixedOutMaterials.CellContentClick -= new TTGridCellEventDelegate(PresCensusFixedOutMaterials_CellContentClick);
            PresCensusFixedOutMaterials.CellValueChanged -= new TTGridCellEventDelegate(PresCensusFixedOutMaterials_CellValueChanged);
            PresCensusFixedOutMaterials.CellDoubleClick -= new TTGridCellEventDelegate(PresCensusFixedOutMaterials_CellDoubleClick);
            base.UnBindControlEvents();
        }

        private void PresCensusFixedInMaterials_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region BasePresCensusFixedForm_PresCensusFixedInMaterials_CellContentClick
   if(PresCensusFixedInMaterials.CurrentCell.OwningColumn.Name =="InDetail")
                this.ShowStockActionDetailForm((StockActionDetail)PresCensusFixedInMaterials.CurrentCell.OwningRow.TTObject);
#endregion BasePresCensusFixedForm_PresCensusFixedInMaterials_CellContentClick
        }

        private void PresCensusFixedInMaterials_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region BasePresCensusFixedForm_PresCensusFixedInMaterials_CellValueChanged
   if (this is PresCensusFixedNewForm)
            {
                ITTGridCell changedCell = PresCensusFixedInMaterials.Rows[rowIndex].Cells[columnIndex];
                ITTGridRow changedRow = changedCell.OwningRow;
                if (changedCell.OwningColumn.Name == CardAmount.Name || changedCell.OwningColumn.Name == CensusAmount.Name)
                {
                    if (changedCell.Value != null)
                    {
                        PresCensusFixedMaterialIn censusFixedMaterialIn = changedRow.TTObject as PresCensusFixedMaterialIn;
                        if (censusFixedMaterialIn != null && censusFixedMaterialIn.CardAmount.HasValue && censusFixedMaterialIn.CensusAmount.HasValue)
                            censusFixedMaterialIn.Amount = censusFixedMaterialIn.CensusAmount - censusFixedMaterialIn.CardAmount;
                    }
                }
            }
#endregion BasePresCensusFixedForm_PresCensusFixedInMaterials_CellValueChanged
        }

        private void PresCensusFixedInMaterials_CellDoubleClick(Int32 rowIndex, Int32 columnIndex)
        {
#region BasePresCensusFixedForm_PresCensusFixedInMaterials_CellDoubleClick
   CheckWhetherTheInventoryOfMaterial(rowIndex, columnIndex, PresCensusFixedInMaterials);
#endregion BasePresCensusFixedForm_PresCensusFixedInMaterials_CellDoubleClick
        }

        private void PresCensusFixedOutMaterials_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region BasePresCensusFixedForm_PresCensusFixedOutMaterials_CellContentClick
   if(PresCensusFixedOutMaterials.CurrentCell.OwningColumn.Name =="OutDetail")
                this.ShowStockActionDetailForm((StockActionDetail)PresCensusFixedOutMaterials.CurrentCell.OwningRow.TTObject);
#endregion BasePresCensusFixedForm_PresCensusFixedOutMaterials_CellContentClick
        }

        private void PresCensusFixedOutMaterials_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region BasePresCensusFixedForm_PresCensusFixedOutMaterials_CellValueChanged
   if (this is PresCensusFixedNewForm)
            {
                ITTGridCell changedCell = PresCensusFixedOutMaterials.Rows[rowIndex].Cells[columnIndex];
                ITTGridRow changedRow = changedCell.OwningRow;
                if (changedCell.OwningColumn.Name == CardAmountOut.Name || changedCell.OwningColumn.Name == CensusAmountOut.Name)
                {
                    if (changedCell.Value != null)
                    {
                        PresCensusFixedMaterialOut censusFixedMaterialOut = changedRow.TTObject as PresCensusFixedMaterialOut;
                        if (censusFixedMaterialOut != null && censusFixedMaterialOut.CardAmount.HasValue && censusFixedMaterialOut.CensusAmount.HasValue)
                            censusFixedMaterialOut.Amount = censusFixedMaterialOut.CardAmount - censusFixedMaterialOut.CensusAmount;
                    }
                }
            }
#endregion BasePresCensusFixedForm_PresCensusFixedOutMaterials_CellValueChanged
        }

        private void PresCensusFixedOutMaterials_CellDoubleClick(Int32 rowIndex, Int32 columnIndex)
        {
#region BasePresCensusFixedForm_PresCensusFixedOutMaterials_CellDoubleClick
   CheckWhetherTheInventoryOfMaterial(rowIndex, columnIndex, PresCensusFixedOutMaterials);
#endregion BasePresCensusFixedForm_PresCensusFixedOutMaterials_CellDoubleClick
        }
    }
}