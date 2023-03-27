
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
    /// Taşınır Mal İşlemi Giriş (Reçeteler İçin)
    /// </summary>
    public partial class BasePresChaDocInputWithAccountancyForm : BaseChattelDocumentInputWithAccountancyForm
    {
        override protected void BindControlEvents()
        {
            PresChaDocInputWithAccountancyDetails.CellValueChanged += new TTGridCellEventDelegate(PresChaDocInputWithAccountancyDetails_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            PresChaDocInputWithAccountancyDetails.CellValueChanged -= new TTGridCellEventDelegate(PresChaDocInputWithAccountancyDetails_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void PresChaDocInputWithAccountancyDetails_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region BasePresChaDocInputWithAccountancyForm_PresChaDocInputWithAccountancyDetails_CellValueChanged
   if(PresChaDocInputWithAccountancyDetails.CurrentCell.OwningColumn.Name == "AmountPresChaDocInputDetWithAccountancy" ||
               PresChaDocInputWithAccountancyDetails.CurrentCell.OwningColumn.Name == "UnitPricePresChaDocInputDetWithAccountancy")
                txtTotalPrice.Text = CalculateTotalPrice().ToString();
#endregion BasePresChaDocInputWithAccountancyForm_PresChaDocInputWithAccountancyDetails_CellValueChanged
        }

        protected override void PreScript()
        {
#region BasePresChaDocInputWithAccountancyForm_PreScript
    base.PreScript();
            txtTotalPrice.Text = CalculateTotalPrice().ToString();
            ChattelDocumentTabcontrol.HideTabPage(ChattelDocumentDetailTabpage);
#endregion BasePresChaDocInputWithAccountancyForm_PreScript

            }
                }
}