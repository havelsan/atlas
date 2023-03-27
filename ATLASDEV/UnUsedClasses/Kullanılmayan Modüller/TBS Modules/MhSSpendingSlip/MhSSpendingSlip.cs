
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
    /// Tediye Fişi Girişi
    /// </summary>
    public  partial class MhSSpendingSlip : MhSSlip
    {
        protected override void PreInsert()
        {
#region PreInsert
            Type = MhSSlipTypesEnum.ChargingSlip;
            CalculateMonthFromJournalDate();
#endregion PreInsert
        }

        protected void PreTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PreTransition_New2Completed
            CreateCaseJournalEntry();
            ControlJournalEntries();
            AddJournalEntriesToAccounts();
#endregion PreTransition_New2Completed
        }

#region Methods
        private void CreateCaseJournalEntry(){
            MhSJournalEntry entry = new MhSJournalEntry(ObjectContext);
            entry.Account = SelectedCase;
            if(!String.IsNullOrEmpty(WhyCreated))
                entry.Comment = WhyCreated;
            entry.Credit = Debit;
            entry.Order = 1;
            JournalEntries.Insert(0, entry);
            foreach(MhSJournalEntry e in JournalEntries){
                if(e.Order != null)
                    e.Order++;
            }   
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(MhSSpendingSlip).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == States.New && toState == States.Completed)
                PreTransition_New2Completed();
        }

    }
}