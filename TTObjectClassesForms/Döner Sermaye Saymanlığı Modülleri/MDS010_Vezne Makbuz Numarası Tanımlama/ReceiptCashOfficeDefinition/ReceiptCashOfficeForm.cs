
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
    /// Vezne Alındı Numarası Tanımlama
    /// </summary>
    public partial class ReceiptCashOfficeForm : TTDefinitionForm
    {
        override protected void BindControlEvents()
        {
            chxCreditCardPayment.CheckedChanged += new TTControlEventDelegate(chxCreditCardPayment_CheckedChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            chxCreditCardPayment.CheckedChanged -= new TTControlEventDelegate(chxCreditCardPayment_CheckedChanged);
            base.UnBindControlEvents();
        }

        private void chxCreditCardPayment_CheckedChanged()
        {
#region ReceiptCashOfficeForm_chxCreditCardPayment_CheckedChanged
   ChangeCreditCardTextBoxesAccessibility(chxCreditCardPayment.Value.Value == true);
#endregion ReceiptCashOfficeForm_chxCreditCardPayment_CheckedChanged
        }

        protected override void PreScript()
        {
#region ReceiptCashOfficeForm_PreScript
    base.PreScript();
            ChangeCreditCardTextBoxesAccessibility(_ReceiptCashOfficeDefinition.UseDifferentNumberForCC !=null ? _ReceiptCashOfficeDefinition.UseDifferentNumberForCC.Value : false );
#endregion ReceiptCashOfficeForm_PreScript

            }
            
#region ReceiptCashOfficeForm_Methods
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ChangeCreditCardTextBoxesAccessibility(false);
        }
        
        public void ChangeCreditCardTextBoxesAccessibility(bool isEnabled)
        {
            txtCREDITCARDSERIESNO.Enabled = isEnabled;
            txtCREDITCARDSTARTNUMBER.Enabled = isEnabled;
            txtCREDITCARDENDNUMBER.Enabled = isEnabled;
            txtCURRENTCREDITCARDNUMBER.Enabled = isEnabled;
            txtCREDITCARDSERIESNO.Required = isEnabled;
            txtCREDITCARDSTARTNUMBER.Required = isEnabled;
            txtCREDITCARDENDNUMBER.Required = isEnabled;
            txtCURRENTCREDITCARDNUMBER.Required = isEnabled;
        }
        
#endregion ReceiptCashOfficeForm_Methods
    }
}