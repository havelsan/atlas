
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
    /// Hesap Tanımlama
    /// </summary>
    public partial class NewAccountForm : TTForm
    {
        override protected void BindControlEvents()
        {
            ParentAccount.SelectedObjectChanged += new TTControlEventDelegate(ParentAccount_SelectedObjectChanged);
            Code.TextChanged += new TTControlEventDelegate(Code_TextChanged);
            tttabcontrol1.SelectedTabChanged += new TTControlEventDelegate(tttabcontrol1_SelectedTabChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ParentAccount.SelectedObjectChanged -= new TTControlEventDelegate(ParentAccount_SelectedObjectChanged);
            Code.TextChanged -= new TTControlEventDelegate(Code_TextChanged);
            tttabcontrol1.SelectedTabChanged -= new TTControlEventDelegate(tttabcontrol1_SelectedTabChanged);
            base.UnBindControlEvents();
        }

        private void ParentAccount_SelectedObjectChanged()
        {
#region NewAccountForm_ParentAccount_SelectedObjectChanged
   MhSAccount selectedParent = _MhSAccount.ParentAccount; //ParentAccount.TTObject as MhSAccount;
            if(selectedParent == null){
                _MhSAccount.Level = 1;
            }else{
                _MhSAccount.Level = selectedParent.Level + 1;
                if (selectedParent.Level >= 1)
                    Code.Text = selectedParent.Level >= 3 ? selectedParent.Code + "." : selectedParent.Code;
            }
#endregion NewAccountForm_ParentAccount_SelectedObjectChanged
        }

        private void Code_TextChanged()
        {
#region NewAccountForm_Code_TextChanged
   if(_MhSAccount.ParentAccount != null){
                String baseCode = _MhSAccount.ParentAccount.Level >= 3 ? _MhSAccount.ParentAccount.Code + "." : _MhSAccount.ParentAccount.Code;
                if (Code.Text.IndexOf(baseCode) != 0)
                {
                    MessageBox.Show("Hesap kodu üst hesabın kodunu içermek zorundadır.", "Hata");
                    Code.Text = baseCode;
                }
            }
#endregion NewAccountForm_Code_TextChanged
        }

        private void tttabcontrol1_SelectedTabChanged()
        {
#region NewAccountForm_tttabcontrol1_SelectedTabChanged
   if(tttabcontrol1.SelectedTab.Name.Equals("Balances")){
                IList<MhSMonthlyBalance> list = _MhSAccount.BalanceStatuses.Select(null);
                foreach(MhSMonthlyBalance mB in list){
                    _MhSAccount.BalanceStatuses.Add(mB);
                }
            }
#endregion NewAccountForm_tttabcontrol1_SelectedTabChanged
        }

        protected override void PreScript()
        {
#region NewAccountForm_PreScript
    SetParentAccountFilter();
#endregion NewAccountForm_PreScript

            }
            
#region NewAccountForm_Methods
        private void SetParentAccountFilter(){
            String filterString = "";
            filterString += "ChartOfAccounts = '" + _MhSAccount.ChartOfAccounts.ObjectID + "'";
            this.ParentAccount.ListFilterExpression = filterString;
        }
        
#endregion NewAccountForm_Methods
    }
}