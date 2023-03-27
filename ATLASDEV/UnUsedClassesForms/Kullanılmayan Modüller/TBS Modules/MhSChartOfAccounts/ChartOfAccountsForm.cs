
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
    /// Hesap Planı
    /// </summary>
    public partial class ChartOfAccountsForm : TTForm
    {
        override protected void BindControlEvents()
        {
            deleteAccountButton.Click += new TTControlEventDelegate(deleteAccountButton_Click);
            Accounts.CellDoubleClick += new TTGridCellEventDelegate(Accounts_CellDoubleClick);
            editAccountButton.Click += new TTControlEventDelegate(editAccountButton_Click);
            newAccountButton.Click += new TTControlEventDelegate(newAccountButton_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            deleteAccountButton.Click -= new TTControlEventDelegate(deleteAccountButton_Click);
            Accounts.CellDoubleClick -= new TTGridCellEventDelegate(Accounts_CellDoubleClick);
            editAccountButton.Click -= new TTControlEventDelegate(editAccountButton_Click);
            newAccountButton.Click -= new TTControlEventDelegate(newAccountButton_Click);
            base.UnBindControlEvents();
        }

        private void deleteAccountButton_Click()
        {
#region ChartOfAccountsForm_deleteAccountButton_Click
   MhSAccount rAccount = GetSelectedAccount();
            if(rAccount == null)
                return;
            if(rAccount.Level <= 3){
                MessageBox.Show("Hesap Tekdüzen Muhasebe Sistemi ana hesabı olduğu için silinemez!", "Hata");
            }else{
                IList resultList = _MhSChartOfAccounts.ObjectContext.QueryObjects("MhSJournalEntry", "Account = '" + rAccount.ObjectID + "' ");
                if(resultList == null || resultList.Count == 0){
                    _MhSChartOfAccounts.Accounts.Remove(rAccount);
                }else{
                    MessageBox.Show("Hesap Fiş Girişlerinde kullanıldığı için silinemez", "Hata");
                }
            }
#endregion ChartOfAccountsForm_deleteAccountButton_Click
        }

        private void Accounts_CellDoubleClick(Int32 rowIndex, Int32 columnIndex)
        {
#region ChartOfAccountsForm_Accounts_CellDoubleClick
   //            if(rowIndex >= _MhSChartOfAccounts.Accounts.Count)
            //                return;
            //            MhSAccount selectedAccount = _MhSChartOfAccounts.Accounts[rowIndex] as MhSAccount;
            //
            //            TTObjectContext subContext = new TTObjectContext(false);
            //            MhSAccount sAccount = subContext.GetObject(selectedAccount.ObjectID, "MhSAccount") as MhSAccount;
            //            NewAccountForm accountForm = new NewAccountForm();
            //            DialogResult deaResult = accountForm.ShowEdit(this.FindForm(), sAccount);
            //            if(deaResult == DialogResult.OK){
            //                subContext.Save();
            //                selectedAccount = _MhSChartOfAccounts.ObjectContext.QueryObjects<MhSAccount>("ObjectID = '" + sAccount.ObjectID + "'")[0];
            //                _MhSChartOfAccounts.Accounts[rowIndex] = selectedAccount;
            //            }
            //            subContext.Dispose();
            if(GetSelectedAccount()== null){
                newAccountButton_Click();
            }else{
                editAccountButton_Click();
            }
#endregion ChartOfAccountsForm_Accounts_CellDoubleClick
        }

        private void editAccountButton_Click()
        {
#region ChartOfAccountsForm_editAccountButton_Click
   MhSAccount selectedAccount = GetSelectedAccount();
            if (selectedAccount == null)
                return;
            else
            {
                TTObjectContext subContext = new TTObjectContext(false);
                MhSAccount sAccount = subContext.GetObject(selectedAccount.ObjectID, "MhSAccount") as MhSAccount;
                NewAccountForm accountForm = new NewAccountForm();
                DialogResult dResult = accountForm.ShowEdit(this.FindForm(), sAccount);
                if (DialogResult.OK.Equals(dResult))
                {
                    subContext.Save();
                    selectedAccount = _MhSChartOfAccounts.ObjectContext.QueryObjects<MhSAccount>("ObjectID = '" + sAccount.ObjectID + "'")[0];
                    _MhSChartOfAccounts.Accounts.ResetBindings();
                }
                subContext.Dispose(); 
            }
#endregion ChartOfAccountsForm_editAccountButton_Click
        }

        private void newAccountButton_Click()
        {
#region ChartOfAccountsForm_newAccountButton_Click
   TTObjectContext subContext = new TTObjectContext(false);
            MhSAccount subAccount = new MhSAccount(subContext);
            subAccount.ChartOfAccounts = _MhSChartOfAccounts;
            NewAccountForm accountForm = new NewAccountForm();
            DialogResult dResult =  accountForm.ShowEdit(this.FindForm(), subAccount);
            if (dResult.Equals(DialogResult.OK))
            {
                subContext.Save();
                subAccount = _MhSChartOfAccounts.ObjectContext.QueryObjects<MhSAccount>("ObjectID = '" + subAccount.ObjectID + "'")[0];
                _MhSChartOfAccounts.Accounts.Add(subAccount);
            }
            subContext.Dispose();
#endregion ChartOfAccountsForm_newAccountButton_Click
        }

        protected override void PreScript()
        {
#region ChartOfAccountsForm_PreScript
    if(_MhSChartOfAccounts.CurrentStateDef!= null){
                if (MhSChartOfAccounts.States.New.Equals(_MhSChartOfAccounts.CurrentStateDef.StateDefID))
                {
                    this.newAccountButton.Visible = false;
                    this.editAccountButton.Visible = false;
                    this.deleteAccountButton.Visible = false;
                    //this.Accounts.ReadOnly = true;
                }
                if (MhSChartOfAccounts.States.Completed.Equals(_MhSChartOfAccounts.CurrentStateDef.StateDefID))
                {
                    this.newAccountButton.Visible = false;
                    this.editAccountButton.Visible = false;
                    this.deleteAccountButton.Visible = false;
                    //this.Accounts.ReadOnly = true;
                }
            }
#endregion ChartOfAccountsForm_PreScript

            }
            
#region ChartOfAccountsForm_Methods
        public MhSAccount GetSelectedAccount(){
            int rowIndex = Accounts.CurrentCell.RowIndex;
            if(rowIndex != -1 && _MhSChartOfAccounts.Accounts.Count > rowIndex){
                return _MhSChartOfAccounts.Accounts[rowIndex];
            }
            return null;
        }
        public void SetSelectedAccount(MhSAccount account)
        {
            int rowIndex = Accounts.CurrentCell.RowIndex;
            if(rowIndex != -1 && _MhSChartOfAccounts.Accounts.Count > rowIndex){
                _MhSChartOfAccounts.Accounts[rowIndex] = account;
            }
        }
        
#endregion ChartOfAccountsForm_Methods
    }
}