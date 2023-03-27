
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
    /// Mahsup Fişi Girişi
    /// </summary>
    public partial class MhSChargingSlipForm : TTForm
    {
        override protected void BindControlEvents()
        {
            JournalEntries.RowEnter += new TTGridCellEventDelegate(JournalEntries_RowEnter);
            JournalEntries.CellValueChanged += new TTGridCellEventDelegate(JournalEntries_CellValueChanged);
            JournalEntries.RowLeave += new TTGridCellEventDelegate(JournalEntries_RowLeave);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            JournalEntries.RowEnter -= new TTGridCellEventDelegate(JournalEntries_RowEnter);
            JournalEntries.CellValueChanged -= new TTGridCellEventDelegate(JournalEntries_CellValueChanged);
            JournalEntries.RowLeave -= new TTGridCellEventDelegate(JournalEntries_RowLeave);
            base.UnBindControlEvents();
        }

        private void JournalEntries_RowEnter(Int32 rowIndex, Int32 columnIndex)
        {
#region MhSChargingSlipForm_JournalEntries_RowEnter
   int? i=0;
            i= null;
            i.ToString();
#endregion MhSChargingSlipForm_JournalEntries_RowEnter
        }

        private void JournalEntries_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region MhSChargingSlipForm_JournalEntries_CellValueChanged
   int DEBITCOLUMNINDEX = 2, CREDITCOLUMNINDEX = 3, ACCOUNTCOLUMNINDEX = 0;
            MhSChargingSlipOperations cSlip = _ttObject as MhSChargingSlipOperations;
            double debitTotal = 0.0, creditTotal = 0.0;
            double debitEx = Debit.Text.Equals("")?0:Double.Parse(Debit.Text);
            double creditEx = Credit.Text.Equals("")?0:Double.Parse(Credit.Text);
            if( columnIndex == DEBITCOLUMNINDEX ){
               foreach(ITTGridRow gridRow in JournalEntries.Rows){
                    double debit = 0.0;
                    if( gridRow.Cells[DEBITCOLUMNINDEX].Value != null){
                        try{
                            debit = Double.Parse(gridRow.Cells[DEBITCOLUMNINDEX].Value.ToString());
                        }catch(FormatException fex){
                            MessageBox.Show("Not a number", "Hata");
                            return;
                        }
                        debitTotal += debit;
                    }
                }
                Debit.Text = debitTotal.ToString();
                Balance.Text = Math.Abs(debitTotal-creditEx).ToString();
            }else if( columnIndex == CREDITCOLUMNINDEX){
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
#endregion MhSChargingSlipForm_JournalEntries_CellValueChanged
        }

        private void JournalEntries_RowLeave(Int32 rowIndex, Int32 columnIndex)
        {
#region MhSChargingSlipForm_JournalEntries_RowLeave
   int i = 0;
#endregion MhSChargingSlipForm_JournalEntries_RowLeave
        }

        protected override void PreScript()
        {
#region MhSChargingSlipForm_PreScript
    SetAccountSearchFilter();
#endregion MhSChargingSlipForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region MhSChargingSlipForm_PostScript
    if(_MhSChargingSlipOperations.Balance > 0.0)
                throw new TTUtils.TTException("Balance 0 olmalı");
#endregion MhSChargingSlipForm_PostScript

            }
            
#region MhSChargingSlipForm_Methods
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
        
#endregion MhSChargingSlipForm_Methods
    }
}