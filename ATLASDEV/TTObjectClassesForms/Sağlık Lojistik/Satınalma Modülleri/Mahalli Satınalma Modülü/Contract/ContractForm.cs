
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
    /// Sözleşme Bilgileri
    /// </summary>
    public partial class ContractForm : TTForm
    {
        override protected void BindControlEvents()
        {
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            KIKWage.TextChanged += new TTControlEventDelegate(KIKWage_TextChanged);
            KIKWageRate.TextChanged += new TTControlEventDelegate(KIKWageRate_TextChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            KIKWage.TextChanged -= new TTControlEventDelegate(KIKWage_TextChanged);
            KIKWageRate.TextChanged -= new TTControlEventDelegate(KIKWageRate_TextChanged);
            base.UnBindControlEvents();
        }

        private void ttbutton1_Click()
        {
#region ContractForm_ttbutton1_Click
   if(string.IsNullOrEmpty(txtNewBondAmount.Text))
                return;

            try
            {
                if(_Contract.ContractBondAmount == null)
                    _Contract.ContractBondAmount = Convert.ToDouble(txtNewBondAmount.Text);
                else if (Convert.ToDouble(txtNewBondAmount.Text) > (double)_Contract.ContractBondAmount)
                    _Contract.ContractBondAmount = Convert.ToDouble(txtNewBondAmount.Text);
                else if (Convert.ToDouble(txtNewBondAmount.Text) < (double)_Contract.ContractBondAmount)
                    InfoBox.Show(SystemMessage.GetMessage(46));
            }
            catch
            {
                InfoBox.Show(SystemMessage.GetMessage(47));
            }
#endregion ContractForm_ttbutton1_Click
        }

        private void KIKWage_TextChanged()
        {
#region ContractForm_KIKWage_TextChanged
   _Contract.KIKWage = _Contract.TotalContractValue * _Contract.KIKWageRate;
#endregion ContractForm_KIKWage_TextChanged
        }

        private void KIKWageRate_TextChanged()
        {
#region ContractForm_KIKWageRate_TextChanged
   if (KIKWageRate.Text != "" && txtTotalContractValue.Text != "")
                KIKWage.Text = Convert.ToString(Convert.ToDouble(KIKWageRate.Text) * Convert.ToDouble(txtTotalContractValue.Text));
#endregion ContractForm_KIKWageRate_TextChanged
        }

        protected override void PreScript()
        {
#region ContractForm_PreScript
    base.PreScript();
            
            this.DropStateButton(Contract.States.Cancelled);
            if(this.Owner is ContractEntryForm)
                this.DropStateButton(Contract.States.Closed);
            
            if(_Contract.PurchaseProject.CurrentStateDefID == PurchaseProject.States.Completed)
                ContractInfoGroup.ReadOnly = true;
            else
                ContractInfoGroup.ReadOnly = false;
            
            if(_Contract.ContractDetails.Count == 0)
            {
                foreach(PurchaseProjectDetail ppd in _Contract.PurchaseProject.PurchaseProjectDetails)
                {
                    ContractDetail cd = new ContractDetail(_Contract.ObjectContext);
                    cd.Contract = _Contract;
                    cd.CurrentStateDefID = ContractDetail.States.New;
                    cd.PurchaseItemDef = ppd.PurchaseItemDef;
                    cd.Amount = ppd.Amount;
                }
            }
#endregion ContractForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ContractForm_PostScript
    base.PostScript(transDef);

    foreach (ITTGridRow row in ContractDetailsGrid.Rows)
    {
        if ((bool)row.Cells[IncludeContract.Name].Value == false)
        {
            ContractDetail cd = (ContractDetail)row.TTObject;
            ((ITTObject)cd).Delete();
        }
    }
#endregion ContractForm_PostScript

            }
                }
}