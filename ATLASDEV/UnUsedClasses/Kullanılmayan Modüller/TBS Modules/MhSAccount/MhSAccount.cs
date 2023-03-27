
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



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    /// <summary>
    /// Hesap
    /// </summary>
    public  partial class MhSAccount : TTDefinitionSet
    {
        protected override void PreInsert()
        {
#region PreInsert
            if(ParentAccount != null){
                ParentAccount.IsSelectable = false;
            }
#endregion PreInsert
        }

#region Methods
        //Eğer alt hesapların tipi kontrol edilmiyorsa bu kontrollerin 3.seviyede yapılması lazım.
        public bool CanTransitionBeAllowed(MhSTransitionTypesEnum? ptransitionType, double amount){
            if (ptransitionType.HasValue == false)
                throw new TTException("Geçiş türü NULL olamaz!");
            MhSTransitionTypesEnum transitionType = ptransitionType.Value;
            if(((int)Type) == ((int)transitionType) || Type == MhSAccountTypes.Normal)
                return true;
            else{
                if(Type == MhSAccountTypes.Debit)
                    return Debit >= Credit + amount;
                if(Type == MhSAccountTypes.Credit)
                    return Credit >= Debit + amount;
            }
            throw new InvalidOperationException("Hesap bakiye kontrolunde hata oluştu! (System)");
        }
        //Recursive yukarı doğru uygulanıyor.
        public void ApplyTransitionToAccount(MhSTransitionTypesEnum? ptransitionType, double amount, MhSAccountingMonths month){
            if (ptransitionType.HasValue == false)
                throw new TTException("Geçiş türü NULL olamaz!");
            MhSTransitionTypesEnum transitionType = ptransitionType.Value;
            MhSMonthlyBalance mBalance = null;//this.BalanceStatus[((int)month)];
            IList<MhSMonthlyBalance> balances = BalanceStatuses.Select("MONTH = " + (int)month );
            if(balances.Count == 1){
                mBalance = balances[0];
            }
            if(mBalance == null){
                mBalance = new MhSMonthlyBalance(ObjectContext);
                mBalance.Month = month;
                mBalance.Account = this;
            }
            if(transitionType == MhSTransitionTypesEnum.Debited){
                Debit += amount;
                mBalance.AddDebit(amount);
            }else if(transitionType == MhSTransitionTypesEnum.Credited){
                Credit += amount;
                mBalance.AddCredit(amount);
            }
            Balance = Math.Abs((double)Debit - (double)Credit);
            if(ParentAccount != null)
                ParentAccount.ApplyTransitionToAccount(transitionType, amount, month);
        }
        public MhSAccount CreateACopyAccount(){
            MhSAccount cAccnt = new MhSAccount(ObjectContext);
            
            cAccnt.Code = Code;
            cAccnt.Comment = Comment;
            cAccnt.ExpenceCenter = ExpenceCenter;
            cAccnt.Group1 = Group1;
            cAccnt.Group2 = Group2;
            cAccnt.Group3 = Group3;
            cAccnt.Group4 = Group4;
            cAccnt.Level = Level;
            cAccnt.Name = Name;
            cAccnt.Type = Type;
            
            foreach(MhSAccount child in ChildAccounts){
                MhSAccount cChild = child.CreateACopyAccount();
                cAccnt.ChildAccounts.Add(cChild);
            }
            
            return cAccnt;
        }
        public void AddAccountToChartOfAccounts(MhSChartOfAccounts chartOfAccounts){
            ChartOfAccounts = chartOfAccounts;
            foreach(MhSAccount child in ChildAccounts){
                child.AddAccountToChartOfAccounts(chartOfAccounts);
            }
        }
        
#endregion Methods

    }
}