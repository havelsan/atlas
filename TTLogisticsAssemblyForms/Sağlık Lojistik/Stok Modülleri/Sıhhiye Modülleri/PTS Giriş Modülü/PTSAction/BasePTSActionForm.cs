
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
    public partial class BasePTSActionForm : StockActionBaseForm
    {
        override protected void BindControlEvents()
        {
            StockActionInDetails.CellContentClick += new TTGridCellEventDelegate(StockActionInDetails_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            StockActionInDetails.CellContentClick -= new TTGridCellEventDelegate(StockActionInDetails_CellContentClick);
            base.UnBindControlEvents();
        }

        private void StockActionInDetails_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region BasePTSActionForm_StockActionInDetails_CellContentClick
   if(StockActionInDetails.CurrentCell.OwningColumn.Name =="Detail")
                this.ShowStockActionDetailForm((StockActionDetail)StockActionInDetails.CurrentCell.OwningRow.TTObject);
#endregion BasePTSActionForm_StockActionInDetails_CellContentClick
        }

        protected override void PreScript()
        {
#region BasePTSActionForm_PreScript
    base.PreScript();
#endregion BasePTSActionForm_PreScript

            }
                }
}