
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
    /// El Senedi Dağıtım Belgesi
    /// </summary>
    public partial class VoucherDistributingDocumentApprovalForm : BaseVoucherDistributingDocumentForm
    {
        override protected void BindControlEvents()
        {
            StockActionOutDetails.CellContentClick += new TTGridCellEventDelegate(StockActionOutDetails_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            StockActionOutDetails.CellContentClick -= new TTGridCellEventDelegate(StockActionOutDetails_CellContentClick);
            base.UnBindControlEvents();
        }

        private void StockActionOutDetails_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region VoucherDistributingDocumentApprovalForm_StockActionOutDetails_CellContentClick
   if(StockActionOutDetails.CurrentCell.OwningColumn.Name =="Detail")
                this.ShowStockActionDetailForm((StockActionDetail)StockActionOutDetails.CurrentCell.OwningRow.TTObject);
#endregion VoucherDistributingDocumentApprovalForm_StockActionOutDetails_CellContentClick
        }

        protected override void PreScript()
        {
#region VoucherDistributingDocumentApprovalForm_PreScript
    base.PreScript();

            foreach (ITTGridRow stockActionOutDetailRow in StockActionOutDetails.Rows)
                if (stockActionOutDetailRow.Cells[Material.Name].Value != null)
                    stockActionOutDetailRow.Cells[Amount.Name].Value = stockActionOutDetailRow.Cells[RequireMaterial.Name].Value;
#endregion VoucherDistributingDocumentApprovalForm_PreScript

            }
                }
}