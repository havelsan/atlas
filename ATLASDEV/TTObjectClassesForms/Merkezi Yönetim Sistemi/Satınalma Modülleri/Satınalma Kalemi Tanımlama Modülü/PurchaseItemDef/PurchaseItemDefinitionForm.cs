
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
    /// Satınalma Kalemi Tanımları
    /// </summary>
    public partial class PurchaseItemDefinitionForm : TerminologyManagerDefForm
    {
        override protected void BindControlEvents()
        {
            StockCardListBox.SelectedObjectChanged += new TTControlEventDelegate(StockCardListBox_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            StockCardListBox.SelectedObjectChanged -= new TTControlEventDelegate(StockCardListBox_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void StockCardListBox_SelectedObjectChanged()
        {
#region PurchaseItemDefinitionForm_StockCardListBox_SelectedObjectChanged
   if (StockCardListBox.SelectedObject == null)
                txtTempDistType.ReadOnly = false;
            else
                txtTempDistType.ReadOnly = true;
#endregion PurchaseItemDefinitionForm_StockCardListBox_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region PurchaseItemDefinitionForm_PreScript
    base.PreScript();
            
            if(_PurchaseItemDef.StockCard == null)
                txtTempDistType.ReadOnly = false;
            else
                txtTempDistType.ReadOnly = true;
#endregion PurchaseItemDefinitionForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region PurchaseItemDefinitionForm_PostScript
    base.PostScript(transDef);
            
            if(_PurchaseItemDef.StockCard == null && string.IsNullOrEmpty(txtTempDistType.Text))
                throw new TTUtils.TTException("Stok kartı yada geçici ölçü birimi alanlarından en az biri doldurulmalıdır.");
#endregion PurchaseItemDefinitionForm_PostScript

            }
                }
}