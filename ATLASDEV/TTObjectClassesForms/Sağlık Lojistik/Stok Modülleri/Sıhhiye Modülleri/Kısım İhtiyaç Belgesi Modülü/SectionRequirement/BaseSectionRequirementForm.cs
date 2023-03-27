
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
    /// BaseSectionRequirementForm
    /// </summary>
    public partial class BaseSectionRequirementForm : StockActionBaseForm
    {
        override protected void BindControlEvents()
        {
            StockActionOutDetails.CellDoubleClick += new TTGridCellEventDelegate(StockActionOutDetails_CellDoubleClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            StockActionOutDetails.CellDoubleClick -= new TTGridCellEventDelegate(StockActionOutDetails_CellDoubleClick);
            base.UnBindControlEvents();
        }

        private void StockActionOutDetails_CellDoubleClick(Int32 rowIndex, Int32 columnIndex)
        {
#region BaseSectionRequirementForm_StockActionOutDetails_CellDoubleClick
   CheckWhetherTheInventoryOfMaterial(rowIndex, columnIndex, StockActionOutDetails);
#endregion BaseSectionRequirementForm_StockActionOutDetails_CellDoubleClick
        }
    }
}