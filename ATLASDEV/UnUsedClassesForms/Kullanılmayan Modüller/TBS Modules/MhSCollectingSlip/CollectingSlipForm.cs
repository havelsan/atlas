
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
    /// Tahsil Fişi
    /// </summary>
    public partial class CollectingSlip : TTForm
    {
        override protected void BindControlEvents()
        {
            JournalEntries.CellValueChanged += new TTGridCellEventDelegate(JournalEntries_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            JournalEntries.CellValueChanged -= new TTGridCellEventDelegate(JournalEntries_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void JournalEntries_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region CollectingSlip_JournalEntries_CellValueChanged
   int CREDITCOLUMNINDEX = 2, ACCOUNTCOLUMNINDEX = 0;
            MhSChargingSlipOperations cSlip = _ttObject as MhSChargingSlipOperations;
            double creditTotal = 0.0;
            double creditEx = Credit.Text.Equals("")?0:Double.Parse(Credit.Text);
            double debitEx = Debit.Text.Equals("")?0:Double.Parse(Debit.Text);
            if( columnIndex == CREDITCOLUMNINDEX){
                foreach(ITTGridRow gridRow in JournalEntries.Rows){
                    double credit = 0.0;
                    if( gridRow.Cells[CREDITCOLUMNINDEX].Value != null){
                        try{
                            credit = Double.Parse(gridRow.Cells[CREDITCOLUMNINDEX].Value.ToString());
                        }catch(FormatException fex){
                            MessageBox.Show("Not a number", "Hata");
                            return;
                        }                    
                        creditTotal += credit;
                    }
                }
                Credit.Text = creditTotal.ToString();
                Balance.Text = Math.Abs(debitEx-creditTotal).ToString();
            }else if( columnIndex == ACCOUNTCOLUMNINDEX){
                if(JournalEntries.Rows[rowIndex].Cells[ACCOUNTCOLUMNINDEX].Value != null){
                    Guid accountId = (Guid)JournalEntries.Rows[rowIndex].Cells[ACCOUNTCOLUMNINDEX].Value;
                    MhSAccount account = _ttObject.ObjectContext.GetObject(accountId, "MhSAccount") as MhSAccount;
                    
                    if(account.ChildAccounts.Count > 0){
                        MessageBox.Show("Alt hesapları olan bir hesabı seçemezsiniz", "Hata");
                        JournalEntries.Rows[rowIndex].Cells[ACCOUNTCOLUMNINDEX].Value = null;
                    }
                }
            }
#endregion CollectingSlip_JournalEntries_CellValueChanged
        }

        protected override void PreScript()
        {
#region CollectingSlip_PreScript
    SetSelectedCaseFilter();
            SetAccountSearchFilter();
#endregion CollectingSlip_PreScript

            }
            
#region CollectingSlip_Methods
        public MhSPeriod FindPeriod(){
            return _ttObject.ObjectContext.QueryObjects<MhSPeriod>("YEAR = 2103")[0];
        }
        public Guid GetChartOfAccountsObjectId(){
            return (Guid)FindPeriod().ChartOfAccounts[0].ObjectID;
        }
        private void SetAccountSearchFilter(){
            TTVisual.TTListBoxColumn accountColumn = JournalEntries.Columns["Account"] as TTVisual.TTListBoxColumn;
            accountColumn.ListFilterExpression = "CHARTOFACCOUNTS = '" + GetChartOfAccountsObjectId() + "'";
        }
        private void SetSelectedCaseFilter(){
            SelectedCase.ListFilterExpression = "CHARTOFACCOUNTS = '" + GetChartOfAccountsObjectId() + "'";
        }
        
#endregion CollectingSlip_Methods
    }
}