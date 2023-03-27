
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
    /// Tahsil Fişi Girişi
    /// </summary>
    public  partial class MhSCollectingSlip : MhSSlip
    {
        protected override void PreInsert()
        {
#region PreInsert
            Type = MhSSlipTypesEnum.Collecting;
            CalculateMonthFromJournalDate();
#endregion PreInsert
        }

        protected void PreTransition_New2Complete()
        {
            // From State : New   To State : Complete
#region PreTransition_New2Complete
            CreateCaseJournalEntry();
            ControlJournalEntries();
            AddJournalEntriesToAccounts();
#endregion PreTransition_New2Complete
        }

#region Methods
        private void CreateCaseJournalEntry(){
            MhSJournalEntry entry = new MhSJournalEntry(ObjectContext);
            entry.Account = SelectedCase;
            if(!String.IsNullOrEmpty(WhyCreated))
                entry.Comment = WhyCreated;
            entry.Debit = Credit;
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
            if (transDef.ObjectDef.CodeName != typeof(MhSCollectingSlip).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == States.New && toState == States.Complete)
                PreTransition_New2Complete();
        }

    }
}