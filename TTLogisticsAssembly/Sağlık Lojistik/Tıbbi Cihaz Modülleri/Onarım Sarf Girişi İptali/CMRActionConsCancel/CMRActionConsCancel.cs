
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
    /// Onarım Sarf Girişi İptali
    /// </summary>
    public  partial class CMRActionConsCancel : BaseAction, IWorkListBaseAction
    {
        protected void PreTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PreTransition_New2Completed
            

            foreach (CMRActionConsCancelDetail detail in CMRActionConsCancelDetails)
            {
                if ((bool)detail.DetailCancel)
                {
                    detail.UsedConsumedMaterail.CurrentStateDefID = UsedConsumedMaterail.States.Cancelled;
                }
            }

#endregion PreTransition_New2Completed
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(CMRActionConsCancel).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == CMRActionConsCancel.States.New && toState == CMRActionConsCancel.States.Completed)
                PreTransition_New2Completed();
        }

    }
}