
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
    public partial class BaseDeleteAnimalRecordForm : BaseDeleteRecordDocumentForm
    {
        override protected void BindControlEvents()
        {
            StockActionOutDetails.CellContentClick += new TTGridCellEventDelegate(StockActionOutDetails_CellContentClick);
            StockActionOutDetails.CellDoubleClick += new TTGridCellEventDelegate(StockActionOutDetails_CellDoubleClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            StockActionOutDetails.CellContentClick -= new TTGridCellEventDelegate(StockActionOutDetails_CellContentClick);
            StockActionOutDetails.CellDoubleClick -= new TTGridCellEventDelegate(StockActionOutDetails_CellDoubleClick);
            base.UnBindControlEvents();
        }

        private void StockActionOutDetails_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region BaseDeleteAnimalRecordForm_StockActionOutDetails_CellContentClick
   if(StockActionOutDetails.CurrentCell.OwningColumn.Name =="Detail")
                this.ShowStockActionDetailForm((StockActionDetail)StockActionOutDetails.CurrentCell.OwningRow.TTObject);
#endregion BaseDeleteAnimalRecordForm_StockActionOutDetails_CellContentClick
        }

        private void StockActionOutDetails_CellDoubleClick(Int32 rowIndex, Int32 columnIndex)
        {
#region BaseDeleteAnimalRecordForm_StockActionOutDetails_CellDoubleClick
   CheckWhetherTheInventoryOfMaterial(rowIndex, columnIndex, StockActionOutDetails);
#endregion BaseDeleteAnimalRecordForm_StockActionOutDetails_CellDoubleClick
        }

        protected override void PreScript()
        {
#region BaseDeleteAnimalRecordForm_PreScript
    base.PreScript();
            
            ((ITTListBoxColumn)((ITTGridColumn)this.StockActionOutDetails.Columns[Material.Name])).ListFilterExpression = "STOCKS.STORE=" + ConnectionManager.GuidToString(this._DeleteAnimalRecordDocument.Store.ObjectID) + " AND STOCKS.INHELD > 0 AND STOCKS.MATERIAL.OBJECTDEFID = " + ConnectionManager.GuidToString(TTObjectDefManager.Instance.ObjectDefs[typeof(FixedAssetDefinition).Name].ID);
#endregion BaseDeleteAnimalRecordForm_PreScript

            }
                }
}