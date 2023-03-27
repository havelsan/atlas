
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
    /// Red Tebliğ
    /// </summary>
    public partial class RejectNoticeForm : StockActionBaseForm
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
#region RejectNoticeForm_StockActionInDetails_CellContentClick
   if(StockActionInDetails.CurrentCell == null)
                return;
            
            if(StockActionInDetails.CurrentCell.OwningColumn.Name == "CheckList")
            {
                CheckListForm cf = new CheckListForm();
                cf.ShowEdit(this.FindForm(), (PurchaseExaminationDetail)StockActionInDetails.CurrentCell.OwningRow.TTObject);
            }
#endregion RejectNoticeForm_StockActionInDetails_CellContentClick
        }

        protected override void PreScript()
        {
#region RejectNoticeForm_PreScript
    base.PreScript();
#endregion RejectNoticeForm_PreScript

            }
                }
}