
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
    /// Eski Siparişler
    /// </summary>
    public partial class RelatedOrdersForm : TTForm
    {
        override protected void BindControlEvents()
        {
            PurchaseOrdersGrid.SelectionChanged += new TTControlEventDelegate(PurchaseOrdersGrid_SelectionChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            PurchaseOrdersGrid.SelectionChanged -= new TTControlEventDelegate(PurchaseOrdersGrid_SelectionChanged);
            base.UnBindControlEvents();
        }

        private void PurchaseOrdersGrid_SelectionChanged()
        {
#region RelatedOrdersForm_PurchaseOrdersGrid_SelectionChanged
   Contract c = _Contract;
            c.tmpSelectedOrder = _Contract.PurchaseOrders[PurchaseOrdersGrid.CurrentCell.RowIndex];
#endregion RelatedOrdersForm_PurchaseOrdersGrid_SelectionChanged
        }

        protected override void PreScript()
        {
#region RelatedOrdersForm_PreScript
    base.PreScript();
            
            this.DropStateButton(Contract.States.Cancelled);
            foreach(ITTGridRow row in PurchaseOrdersGrid.Rows)
            {
                PurchaseOrder po = (PurchaseOrder)row.TTObject;
                row.Cells["State"].Value = po.CurrentStateDef.DisplayText.ToString();
            }
#endregion RelatedOrdersForm_PreScript

            }
                }
}