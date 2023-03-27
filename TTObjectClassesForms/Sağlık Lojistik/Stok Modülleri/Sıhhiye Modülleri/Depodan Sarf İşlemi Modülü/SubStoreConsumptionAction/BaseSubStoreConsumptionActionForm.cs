
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
    /// Depodan Sarf
    /// </summary>
    public partial class BaseSubStoreConsumptionActionForm : StockActionBaseForm
    {
        override protected void BindControlEvents()
        {
            SubStoreConsumptionActionDetails.CellContentClick += new TTGridCellEventDelegate(SubStoreConsumptionActionDetails_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            SubStoreConsumptionActionDetails.CellContentClick -= new TTGridCellEventDelegate(SubStoreConsumptionActionDetails_CellContentClick);
            base.UnBindControlEvents();
        }

        private void SubStoreConsumptionActionDetails_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region BaseSubStoreConsumptionActionForm_SubStoreConsumptionActionDetails_CellContentClick
   if(SubStoreConsumptionActionDetails.CurrentCell.OwningColumn.Name =="Detail")
                this.ShowStockActionDetailForm((StockActionDetail)SubStoreConsumptionActionDetails.CurrentCell.OwningRow.TTObject);
#endregion BaseSubStoreConsumptionActionForm_SubStoreConsumptionActionDetails_CellContentClick
        }

        protected override void PreScript()
        {
#region BaseSubStoreConsumptionActionForm_PreScript
    base.PreScript();

            if (this._SubStoreConsumptionAction.CurrentStateDefID == SubStoreConsumptionAction.States.New)
            {
                string filterExpression = string.Empty;
                if (this._SubStoreConsumptionAction.Store != null && this._SubStoreConsumptionAction.Store is DependentStoreDefinition)
                    filterExpression = "STOCKS.STORE = " + ConnectionManager.GuidToString(this._SubStoreConsumptionAction.Store.ObjectID) + " AND STOCKS.INHELD > 0";
                //else
                //    filterExpression = "STOCKS.STORE = " + ConnectionManager.GuidToString(this._SubStoreConsumptionAction.Store.ObjectID) + " AND (STOCKS.EXPENDABLE = 1 OR (STOCKS.STOCKEXPENDABLEDETAILS.STARTDATE < GETDATE() AND STOCKS.STOCKEXPENDABLEDETAILS.ENDDATE > GETDATE()))";

                ((ITTListBoxColumn)((ITTGridColumn)this.SubStoreConsumptionActionDetails.Columns["Material"])).ListFilterExpression = filterExpression;
            }
#endregion BaseSubStoreConsumptionActionForm_PreScript

            }
                }
}