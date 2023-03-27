
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
    /// Mahsup Fişi Girişi
    /// </summary>
    public  partial class MhSChargingSlipOperations : MhSSlip
    {
        protected override void PreInsert()
        {
#region PreInsert
            Type = MhSSlipTypesEnum.ChargingSlip;
            CalculateMonthFromJournalDate();
#endregion PreInsert
        }

        protected void PreTransition_New2Complete()
        {
            // From State : New   To State : Complete
#region PreTransition_New2Complete
            ControlJournalEntries();
            AddJournalEntriesToAccounts();
#endregion PreTransition_New2Complete
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(MhSChargingSlipOperations).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == States.New && toState == States.Complete)
                PreTransition_New2Complete();
        }

    }
}