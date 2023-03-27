
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
    /// Fiş
    /// </summary>
    public  partial class MhSSlip : TTObject
    {
#region Methods
        protected virtual void CalculateMonthFromJournalDate(){
            int monthVal = JournalDate.Value.Month;
            Month = (MhSAccountingMonths) Enum.ToObject(typeof(MhSAccountingMonths), monthVal);
        }
        public virtual void ControlJournalEntries(){
            foreach(MhSJournalEntry jEntry in JournalEntries){
                MhSTransitionTypesEnum jType = jEntry.Debit != null?MhSTransitionTypesEnum.Debited:MhSTransitionTypesEnum.Credited;
                double amount = jEntry.Debit !=null?(double)jEntry.Debit:(double)jEntry.Credit;
                if(!jEntry.Account.CanTransitionBeAllowed(jType, amount)){
                    string message = jEntry.Account.Code + " kodlu hesaba " +amount ;
                    message += jType == MhSTransitionTypesEnum.Debited ? " borç" : " alacak";
                    message += " kaydedilemez!";
                    throw new TTUtils.TTException(message);
                }
            }
        }
        public virtual void AddJournalEntriesToAccounts(){
            foreach(MhSJournalEntry jEntry in JournalEntries){
                MhSTransitionTypesEnum jType = jEntry.Debit != null?MhSTransitionTypesEnum.Debited:MhSTransitionTypesEnum.Credited;
                double amount = jEntry.Debit !=null?(double)jEntry.Debit:(double)jEntry.Credit;
                jEntry.Account.ApplyTransitionToAccount(jType, amount, Month.Value);
            }
        }
        
#endregion Methods

    }
}