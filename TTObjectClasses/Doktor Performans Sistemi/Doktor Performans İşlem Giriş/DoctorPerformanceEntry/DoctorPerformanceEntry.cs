
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
    /// Doktor Performans İşlem Giriş
    /// </summary>
    public  partial class DoctorPerformanceEntry : EpisodeAction
    {
        protected void PostTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PostTransition_New2Completed
            foreach(DPEntryProcedure procedure in DPEntryProcedures)
            {
                procedure.SetPerformedDate();
            }

#endregion PostTransition_New2Completed
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PostTransition_Completed2Cancelled
            Cancel();
#endregion PostTransition_Completed2Cancelled
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DoctorPerformanceEntry).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DoctorPerformanceEntry.States.New && toState == DoctorPerformanceEntry.States.Completed)
                PostTransition_New2Completed();
            else if (fromState == DoctorPerformanceEntry.States.Completed && toState == DoctorPerformanceEntry.States.Cancelled)
                PostTransition_Completed2Cancelled();
        }

    }
}