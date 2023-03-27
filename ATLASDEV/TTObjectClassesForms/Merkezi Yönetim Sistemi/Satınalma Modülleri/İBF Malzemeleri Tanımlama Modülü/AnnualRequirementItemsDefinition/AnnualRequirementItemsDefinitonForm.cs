
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
    /// İBF Malzemeleri Tanımlama
    /// </summary>
    public partial class AnnualRequirementItemsDefiniton : TerminologyManagerDefForm
    {
        override protected void BindControlEvents()
        {
            ARItemsGrid.CellValueChanged += new TTGridCellEventDelegate(ARItemsGrid_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ARItemsGrid.CellValueChanged -= new TTGridCellEventDelegate(ARItemsGrid_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void ARItemsGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region AnnualRequirementItemsDefiniton_ARItemsGrid_CellValueChanged
   if(ARItemsGrid.CurrentCell == null)
                return;
            
            if(columnIndex == ARItemsGrid.Columns[PurchaseItem.Name].Index)
            {
                AnnualRequirementItem ari = (AnnualRequirementItem)ARItemsGrid.Rows[rowIndex].TTObject;
                if(ari.PurchaseItemDef != null && ari.OrderNo == null)
                {
                    ari.OrderNo = rowIndex + 1;
                }
            }
#endregion AnnualRequirementItemsDefiniton_ARItemsGrid_CellValueChanged
        }
    }
}